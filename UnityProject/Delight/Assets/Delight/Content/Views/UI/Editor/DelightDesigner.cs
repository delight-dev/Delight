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

        public UIView _displayedView;
        public DesignerView _currentEditedView;

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
            if (_displayedView != null)
            {
                _displayedView.Destroy();
            }

            _currentEditedView = designerView;

            if (!designerView.IsRuntimeParsed)
            {
                _displayedView = Assets.CreateView(designerView.ViewTypeName, this, ViewContentRegion) as UIView;

                var sw2 = System.Diagnostics.Stopwatch.StartNew();

                await _displayedView?.LoadAsync();
                _displayedView?.PrepareForDesigner();

                sw2.Stop();
                Debug.Log(String.Format("Loading view {0}: {1}", designerView.ViewTypeName, sw2.ElapsedMilliseconds));

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
                    var ellipsis = string.Concat(Enumerable.Repeat("../", directoryDepth));
                    var schemaElement = " xsi:schemaLocation=\"Delight";
                    //var schemaElement = String.Format(" xsi:schemaLocation=\"Delight {0}Delight.xsd\"", ellipsis);

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
            ConsoleLogger.LogParseError = LogParseErrorToDesignerConsole;
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

                ConsoleLogger.LogParseError(_currentEditedView.FilePath, line,
                    String.Format("#Delight# Error parsing XML file. Exception thrown: {0}", e.Message));
                return;
            }

            // create view object
            var viewObject = ContentParser.ParseViewXml(_currentEditedView.FilePath, rootXmlElement, false);

            // instantiate view
            var view = InstantiateRuntimeView(viewObject, this, ViewContentRegion);
            if (view == null)
                return;

            ConsoleLogger.LogParseError = ConsoleLogger.LogParseErrorToDebug;

            // destroy previous view
            if (_displayedView != null)
            {
                _displayedView.Destroy();
            }

            _displayedView = view;

            // load and present view
            await _displayedView?.LoadAsync();
            _displayedView?.PrepareForDesigner();

#endif
        }

        /// <summary>
        /// Instantiates a view object.
        /// </summary>
        public UIView InstantiateRuntimeView(ViewObject viewObject, View parent, View layoutParent)
        {
            // TODO look at code generator and generate constructor logic in a similar way
            // TODO some operations we might cache if the runtime view is to instantiated more than once
            // like the update calls and data templates
            // TODO we might be able to use some smart logic to instantiate partially changed views 
            // so we simply update the templates that aren't new and construct the views that are new
            // or we simply reparse the entire view, that's fine too, and we make it so atomic views like
            // buttons, labels, groups, etc. can't really be changed in the editor. 

            // update view declarations (might not be necessary)
            CodeGenerator.UpdateViewDeclarations(viewObject, viewObject.ViewDeclarations, false);
            CodeGenerator.UpdateMappedProperties(viewObject);

            // create the runtime data templates used when instantiating the view
            Dictionary<string, Template> dataTemplates = new Dictionary<string, Template>();
            CreateRuntimeDataTemplates(viewObject, string.Empty, string.Empty, string.Empty, null, null, viewObject.FilePath, dataTemplates);

            // instantiate view
            var viewTypeName = viewObject.BasedOn.TypeName;
            var view = Assets.CreateView(viewTypeName, parent, layoutParent, viewObject.TypeName, dataTemplates[viewObject.TypeName]) as UIView;
            if (view == null)
                return null;

            InstantiateRuntimeChildViews(viewObject.TypeName, dataTemplates, view, view, viewObject.FilePath, viewObject, viewTypeName, null, viewObject.ViewDeclarations);

            return view;
        }

        /// <summary>
        /// Creates runtime data templates.
        /// </summary>
        private static void CreateRuntimeDataTemplates(ViewObject viewObject, string idPath, string basedOnPath, string basedOnViewName, ViewDeclaration viewDeclaration,
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
            var templateBasedOnType = TypeHelper.GetType(String.Format("{0}Templates", templateBasedOnViewTypeName));
            var templateBasedOnTypeField = templateBasedOnType.GetProperty(templateBasedOn);
            var templateBasedOnInstance = templateBasedOnTypeField.GetValue(null) as Template;
            var dataTemplate = new Template(templateBasedOnInstance);

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
        /// Instantiates view construction logic from view declaration.
        /// </summary>
        private static void InstantiateRuntimeChildViews(string idPath, Dictionary<string, Template> dataTemplates, View parent, View layoutParent, string fileName, ViewObject viewObject,
            string parentViewType, ViewDeclaration parentViewDeclaration, List<ViewDeclaration> childViewDeclarations, string localParentId = null, int templateDepth = 0, List<TemplateItemInfo> templateItems = null, string firstTemplateChild = null)
        {
            bool inTemplate = templateDepth > 0;
            var contentObjectModel = ContentObjectModel.GetInstance();

            // so we need to loop through all child views, print their construction logic
            foreach (var childViewDeclaration in childViewDeclarations)
            {
                // get identifier for view declaration
                var childId = childViewDeclaration.Id;
                var templateIdPath = idPath + childId;
                var childIdVar = inTemplate ? childId.ToLocalVariableName() : childId;
                var childViewObject = contentObjectModel.LoadViewObject(childViewDeclaration.ViewName, false);
                bool templateContent = childViewObject.HasContentTemplates;

                // instantiate view from view declaration: _view = new View(this, layoutParent, id, initializer);
                // TODO if childViewObject.TypeName doesn't exist create a placeholder view that just displays the name
                // of the new view
                var layoutParentContent = parentViewDeclaration == null ? layoutParent : layoutParent.Content;
                var childView = Assets.CreateView(childViewObject.TypeName, parent, layoutParentContent, childId, dataTemplates[templateIdPath]) as UIView;

                // TODO maybe add action handlers and method assignments

                var propertyBindings = childViewDeclaration.GetPropertyBindingsWithStyle(out var styleMissing);

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

                    if (inTemplate)
                    {
                        // TODO handle attached properties in templates
                        //var attachedParentIdVar = inTemplate ? attachedProperty.ParentId.ToLocalVariableName() : attachedProperty.ParentId;
                    }
                    else
                    {
                        var attachedParent = childView.FindParent<UIView>(attachedProperty.ParentId);
                        var attachedPropertyValue = typeValueConverter.ConvertGeneric(attachedProperty.PropertyValue);

                        // get attached property through reflection
                        var childViewAttachedProperty = attachedParent.GetType()?.GetProperty(attachedProperty.PropertyName)?.GetValue(attachedParent) as AttachedProperty;
                        childViewAttachedProperty?.SetValueGeneric(childView, attachedPropertyValue);
                    }
                }

                // create bindings
                if (propertyBindings.Any())
                {
                    foreach (var propertyBinding in propertyBindings)
                    {
                        // create binding paths to sourcse
                        var bindingSources = new List<BindingPath>();
                        foreach (var bindingSource in propertyBinding.Sources)
                        {
                            var sourcePath = new List<string>();
                            sourcePath.AddRange(bindingSource.BindingPath.Split('.'));

                            bool isModelSource = bindingSource.SourceTypes.HasFlag(BindingSourceTypes.Model);
                            bool isNegated = bindingSource.SourceTypes.HasFlag(BindingSourceTypes.Negated);

                            bool isLoc = false;
                            string locId = string.Empty;

                            // handle special case when source is localization dictionary
                            if (isModelSource && sourcePath.Count == 3 &&
                                (sourcePath[1].IEquals("Loc") || sourcePath[1].IEquals("Localization")))
                            {
                                sourcePath[1] = "Loc";

                                // change Models.Loc.Greeting1 to Models.Loc["Greeting1"].Label
                                locId = sourcePath[2];
                                sourcePath[1] = String.Format("{0}[\"{1}\"]", sourcePath[1], locId);
                                sourcePath[2] = "Label";
                                isLoc = true;
                            }

                            // get property names along path
                            var templateItemInfo = templateItems != null
                                ? templateItems.FirstOrDefault(x => x.Name == sourcePath[0])
                                : null;
                            bool isTemplateItemSource = templateItemInfo != null;

                            if (isTemplateItemSource)
                            {
                                if (templateItemInfo.ItemTypeName == null)
                                    continue; // item type was not inferred so ignore binding

                                sourcePath[0] = templateItemInfo.VariableName;
                                sourcePath.Insert(1, "Item");
                            }

                            // handle collection indexers in binding path
                            // TODO below line might be unnecessary with update that generates readonly model fields. The call below translates e.g. Players.Player1 => Players["Player1"]
                            //sourcePath = CodeGenerator.UpdateSourcePathWithCollectionIndexers(fileName, viewObject, sourcePath, templateItemInfo, childViewDeclaration);

                            var sourceProperties = sourcePath.Skip(isModelSource ? 2 : (isTemplateItemSource ? 1 : 0)).ToList();
                            if (isLoc)
                            {
                                sourceProperties.Insert(0, locId);
                            }

                            // get object getters along path
                            var sourceObjectGetters = new List<Func<BindableObject>>();
                            int sourcePathCount = isModelSource ? sourcePath.Count - 2 : sourcePath.Count - 1;
                            int sourcePathTake = isModelSource ? 2 : 1;
                            if (!isModelSource && !isTemplateItemSource)
                            {
                                sourceObjectGetters.Add(() => parent);
                            }

                            if (isLoc)
                            {
                                sourceObjectGetters.Add(() => Models.Loc);
                            }

                            for (int i = 0; i < sourcePathCount; ++i)
                            {
                                var currentSourcePath = sourcePath.Take(i + sourcePathTake);
                                sourceObjectGetters.Add(() => parent.GetPropertyValue(currentSourcePath) as BindableObject);
                            }

                            if (isTemplateItemSource)
                            {
                                // TODO we might need to cast items in source getters if reference to template item
                                // in source path and source getters for template items make sure item is cast: () => (tiItem.Item as ItemType).Property
                                //var itemRef = String.Format("{0}.Item", templateItemInfo.VariableName);
                                //var castItemRef = String.Format("({0} as {1})", itemRef, templateItemInfo.ItemTypeName);
                                //sourcePath = sourcePath.Skip(2).ToList();
                                //sourcePath.Insert(0, castItemRef);

                                //for (int i = 0; i < sourceGetters.Count; ++i)
                                //{
                                //    // replace "tiItem.Item" with "(tiItem.Item as ItemType)"
                                //    sourceGetters[i] = sourceGetters[i].Replace(itemRef, castItemRef);
                                //}
                            }

                            // TODO support converters and negated bindings
                            // add converter
                            ValueConverter valueConverter = null; 
                            if (!String.IsNullOrEmpty(bindingSource.Converter))
                            {
                                valueConverter = ValueConverters.Get(bindingSource.Converter);
                                //convertedSourceProperty = String.Format("ValueConverters.{0}.ConvertTo({1}{2})", bindingSource.Converter, negatedString, sourceProperty);
                            }
                            else if (isNegated)
                            {
                                //convertedSourceProperty = "!" + convertedSourceProperty;
                            }

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
                        }
                        for (int i = 0; i < targetPath.Count - 1; ++i)
                        {                            
                            var currentTargetPath = targetPath.Take(i + 1);
                            targetObjectGetters.Add(() => parent.GetPropertyValue(currentTargetPath) as BindableObject);
                        }

                        string targetProperty = string.Join(".", targetPath);
                        string convertedTargetProperty = targetProperty;

                        // if the binding is two-way single binding and is converted, add conversion of target
                        bool isTwoWay = false;
                        if (propertyBinding.BindingType == BindingType.SingleBinding)
                        {
                            var bindingSource = propertyBinding.Sources.First();
                            isTwoWay = bindingSource.SourceTypes.HasFlag(BindingSourceTypes.TwoWay);
                            if (isTwoWay && !String.IsNullOrEmpty(bindingSource.Converter))
                            {
                                convertedTargetProperty = String.Format("ValueConverters.{0}.ConvertFrom({1})", bindingSource.Converter, targetProperty);
                            }

                            if (bindingSource.SourceTypes.HasFlag(BindingSourceTypes.Negated))
                            {
                                convertedTargetProperty = "!" + convertedTargetProperty;
                            }
                        }

                        var bindingTargetPath = new BindingPath(targetProperties, targetObjectGetters);

                        // TODO implement binding value propagation 
                        //string sourceToTargetValue = null;
                        //string targetToSourceValue = null;
                        switch (propertyBinding.BindingType)
                        {
                            case BindingType.SingleBinding:
                            default:
                                //propagateSourceToTarget = () => PropagateBindingValue(childView, targetPath);
                                break;
                        //        if (convertedSourceProperties.Count <= 0)
                        //        {
                        //            ConsoleLogger.LogParseError(fileName, propertyBinding.LineNumber,
                        //                String.Format("#Delight# Something wrong with binding <{0} {1}=\"{2}\">.",
                        //                viewObject.Name, propertyBinding.PropertyName, propertyBinding.PropertyBindingString));
                        //            continue;
                        //        }

                        //        sourceToTargetValue = String.Format("{0}", convertedSourceProperties.First());
                        //        if (isTwoWay)
                        //        {
                        //            targetToSourceValue = string.Format("{0}", convertedTargetProperty);
                        //        }
                        //        break;

                        //    case BindingType.MultiBindingTransform:
                        //        sourceToTargetValue = string.Format("{0}({1})", propertyBinding.TransformMethod, string.Join(", ", convertedSourceProperties));
                        //        break;

                        //    case BindingType.MultiBindingFormatString:
                        //        sourceToTargetValue = string.Format("String.Format(\"{0}\", {1})", propertyBinding.FormatString, string.Join(", ", convertedSourceProperties));
                        //        break;
                        }

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

                        // create binding
                        //sb.AppendLine(indent,
                        //    "{0}Bindings.Add(new Binding(new List<BindingPath> {{ {1} }}, {2}, () => {3}, () => {4}, {5}));",
                        //    inTemplate ? firstTemplateChild + "." : "",
                        //    string.Join(", ", sourceBindingPathObjects),
                        //    String.Format(
                        //        "new BindingPath(new List<string> {{ {0} }}, new List<Func<BindableObject>> {{ {1} }})",
                        //        targetProperties, targetGettersString),
                        //    sourceToTarget,
                        //    targetToSource,
                        //    isTwoWay ? "true" : "false");

                        // TODO add binding to template item if inside a template
                        childView.Bindings.Add(new RuntimeBinding(bindingSources, bindingTargetPath, isTwoWay, propertyBinding.BindingType));
                    }
                }                                

                if (templateContent)
                {
                    // TODO support template content
                    //        foreach (var templateChild in childViewDeclaration.ChildDeclarations)
                    //        {
                    //            var templateChildId = templateChild.Id.ToLocalVariableName();

                    //            sb.AppendLine();
                    //            sb.AppendLine(indent, "// templates for {0}", childIdVar);
                    //            sb.AppendLine(indent, "{0}.ContentTemplates.Add(new ContentTemplate({1} => ", childIdVar, ti != null ? ti.VariableName : "x" + templateDepth.ToString());
                    //            sb.AppendLine(indent, "{{");

                    //            // print child view declaration
                    //            InstantiateRuntimeChildViews(viewObject.FilePath, viewObject, sb, parentViewType, childViewDeclaration, new List<ViewDeclaration> { templateChild }, childIdVar, childTemplateDepth, templateItems, templateChildId);

                    //            sb.AppendLine(indent, "    {0}.IsDynamic = true;", templateChildId);
                    //            sb.AppendLine(indent, "    {0}.SetContentTemplateData({1});", templateChildId, ti != null ? ti.VariableName : "x" + templateDepth.ToString());
                    //            sb.AppendLine(indent, "    return {0};", templateChildId);
                    //            sb.AppendLine(indent, "}}, typeof({0}), \"{1}\"));", templateChild.ViewName, templateChild.Id);
                    //        }
                }
                else
                {
                    // create child views from child view declarations
                    InstantiateRuntimeChildViews(idPath, dataTemplates, parent, childView, viewObject.FilePath, viewObject, parentViewType, childViewDeclaration, childViewDeclaration.ChildDeclarations, childIdVar, childTemplateDepth, templateItems, firstTemplateChild);
                }
            }
        }

        /// <summary>
        /// Uses reflection to get the specified bindable object from a path like "NewView.Button.Label". 
        /// </summary>
        private static BindableObject GetBindableObjectFromPath(object obj, IEnumerable<string> path)
        {
            // TODO replace with extension method obj.GetPropertyValue()
            if (obj == null) return null;
            var type = obj.GetType();

            var currentObj = obj;
            foreach (var fieldName in path)
            {
                type = currentObj.GetType();
                var fieldInfo = type.GetField(fieldName, BindingFlags.FlattenHierarchy);
                if (fieldInfo != null)
                {
                    currentObj = fieldInfo.GetValue(currentObj);
                    continue;
                }

                var propertyInfo = type.GetProperty(fieldName, BindingFlags.FlattenHierarchy);
                if (propertyInfo != null)
                {
                    currentObj = propertyInfo.GetValue(currentObj);
                }
            }

            return currentObj as BindableObject;
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

            // set view path
            // TODO ask user which content directory to put the new view in

            // generate XML
            var sb = new StringBuilder();

            var config = MasterConfig.GetInstance();
            string path = String.Format("{0}/{1}Delight/Content{2}{3}.xml", Application.dataPath, config.DelightPath, ContentParser.ViewsFolder, viewName);
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