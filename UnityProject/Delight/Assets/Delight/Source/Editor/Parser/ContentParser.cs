#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Xml.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;
using Delight.Editor;
using UnityEngine;
using System.Xml.Serialization;
using ProtoBuf;
using UnityEditor;
#endregion

namespace Delight.Editor.Parser
{
    /// <summary>
    /// Parses content assets.
    /// </summary>
    public static class ContentParser
    {
        #region Fields

        public const string AssetsFolder = "/Assets/";
        public const string ModelsFolder = "/Models/";
        public const string ViewsFolder = "/Views/";
        public const string StylesFolder = "/Styles/";
        public const string ScenesFolder = "/Scenes/";
        public const string StreamingPath = "Assets/StreamingAssets/" + AssetBundle.DelightAssetsFolder;
        public const string RemoteAssetBundlesBasePath = "AssetBundles/";
        private const string DefaultViewType = "UIView";
        private const string DefaultNamespace = "Delight";
        private const string ModelsClassName = "Models";
        private static readonly char[] BindingDelimiterChars = { ' ', ',', '$', '(', ')', '{', '}' };

        private static ContentObjectModel _contentObjectModel = ContentObjectModel.GetInstance();

        private static XmlFile _currentXmlFile;
        private static Regex _bindingRegex = new Regex(@"{[ ]*((?<item>[A-Za-z0-9_#!=@\.\[\]]+)[ ]+in[ ]+)?(?<field>[A-Za-z0-9_#!=@\.\[\]]+)(?<format>:[^}]+)?[ ]*}");

        #endregion

        #region Views, Scenes and Styles

        /// <summary>
        /// Processes all XML assets and generates code.
        /// </summary>
        public static void RebuildViews()
        {
            // wait for any uncompiled scripts to be compiled first
            AssetDatabase.Refresh(ImportAssetOptions.ForceSynchronousImport);

            // parse all XML assets
            ParseAllXmlFiles();

            // refresh generated scripts
            AssetDatabase.Refresh();
        }

        /// <summary>
        /// Processes XML assets and generates code.
        /// </summary>
        public static void ParseAllXmlFiles()
        {
            var config = MasterConfig.GetInstance();

            // clear XML content objects from model
            _contentObjectModel.ClearParsedContent();
            _contentObjectModel.ClearAssetTypes(false);

            // get all XML assets
            var ignoreFiles = new HashSet<string>();
            var xumlFiles = new List<XmlFile>();
            foreach (var localPath in config.ContentFolders)
            {
                string path = String.Format("{0}/{1}", Application.dataPath,
                    localPath.StartsWith("Assets/") ? localPath.Substring(7) : localPath);

                foreach (var xumlFile in GetXmlFilesAtPath(path, ignoreFiles))
                {
                    xumlFiles.Add(xumlFile);
                    ignoreFiles.Add(xumlFile.Path);
                }
            }

            // parse and generate code for the xuml files
            ParseXmlFiles(xumlFiles);
        }

        /// <summary>
        /// Parses XML assets and generates code.
        /// </summary>
        public static void ParseXmlFiles(IEnumerable<string> paths)
        {
            // parse and generate code for the xuml files
            var files = new List<XmlFile>();
            foreach (var path in paths)
            {
                var xumlFile = GetXmlFileAtPath(path);
                files.Add(xumlFile);
            }

            ParseXmlFiles(files);
        }

        /// <summary>
        /// Parses XML files and generates code. 
        /// </summary>
        private static void ParseXmlFiles(List<XmlFile> xumlFiles)
        {
            // sort files by content type (styles -> scenes -> views)
            xumlFiles = xumlFiles.OrderBy(x => x.ContentType).ToList();

            foreach (var file in xumlFiles)
            {
                ParseXmlFile(file);
            }

            CodeGenerator.GenerateViewCode();

            if (_contentObjectModel.AssetsNeedUpdate)
            {
                _contentObjectModel.AssetsNeedUpdate = false;
                CodeGenerator.GenerateAssetCode();
            }

            _contentObjectModel.SaveObjectModel();

            // update config
            var config = MasterConfig.GetInstance();
            config.Views = _contentObjectModel.ViewObjects.Select(x => x.TypeName).OrderBy(x => x).ToList();
            config.SaveConfig();

            Debug.Log(String.Format("[Delight] Content processed. {0}", DateTime.Now));
        }

        /// <summary>
        /// Parses XML.
        /// </summary>
        private static void ParseXmlFile(XmlFile xumlFile)
        {
            Debug.Log("Parsing " + xumlFile.Path);
            if (xumlFile.ContentType == XmlContentType.Unknown)
            {
                Debug.LogWarning(String.Format("[Delight] Ignoring XML file \"{0}\" as it's not in a XML content type subdirectory (\"{1}\", \"{2}\" or \"{3}\").", xumlFile.Path, ViewsFolder, ScenesFolder, StylesFolder));
                return;
            }

            XElement rootXmlElement = null;
            try
            {
                rootXmlElement = XElement.Parse(xumlFile.Content, LoadOptions.SetLineInfo);
            }
            catch (Exception e)
            {
                Debug.LogError(String.Format("[Delight] Error parsing XML file \"{0}\". Exception thrown: {1}", xumlFile.Content, e.Message + e.StackTrace));
                return;
            }

            if (xumlFile.ContentType == XmlContentType.View)
            {
                ParseViewXml(xumlFile, rootXmlElement);
            }
            else if (xumlFile.ContentType == XmlContentType.Style)
            {
                ParseStyleXml(xumlFile, rootXmlElement);
            }
            else
            {
                Debug.LogWarning(String.Format("[Delight] Ignoring XML file \"{0}\". Parsing of content type \"{1}\" not implemented.", xumlFile.Path, xumlFile.ContentType));
            }
        }

        /// <summary>
        /// Parses view XML.
        /// </summary>
        private static void ParseViewXml(XmlFile xumlFile, XElement rootXmlElement)
        {
            _currentXmlFile = xumlFile;
            var viewName = rootXmlElement.Name.LocalName;
            var viewObject = _contentObjectModel.LoadViewObject(viewName);

            // clear view object 
            viewObject.Clear();
            viewObject.Name = viewName;
            viewObject.TypeName = viewName;
            viewObject.FilePath = xumlFile.Path;
            viewObject.NeedUpdate = true;

            var propertyExpressions = new List<PropertyExpression>();

            // parse view's initialization attributes
            foreach (var attribute in rootXmlElement.Attributes())
            {
                string attributeName = attribute.Name.LocalName;
                string attributeValue = attribute.Value;

                // ignore namespace specification
                if (attributeName.IEquals("xmlns"))
                    continue;

                if (attributeName.IEquals("Namespace"))
                {
                    viewObject.Namespace = attributeValue;
                    continue;
                }

                if (attributeName.IEquals("BasedOn"))
                {
                    viewObject.BasedOn = _contentObjectModel.LoadViewObject(attributeValue);
                    continue;
                }

                if (attributeName.IEquals("TypeName"))
                {
                    viewObject.TypeName = attributeValue;
                    continue;
                }

                if (attributeName.IEquals("HasContentTemplate"))
                {
                    bool hasContentTemplate;
                    if (!bool.TryParse(attributeValue, out hasContentTemplate))
                    {
                        Debug.LogError(String.Format("[Delight] {0}: Invalid HasContentTemplate value \"{1}\". Should be either \"True\" or \"False\".", GetLineInfo(rootXmlElement), attributeValue));
                        continue;
                    }
                    viewObject.HasContentTemplate = hasContentTemplate;
                    continue;
                }

                if (attributeName.IEquals("ContentTemplateType"))
                {
                    viewObject.ContentTemplate = _contentObjectModel.LoadViewObject(attributeValue);
                    continue;
                }

                // parse property expression
                var result = ParsePropertyExpression(rootXmlElement, attributeName, attributeValue);
                propertyExpressions.AddRange(result);
            }

            if (viewObject.BasedOn == null && !viewObject.Name.IEquals("View"))
            {
                viewObject.BasedOn = _contentObjectModel.LoadViewObject(DefaultViewType);
            }

            // parse the view's children recursively
            List<ViewDeclaration> viewDeclarations = ParseViewDeclarations(viewObject, xumlFile.Path, rootXmlElement.Elements(), new Dictionary<string, int>());

            // add property declarations for view declarations having IDs
            propertyExpressions.AddRange(GetPropertyDeclarations(viewDeclarations));

            viewObject.PropertyExpressions.AddRange(propertyExpressions);
            viewObject.ViewDeclarations.AddRange(viewDeclarations);
        }

        /// <summary>
        /// Parses style XML file.
        /// </summary>
        private static void ParseStyleXml(XmlFile xumlFile, XElement rootXmlElement)
        {
            _currentXmlFile = xumlFile;
            var styleName = rootXmlElement.Name.LocalName;
            var styleObject = _contentObjectModel.LoadStyleObject(styleName);

            // clear style object
            styleObject.Clear();
            styleObject.Name = styleName;
            styleObject.FilePath = xumlFile.Path;
            styleObject.NeedUpdate = true;

            // parse view's initialization attributes
            foreach (var attribute in rootXmlElement.Attributes())
            {
                string attributeName = attribute.Name.LocalName;
                string attributeValue = attribute.Value;

                // ignore namespace specification
                if (attributeName.IEquals("xmlns"))
                    continue;

                Debug.LogWarning(String.Format("[Delight] {0}: Invalid attribute <{1} {2}=\"{3}\">. Attributes can't be specified on style root element.", GetLineInfo(rootXmlElement), styleName, attributeName, attributeValue));
            }

            // parse style declarations
            List<StyleDeclaration> viewDeclarations = ParseStyleDeclarations(xumlFile.Path, rootXmlElement.Elements());
            styleObject.StyleDeclarations.AddRange(viewDeclarations);
        }

        /// <summary>
        /// Parses view declarations.
        /// </summary>
        private static List<StyleDeclaration> ParseStyleDeclarations(string path, IEnumerable<XElement> styleElements)
        {
            var styleDeclarations = new List<StyleDeclaration>();
            foreach (var styleElement in styleElements)
            {
                var styleDeclaration = new StyleDeclaration();
                styleDeclaration.ViewName = styleElement.Name.LocalName;
                styleDeclaration.LineNumber = styleElement.GetLineNumber();
                styleDeclarations.Add(styleDeclaration);

                // parse style property expressions
                foreach (var attribute in styleElement.Attributes())
                {
                    string attributeName = attribute.Name.LocalName;
                    string attributeValue = attribute.Value;

                    if (attributeName.IEquals("Style"))
                    {
                        styleDeclaration.StyleName = attributeValue;
                        continue;
                    }

                    if (attributeName.IEquals("BasedOn"))
                    {
                        styleDeclaration.BasedOn = styleDeclarations.FirstOrDefault(x => x.ViewName.IEquals(styleDeclaration.ViewName) && x.StyleName.IEquals(attributeValue));
                        if (styleDeclaration.BasedOn == null)
                        {
                            Debug.LogError(String.Format("[Delight] {0}: Invalid style <{1} {2}=\"{3}\">. Couldn't find the style \"{3}\" this style is based on - make sure it's declared in the same file before this style.", GetLineInfo(styleElement), styleDeclaration.ViewName, attributeName, attributeValue));
                        }
                        continue;
                    }

                    // parse property expressions
                    var propertyExpressions = ParsePropertyExpression(styleElement, attributeName, attributeValue);
                    foreach (var propertyExpression in propertyExpressions)
                    {
                        var propertyDeclaration = propertyExpression as PropertyDeclaration;
                        if (propertyDeclaration != null)
                        {
                            Debug.LogError(String.Format("[Delight] {0}: Invalid style <{1} {2}=\"{3}\">. Property declarations can't be specified in the style.", GetLineInfo(styleElement), styleDeclaration.ViewName, attributeName, attributeValue));
                            continue;
                        }

                        var mappedViewDeclaration = propertyExpression as PropertyMapping;
                        if (mappedViewDeclaration != null)
                        {
                            Debug.LogError(String.Format("[Delight] {0}: Invalid style <{1} {2}=\"{3}\">. Property mappings can't be specified in the style.", GetLineInfo(styleElement), styleDeclaration.ViewName, attributeName, attributeValue));
                            continue;
                        }

                        var propertyAssignment = propertyExpression as PropertyAssignment;
                        if (propertyAssignment != null)
                        {
                            styleDeclaration.PropertyAssignments.Add(propertyAssignment);
                            continue;
                        }

                        var propertyBinding = propertyExpression as PropertyBinding;
                        if (propertyBinding != null)
                        {
                            Debug.LogError(String.Format("[Delight] {0}: Invalid style <{1} {2}=\"{3}\">. Property bindings can't be specified in the style.", GetLineInfo(styleElement), styleDeclaration.ViewName, attributeName, attributeValue));
                            continue;
                        }
                    }
                }
            }

            return styleDeclarations;
        }

        /// <summary>
        /// Gets property declarations from view declarations.
        /// </summary>
        public static IEnumerable<PropertyExpression> GetPropertyDeclarations(List<ViewDeclaration> viewDeclarations)
        {
            var propertyExpressions = new List<PropertyExpression>();
            foreach (var viewDeclaration in viewDeclarations)
            {
                propertyExpressions.AddRange(GetPropertyDeclarations(viewDeclaration));
                propertyExpressions.AddRange(GetPropertyDeclarations(viewDeclaration.ChildDeclarations));
            }

            return propertyExpressions;
        }

        /// <summary>
        /// Gets property declarations from a view declaration.
        /// </summary>
        public static IEnumerable<PropertyExpression> GetPropertyDeclarations(ViewDeclaration viewDeclaration)
        {
            if (String.IsNullOrEmpty(viewDeclaration.Id))
                return Enumerable.Empty<PropertyExpression>();

            // TODO get the type of the view and create a proper full property name, note that the view might not exist yet though since its code hasn't been generated

            PropertyExpression[] propertyExpressions = new PropertyExpression[2];
            propertyExpressions[0] = new PropertyDeclaration { PropertyName = viewDeclaration.Id, PropertyTypeFullName = viewDeclaration.ViewName, PropertyTypeName = viewDeclaration.ViewName, DeclarationType = PropertyDeclarationType.View };
            propertyExpressions[1] = new PropertyDeclaration { PropertyName = String.Format("{0}Template", viewDeclaration.Id), PropertyTypeName = "Template", PropertyTypeFullName = "Template", DeclarationType = PropertyDeclarationType.Template };
            return propertyExpressions;
        }

        /// <summary>
        /// Parses view declarations.
        /// </summary>
        private static List<ViewDeclaration> ParseViewDeclarations(ViewObject viewObject, string path, IEnumerable<XElement> viewElements, Dictionary<string, int> viewIdCount)
        {
            var viewDeclarations = new List<ViewDeclaration>();
            foreach (var viewElement in viewElements)
            {
                var viewDeclaration = new ViewDeclaration();
                viewDeclaration.ViewName = viewElement.Name.LocalName;
                viewDeclaration.LineNumber = viewElement.GetLineNumber();

                // parse view's initialization attributes
                foreach (var attribute in viewElement.Attributes())
                {
                    string attributeName = attribute.Name.LocalName;
                    string attributeValue = attribute.Value;

                    if (attributeName.IEquals("Id"))
                    {
                        viewDeclaration.Id = attributeValue;
                        continue;
                    }

                    if (attributeName.IEquals("Style"))
                    {
                        viewDeclaration.Style = attributeValue;
                        continue;
                    }

                    if (attributeName.IEquals("IsContentContainer"))
                    {
                        viewObject.ContentContainer = viewDeclaration;
                        continue;
                    }

                    // parse property expression
                    var propertyExpressions = ParsePropertyExpression(viewElement, attributeName, attributeValue);
                    foreach (var propertyExpression in propertyExpressions)
                    {
                        var propertyDeclaration = propertyExpression as PropertyDeclaration;
                        if (propertyDeclaration != null)
                        {
                            Debug.LogError(String.Format("[Delight] {0}: Invalid property declaration <{1} {2}=\"{3}\">. Property declarations (like PropertyName=\"t:string\") can only be specified on the root view element.", GetLineInfo(viewElement), viewDeclaration.ViewName, attributeName, attributeValue));
                            continue;
                        }

                        var mappedViewDeclaration = propertyExpression as PropertyMapping;
                        if (mappedViewDeclaration != null)
                        {
                            Debug.LogError(String.Format("[Delight] {0}: Invalid mapped view declaration <{1} {2}=\"{3}\">. Property declarations (like PropertyName=\"t:string\") can only be specified on the root view element.", GetLineInfo(viewElement), viewDeclaration.ViewName, attributeName, attributeValue));
                            continue;
                        }

                        var propertyAssignment = propertyExpression as PropertyAssignment;
                        if (propertyAssignment != null)
                        {
                            viewDeclaration.PropertyAssignments.Add(propertyAssignment);
                            continue;
                        }

                        var propertyBinding = propertyExpression as PropertyBinding;
                        if (propertyBinding != null)
                        {
                            viewDeclaration.PropertyBindings.Add(propertyBinding);
                            continue;
                        }
                    }
                }

                if (String.IsNullOrEmpty(viewDeclaration.Id))
                {
                    if (!viewIdCount.ContainsKey(viewDeclaration.ViewName))
                    {
                        viewIdCount.Add(viewDeclaration.ViewName, 0);
                    }

                    ++viewIdCount[viewDeclaration.ViewName];
                    viewDeclaration.Id = viewDeclaration.ViewName + viewIdCount[viewDeclaration.ViewName];
                }

                // parse child elements
                viewDeclaration.ChildDeclarations = ParseViewDeclarations(viewObject, path, viewElement.Elements(), viewIdCount);
                viewDeclarations.Add(viewDeclaration);
            }

            return viewDeclarations;
        }

        /// <summary>
        /// Parses property expression.
        /// </summary>
        private static List<PropertyExpression> ParsePropertyExpression(XElement element, string attributeName, string attributeValue)
        {
            var propertyExpressions = new List<PropertyExpression>();
            int dotCount = attributeName.Count(x => x == '.');

            // see if property name has state name specified
            string propertyName = attributeName;
            string stateName = string.Empty;
            bool hasStateName = false;
            if (attributeName.Contains("-"))
            {
                var names = attributeName.Split('-');
                if (names.Length != 2)
                {
                    Debug.LogError(String.Format("[Delight] {0}: Invalid property expression {1}=\"{2}\". Only a single dash \"-\" may be used to denote state property assignment.", GetLineInfo(element), attributeName, attributeValue));
                    return propertyExpressions;
                }

                hasStateName = true;

                int stateNameStartIndex = names[0].LastIndexOf('.');
                if (stateNameStartIndex < 0) stateNameStartIndex = 0;
                stateName = names[0].Substring(stateNameStartIndex);
                propertyName = attributeName.Replace(stateName + "-", "");
            }

            if (attributeValue.IEquals("t:Action"))
            {
                // validate
                if (dotCount > 0 || hasStateName)
                {
                    Debug.LogError(String.Format("[Delight] {0}: Invalid property declaration {1}=\"{2}\". Make sure declaration contains a single property name.", GetLineInfo(element), attributeName, attributeValue));
                    return propertyExpressions;
                }

                // action property declaration
                var propertyDeclaration = new PropertyDeclaration();
                propertyExpressions.Add(propertyDeclaration);

                propertyDeclaration.PropertyName = attributeName;
                propertyDeclaration.PropertyTypeName = "ViewAction"; // TODO these can be removed if generator handles action declaration as special case
                propertyDeclaration.PropertyTypeFullName = "ViewAction"; // TODO these can be removed if generator handles action declaration as special case
                propertyDeclaration.DeclarationType = PropertyDeclarationType.Action;
                propertyDeclaration.LineNumber = element.GetLineNumber();

                return propertyExpressions;
            }

            if (attributeValue.IStartsWith("t:"))
            {
                // validate
                if (dotCount > 0 || hasStateName)
                {
                    Debug.LogError(String.Format("[Delight] {0}: Invalid property declaration {1}=\"{2}\". Make sure declaration contains a single property name.", GetLineInfo(element), attributeName, attributeValue));
                    return propertyExpressions;
                }

                // regular property declaration
                var propertyDeclaration = new PropertyDeclaration();
                propertyExpressions.Add(propertyDeclaration);
                propertyDeclaration.LineNumber = element.GetLineNumber();
                //propertyDeclaration.

                int commaIndex = attributeValue.IndexOf(",");
                int assignmentIndex = attributeValue.IndexOf("=");

                // parse property value if any
                if (assignmentIndex > 0 && commaIndex <= 0)
                {
                    var propertyAssignment = new PropertyAssignment();
                    propertyExpressions.Add(propertyAssignment);

                    propertyAssignment.PropertyName = attributeName;
                    propertyAssignment.PropertyValue = attributeValue.Substring(assignmentIndex + 1).Trim();
                    propertyAssignment.LineNumber = element.GetLineNumber();
                    attributeValue = attributeValue.Substring(0, assignmentIndex).Trim();
                }

                Type propertyType = null;
                string propertyTypeName = attributeValue.Substring(2);
                string propertyNamespace = null;

                // check if it's a generic type 
                int startBracketIndex = propertyTypeName.IndexOf("[");
                if (startBracketIndex > 0)
                {
                    // validate generic type
                    var genericTypeName = propertyTypeName.Substring(0, startBracketIndex);
                    GetPropertyTypeNameAndNamespace(genericTypeName, out genericTypeName, out propertyNamespace);

                    // TODO validate generic type parameters, loop through each generic parameter and get their type and full name 

                    propertyType = TypeHelper.GetType(genericTypeName, propertyNamespace);
                    propertyDeclaration.PropertyName = attributeName;
                    propertyDeclaration.PropertyTypeName = propertyType.Name;
                    propertyDeclaration.PropertyTypeFullName = String.Format("{0}{1}", propertyType.FullName, propertyTypeName.Substring(startBracketIndex).Replace('[', '<').Replace(']', '>').Trim());

                    return propertyExpressions;
                }

                if (commaIndex > 0)
                {
                    // assembly qualified type is specified
                    propertyType = Type.GetType(propertyTypeName);
                }
                else
                {
                    // get type from specified name (and namespace)
                    GetPropertyTypeNameAndNamespace(propertyTypeName, out propertyTypeName, out propertyNamespace);
                    propertyType = TypeHelper.GetType(propertyTypeName, propertyNamespace);
                }

                if (propertyType == null)
                {
                    Debug.LogError(String.Format("[Delight] {0}: Property type not found {1}=\"{2}\".", GetLineInfo(element), attributeName, attributeValue));
                    return new List<PropertyExpression>();
                }

                bool isUnityComponent = typeof(UnityEngine.Component).IsAssignableFrom(propertyType);
                if (isUnityComponent)
                {
                    propertyDeclaration.DeclarationType = PropertyDeclarationType.UnityComponent;
                }

                if (IsUnityAssetType(propertyType))
                {
                    propertyDeclaration.DeclarationType = PropertyDeclarationType.Asset;
                    propertyDeclaration.AssetType = _contentObjectModel.LoadAssetType(propertyType, false);                    
                }

                propertyDeclaration.AssemblyQualifiedType = propertyType.AssemblyQualifiedName;
                propertyDeclaration.PropertyName = attributeName;
                propertyDeclaration.PropertyTypeName = propertyType.Name;
                propertyDeclaration.PropertyTypeFullName = propertyType.FullName;

                return propertyExpressions;
            }

            if (attributeName.IStartsWith("m."))
            {
                // mapped view
                var mappedViewDeclaration = new PropertyMapping();
                propertyExpressions.Add(mappedViewDeclaration);

                mappedViewDeclaration.TargetObjectName = attributeName.Substring(2);
                mappedViewDeclaration.MapPattern = attributeValue;
                mappedViewDeclaration.LineNumber = element.GetLineNumber();
                return propertyExpressions;
            }

            if (attributeName.IStartsWith("rename."))
            {
                // renamed property
                var propertyRename = new PropertyRename();
                propertyExpressions.Add(propertyRename);

                propertyRename.TargetPropertyName = attributeName.Substring(7);
                propertyRename.NewPropertyName = attributeValue;
                propertyRename.LineNumber = element.GetLineNumber();
                return propertyExpressions;
            }

            if (attributeName.IStartsWith("i."))
            {
                // initializer property
                var initializerProperty = new InitializerProperty();
                propertyExpressions.Add(initializerProperty);

                initializerProperty.PropertyName = attributeName.Substring(2);
                var properties = attributeValue.Split(',').Select(x => x.Trim()).Where(y => !String.IsNullOrEmpty(y));
                initializerProperty.Properties = properties.ToList();
                initializerProperty.LineNumber = element.GetLineNumber();
                return propertyExpressions;
            }

            // is the value a binding?
            if (ValueIsBinding(attributeValue))
            {
                // validate
                if (hasStateName)
                {
                    Debug.LogError(String.Format("[Delight] {0}: Invalid property binding {1}=\"{2}\". Binding to state properties are not allowed.", GetLineInfo(element), attributeName, attributeValue));
                    return propertyExpressions;
                }

                // parse binding string
                propertyExpressions.Add(ParseBinding(element, attributeName, attributeValue));
                return propertyExpressions;
            }

            propertyExpressions.Add(new PropertyAssignment { PropertyName = propertyName, StateName = stateName, PropertyValue = attributeValue, LineNumber = element.GetLineNumber() });
            return propertyExpressions;
        }

        /// <summary>
        /// Checks if a type is a unity asset object type.
        /// </summary>
        public static bool IsUnityAssetType(Type type)
        {
            Type unityObjectType = typeof(UnityEngine.Object);
            return unityObjectType.IsAssignableFrom(type) &&
                !typeof(UnityEngine.GameObject).IsAssignableFrom(type) &&
                !typeof(UnityEngine.Component).IsAssignableFrom(type);
        }

        /// <summary>
        /// Extracts property type name and namespace from string. 
        /// </summary>
        private static void GetPropertyTypeNameAndNamespace(string fullTypeName, out string propertyTypeName, out string propertyNamespace)
        {
            propertyNamespace = null;

            // get type from specified name (and namespace)                    
            int namespaceIndex = fullTypeName.LastIndexOf(".");
            if (namespaceIndex > 0)
            {
                propertyNamespace = fullTypeName.Substring(0, namespaceIndex);
                propertyTypeName = fullTypeName.Substring(namespaceIndex + 1);
            }
            else
            {
                propertyTypeName = fullTypeName;
            }
        }

        /// <summary>
        /// Parses binding. 
        /// </summary>
        private static PropertyBinding ParseBinding(XElement element, string propertyName, string propertyBindingString)
        {
            string trimmedBinding = propertyBindingString.Trim();
            var propertyBinding = new PropertyBinding();
            propertyBinding.PropertyName = propertyName;
            propertyBinding.PropertyBindingString = propertyBindingString;
            propertyBinding.LineNumber = element.GetLineNumber();

            if (trimmedBinding.StartsWith("$"))
            {
                // transformed multi-binding
                string[] bindings = trimmedBinding.Split(BindingDelimiterChars, StringSplitOptions.RemoveEmptyEntries);
                if (bindings.Length < 1)
                {
                    Debug.LogError(String.Format("[Delight] {0}: Improperly formatted property binding {1}=\"{2}\".", GetLineInfo(element), propertyName, propertyBindingString));
                    return null;
                }

                propertyBinding.BindingType = BindingType.MultiBindingTransform;
                propertyBinding.TransformMethod = bindings[0];

                foreach (var bindingSourceString in bindings.Skip(1))
                {
                    var bindingSource = ParseBindingSource(bindingSourceString);
                    propertyBinding.Sources.Add(bindingSource);
                }

                return propertyBinding;
            }

            // check for bindings in string
            string formatString = String.Empty;
            List<Match> matches = new List<Match>();
            foreach (Match match in _bindingRegex.Matches(propertyBindingString))
            {
                matches.Add(match);
            }

            if (matches.Count <= 0)
            {
                // no bindings found
                Debug.LogError(String.Format("[Delight] {0}: Improperly formatted property binding {1}=\"{2}\". String contains no binding.", GetLineInfo(element), propertyName, propertyBindingString));
                return null;
            }

            // is the binding a format string?
            if (matches.Count > 1 || (matches[0].Value.Length != propertyBindingString.Length) || !String.IsNullOrEmpty(matches[0].Groups["format"].Value))
            {
                // yes. 
                int matchCount = 0;
                formatString = _bindingRegex.Replace(propertyBindingString, x =>
                {
                    string matchCountString = matchCount.ToString();
                    ++matchCount;
                    return String.Format("{{{0}{1}}}", matchCountString, x.Groups["format"]);
                });

                propertyBinding.BindingType = BindingType.MultiBindingFormatString;
                propertyBinding.FormatString = formatString;
            }

            // parse view fields for binding source(s)
            foreach (var match in matches)
            {
                var bindingSourceString = match.Groups["field"].Value.Trim();
                var bindingSource = ParseBindingSource(bindingSourceString);
                propertyBinding.ItemId = match.Groups["item"].Value.Trim();
                propertyBinding.Sources.Add(bindingSource);
            }

            return propertyBinding;
        }

        /// <summary>
        /// Parses a binding source.
        /// </summary>
        private static PropertyBindingSource ParseBindingSource(string bindingSourceString)
        {
            var bindingSource = new PropertyBindingSource();

            var viewField = bindingSourceString;
            while (viewField.Length > 0)
            {
                if (viewField.StartsWith("!"))
                {
                    bindingSource.SourceTypes |= BindingSourceTypes.Negated;
                    viewField = viewField.Substring(1);
                }
                else if (viewField.StartsWith("="))
                {
                    bindingSource.SourceTypes |= BindingSourceTypes.TwoWay;
                    viewField = viewField.Substring(1);
                }
                else if (viewField.StartsWith("@"))
                {
                    bindingSource.SourceTypes |= BindingSourceTypes.Model;
                    viewField = String.Format("{0}.{1}", ModelsClassName, viewField.Substring(1));
                }
                else
                {
                    break;
                }
            }

            bindingSource.BindingPath = viewField;
            return bindingSource;
        }

        /// <summary>
        /// Checks if a value is a binding.
        /// </summary>
        private static bool ValueIsBinding(string value)
        {
            int startBracketIndex = value.IndexOf('{');
            if (startBracketIndex >= 0)
            {
                return value.IndexOf('}') > startBracketIndex;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets formatted line information from element.
        /// </summary>
        private static string GetLineInfo(IXmlLineInfo element)
        {
            return String.Format("{0}.xml ({1})", _currentXmlFile.Name, element.LineNumber);
        }

        /// <summary>
        /// Gets all XML assets at a path.
        /// </summary>
        private static List<XmlFile> GetXmlFilesAtPath(string path, HashSet<string> ignoreFiles = null)
        {
            var assets = new List<XmlFile>();
            if (Directory.Exists(path))
            {
                string[] filePaths = Directory.GetFiles(path, "*.xml", SearchOption.AllDirectories);
                foreach (string unformattedFilePath in filePaths)
                {
                    var filePath = MasterConfig.GetFormattedPath(unformattedFilePath);
                    if (ignoreFiles != null && ignoreFiles.Contains(filePath))
                        continue;

                    assets.Add(GetXmlFileAtPath(filePath));
                }
            }

            return assets;
        }

        /// <summary>
        /// Gets XML asset at path.
        /// </summary>
        private static XmlFile GetXmlFileAtPath(string path)
        {
            var filename = Path.GetFileNameWithoutExtension(path);
            var xumlContentType = GetXmlContentType(path);
            return new XmlFile
            {
                Name = filename,
                Path = path,
                Content = File.ReadAllText(path),
                ContentType = xumlContentType
            };
        }

        /// <summary>
        /// Gets XML content type based on path.
        /// </summary>
        private static XmlContentType GetXmlContentType(string path)
        {
            if (path.IContains(ViewsFolder))
            {
                return XmlContentType.View;
            }
            else if (path.IContains(StylesFolder))
            {
                return XmlContentType.Style;
            }
            else if (path.IContains(ScenesFolder))
            {
                return XmlContentType.Scene;
            }
            else
            {
                return XmlContentType.Unknown;
            }
        }

        /// <summary>
        /// XML file.
        /// </summary>
        private struct XmlFile
        {
            public string Name;
            public string Path;
            public string Content;
            public XmlContentType ContentType;
        }

        /// <summary>
        /// XML content type.
        /// </summary>
        private enum XmlContentType
        {
            Style = 0,
            View = 1,
            Scene = 2,
            Unknown
        }

        #endregion

        #region Assets

        /// <summary>
        /// Parses asset objects. 
        /// </summary>
        public static void ParseAssetFiles(List<string> addedOrUpdatedAssetObjects, List<string> deletedAssetObjects, List<string> movedAssetObjects, List<string> movedFromAssetObjects)
        {
            bool assetsNeedBuild = false;

            // add asset objects and bundles
            foreach (var newAssetPath in addedOrUpdatedAssetObjects.Concat(movedAssetObjects))
            {
                // get asset bundle from file path
                var bundle = GetAssetBundleFromFilePath(newAssetPath);
                if (bundle == null)
                    continue;

                bundle.NeedBuild = !bundle.IsResource;
                assetsNeedBuild |= bundle.NeedBuild;

                // add asset object to bundle
                var asset = AddAssetToBundle(bundle, newAssetPath);
                if (asset == null)
                    continue;

                Debug.Log(String.Format("Adding asset \"{0}\" of type \"{1}\" to bundle \"{2}\".", asset.Name, asset.Type.Name, bundle.Name)); // TODO remove
            }

            // delete asset objects
            foreach (var deletedAssetPath in deletedAssetObjects.Concat(movedFromAssetObjects))
            {
                // get asset bundle from file path
                var bundle = GetAssetBundleFromFilePath(deletedAssetPath);
                if (bundle == null)
                    continue;

                bundle.NeedBuild = !bundle.IsResource;
                assetsNeedBuild |= bundle.NeedBuild;

                // remove asset object from bundle
                bundle.RemoveAssetAtPath(deletedAssetPath);

                var assetName = Path.GetFileNameWithoutExtension(deletedAssetPath); // TODO remove
                Debug.Log(String.Format("Removing asset \"{0}\" from bundle \"{1}\".", assetName, bundle.Name)); // TODO remove
            }

            // generate code
            CodeGenerator.GenerateAssetCode();

            _contentObjectModel.AssetsNeedUpdate = false;
            _contentObjectModel.SaveObjectModel();

            var config = MasterConfig.GetInstance();
            if (assetsNeedBuild && !config.AssetsNeedBuild)
            {
                config.AssetsNeedBuild = true;
                config.SaveConfig();
            }
        }

        /// <summary>
        /// Rebuilds assets bundles. 
        /// </summary>
        public static void RebuildAssetBundles()
        {
            var config = MasterConfig.GetInstance();

            // clear parsed assets from model
            _contentObjectModel.AssetBundleObjects.Clear();
            _contentObjectModel.ClearAssetTypes(true);

            // get all assets
            var ignoreFiles = new HashSet<string>();
            var assetFiles = new List<string>();
            foreach (var localPath in config.ContentFolders)
            {
                string path = String.Format("{0}/{1}{2}", Application.dataPath,
                    localPath.StartsWith("Assets/") ? localPath.Substring(7) : localPath,
                    AssetsFolder.Substring(1));

                foreach (var assetFile in GetAssetFilesAtPath(path, ignoreFiles))
                {
                    assetFiles.Add(assetFile);
                    ignoreFiles.Add(assetFile);
                }
            }

            // create asset bundles and asset objects for the assets found
            foreach (var assetFile in assetFiles)
            {
                var relativeAssetFilePath = "Assets" + assetFile.Substring(Application.dataPath.Length);

                // get asset bundle from file path
                var bundle = GetAssetBundleFromFilePath(relativeAssetFilePath);
                if (bundle == null)
                    continue;

                AddAssetToBundle(bundle, relativeAssetFilePath);
                bundle.NeedBuild = true;
            }

            _contentObjectModel.SaveObjectModel();

            // ask to clear output folders
            var outputPath = GetRemoteBundlePath();
            string message = String.Format("Do you want to delete all files in the directory {0} and {1}?", outputPath, StreamingPath);
            if (EditorUtility.DisplayDialog("Clearing previous asset builds confirmation", message, "Yes", "No"))
            {
                try
                {
                    if (Directory.Exists(outputPath))
                    {
                        Directory.Delete(outputPath, true);
                    }
                    if (Directory.Exists(StreamingPath))
                    {
                        Directory.Delete(StreamingPath, true);
                    }
                }
                catch (System.Exception e)
                {
                    Debug.LogException(e);
                }
            }

            // build asset bundles
            BuildAssetBundles(_contentObjectModel.AssetBundleObjects);

            // generate asset code
            CodeGenerator.GenerateAssetCode();

            _contentObjectModel.AssetsNeedUpdate = false;
            _contentObjectModel.SaveObjectModel();

            Debug.Log("[Delight] Asset bundles rebuild completed.");
        }

        /// <summary>
        /// Adds asset to bundle. 
        /// </summary>
        private static UnityAssetObject AddAssetToBundle(AssetBundleObject bundle, string assetFile)
        {
            // add asset object to bundle
            var unityAssetObject = AssetDatabase.LoadMainAssetAtPath(assetFile);
            if (unityAssetObject == null)
            {
                Debug.LogError(String.Format("[Delight] Unable to load asset at \"{0}\". Asset ignored.", assetFile));
                return null;
            }

            // set bundle name on asset
            AssetImporter assetImporter = AssetImporter.GetAtPath(assetFile);
            assetImporter.assetBundleName = !bundle.IsResource ? bundle.Name.ToLower() : String.Empty;

            // see what type of asset it is
            Type assetObjectType = unityAssetObject.GetType();

            // handle special case when Texture2D is a sprite
            if (unityAssetObject is Texture2D)
            {
                var sprite = AssetDatabase.LoadAssetAtPath<Sprite>(assetFile);
                if (sprite != null)
                {
                    assetObjectType = typeof(Sprite);
                }
            }

            var assetName = Path.GetFileNameWithoutExtension(assetFile);
            var asset = bundle.LoadUnityAssetObject(assetName, assetFile, assetObjectType);
            return asset;
        }

        /// <summary>
        /// Builds asset bundle.
        /// </summary>
        public static void BuildAssetBundle(AssetBundleObject bundle)
        {
            BuildAssetBundles(new List<AssetBundleObject> { bundle });
        }

        /// <summary>
        /// Builds asset bundle. 
        /// </summary>
        public static void BuildAssetBundles(List<AssetBundleObject> bundles)
        {
            if (bundles.Count <= 0)
                return;

            var streamedBundles = new List<AssetBundleBuild>();
            var remoteBundles = new List<AssetBundleBuild>();
            foreach (var bundle in bundles)
            {
                bundle.NeedBuild = false;
                if (bundle.IsResource)
                    continue;

                Debug.Log(String.Format("[Delight] Building asset bundle \"{0}\".", bundle.Name));

                // TODO remove
                if (bundle.Name.IEquals("Bundle2"))
                {
                    bundle.StorageMode = StorageMode.Remote;
                }

                var build = new AssetBundleBuild();
                build.assetBundleName = bundle.Name.ToLower();
                build.assetBundleVariant = String.Empty;
                build.assetNames = AssetDatabase.GetAssetPathsFromAssetBundle(build.assetBundleName);
                if (bundle.StorageMode == StorageMode.Local)
                {
                    streamedBundles.Add(build);
                }
                else
                {
                    remoteBundles.Add(build);
                }
            }

            _contentObjectModel.SaveObjectModel();

            var config = MasterConfig.GetInstance();            
            if (!_contentObjectModel.AssetBundleObjects.Any(x => x.NeedBuild))
            {
                config.AssetsNeedBuild = false;
                config.SaveConfig();
            }

            // build streamed bundles
            if (streamedBundles.Count() > 0)
            {
                if (!Directory.Exists(StreamingPath))
                    Directory.CreateDirectory(StreamingPath);

                // build bundles with LZ4 compression
                BuildPipeline.BuildAssetBundles(StreamingPath, streamedBundles.ToArray(), BuildAssetBundleOptions.ChunkBasedCompression, EditorUserBuildSettings.activeBuildTarget);
            }

            if (remoteBundles.Count() > 0)
            {
                // get output path
                var outputPath = GetRemoteBundlePath();
                if (!Directory.Exists(outputPath))
                    Directory.CreateDirectory(outputPath);

                BuildPipeline.BuildAssetBundles(outputPath, remoteBundles.ToArray(), BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
            }
        }

        /// <summary>
        /// Gets remote asset bundle path.
        /// </summary>
        public static string GetRemoteBundlePath()
        {
            return String.Format("{0}{1}{2}", RemoteAssetBundlesBasePath, AssetBundleData.GetPlatformName() + "/", AssetBundle.DelightAssetsFolder);
        }


        /// <summary>
        /// Gets all assets at a path.
        /// </summary>
        private static List<string> GetAssetFilesAtPath(string path, HashSet<string> ignoreFiles = null)
        {
            var assets = new List<string>();
            if (Directory.Exists(path))
            {
                string[] filePaths = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
                foreach (string unformattedFilePath in filePaths)
                {
                    if (unformattedFilePath.EndsWith(".cs") || unformattedFilePath.EndsWith(".meta"))
                        continue;

                    var filePath = MasterConfig.GetFormattedPath(unformattedFilePath);
                    if (ignoreFiles != null && ignoreFiles.Contains(filePath))
                        continue;

                    assets.Add(filePath);
                }
            }

            return assets;
        }

        /// <summary>
        /// Gets Asset bundle from file path.
        /// </summary>
        private static AssetBundleObject GetAssetBundleFromFilePath(string newAssetPath)
        {
            // get asset bundle object
            int assetFolderIndex = newAssetPath.ILastIndexOf(AssetsFolder);
            var pathInContentFolder = newAssetPath.Substring(assetFolderIndex + AssetsFolder.Length);

            var paths = pathInContentFolder.Split('/');
            if (paths.Length <= 1)
                return null;

            var bundleName = paths[0];
            return _contentObjectModel.LoadAssetBundleObject(bundleName, newAssetPath.Substring(0, assetFolderIndex + AssetsFolder.Length));
        }

        #endregion
    }
}

