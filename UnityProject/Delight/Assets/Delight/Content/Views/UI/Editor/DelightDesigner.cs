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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Delight;
using UnityScript.Steps;
#if UNITY_EDITOR
using UnityEditor;
using Delight.Editor;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis;
#endif
#endregion

namespace Delight
{
    /// <summary>
    /// Designer for editing view XML and data models during runtime.
    /// </summary>
    public partial class DelightDesigner
    {
        #region Fields

        private UIView _displayedViewInstance;
        private DesignerView _currentEditedView;
        private DesignerView _currentDisplayedView;
        private Dictionary<string, Template> _runtimeTemplates;
        private DesignerView _lastOpenView;
        private bool _readOnlyOverride;
        private Dictionary<Type, Dictionary<string, Script<object>>> _cachedScripts = new Dictionary<Type, Dictionary<string, Script<object>>>();
        private List<UIView> _selectedViews = new List<UIView>();
        private List<UIView> _raycastedViews = new List<UIView>();
        private int _selectedRaycastedIndex = 0;
        private List<SelectionIndicator> _selectionIndicators = new List<SelectionIndicator>();
        private bool _viewLockEnabled = false;

        public EventSystem _eventSystem;
        public EventSystem EventSystem
        {
            get
            {
                if (_eventSystem == null)
                {
                    _eventSystem = GameObject.FindObjectOfType<EventSystem>();
                }

                return _eventSystem;
            }
        }

        public string LastOpenedViewEditorPref
        {
            get
            {
                return EditorPrefs.GetString("Delight_DesignerLastOpenedView", string.Empty);
            }
            set
            {
                EditorPrefs.SetString("Delight_DesignerLastOpenedView", value);
            }
        }

        public bool ShowReadOnlyViewsEditorPref
        {
            get
            {
                return EditorPrefs.GetBool("Delight_DesignerShowReadOnlyViews", false);
            }
            set
            {
                EditorPrefs.SetBool("Delight_DesignerShowReadOnlyViews", value);
            }
        }

        public bool IsMaster = true;

        #endregion

        #region Methods

        /// <summary>
        /// Called every frame and handles keyboard and mouse input. 
        /// </summary>
        public override void Update()
        {
            base.Update();

            bool ctrlDown = Input.GetKey(KeyCode.LeftApple) || Input.GetKey(KeyCode.RightApple) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
            bool shiftDown = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

            // F5 reparses the currently edited view
            if (Input.GetKeyDown(KeyCode.F5))
            {
                ParseView();
            }

            // F11 maximizes designer window in editor
            if (Input.GetKeyDown(KeyCode.F11))
            {
                UnityEditor.EditorWindow.focusedWindow.maximized = !UnityEditor.EditorWindow.focusedWindow.maximized;

                // center on view
                ScrollableContentRegion.SetScrollPosition(0.5f, 0.5f);
                SetScale(Vector3.one);
            }

            // F12 jumps to definition
            if (Input.GetKeyDown(KeyCode.F12) && _currentEditedView != null)
            {
                var viewAtCaret = XmlEditor.GetViewAtCaret();
                if (!String.IsNullOrEmpty(viewAtCaret))
                {
                    var designerViewAtCaret = DesignerViews.FirstOrDefault(x => x.Name == viewAtCaret);
                    if (designerViewAtCaret != null && designerViewAtCaret != _currentEditedView)
                    {
                        OpenView(designerViewAtCaret);
                    }
                }
            }

            // unlocks read-only views to be edited
            if (Input.GetKeyDown(KeyCode.L) && ctrlDown && shiftDown)
            {
                _readOnlyOverride = !_readOnlyOverride;
                UpdateXmlEditorReadonly();
            }

            // F10 jumps to last open view
            if (Input.GetKeyDown(KeyCode.F10) && _lastOpenView != null)
            {
                OpenView(_lastOpenView);
            }

            // CTRL+S and CTRL+SHIFT+S saves all changes
            if (ctrlDown && Input.GetKeyDown(KeyCode.S))
            {
                SaveChanges();
            }

            // Mouse click - selection logic for selecting views in the designer
            if (Input.GetMouseButtonDown(0) &&
                ScrollableContentRegion.ContainsMouse(Input.mousePosition) &&
                _currentEditedView != null)
            {
                var pointerEventData = new PointerEventData(EventSystem);
                pointerEventData.position = Input.mousePosition;

                List<RaycastResult> results = new List<RaycastResult>();
                EventSystem.RaycastAll(pointerEventData, results);
                bool multiSelect = ctrlDown;
                results.RemoveAll(x => x.gameObject.name == "SelectionIndicator"); // remove selection indicators from raycast

                // get selected object
                var selectedObject = results.Select(x => x.gameObject).FirstOrDefault(); // TODO here we might want to handle overlapping views
                if (selectedObject != null)
                {
                    // find view with the selected game object
                    var selectedView = ViewContentRegion.Find<UIView>(x => x.GameObject == selectedObject);
                    while (selectedView?.Parent?.GetType().Name != _currentEditedView.ViewTypeName)
                    {
                        selectedView = selectedView?.LayoutParent as UIView;
                        if (selectedView == null)
                            break;
                    }

                    if (selectedView != null)
                    {
                        _raycastedViews.Clear();
                        if (multiSelect)
                        {
                            // multi-select
                            if (_selectedViews.Contains(selectedView))
                            {
                                // deselect already selected view
                                _selectedViews.Remove(selectedView);
                            }
                            else
                            {
                                // select new view
                                _selectedViews.Add(selectedView);
                            }
                        }
                        else
                        {
                            // regular select
                            _selectedViews.Clear();
                            _selectedViews.Add(selectedView);

                            // add all parent views in hierarhcy as raycasted views
                            _raycastedViews.Add(selectedView);
                            var nextView = selectedView;
                            while (nextView != _displayedViewInstance)
                            {
                                nextView = nextView.LayoutParent as UIView;
                                if (nextView == null || (nextView?.Parent?.GetType().Name != _currentEditedView.ViewTypeName &&
                                    nextView.GetType().Name != _currentEditedView.ViewTypeName))
                                    break;

                                _raycastedViews.Add(nextView);
                            }
                        }

                        UpdateSelectedViews();
                    }
                    else if (!multiSelect)
                    {
                        ClearSelectedViews();
                    }
                }
                else if (!multiSelect)
                {
                    ClearSelectedViews();
                }
            }

            // CTRL+scroll wheel up/down traverses raycast selection hieararchy to easy e.g. select parent to clicked view
            if (_selectedViews.Count == 1 && Input.mouseScrollDelta.y > 0 && ctrlDown)
            {
                if (_selectedRaycastedIndex > 0)
                {
                    --_selectedRaycastedIndex;
                    _selectedViews.Clear();
                    _selectedViews.Add(_raycastedViews[_selectedRaycastedIndex]);
                    UpdateSelectedViews();
                }
            }
            else if (_selectedViews.Count == 1 && Input.mouseScrollDelta.y < 0 && ctrlDown)
            {
                if (_selectedRaycastedIndex < _raycastedViews.Count() - 1)
                {
                    ++_selectedRaycastedIndex;
                    _selectedViews.Clear();
                    _selectedViews.Add(_raycastedViews[_selectedRaycastedIndex]);
                    UpdateSelectedViews();
                }
            }
        }

        /// <summary>
        /// Updates selected views.
        /// </summary>
        private void UpdateSelectedViews(bool scrollToLastSelectedView = true)
        {
            var lastSelectedView = _selectedViews.LastOrDefault();
            if (lastSelectedView != null)
            {
                Selection.activeObject = lastSelectedView.GameObject;
                Selection.objects = _selectedViews.Select(x => x.GameObject).ToArray();
                EditorGUIUtility.PingObject(lastSelectedView.GameObject);

                //Debug.Log(String.Format("Selecting {0} ({1},{2})", lastSelectedView.GetType().Name, lastSelectedView.Template.LineNumber, lastSelectedView.Template.LinePosition));
            }

            // destroy selection indicators not in new list
            foreach (var selectionIndicator in _selectionIndicators.ToList())
            {
                if (!_selectedViews.Contains(selectionIndicator.SelectedViewInfo.View))
                {
                    selectionIndicator.Destroy();
                    _selectionIndicators.Remove(selectionIndicator);
                }
            }

            // add selection indicators for selected views
            _selectedViews.ForEach(x =>
            {
                if (_selectionIndicators.Any(y => y.SelectedViewInfo.View == x))
                    return; // indicator already exist

                var selectionIndicator = new SelectionIndicator(ViewContentRegion);
                selectionIndicator.SelectedViewInfo = new SelectedViewInfo { View = x };
                selectionIndicator.Load();
                _selectionIndicators.Add(selectionIndicator);
            });

            // highlight selected views in the XML editor
            XmlEditor.SetSelectedViews(_selectedViews, scrollToLastSelectedView);
        }

        /// <summary>
        /// Clears selected views.
        /// </summary>
        public void ClearSelectedViews()
        {
            _selectedRaycastedIndex = 0;
            _raycastedViews.Clear();
            _selectedViews.Clear();
            UpdateSelectedViews();
        }

        /// <summary>
        /// Opens the specified view in the designer.
        /// </summary>
        private void OpenView(DesignerView designerViewName)
        {
            if (DisplayedDesignerViews.Contains(designerViewName))
            {
                DisplayedDesignerViews.Select(designerViewName);
            }
            else
            {
                // open unlisted designer view
                ViewSelected(designerViewName);
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
            DisplayedDesignerViews = new DesignerViewData();
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

                var designerView = new DesignerView
                {
                    Id = viewObject.Name,
                    Name = viewObject.Name,
                    ViewTypeName = viewObject.TypeName,
                    ViewObject = viewObject,
                    FilePath = viewObject.FilePath
                };

                designerViews.Add(designerView);
            }

            DesignerViews.AddRange(designerViews.OrderBy(x => x.Id));
            DisplayedDesignerViews.AddRange(designerViews.Where(x => !x.IsLocked || DisplayReadOnlyViews).OrderBy(y => y.Id));

            DisplayReadOnlyViews = ShowReadOnlyViewsEditorPref;
            OnDisplayReadOnlyViewsChanged();
        }

        /// <summary>
        /// Called when the user edits the current view.
        /// </summary>
        public void OnEdit(bool needReparsing)
        {
            if (_currentEditedView == null)
                return;

            _currentEditedView.IsDirty = true;
            if (AutoParse && needReparsing)
            {
                ParseView();
            }
        }

        /// <summary>
        /// Toogles the view lock.
        /// </summary>
        public async void ToggleViewLock(bool toggleValue)
        {
            if (_currentEditedView == null)
                return;

            // when view lock is enabled the user can switch to edit other views and the current view is always displayed
            _viewLockEnabled = toggleValue;
            _currentDisplayedView.IsDisplayLocked = false;
            _currentDisplayedView = _currentEditedView;
            _currentDisplayedView.IsDisplayLocked = _viewLockEnabled;

            if (_viewLockEnabled)
            {
                _currentDisplayedView.XmlText = XmlEditor.GetXmlText();
                ParseView();
            }
            else
            {
                await DisplayView(_currentDisplayedView); // if lock disabled then display currently selected view

                // center on view
                ScrollableContentRegion.SetScrollPosition(0.5f, 0.5f);
                SetScale(Vector3.one);
            }
        }

        /// <summary>
        /// Called when the user selects a view in the XML editor. 
        /// </summary>
        public void OnSelectViewAtLine(int line)
        {
            OnSelectViewsAtLine(new List<int> { line });
        }

        /// <summary>
        /// Called when the user selects a view in the XML editor. 
        /// </summary>
        public void OnSelectViewsAtLine(List<int> lines)
        {
            bool foundView = false;
            foreach (var line in lines)
            {
                var view = ViewContentRegion.Find<UIView>(x =>
                {
                    if (x?.Parent?.GetType().Name != _currentEditedView.ViewTypeName &&
                        x.GetType().Name != _currentEditedView.ViewTypeName)
                        return false;

                    int viewLineNumber = Math.Max(x.Template.LineNumber - 1, 0);
                    if (viewLineNumber != line)
                        return false;

                    if (_selectedViews.Contains(x))
                    {
                        _selectedViews.Remove(x);
                    }
                    else
                    {
                        _selectedViews.Add(x);
                    }
                    return true;
                });

                if (view != null)
                {
                    foundView = true;
                }
            }

            if (foundView)
            {
                UpdateSelectedViews(false);
            }
        }

        /// <summary>
        /// Called after the view has been loaded.
        /// </summary>
        protected override async void AfterLoad()
        {
            base.AfterLoad();

            if (!IsMaster)
                return;

            // open last opened designer view on startup
            var lastOpenedViewEditorPref = LastOpenedViewEditorPref;
            if (!String.IsNullOrEmpty(lastOpenedViewEditorPref))
            {
                var lastOpenedDesignerView = DesignerViews.FirstOrDefault(x => x.Name == lastOpenedViewEditorPref);
                if (lastOpenedDesignerView != null)
                {
                    await new WaitForSeconds(0.0001f); // bugfix with syntax highlighting not being initialized
                    OpenView(lastOpenedDesignerView);
                }
            }
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
            ClearSelectedViews();
            UpdateCurrentEditedViewXml();

            _lastOpenView = _currentEditedView;
            _currentEditedView = designerView;
            XmlEditorRegion.IsVisible = true;
            DisplayRegion.IsVisible = true;

            // change display if editor is readonly
            UpdateXmlEditorReadonly();

            // set editor XML text
            if (!designerView.IsRuntimeParsed)
            {
                // load XML into the editor
                if (!String.IsNullOrEmpty(_currentEditedView.XmlText))
                {
                    XmlEditor.XmlText = _currentEditedView.XmlText;
                }
                else
                {
                    var path = designerView.FilePath;
                    var xmlText = File.ReadAllText(path);

                    xmlText = StripNamespaceAndSchema(xmlText);
                    XmlEditor.XmlText = xmlText;
                }
            }
            else
            {
                // create runtime parsed view
                XmlEditor.XmlText = _currentEditedView.XmlText;
            }

            if (_viewLockEnabled)
                return; // if view lock we're done here

            await DisplayView(designerView);

            // center on view
            ScrollableContentRegion.SetScrollPosition(0.5f, 0.5f);
            SetScale(Vector3.one);
        }

        /// <summary>
        /// Instantiates designer view in the display region.
        /// </summary>
        private async Task DisplayView(DesignerView designerView)
        {
            _currentDisplayedView = designerView;
            LastOpenedViewEditorPref = designerView.Name;

            try
            {
                ConsoleLogger.LogParseError = LogParseErrorToDesignerConsole;
                var sw2 = System.Diagnostics.Stopwatch.StartNew();

                UIView view = null;
                if (!_currentDisplayedView.IsRuntimeParsed)
                {
                    view = CreateView(_currentDisplayedView.ViewTypeName, this, ViewContentRegion);
                }
                else
                {
                    view = InstantiateRuntimeView(_currentDisplayedView.ViewObject, this, ViewContentRegion,
                        _currentEditedView.IsNew, null, _currentEditedView);
                }

                if (view == null)
                    return;

                if (view.GetType() == typeof(DelightDesigner))
                {
                    (view as DelightDesigner).IsMaster = false;
                }

                await view?.LoadAsync();
                view?.PrepareForDesigner();

                sw2.Stop();

                // destroy previous view
                if (_displayedViewInstance != null)
                {
                    _displayedViewInstance.Destroy();
                }

                _displayedViewInstance = view;

                // attempt to reselect currently selected views
                var selectedViews = _selectedViews.ToList();
                _selectedViews.Clear();
                OnSelectViewsAtLine(XmlEditor.SelectedLines);

                // uncomment to log loading time 
                //Debug.Log(String.Format("Loading view {0}: {1}", designerView.ViewTypeName, sw2.ElapsedMilliseconds));
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
        }

        /// <summary>
        /// Updates the xml editor based on read-only mode. 
        /// </summary>
        public void UpdateXmlEditorReadonly()
        {
            bool isReadOnly = _currentEditedView != null ? _currentEditedView.IsLocked && !_readOnlyOverride : false;
            var color = isReadOnly ? ColorValueConverter.HexToColor("#ECECEC").Value : ColorValueConverter.HexToColor("#fbfbfb").Value;
            XmlEditor.IsReadOnly = isReadOnly;
            XmlEditor.BackgroundColor = color;
            XmlEditor.XmlEditLeftMargin.BackgroundColor = color;
            XmlEditor.LineNumbersRightBorder.BackgroundColor = color;
            XmlEditor.ScrollableRegion.HorizontalScrollbarBackgroundColor = color;
            XmlEditor.ScrollableRegion.VerticalScrollbarBackgroundColor = color;
            XmlEditorRegion.BackgroundColor = color;
            LockIcon.IsActive = isReadOnly;
        }

        /// <summary>
        /// Strips namespace and schema from XML root.
        /// </summary>
        private string StripNamespaceAndSchema(string xmlText)
        {
            // strip namespace and schema elements from XML root
            xmlText = xmlText.Replace(" xmlns=\"Delight\"", string.Empty);
            xmlText = xmlText.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", string.Empty);
            var schemaElement = " xsi:schemaLocation=\"Delight";

            int indexOfSchemaElement = xmlText.IndexOf(schemaElement);
            if (indexOfSchemaElement > 0)
            {
                xmlText = xmlText.Remove(indexOfSchemaElement, (1 + xmlText.IndexOf("\"", indexOfSchemaElement + schemaElement.Length)) - indexOfSchemaElement);
            }

            return xmlText;
        }

        /// <summary>
        /// Logs parse errors to the designer console. 
        /// </summary>
        public static void LogParseErrorToDesignerConsole(string file, int line, string message)
        {
            // TODO implement designer console, for now log to unity console
            Debug.LogException(new XmlParseError(message, String.Format("Delight:XmlError() (at {0}:{1})", file, line)));
        }

        /// <summary>
        /// Parses run-time view XML and generates the view in the designer.
        /// </summary>
        public async void ParseView()
        {
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

            // parse view XML into view object
            ConsoleLogger.LogParseError = LogParseErrorToDesignerConsole;
            try
            {
                var viewObject = ContentParser.ParseViewXml(_currentEditedView.FilePath, rootXmlElement, false);
                _currentEditedView.ViewObject = viewObject;

                if (_currentEditedView != _currentDisplayedView)
                {
                    // even if view isn't displayed we need to instantiate view to update data templates
                    var view = InstantiateRuntimeView(viewObject, this, ViewContentRegion,
                        _currentEditedView.IsNew, null, _currentEditedView);
                    if (view != null)
                    {
                        view.Destroy();
                    }
                }
            }
            catch (Exception e)
            {
                ConsoleLogger.LogParseError(_currentEditedView.FilePath, 1,
                    String.Format("#Delight# Error parsing view. Exception thrown: {0}. See Unity console for code stacktrace.", e.Message));
                ConsoleLogger.LogException(e);
            }
            finally
            {
                ConsoleLogger.LogParseError = ConsoleLogger.LogParseErrorToDebug;
            }

            // parse successful
            XmlEditor.OnParseSuccessful();

            // display view
            await DisplayView(_currentDisplayedView);
        }

        /// <summary>
        /// Instantiates a view object.
        /// </summary>
        public UIView InstantiateRuntimeView(ViewObject viewObject, View parent, View layoutParent, bool isNew, Template template = null,
            DesignerView inDesignerView = null)
        {
            // ** important: changes in runtime instantiation of views need to be reflected in the view code generation in
            // CodeGenerator.GenerateChildViewDeclarations() **

            // update view declarations and mapped properties
            CodeGenerator.UpdateViewDeclarations(viewObject, viewObject.ViewDeclarations, false);
            CodeGenerator.UpdateMappedProperties(viewObject);

            // create the runtime data templates used when instantiating the view
            Dictionary<string, Template> dataTemplates = new Dictionary<string, Template>();
            CreateRuntimeDataTemplates(viewObject, string.Empty, string.Empty, string.Empty, null, null, viewObject.FilePath, dataTemplates, null);

            // get view type name
            var viewTypeName = viewObject.TypeName;
            if (isNew)
            {
                viewTypeName = viewObject.BasedOn.TypeName;
            }
            else
            {
                // use original name to lookup view type in renamed views
                var designerView = inDesignerView ?? DesignerViews.FirstOrDefault(x => x.Name == viewObject.Name);
                if (designerView != null && designerView.IsRenamed && !viewObject.HasNonDefaultTypeName)
                {
                    viewTypeName = designerView.OriginalName;
                }
            }

            // instantiate view
            var view = CreateView(viewTypeName, parent, layoutParent, viewObject.TypeName, template ?? dataTemplates[viewObject.TypeName], true) as UIView;
            if (view == null)
            {
                return null;
            }

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
            // ** important: changes in runtime instantiation of views need to be reflected in the view code generation in
            // CodeGenerator.GenerateChildViewDeclarations() **

            bool inTemplate = templateDepth > 0;
            var contentObjectModel = ContentObjectModel.GetInstance();
            var instantiatedChildViews = new List<View>();

            // so we need to loop through all child views, print their construction logic
            foreach (var childViewDeclaration in childViewDeclarations)
            {
                // get identifier for view declaration
                var designerView = DesignerViews.FirstOrDefault(x => x.Name == childViewDeclaration.ViewName);
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
                    childView = CreateView(childViewObject.TypeName, parent, layoutParentContent, childId, dataTemplates[templateIdPath]) as UIView;
                }

                if (childView == null)
                {
                    ConsoleLogger.LogParseError(fileName, childViewDeclaration.LineNumber, String.Format("#Delight# Unable to instantiate view <{0}>.", viewObject.Name));
                    continue;
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
                var actionAssignments = childPropertyAssignments.Where(x => x.PropertyDeclarationInfo != null && x.PropertyDeclarationInfo.Declaration.DeclarationType == PropertyDeclarationType.Action);
                if (actionAssignments.Any())
                {
                    // yes. add initializer for action handlers
                    foreach (var actionAssignment in actionAssignments)
                    {
                        var actionValue = actionAssignment.PropertyValue;
                        var action = childView.GetPropertyValue(actionAssignment.PropertyName) as ViewAction;

                        if (actionAssignment.HasEmbeddedCode)
                        {
                            // set runtime path to template items in expression
                            actionValue = CodeGenerator.SetTemplateItemsInExpression(templateItems, actionValue, true);
                            var script = GetCSharpScript(parent.GetType(), actionValue);

                            // copy template items
                            var templateItemsCopy = CopyTemplateItems(templateItems);
                            Action runtimeAction = async () =>
                            {
                                try
                                {
                                    // set template items on parent before execution
                                    parent.TemplateItems = new Dictionary<string, ContentTemplateData>();
                                    foreach (var templateItem in templateItemsCopy)
                                    {
                                        if (parent.TemplateItems.ContainsKey(templateItem.VariableName))
                                        {
                                            parent.TemplateItems[templateItem.VariableName] = templateItem.ContentTemplateData;
                                        }
                                        else
                                        {
                                            parent.TemplateItems.Add(templateItem.VariableName, templateItem.ContentTemplateData);
                                        }
                                    }

                                    // uses roslyn to evaluate script at runtime
                                    await script.RunAsync(globals: parent);
                                    parent.TemplateItems = null;
                                }
                                catch (Exception e)
                                {
                                    ConsoleLogger.LogParseError(fileName, actionAssignment.LineNumber,
                                        String.Format("#Delight# Unable to execute view action expression <{0} {1}=\"{2}\">. Compilation error thrown: {3}",
                                            childViewDeclaration.ViewName, actionAssignment.PropertyName, actionValue, e.InnerException.Message));
                                }
                            };

                            // register runtime action handler
                            action?.RegisterHandler(runtimeAction);
                            continue;
                        }

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
                        action?.RegisterHandler(parent, actionHandlerName);
                    }
                }

                // do we have assignments with embedded expressions?
                var embeddedAssignments = childPropertyAssignments.Where(x => x.PropertyDeclarationInfo != null && x.HasEmbeddedCode && x.PropertyDeclarationInfo.Declaration.DeclarationType != PropertyDeclarationType.Action);
                if (embeddedAssignments.Any())
                {
                    // generate assignment for expressions
                    foreach (var embeddedAssignment in embeddedAssignments)
                    {
                        var expression = embeddedAssignment.PropertyValue;

                        // set runtime path to template items in expression
                        expression = CodeGenerator.SetTemplateItemsInExpression(templateItems, expression, true);
                        var script = GetCSharpScript(parent.GetType(), expression);

                        Func<Task<object>> transformMethod = async () =>
                        {
                            try
                            {
                                // set template items on parent before execution
                                parent.TemplateItems = new Dictionary<string, ContentTemplateData>();
                                foreach (var templateItem in templateItems)
                                {
                                    if (parent.TemplateItems.ContainsKey(templateItem.VariableName))
                                    {
                                        parent.TemplateItems[templateItem.VariableName] = templateItem.ContentTemplateData;
                                    }
                                    else
                                    {
                                        parent.TemplateItems.Add(templateItem.VariableName, templateItem.ContentTemplateData);
                                    }
                                }

                                // uses roslyn to evaluate script at runtime
                                var result = (await script.RunAsync(globals: parent)).ReturnValue;
                                parent.TemplateItems = null;
                                childView.SetPropertyValue(embeddedAssignment.PropertyName, result);
                                return result;
                            }
                            catch (Exception e)
                            {
                                ConsoleLogger.LogParseError(fileName, embeddedAssignment.LineNumber,
                                    String.Format("#Delight# Unable to execute binding expression <{0} {1}=\"$ {2}\">. Compilation error thrown: {3}",
                                        childViewDeclaration.ViewName, embeddedAssignment.PropertyName, embeddedAssignment.PropertyValue, e.ToString()));
                                return null;
                            }
                        };

                        childView.Bindings.Add(new RuntimeBinding(transformMethod));
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

                        // generate code for embedded C# code expressions
                        Func<Task<object>> transformMethod = null;
                        if (propertyBinding.BindingType == BindingType.MultiBindingTransform)
                        {
                            List<string> sourceBindingPathObjects, convertedSourceProperties, sourceProperties;
                            CodeGenerator.GetBindingSourceProperties(fileName, viewObject, templateItems, childViewDeclaration, propertyBinding, out sourceBindingPathObjects, out convertedSourceProperties, out sourceProperties, true);

                            // get expression to be evaluated at run-time
                            var expression = String.Format(propertyBinding.TransformExpression, convertedSourceProperties.ToArray<object>());
                            var script = GetCSharpScript(parent.GetType(), expression);

                            transformMethod = async () =>
                            {
                                try
                                {
                                    // set template items on parent before execution
                                    parent.TemplateItems = new Dictionary<string, ContentTemplateData>();
                                    foreach (var templateItem in templateItems)
                                    {
                                        if (parent.TemplateItems.ContainsKey(templateItem.VariableName))
                                        {
                                            parent.TemplateItems[templateItem.VariableName] = templateItem.ContentTemplateData;
                                        }
                                        else
                                        {
                                            parent.TemplateItems.Add(templateItem.VariableName, templateItem.ContentTemplateData);
                                        }
                                    }

                                    // uses roslyn to evaluate script at runtime
                                    var result = (await script.RunAsync(globals: parent)).ReturnValue;
                                    parent.TemplateItems = null;
                                    return result;
                                }
                                catch (Exception e)
                                {
                                    ConsoleLogger.LogParseError(fileName, propertyBinding.LineNumber,
                                        String.Format("#Delight# Unable to execute binding expression <{0} {1}=\"{2}\">. Compilation error thrown: {3}",
                                            childViewDeclaration.ViewName, propertyBinding.PropertyName, propertyBinding.PropertyBindingString, e.ToString()));
                                    return null;
                                }
                            };
                        }

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
                            var tiVar = ti;
                            if (tiVar != null)
                            {
                                ti.ContentTemplateData = x;
                            }
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
        /// Copies template items.
        /// </summary>
        private static List<TemplateItemInfo> CopyTemplateItems(List<TemplateItemInfo> templateItems)
        {
            var templateItemsCopy = new List<TemplateItemInfo>();
            foreach (var templateItem in templateItems)
            {
                templateItemsCopy.Add(new TemplateItemInfo
                {
                    ContentTemplateData = new ContentTemplateData
                    {
                        Id = templateItem.ContentTemplateData.Id,
                        Index = templateItem.ContentTemplateData.Index,
                        ZeroIndex = templateItem.ContentTemplateData.ZeroIndex,
                        Item = templateItem.ContentTemplateData.Item
                    },
                    ItemIdDeclaration = templateItem.ItemIdDeclaration,
                    ItemType = templateItem.ItemType,
                    ItemTypeName = templateItem.ItemTypeName,
                    Name = templateItem.Name,
                    VariableName = templateItem.VariableName,
                });
            }

            return templateItemsCopy;
        }

        /// <summary>
        /// Gets C# script that can be evaluated at runtime, using roslyn compiler.
        /// </summary>
        private Script<object> GetCSharpScript(Type parentType, string expression)
        {
            //Debug.Log("Creating script for expression: " + expression);

            // cache scripts so they don't have to be re-compiled
            if (!_cachedScripts.TryGetValue(parentType, out var scripts))
            {
                scripts = new Dictionary<string, Script<object>>();
                _cachedScripts.Add(parentType, scripts);
            }

            if (!scripts.TryGetValue(expression, out var script))
            {
                script = CSharpScript.Create(expression, ScriptOptions.Default.WithImports(
                "System",
                "System.Collections.Generic",
                "System.Runtime.CompilerServices",
                "System.Linq",
                "UnityEngine",
                "UnityEngine.UI",
                "Delight"
                ).AddReferences(
                    typeof(System.Linq.Enumerable).Assembly,
                    typeof(UnityEngine.GameObject).Assembly,
                    typeof(UnityEngine.UI.Button).Assembly,
                    typeof(Delight.Button).Assembly
                ),
                globalsType: parentType);
                scripts.Add(expression, script);
            }

            return script;
        }

        /// <summary>
        /// Creates runtime data templates.
        /// </summary>
        private void CreateRuntimeDataTemplates(ViewObject viewObject, string idPath, string basedOnPath, string basedOnViewName, ViewDeclaration viewDeclaration,
            List<PropertyExpression> nestedPropertyExpressions, string fileName, Dictionary<string, Template> dataTemplates, ViewDeclaration internalViewDeclaration)
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

            dataTemplate.LineNumber = internalViewDeclaration != null ? internalViewDeclaration.LineNumber : 0;
            dataTemplate.LinePosition = internalViewDeclaration != null ? internalViewDeclaration.LinePosition : 0;
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
                    childPropertyAssignments, fileName, dataTemplates, declaration.Declaration);
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
            if (_displayedViewInstance == null)
                return;

            bool ctrlDown = Input.GetKey(KeyCode.LeftApple) || Input.GetKey(KeyCode.RightApple) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
            bool shiftDown = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
            if (ctrlDown || shiftDown)
            {
                return;
            }

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
            if (_displayedViewInstance == null)
            {
                ContentRegionCanvas.Scale = Vector3.one;
                return;
            }

            ContentRegionCanvas.Scale = scale;

            // adjust size of view region based on size of view and viewport
            var viewportWidth = ScrollableContentRegion.ActualWidth;
            var viewportHeight = ScrollableContentRegion.ActualHeight;

            var width = _displayedViewInstance.OverrideWidth ?? _displayedViewInstance.Width ?? ElementSize.FromPercents(1);
            var height = _displayedViewInstance.OverrideHeight ?? _displayedViewInstance.Height ?? ElementSize.FromPercents(1);

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
            if (!IsMaster)
                return;

            var changedViews = DesignerViews.Where(x => x.IsDirty).ToList();
            UpdateCurrentEditedViewXml();

            if (!changedViews.Any())
                return;

            // see if any views are renamed and update references to it
            for (int viewIndex = changedViews.Count() - 1; viewIndex >= 0; --viewIndex)
            {
                var changedView = changedViews[viewIndex];
                UpdateViewsIfRenamed(changedView, changedViews);
            }

            for (int viewIndex = 0; viewIndex < changedViews.Count(); ++viewIndex)
            {
                var changedView = changedViews[viewIndex];
                var xmlText = changedView.XmlText;

                // add namespace and schema elements to XML root if it's missing
                if (!xmlText.Contains("xmlns="))
                {
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
                            startIndex = i;
                            break;
                        }
                    }

                    if (startIndex > 0)
                    {
                        var path = changedView.FilePath;
                        bool isScene = path.IndexOf(ContentParser.ScenesFolder) > 0;
                        var contentFolder = isScene ? ContentParser.ScenesFolder : ContentParser.ViewsFolder;
                        int contentDirIndex = path.LastIndexOf(contentFolder);
                        string p1 = path.Substring(contentDirIndex + contentFolder.Length);
                        int directoryDepth = 1 + p1.Count(x => x == '/');
                        var ellipsis = string.Concat(Enumerable.Repeat("../", directoryDepth));
                        var namespaceAndSchema = String.Format(" xmlns=\"Delight\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"Delight {0}Delight.xsd\"", ellipsis);
                        xmlText = xmlText.Insert(startIndex, namespaceAndSchema);
                    }
                }

                // check if view has changed name and rename files
                if (changedView.IsRenamed)
                {
                    var viewName = changedView.Name;
                    var oldViewName = String.IsNullOrEmpty(changedView.LastSavedName) ? changedView.OriginalName : changedView.LastSavedName;
                    string dir = Path.GetDirectoryName(changedView.FilePath);
                    string newPath = Path.Combine(dir, viewName);
                    changedView.FilePath = newPath + ".xml";

                    // rename existing .xml and .cs files
                    try
                    {
                        File.Move(Path.Combine(dir, oldViewName + ".xml"), newPath + ".xml");
                    }
                    catch
                    {
                    }

                    try
                    {
                        File.Move(Path.Combine(dir, oldViewName + "_g.cs"), newPath + "_g.cs");
                    }
                    catch
                    {
                    }

                    try
                    {
                        string csFile = newPath + ".cs";
                        File.Move(Path.Combine(dir, oldViewName + ".cs"), csFile);

                        if (!changedView.ViewObject.HasNonDefaultTypeName)
                        {
                            // rename the class in the file
                            var csFileText = File.ReadAllText(csFile);
                            csFileText = csFileText.Replace("public partial class " + oldViewName, "public partial class " + viewName);
                            File.WriteAllText(csFile, csFileText);
                        }
                    }
                    catch
                    {
                    }

                    changedView.LastSavedName = viewName;

                    // rename the view object
                    var contentObjectModel = ContentObjectModel.GetInstance();
                    changedView.ViewObject.Name = viewName;
                    contentObjectModel.RenameViewObject(oldViewName, viewName);
                    contentObjectModel.SaveObjectModel();
                }

                // TODO check if view references new views that haven't been created and create them

                File.WriteAllText(changedView.FilePath, xmlText);
                changedView.IsDirty = false;
            }

#if UNITY_EDITOR
            AssetDatabase.Refresh(ImportAssetOptions.ForceSynchronousImport);
#endif
        }

        /// <summary>
        /// Checks if designer view has been renamed, and if so renames it and updates all references to it in other views.
        /// </summary>
        private void UpdateViewsIfRenamed(DesignerView changedView, List<DesignerView> changedViews)
        {
            try
            {
                var xmlText = changedView.XmlText;
                XElement rootXmlElement = XElement.Parse(xmlText, LoadOptions.SetLineInfo);

                // check if root element has been renamed
                // if root element has changed, then rename the view. 
                var viewName = rootXmlElement.Name.LocalName;
                if (!viewName.IEquals(changedView.Name))
                {
                    // check if name already exist
                    int i = 1;
                    var name = viewName;
                    bool renameThisViewXml = false;
                    while (true)
                    {
                        if (!DesignerViews.Any(x => x.Name == viewName))
                        {
                            break;
                        }

                        renameThisViewXml = true;
                        viewName = name + i;
                        ++i;
                    }

                    // rename view
                    var oldViewName = changedView.Name;
                    changedView.Name = viewName;
                    changedView.IsRenamed = true;
                    if (String.IsNullOrEmpty(changedView.OriginalName))
                    {
                        changedView.OriginalName = oldViewName;
                    }

                    // update all references to the view 
                    foreach (var view in DesignerViews)
                    {
                        if (view == changedView && !renameThisViewXml)
                            continue;

                        var viewXmlText = !String.IsNullOrWhiteSpace(view.XmlText) ? view.XmlText :
                            File.ReadAllText(view.FilePath);

                        // see if the view references the old view and update the xml
                        // the regex pattern below matches start/end tags with the specified view name
                        bool foundMatch = false;
                        var pattern = String.Format(@"(?<=<[/]?){0}(?=[\s>/])", oldViewName);
                        var replacedXml = Regex.Replace(viewXmlText, pattern, m =>
                        {
                            foundMatch = true;
                            return viewName;
                        });

                        if (foundMatch)
                        {
                            // update XML and add to list of changed views
                            replacedXml = StripNamespaceAndSchema(replacedXml);

                            view.XmlText = replacedXml;
                            view.IsDirty = true;
                            view.IsRuntimeParsed = true;

                            if (view == _currentEditedView)
                            {
                                // update current editor XML
                                XmlEditor.XmlText = view.XmlText;
                            }

                            // update list of changed views
                            if (!changedViews.Contains(view))
                            {
                                changedViews.Add(view);
                            }
                        }
                    }
                }
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

                LogParseErrorToDesignerConsole(changedView.FilePath, line,
                    String.Format("#Delight# Error parsing XML file. Exception thrown: {0}", e.Message));
                return;
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
        /// Called when user adds new view. 
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
            string path = !String.IsNullOrEmpty(config.DefaultContentFolder) ?
                String.Format("{0}/{1}{2}{3}.xml", Application.dataPath,
                config.DefaultContentFolder.StartsWith("Assets/") ? config.DefaultContentFolder.Substring(7) : config.DefaultContentFolder, ContentParser.ViewsFolder, viewName) :
                String.Format("{0}/Content{1}{2}.xml", Application.dataPath, ContentParser.ViewsFolder, viewName);

            newView.FilePath = path;

            sb.AppendLine("<{0}>", viewName);
            sb.AppendLine("  ");
            sb.AppendLine("</{0}>", viewName);
            newView.XmlText = sb.ToString();

            newView.IsDirty = false;
            newView.IsNew = true;
            newView.IsRuntimeParsed = true;

            DesignerViews.Add(newView);
            DisplayedDesignerViews.Add(newView);
            DisplayedDesignerViews.SelectAndScrollTo(newView);

            XmlEditorRegion.IsVisible = true;
        }

        /// <summary>
        /// Toggles if read-only views should be shown in the list or not.
        /// </summary>
        public void ToggleShowReadOnlyViews()
        {
            DisplayReadOnlyViews = !DisplayReadOnlyViews;
            ShowReadOnlyViewsEditorPref = DisplayReadOnlyViews;
            OnDisplayReadOnlyViewsChanged();
        }

        /// <summary>
        /// Called when display only views option changes value.
        /// </summary>
        public void OnDisplayReadOnlyViewsChanged()
        {
            DisplayReadOnlyViewsText = DisplayReadOnlyViews ? "Hide Read-Only Views" : "Show Read-Only Views";
            DisplayedDesignerViews.Replace(DesignerViews.Where(x => !x.IsLocked || DisplayReadOnlyViews).OrderBy(y => y.Id));
        }

        public static UIView CreateView(string viewName)
        {
            return CreateView(viewName, null, null, string.Empty, null, false);
        }

        public static UIView CreateView(string viewName, View parent)
        {
            return CreateView(viewName, parent, null, string.Empty, null, false);
        }

        public static UIView CreateView(string viewName, View parent, View layoutParent)
        {
            return CreateView(viewName, parent, layoutParent, string.Empty, null, false);
        }

        public static UIView CreateView(string viewName, View parent, View layoutParent, string id)
        {
            return CreateView(viewName, parent, layoutParent, id, null, false);
        }

        public static UIView CreateView(string viewName, View parent, View layoutParent, string id, Template template)
        {
            return CreateView(viewName, parent, layoutParent, id, template, false);
        }

        public static UIView CreateView(string viewName, View parent, View layoutParent, string id, Template template, bool deferInitialization)
        {
            // handle special case when instantiating editor views
            if (viewName == "DelightDesigner")
            {
                return new DelightDesigner(parent, layoutParent, id, template, deferInitialization);
            }
            else if (viewName == "XmlEditor")
            {
                return new XmlEditor(parent, layoutParent, id, template, deferInitialization);
            }
            else if (viewName == "DesignerToolbar")
            {
                return new DesignerToolbar(parent, layoutParent, id, template, deferInitialization);
            }
            else
            {
                return Assets.CreateView(viewName, parent, layoutParent, id, template, deferInitialization) as UIView;
            }
        }

        public void ViewMenuItemSelected(ItemSelectionActionData selectionData)
        {

        }

        #endregion
    }
}
#endif