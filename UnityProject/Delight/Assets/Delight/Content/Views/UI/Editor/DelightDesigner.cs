#if DELIGHT_MODULE_TEXTMESHPRO
#region Using Statements
using Delight.Editor.Parser;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Reflection;
#if UNITY_EDITOR
using UnityEditor;
using Delight.Editor;
#endif
#endregion

namespace Delight
{
    /// <summary>
    /// Delight designer.
    /// </summary>
    public partial class DelightDesigner
    {
        #region Fields

        private UIView _displayedView;
        private DesignerView _currentEditedView;
        private Dictionary<string, Template> _runtimeTemplates;

        #endregion

        #region Methods

        /// <summary>
        /// Called every frame and handles keyboard and mouse input. 
        /// </summary>
        public override void Update()
        {
            bool ctrlDown = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
            bool shiftDown = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

            // F11 maximizes designer window in editor
            if (Input.GetKeyDown(KeyCode.F11))
            {
                UnityEditor.EditorWindow.focusedWindow.maximized = !UnityEditor.EditorWindow.focusedWindow.maximized;

                // center on view
                ScrollableContentRegion.SetScrollPosition(0.5f, 0.5f);
                SetScale(Vector3.one);
            }

            // CTRL+S and CTRL+SHIFT+S saves all changes
            if (ctrlDown && Input.GetKeyDown(KeyCode.S))
            {
                SaveChanges();
            }
        }

        /// <summary>
        /// Called after the view has been initialized.
        /// </summary>
        public override void AfterInitialize()
        {
            base.AfterInitialize();

            // initialize designer views
            DesignerViews = new DesignerViewData();
            ChangedDesignerViews = new DesignerViewData();
            _runtimeTemplates = new Dictionary<string, Template>();

            // load designer view data from the object model
            var contentObjectModel = ContentObjectModel.GetInstance();
            var designerViews = new List<DesignerView>();
            foreach (var viewObject in contentObjectModel.ViewObjects.Where(x => !x.HideInDesigner))
            {
                // ignore views that aren't scene object views
                if (!IsUIView(viewObject))
                    continue;

                designerViews.Add(new DesignerView
                {
                    Id = viewObject.Name,
                    Name = viewObject.Name,
                    ViewTypeName = viewObject.TypeName,
                    ViewObject = viewObject,
                    FilePath = viewObject.FilePath
                });
            }

            DesignerViews.AddRange(designerViews.OrderBy(x => x.Id));
        }

        /// <summary>
        /// Called when the user edits the current view.
        /// </summary>
        public void OnEdit()
        {
            if (_currentEditedView == null)
                return;

            _currentEditedView.IsDirty = true;
            ParseView();
        }

        /// <summary>
        /// Called after the view has been loaded.
        /// </summary>
        protected override void AfterLoad()
        {
            base.AfterLoad();
        }

        /// <summary>
        /// Returns boolean indicating if view-object is a UIView.
        /// </summary>
        private bool IsUIView(ViewObject viewObject)
        {
            if (viewObject == null || String.IsNullOrEmpty(viewObject.Name) || viewObject.Name == "View")
                return false;
            if (viewObject.Name == "UIView")
                return true;
            return IsUIView(viewObject.BasedOn);
        }

        /// <summary>
        /// Called when a view gets selected in the view list.
        /// </summary>
        public async void ViewSelected(DesignerView designerView)
        {
            UpdateCurrentEditedViewXml();

            // clear any existing displayed views
            ViewContentRegion.DestroyChildren();

            _currentEditedView = designerView;

            if (!designerView.IsRuntimeParsed)
            {
                _displayedView = Assets.CreateView(designerView.ViewTypeName, this, ViewContentRegion) as UIView;

                var sw2 = System.Diagnostics.Stopwatch.StartNew();

                await _displayedView?.LoadAsync();
                _displayedView?.PrepareForDesigner();

                sw2.Stop();

                // uncomment to log loading time 
                //Debug.Log(String.Format("Loading view {0}: {1}", designerView.ViewTypeName, sw2.ElapsedMilliseconds));

                // load XML into the editor
                if (!String.IsNullOrEmpty(_currentEditedView.XmlText))
                {
                    XmlEditor.XmlText = _currentEditedView.XmlText;
                }
                else
                {
                    var path = designerView.FilePath;
                    var xmlText = File.ReadAllText(path);

                    // strip namespace and schema elements from XML root
                    xmlText = xmlText.Replace(" xmlns=\"Delight\"", string.Empty);
                    xmlText = xmlText.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", string.Empty);

                    int contentDirIndex = path.LastIndexOf(ContentParser.ViewsFolder);
                    string p1 = path.Substring(contentDirIndex + ContentParser.ViewsFolder.Length);
                    int directoryDepth = 1 + p1.Count(x => x == '/');
                    var schemaElement = " xsi:schemaLocation=\"Delight";

                    int indexOfSchemaElement = xmlText.IndexOf(schemaElement);
                    if (indexOfSchemaElement > 0)
                    {
                        xmlText = xmlText.Remove(indexOfSchemaElement, (1 + xmlText.IndexOf("\"", indexOfSchemaElement + schemaElement.Length)) - indexOfSchemaElement);
                    }

                    XmlEditor.XmlText = xmlText;
                }
            }
            else
            {
                // create runtime parsed view
                XmlEditor.XmlText = _currentEditedView.XmlText;
                ParseView();
            }

            // center on view
            ScrollableContentRegion.SetScrollPosition(0.5f, 0.5f);
            SetScale(Vector3.one);
        }

        /// <summary>
        /// Logs parse errors to the designer console. 
        /// </summary>
        public static void LogParseErrorToDesignerConsole(string file, int line, string message)
        {
            Debug.LogException(new XmlParseError(message, String.Format("Delight:XmlError() (at {0}:{1})", file, line)));
        }

        /// <summary>
        /// Parses run-time view XML and generates the view in the designer.
        /// </summary>
        public async void ParseView()
        {
#if UNITY_EDITOR            
            if (_currentEditedView == null)
                return;

            _currentEditedView.IsRuntimeParsed = true;

            // attempt to parse the xml
            string xml = XmlEditor.GetXmlText();
            XElement rootXmlElement = null;
            try
            {
                rootXmlElement = XElement.Parse(xml, LoadOptions.SetLineInfo);
            }
            catch (Exception e)
            {
                // get which line error occurred on from exception message
                int line = 1;
                int indexOfLine = e.Message.IndexOf("Line");
                if (indexOfLine > 0)
                {
                    var msg = e.Message.Substring(indexOfLine + "Line".Length);
                    int indexOfComma = msg.IndexOf(",");

                    // get lineinfo
                    if (!int.TryParse(msg.Substring(0, indexOfComma), out line))
                    {
                        line = 1;
                    }
                }

                LogParseErrorToDesignerConsole(_currentEditedView.FilePath, line,
                    String.Format("#Delight# Error parsing XML file. Exception thrown: {0}", e.Message));
                return;
            }

            try
            {
                ConsoleLogger.LogParseError = LogParseErrorToDesignerConsole;

                // create view object
                var viewObject = ContentParser.ParseViewXml(_currentEditedView.FilePath, rootXmlElement, false);
                _currentEditedView.ViewObject = viewObject;

                // instantiate view
                var view = InstantiateRuntimeView(viewObject, this, ViewContentRegion, _currentEditedView.IsNew);
                if (view == null)
                    return;

                // load and present view
                await view?.LoadAsync();
                view?.PrepareForDesigner();

                // destroy previous view
                if (_displayedView != null)
                {
                    _displayedView.Destroy();
                }

                _displayedView = view;
            }
            catch (Exception e)
            {
                //ConsoleLogger.LogException(e);
                ConsoleLogger.LogParseError(_currentEditedView.FilePath, 1,
                    String.Format("#Delight# Error instantiating view. Exception thrown: {0}. See Unity console for code stacktrace.", e.Message));
                ConsoleLogger.LogException(e);

                // if view failed to load make sure we remove the partially-constructed view from the content region
                // while keeping the previously loaded view                
                for (int i = ViewContentRegion.LayoutChildren.Count - 1; i >= 1; --i)
                {
                    var child = ViewContentRegion.LayoutChildren[i];
                    child.Destroy();
                }

                // destroy any remaining child objects that should not be there
                if (ViewContentRegion.GameObject.transform.childCount > 1)
                {
                    for (int i = ViewContentRegion.GameObject.transform.childCount - 1; i >= 1; --i)
                    {
                        var go = ViewContentRegion.GameObject.transform.GetChild(i).gameObject;
                        GameObject.DestroyImmediate(go);
                    }
                }
            }
            finally
            {
                ConsoleLogger.LogParseError = ConsoleLogger.LogParseErrorToDebug;
            }
#endif
        }

        /// <summary>
        /// Instantiates a view object.
        /// </summary>
        public UIView InstantiateRuntimeView(ViewObject viewObject, View parent, View layoutParent, bool isNew, Template template = null)
        {
            // update view declarations and mapped properties
            CodeGenerator.UpdateViewDeclarations(viewObject, viewObject.ViewDeclarations, false);
            CodeGenerator.UpdateMappedProperties(viewObject);

            // create the runtime data templates used when instantiating the view
            Dictionary<string, Template> dataTemplates = new Dictionary<string, Template>();
            CreateRuntimeDataTemplates(viewObject, string.Empty, string.Empty, string.Empty, null, null, viewObject.FilePath, dataTemplates);

            // instantiate view
            var viewTypeName = isNew ? viewObject.BasedOn.TypeName : viewObject.TypeName;
            var view = Assets.CreateView(viewTypeName, parent, layoutParent, viewObject.TypeName, template ?? dataTemplates[viewObject.TypeName], true) as UIView;
            if (view == null)
                return null;

            InstantiateRuntimeChildViews(viewObject.TypeName, dataTemplates, view, view, viewObject.FilePath, viewObject, viewTypeName, null, viewObject.ViewDeclarations);

            // register action handlers, methods and initialize attached properties
            var propertyAssignments = viewObject.GetPropertyAssignmentsWithStyle();
            var actionAssignments = propertyAssignments.Where(x => x.PropertyDeclarationInfo != null &&
                            x.PropertyDeclarationInfo.Declaration.DeclarationType == PropertyDeclarationType.Action).ToList();

            // register action handlers
            foreach (var actionAssignment in actionAssignments)
            {
                var action = view.GetPropertyValue(actionAssignment.PropertyName) as ViewAction;
                action?.RegisterHandler(view, actionAssignment.PropertyValue);
            }

            // register methods
            var methodAssignments = propertyAssignments.Where(x => x.PropertyDeclarationInfo != null &&
                x.PropertyDeclarationInfo.Declaration.DeclarationType == PropertyDeclarationType.Method).ToList();
            foreach (var methodAssignment in methodAssignments)
            {
                var method = view.GetPropertyValue(methodAssignment.PropertyName) as ViewMethod;
                method?.RegisterMethod(view, methodAssignment.PropertyValue);
            }

            // initialize attached properties        
            var attachedProperties = viewObject.PropertyExpressions.OfType<Delight.Editor.Parser.AttachedProperty>();
            foreach (var attachedProperty in attachedProperties)
            {
                var attachedPropertyInstance = Assets.CreateAttachedProperty(attachedProperty.PropertyTypeFullName, view, attachedProperty.PropertyName);
                if (attachedPropertyInstance == null)
                {
                    ConsoleLogger.LogParseError(viewObject.FilePath, attachedProperty.LineNumber,
                        String.Format("#Delight# Unable to instantiate attached property \"{0}\". Code-behind and property activator needs to be generated.", viewObject.Name, attachedProperty.PropertyName));
                    continue;
                }
                view.SetPropertyValue(attachedProperty.PropertyName, Assets.CreateAttachedProperty(attachedProperty.PropertyTypeFullName, view, attachedProperty.PropertyName));
            }

            // set content container
            if (viewObject.ContentContainer != null)
            {
                view.ContentContainer = view.GetPropertyValue(viewObject.ContentContainer.Id) as View;
            }

            view.AfterInitialize();
            return view;
        }

        /// <summary>
        /// Instantiates view construction logic from view declaration.
        /// </summary>
        private List<View> InstantiateRuntimeChildViews(string idPath, Dictionary<string, Template> dataTemplates, View parent, View layoutParent, string fileName, ViewObject viewObject,
            string parentViewType, ViewDeclaration parentViewDeclaration, List<ViewDeclaration> childViewDeclarations, string localParentId = null, int templateDepth = 0, List<TemplateItemInfo> templateItems = null, string firstTemplateChild = null,
            ContentTemplateData contentTemplateData = null)
        {
            bool inTemplate = templateDepth > 0;
            var contentObjectModel = ContentObjectModel.GetInstance();
            var instantiatedChildViews = new List<View>();

            // so we need to loop through all child views, print their construction logic
            foreach (var childViewDeclaration in childViewDeclarations)
            {
                // get identifier for view declaration
                var designerView = DesignerViews.FirstOrDefault(x => x.ViewTypeName == childViewDeclaration.ViewName);
                bool isRuntimeParsed = designerView != null && designerView.IsRuntimeParsed;

                var childId = childViewDeclaration.Id;
                var templateIdPath = idPath + childId;
                var childIdVar = inTemplate ? childId.ToLocalVariableName() : childId;
                var childViewObject = isRuntimeParsed ? designerView.ViewObject :
                    contentObjectModel.LoadViewObject(childViewDeclaration.ViewName, false);
                bool templateContent = childViewObject.HasContentTemplates;

                // instantiate view from view declaration: _view = new View(this, layoutParent, id, initializer);
                var layoutParentContent = parentViewDeclaration == null ? layoutParent : layoutParent.Content;
                UIView childView = null;
                if (isRuntimeParsed)
                {
                    childView = InstantiateRuntimeView(childViewObject, parent, layoutParentContent, designerView.IsNew, dataTemplates[templateIdPath]);
                }
                else
                {
                    childView = Assets.CreateView(childViewObject.TypeName, parent, layoutParentContent, childId, dataTemplates[templateIdPath]) as UIView;
                }

                // set child view reference property if it exists
                if (!inTemplate)
                {
                    parent.SetPropertyValue(childId, childView);
                }

                instantiatedChildViews.Add(childView);

                // add action handlers and method assignments
                var propertyBindings = childViewDeclaration.GetPropertyBindingsWithStyle(out var styleMissing);
                
                // do we have action handlers?
                var childPropertyAssignments = childViewDeclaration.GetPropertyAssignmentsWithStyle(out var dummy);
                var actionAssignments = childPropertyAssignments.Where(x =>
                {
                    if (x.PropertyDeclarationInfo == null)
                        return false;
                    return x.PropertyDeclarationInfo.Declaration.DeclarationType == PropertyDeclarationType.Action;
                });
                if (actionAssignments.Any())
                {
                    // yes. add initializer for action handlers
                    foreach (var actionAssignment in actionAssignments)
                    {
                        var actionValue = actionAssignment.PropertyValue;
                        var actionHandlerName = actionValue;

                        // does the action have parameters?
                        if (actionValue.Contains("("))
                        {
                            // yes. parse the parameters
                            string[] actionParameters = actionValue.Split(CodeGenerator.ActionDelimiterChars, StringSplitOptions.RemoveEmptyEntries);
                            actionHandlerName = actionParameters[0];
                            if (actionParameters.Length > 1)
                            {
                                var paramGetters = new List<Func<object>>();

                                foreach (var actionParameter in actionParameters.Skip(1))
                                {
                                    var actionParameterPath = new List<string>();
                                    actionParameterPath.AddRange(actionParameter.Split('.'));

                                    var templateItemInfo = templateItems != null
                                        ? templateItems.FirstOrDefault(x => x.Name == actionParameterPath[0])
                                        : null;
                                    bool isTemplateItemSource = templateItemInfo != null;
                                    if (isTemplateItemSource)
                                    {
                                        if (templateItemInfo.ItemTypeName == null)
                                        {
                                            paramGetters.Add(() => null);
                                            continue; // item type was not inferred so ignore parameter
                                        }

                                        actionParameterPath[0] = "Item";
                                    }

                                    paramGetters.Add(() => contentTemplateData.GetPropertyValue(actionParameterPath));
                                }

                                // register action handler with parameters
                                var actionWithParameters = childView.GetPropertyValue(actionAssignment.PropertyName) as ViewAction;
                                actionWithParameters?.RegisterHandler(parent, actionHandlerName, paramGetters.ToArray());
                                continue;
                            }
                        }

                        // register action handler without parameters
                        var action = childView.GetPropertyValue(actionAssignment.PropertyName) as ViewAction;
                        action?.RegisterHandler(parent, actionHandlerName);
                    }
                }

                // do we have method assignments?
                var methodAssignments = childPropertyAssignments.Where(x =>
                {
                    if (x.PropertyDeclarationInfo == null)
                        return false;
                    return x.PropertyDeclarationInfo.Declaration.DeclarationType == PropertyDeclarationType.Method;
                });
                if (methodAssignments.Any())
                {
                    // yes. register methods
                    foreach (var methodAssignment in methodAssignments)
                    {
                        var method = childView.GetPropertyValue(methodAssignment.PropertyName) as ViewMethod;
                        method?.RegisterMethod(parent, methodAssignment.PropertyValue);
                    }
                }

                // get templated content data
                var childTemplateDepth = templateDepth;
                TemplateItemInfo ti = null;
                if (templateContent)
                {
                    ++childTemplateDepth;
                    if (templateItems == null)
                    {
                        templateItems = new List<TemplateItemInfo>();
                    }

                    var itemIdDeclaration = childViewDeclaration.PropertyBindings.FirstOrDefault(x => !String.IsNullOrEmpty(x.ItemId));
                    if (itemIdDeclaration != null)
                    {
                        ti = new TemplateItemInfo();
                        ti.Name = itemIdDeclaration.ItemId;
                        ti.VariableName = String.Format("ti{0}", ti.Name.ToPropertyName());
                        ti.ItemIdDeclaration = itemIdDeclaration;
                        templateItems.Add(ti);

                        ti.ItemType = CodeGenerator.GetItemTypeFromDeclaration(fileName, viewObject, itemIdDeclaration, templateItems, childViewDeclaration);
                        ti.ItemTypeName = ti.ItemType != null ? ti.ItemType.TypeName() : null;
                    }
                }

                // do we have attached properties?
                foreach (var attachedProperty in childViewDeclaration.AttachedPropertyAssignments)
                {
                    // yes. initialize attached property
                    var typeValueConverter = ValueConverters.Get(attachedProperty.PropertyTypeFullName);
                    if (typeValueConverter == null)
                    {
                        ConsoleLogger.LogParseError(fileName, attachedProperty.LineNumber,
                            String.Format("#Delight# Unable to assign value to attached property <{0} {4}.{1}=\"{2}\">. Unable to convert value to property of type \"{3}\". Makes sure to include the namespace in the attached property declaration.",
                            viewObject.Name, attachedProperty.PropertyName, attachedProperty.PropertyValue, attachedProperty.PropertyTypeName, attachedProperty.ParentViewName));
                        continue;
                    }

                    var attachedParent = childView.FindParent<UIView>(attachedProperty.ParentId);
                    var attachedPropertyValue = typeValueConverter.ConvertGeneric(attachedProperty.PropertyValue);

                    // get attached property through reflection
                    var childViewAttachedProperty = attachedParent.GetType()?.GetProperty(attachedProperty.PropertyName)?.GetValue(attachedParent) as AttachedProperty;
                    childViewAttachedProperty?.SetValueGeneric(childView, attachedPropertyValue);
                }

                // create bindings
                if (propertyBindings.Any())
                {
                    foreach (var propertyBinding in propertyBindings)
                    {
                        // create binding paths to source
                        var bindingSources = new List<BindingPath>();
                        foreach (var bindingSource in propertyBinding.Sources)
                        {
                            var sourcePath = new List<string>();
                            sourcePath.AddRange(bindingSource.BindingPath.Split('.'));

                            bool isModelSource = bindingSource.SourceTypes.HasFlag(BindingSourceTypes.Model);
                            bool isNegated = bindingSource.SourceTypes.HasFlag(BindingSourceTypes.Negated);

                            // handle special case when source is localization dictionary
                            if (isModelSource && sourcePath.Count == 3 &&
                                (sourcePath[1].IEquals("Loc") || sourcePath[1].IEquals("Localization")))
                            {
                                sourcePath.Add("Label");
                            }

                            // get property names along path
                            var templateItemInfo = templateItems != null
                                ? templateItems.FirstOrDefault(x => x.Name == sourcePath[0])
                                : null;
                            bool isTemplateItemSource = templateItemInfo != null;
                            bool isIndex = false;

                            if (isTemplateItemSource)
                            {
                                if (templateItemInfo.ItemTypeName == null)
                                    continue; // item type was not inferred so ignore binding

                                // handle special case when binding to Index and ZeroIndex                                
                                if (sourcePath.Count == 2)
                                {
                                    if (sourcePath[1].IEquals("Index"))
                                    {
                                        sourcePath.Clear();
                                        sourcePath.Add("Index");
                                        isIndex = true;
                                    }
                                    else if (sourcePath[1].IEquals("ZeroIndex"))
                                    {
                                        sourcePath.Clear();
                                        sourcePath.Add("ZeroIndex");
                                        isIndex = true;
                                    }
                                }

                                if (!isIndex)
                                {
                                    sourcePath[0] = "Item";
                                }
                            }

                            int skipCount = isModelSource ? 1 : 0; //isModelSource || (isTemplateItemSource && !isIndex) ? 1 : 0;
                            var sourceProperties = sourcePath.Skip(skipCount).ToList();

                            // get object getters along path depending on the type of binding
                            var sourceObjectGetters = new List<Func<BindableObject>>();
                            if (isModelSource)
                            {
                                // model binding
                                sourceObjectGetters.Add(() => Models.RuntimeModelObject);
                                var modelPropertyPath = sourcePath.Skip(1).ToList();
                                for (int i = 0; i < modelPropertyPath.Count - 1; ++i)
                                {
                                    var currentSourcePath = modelPropertyPath.Take(i + 1);
                                    sourceObjectGetters.Add(() => Models.RuntimeModelObject.GetPropertyValue(currentSourcePath) as BindableObject);
                                }
                            }
                            else if (isTemplateItemSource)
                            {
                                // list item binding
                                sourceObjectGetters.Add(() => contentTemplateData);
                                for (int i = 0; i < sourcePath.Count - 1; ++i)
                                {
                                    var currentSourcePath = sourcePath.Take(i + 1);
                                    sourceObjectGetters.Add(() => contentTemplateData.GetPropertyValue(currentSourcePath) as BindableObject);
                                }
                            }
                            else
                            {
                                // regular binding
                                sourceObjectGetters.Add(() => parent);
                                for (int i = 0; i < sourcePath.Count - 1; ++i)
                                {
                                    var currentSourcePath = sourcePath.Take(i + 1);
                                    sourceObjectGetters.Add(() => parent.GetPropertyValue(currentSourcePath) as BindableObject);
                                }
                            }

                            // add value converter
                            ValueConverter valueConverter = null;
                            if (!String.IsNullOrEmpty(bindingSource.Converter))
                            {
                                valueConverter = ValueConverters.Get(bindingSource.Converter);
                            }

                            // add binding path
                            var bindingSourcePath = new RuntimeBindingPath(sourceProperties, sourceObjectGetters, isNegated, valueConverter);
                            bindingSources.Add(bindingSourcePath);
                        }

                        // generate binding path to target
                        var targetPath = new List<string>();
                        if (propertyBinding.IsAttached)
                        {
                            var parentId = propertyBinding.AttachedToParentViewDeclaration.Id;
                            var parentIdVar = inTemplate ? parentId.ToLocalVariableName() : parentId;
                            targetPath.Add(parentIdVar);
                        }
                        else
                        {
                            targetPath.Add(childIdVar);
                        }
                        targetPath.AddRange(propertyBinding.PropertyName.Split('.'));
                        List<string> targetProperties = targetPath.Skip(inTemplate ? 1 : 0).ToList();
                        var targetObjectGetters = new List<Func<BindableObject>>();

                        if (!inTemplate)
                        {
                            targetObjectGetters.Add(() => parent);
                            for (int i = 0; i < targetPath.Count - 1; ++i)
                            {
                                var currentTargetPath = targetPath.Take(i + 1);
                                targetObjectGetters.Add(() => parent.GetPropertyValue(currentTargetPath) as BindableObject);
                            }
                        }
                        else
                        {
                            targetObjectGetters.Add(() => childView);
                            var templateTargetPath = targetPath.Skip(1).ToList();
                            for (int i = 0; i < templateTargetPath.Count - 1; ++i)
                            {
                                var currentTargetPath = templateTargetPath.Take(i + 1);
                                targetObjectGetters.Add(() => childView.GetPropertyValue(currentTargetPath) as BindableObject);
                            }
                        }


                        string targetProperty = string.Join(".", targetPath);
                        string convertedTargetProperty = targetProperty;
                        var bindingTargetPath = new RuntimeBindingPath(targetProperties, targetObjectGetters, false, null);

                        // TODO implement attached binding logic
                        //string sourceToTarget = !propertyBinding.IsAttached ?
                        //    String.Format("{0} = {1}", targetProperty, sourceToTargetValue) :
                        //    String.Format("{0}.SetValue({1}, {2})", targetProperty, childIdVar, sourceToTargetValue);
                        //string targetToSource;
                        //if (targetToSourceValue != null)
                        //{
                        //    targetToSource = !propertyBinding.IsAttached ?
                        //        String.Format("{0} = {1}", sourceProperties.First(), convertedTargetProperty) :
                        //        String.Format("{0} = {1}.GetValue({2})", sourceProperties.First(), targetProperty, childIdVar);
                        //}
                        //else
                        //{
                        //    targetToSource = "{ }";
                        //}

                        // create transform method
                        Func<object[], object> transformMethod = null;
                        if (propertyBinding.BindingType == BindingType.MultiBindingTransform)
                        {
                            var transformMethodName = propertyBinding.TransformMethod;
                            MethodInfo methodInfo = null;
                            if (transformMethodName.IndexOf(".") >= 0)
                            {
                                // if method name contains "." it refers to a static class
                                var methodPath = transformMethodName.Split('.').ToList();
                                if (methodPath.Count == 2)
                                {
                                    var staticType = TypeHelper.GetType(methodPath[0], null, MasterConfig.GetInstance().Namespaces);
                                    methodInfo = staticType?.GetType().GetMethod(transformMethodName);
                                    if (methodInfo != null)
                                    {
                                        transformMethod = x => methodInfo.Invoke(null, x);
                                    }
                                }
                            }
                            else
                            {
                                methodInfo = parent.GetType().GetMethod(transformMethodName);
                                if (methodInfo != null)
                                {
                                    transformMethod = x => methodInfo.Invoke(parent, x);
                                }
                            }
                        }

                        // TODO try add binding to first template child and see if it fixes binding issue
                        bool isTwoWay = propertyBinding.BindingType == BindingType.SingleBinding && propertyBinding.Sources.First().SourceTypes.HasFlag(BindingSourceTypes.TwoWay);
                        childView.Bindings.Add(new RuntimeBinding(bindingSources, bindingTargetPath, isTwoWay, propertyBinding.BindingType, transformMethod, propertyBinding.FormatString));
                    }
                }

                if (templateContent)
                {
                    foreach (var templateChild in childViewDeclaration.ChildDeclarations)
                    {
                        var templateChildId = templateChild.Id.ToLocalVariableName();
                        var viewType = TypeHelper.GetType(templateChild.ViewName, null, MasterConfig.GetInstance().Namespaces);

                        childView.ContentTemplates.Add(new ContentTemplate(x =>
                        {
                            var view = InstantiateRuntimeChildViews(idPath, dataTemplates, parent, childView, viewObject.FilePath, viewObject, parentViewType, childViewDeclaration, new List<ViewDeclaration> { templateChild }, childIdVar, childTemplateDepth, templateItems, templateChildId, x).FirstOrDefault();
                            if (view != null)
                            {
                                view.IsDynamic = true;
                                view.SetContentTemplateData(x);
                            }
                            return view;
                        }, viewType, templateChild.Id));
                    }
                }
                else
                {
                    // create child views from child view declarations
                    InstantiateRuntimeChildViews(idPath, dataTemplates, parent, childView, viewObject.FilePath, viewObject, parentViewType, childViewDeclaration, childViewDeclaration.ChildDeclarations, childIdVar, childTemplateDepth, templateItems, firstTemplateChild, contentTemplateData);
                }
            }

            return instantiatedChildViews;
        }

        /// <summary>
        /// Creates runtime data templates.
        /// </summary>
        private void CreateRuntimeDataTemplates(ViewObject viewObject, string idPath, string basedOnPath, string basedOnViewName, ViewDeclaration viewDeclaration,
            List<PropertyExpression> nestedPropertyExpressions, string fileName, Dictionary<string, Template> dataTemplates)
        {
            if (String.IsNullOrEmpty(idPath))
            {
                idPath = viewObject.TypeName;
            }

            var isParent = String.IsNullOrEmpty(basedOnPath);

            var templateBasedOn = isParent ?
                viewObject.BasedOn != null ? viewObject.BasedOn.TypeName : "View" :
                basedOnPath;
            var templateBasedOnViewTypeName = isParent ?
                viewObject.BasedOn != null ? viewObject.BasedOn.TypeName : "View" :
                basedOnViewName;

            var ns = !String.IsNullOrEmpty(viewObject.Namespace) ? viewObject.Namespace : CodeGenerator.DefaultNamespace;
            var fullViewTypeName = String.Format("{0}.{1}", ns, viewObject.TypeName);
            var localId = idPath.ToPrivateMemberName();

            // create data template for main view object
            // corresponds to e.g. ButtonTemplates.Button = new Template(UIImageViewTemplates.UIImageView);

            // does existing template exist? 
            Template dataTemplate = null;
            if (isParent)
            {
                dataTemplate = TypeHelper.GetType(idPath + "Templates")?.GetProperty(idPath)?.GetValue(null) as Template;

                // check for runtime data template if we're a parent
                if (dataTemplate == null)
                {
                    _runtimeTemplates.TryGetValue(idPath, out dataTemplate);
                }
            }

            if (dataTemplate == null)
            {
                // no. create a new one
                var basedOnTemplate = TypeHelper.GetType(templateBasedOnViewTypeName + "Templates")?.GetProperty(templateBasedOn)?.GetValue(null) as Template;
                if (basedOnTemplate == null)
                {
                    if (!_runtimeTemplates.TryGetValue(templateBasedOnViewTypeName, out basedOnTemplate))
                    {
                        Debug.LogError(String.Format("Data template for child view \"{0}\" missing.", templateBasedOnViewTypeName));
                    }
                }

                dataTemplate = new Template(basedOnTemplate ?? ViewTemplates.View);
                if (isParent)
                {
                    _runtimeTemplates.Add(idPath, dataTemplate);
                }
            }

#if UNITY_EDITOR
            // add name in editor so we can easy track which template is used where in the debugger
            dataTemplate.Name = idPath;
#endif
            dataTemplates.Add(idPath, dataTemplate);

            // generate data template values
            CodeGenerator.GenerateDataTemplateValueInitializers(null, viewObject, isParent,
                viewDeclaration, fileName, nestedPropertyExpressions, fullViewTypeName, localId,
                out var nestedChildViewPropertyExpressions, true, dataTemplates[idPath]);

            var contentObjectModel = ContentObjectModel.GetInstance();
            var viewDeclarations = viewObject.GetViewDeclarations(true);

            // create child view data templates
            foreach (var declaration in viewDeclarations)
            {
                if (String.IsNullOrEmpty(declaration.Declaration.Id))
                    continue;

                var childViewObject = contentObjectModel.LoadViewObject(declaration.Declaration.ViewName, false);
                var childIdPath = idPath + declaration.Declaration.Id;
                var childBasedOnPath = String.IsNullOrEmpty(basedOnPath) ? childViewObject.TypeName
                    : basedOnPath + declaration.Declaration.Id;
                var childBasedOnViewName = isParent ? childViewObject.TypeName : basedOnViewName;

                List<PropertyExpression> childPropertyAssignments = null;
                nestedChildViewPropertyExpressions.TryGetValue(declaration.Declaration.Id, out childPropertyAssignments);

                CreateRuntimeDataTemplates(childViewObject, childIdPath, childBasedOnPath, childBasedOnViewName,
                    isParent && !declaration.IsInherited ? declaration.Declaration : null,
                    childPropertyAssignments, fileName, dataTemplates);
            }

            // set sub-template properties            
            foreach (var declaration in viewDeclarations)
            {
                if (String.IsNullOrEmpty(declaration.Declaration.Id))
                    continue;

                var templateDependencyProperty = CodeGenerator.GetViewObjectDependencyProperty(viewObject,
                    String.Format("{0}TemplateProperty", declaration.Declaration.Id));
                if (templateDependencyProperty == null)
                    continue;

                templateDependencyProperty.SetDefaultGeneric(dataTemplate, dataTemplates[idPath + declaration.Declaration.Id]);
            }
        }

        /// <summary>
        /// Called when the content is scrolled using mouse wheel or track pad.
        /// </summary>
        public void OnScroll(DependencyObject sender, object eventArgs)
        {
            if (_displayedView == null)
                return;

            PointerEventData pointerData = eventArgs as PointerEventData;
            bool zoomIn = pointerData.scrollDelta.x > 0 || pointerData.scrollDelta.y > 0;
            var zoomFactor = 0.10f;
            zoomFactor = zoomIn ? 1 + zoomFactor : 1 - zoomFactor;

            var scale = ContentRegionCanvas.Scale;
            scale.x *= zoomFactor;
            scale.y *= zoomFactor;

            SetScale(scale);
        }

        /// <summary>
        /// Scales view content. 
        /// </summary>
        public void SetScale(Vector3 scale)
        {
            if (_displayedView == null)
            {
                ContentRegionCanvas.Scale = Vector3.one;
                return;
            }

            ContentRegionCanvas.Scale = scale;

            // adjust size of view region based on size of view and viewport
            var viewportWidth = ScrollableContentRegion.ActualWidth;
            var viewportHeight = ScrollableContentRegion.ActualHeight;

            var width = _displayedView.OverrideWidth ?? _displayedView.Width ?? ElementSize.FromPercents(1);
            var height = _displayedView.OverrideHeight ?? _displayedView.Height ?? ElementSize.FromPercents(1);

            float adjustedWidth = viewportWidth * Mathf.Max(scale.x, 1.0f);
            float adjustedHeight = viewportHeight * Mathf.Max(scale.y, 1.0f);

            if (width.Unit != ElementSizeUnit.Percents)
            {
                float viewWidth = width.Pixels * Mathf.Max(scale.x, 1.0f);
                adjustedWidth = Mathf.Max(viewWidth, adjustedWidth);
            }

            if (height.Unit != ElementSizeUnit.Percents)
            {
                float viewHeight = height.Pixels * Mathf.Max(scale.y, 1.0f);
                adjustedHeight = Mathf.Max(viewHeight, adjustedHeight);
            }

            // adjust content regions to size
            ContentRegionCanvas.SetSize(adjustedWidth * 2, adjustedHeight * 2);
            ViewContentRegion.SetSize(adjustedWidth, adjustedHeight);
        }

        /// <summary>
        /// Saves all changes.
        /// </summary>
        public void SaveChanges()
        {
            var changedViews = DesignerViews.Where(x => x.IsDirty);
            UpdateCurrentEditedViewXml();

            if (changedViews.Any())
            {
                foreach (var changedView in changedViews)
                {
                    var path = changedView.FilePath;
                    var xmlText = changedView.XmlText;

                    // add namespace and schema elements to XML root
                    int startIndex = 0;
                    int charCount = xmlText.Length;

                    // find root element
                    // ignore leading comments
                    for (int i = 0; i < charCount; ++i)
                    {
                        var rootElementIndex = xmlText.IndexOf('<', startIndex);
                        if (startIndex + 3 < charCount)
                        {
                            if (xmlText[startIndex + 1] == '!' && xmlText[startIndex + 2] == '-' && xmlText[startIndex + 3] == '-')
                            {
                                startIndex = xmlText.IndexOf("-->", startIndex);
                                if (startIndex < 0)
                                    break;
                                continue;
                            }
                        }
                        break;
                    }

                    // find insert point after root view name
                    for (int i = startIndex + 1; ; ++i)
                    {
                        if (i >= charCount)
                        {
                            startIndex = -1; // insert point not found
                            break;
                        }

                        char c = xmlText[i];
                        if (c == ' ' || c == '>')
                        {
                            // TODO look for last " in the same line
                            startIndex = i;
                            break;
                        }
                    }

                    if (startIndex > 0)
                    {
                        int contentDirIndex = path.LastIndexOf(ContentParser.ViewsFolder);
                        string p1 = path.Substring(contentDirIndex + ContentParser.ViewsFolder.Length);
                        int directoryDepth = 1 + p1.Count(x => x == '/');
                        var ellipsis = string.Concat(Enumerable.Repeat("../", directoryDepth));
                        var namespaceAndSchema = String.Format(" xmlns=\"Delight\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"Delight {0}Delight.xsd\"", ellipsis);
                        xmlText = xmlText.Insert(startIndex, namespaceAndSchema);
                    }

                    File.WriteAllText(path, xmlText);
                    changedView.IsDirty = false;
                }

#if UNITY_EDITOR
                AssetDatabase.Refresh(ImportAssetOptions.ForceSynchronousImport);
#endif
            }
        }

        /// <summary>
        /// Updates currently edited view xml.
        /// </summary>
        private void UpdateCurrentEditedViewXml()
        {
            if (_currentEditedView != null && _currentEditedView.IsDirty)
            {
                _currentEditedView.XmlText = XmlEditor.GetXmlText();
            }
        }

        /// <summary>
        /// Checks and asks if use wants to save unsaved items.
        /// </summary>
        public bool CheckForUnsavedChanges()
        {
            ChangedDesignerViews.Replace(DesignerViews.Where(x => x.IsDirty));
            var isDirty = ChangedDesignerViews.Any();

            // show popup: save changes to following items? Yes No Cancel
            if (isDirty)
            {
                SaveChangesPopup.IsActive = true;
            }

            return isDirty;
        }

        /// <summary>
        /// Called when user clicks "Yes" on popup asking if user wants to save changes.
        /// </summary>
        public void SaveChangesAndQuit()
        {
            SaveChanges();
            SaveChangesPopup.IsActive = false;
            UnityEditor.EditorApplication.isPlaying = false;
        }

        /// <summary>
        /// Called when user clicks "No" on popup asking if user wants to save changes.
        /// </summary>
        public void DiscardChangesAndQuit()
        {
            DesignerViews.ForEach(x =>
            {
                x.IsDirty = false;
                x.XmlText = null;
            });
            SaveChangesPopup.IsActive = false;
            UnityEditor.EditorApplication.isPlaying = false;
        }

        /// <summary>
        /// Called when user clicks "Cancel" on popup asking if user wants to save changes.
        /// </summary>
        public void CancelQuit()
        {
            SaveChangesPopup.IsActive = false;
        }

        /// <summary>
        /// Called when user clicks "+ New View" button. 
        /// </summary>
        public void AddNewView()
        {
            var newView = new DesignerView();

            // generate name
            var viewName = "NewView";
            for (int i = 1; i < int.MaxValue; ++i)
            {
                if (!DesignerViews.Any(x => x.Name == viewName))
                    break;

                viewName = String.Format("NewView{0}", i);
            }
            newView.Id = viewName;
            newView.Name = viewName;
            newView.ViewTypeName = viewName;

            // set view path
            // TODO ask user which content directory to put the new view in

            // generate XML
            var sb = new StringBuilder();

            var config = MasterConfig.GetInstance();
            string path = String.Format("{0}/Content{1}{2}.xml", Application.dataPath, ContentParser.ViewsFolder, viewName);
            newView.FilePath = path;

            sb.AppendLine("<{0}>", viewName);
            sb.AppendLine("  ");
            sb.AppendLine("</{0}>", viewName);
            newView.XmlText = sb.ToString();

            newView.IsDirty = false;
            newView.IsNew = true;
            newView.IsRuntimeParsed = true;

            DesignerViews.Add(newView);
            DesignerViews.SelectAndScrollTo(newView);
        }

        #endregion
    }
}
#endif