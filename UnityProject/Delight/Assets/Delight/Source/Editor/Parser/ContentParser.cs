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
using System.Globalization;
using System.CodeDom.Compiler;
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
        private static readonly char[] ModuleDelimiterChars = { ' ', ';' };

        private static ContentObjectModel _contentObjectModel = ContentObjectModel.GetInstance();

        private static XmlFile _currentXmlFile;
        private static Regex _bindingRegex = new Regex(@"{[ ]*((?<item>[A-Za-z0-9_#!=@\.\[\]]+)[ ]+in[ ]+)?(?<field>[A-Za-z0-9_#!=@\.\[\]]+)(?<format>:[^}\|]+)?([ ]*\|[ ]*(?<converter>[^}]+))?[ ]*}");
        private static Regex _dataInsertRegex = new Regex(@"[^\s,""']+|""(?<str>[^""]*)"":?|'(?<str>[^']*)':?");

        #endregion

        #region Views, Scenes and Styles

        /// <summary>
        /// Processes all content and generates code.
        /// </summary>
        public static void RebuildAll(bool buildAssets, bool buildBundlesLater = false, bool parseConfigFiles = true)
        {
            // wait for any uncompiled scripts to be compiled first
            AssetDatabase.Refresh(ImportAssetOptions.ForceSynchronousImport);

            // parse all config files
            if (parseConfigFiles)
            {
                ParseAllConfigFiles();
            }

            // parse all assets
            if (buildAssets)
            {
                RebuildAssets(buildBundlesLater);
            }

            // parse all schema files
            ParseAllSchemaFiles();

            // parse all views 
            ParseAllXmlFiles();

            // refresh generated scripts
            AssetDatabase.Refresh();

            // generate XSD schemas
            CodeGenerator.GenerateXsdSchema();
        }

        /// <summary>
        /// Updates project settings based on config values.
        /// </summary>
        private static void UpdateProjectSettings()
        {
            string symbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(
                BuildTargetGroup.Standalone);
            var config = MasterConfig.GetInstance();
            var newModules = config.Modules.Select(x => String.Format("DELIGHT_MODULE_{0}", x.ToUpper()));

            // see all modules currently defined 
            var currentModules = symbols.Split(ModuleDelimiterChars, StringSplitOptions.RemoveEmptyEntries).ToList();
            bool symbolsNeedUpdate = false;

            // see if any aren't in the list and remove them
            foreach (var currentModule in currentModules)
            {
                if (!config.Modules.Any(x => x.Equals(currentModule)))
                {
                    symbols = symbols.Replace(currentModule, "");
                    symbolsNeedUpdate = true;
                }
            }

            // see if there are new modules and add them
            foreach (var newModule in newModules)
            {
                if (!symbols.Contains(newModule))
                {
                    symbols += ";" + newModule;
                    symbolsNeedUpdate = true;
                }
            }

            if (symbolsNeedUpdate)
            {
                PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, symbols);
            }
        }

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

            // generate XSD schemas
            CodeGenerator.GenerateXsdSchema();
        }

        /// <summary>
        /// Processes XML assets and generates code.
        /// </summary>
        public static void ParseAllXmlFiles()
        {
            var config = MasterConfig.GetInstance();

            // clear XML content objects from model
            _contentObjectModel.ClearXmlParsedContent();
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
            CodeGenerator.GenerateScenes();

            if (_contentObjectModel.AssetsNeedUpdate)
            {
                _contentObjectModel.AssetsNeedUpdate = false;
                CodeGenerator.GenerateAssetCode();
            }

            _contentObjectModel.SaveObjectModel();

            // update config
            try
            {
                var config = MasterConfig.GetInstance();
                config.Views = _contentObjectModel.ViewObjects.Select(x => x.TypeName).OrderBy(x => x).ToList();
                config.SaveConfig();
            }
            finally
            {
                ConsoleLogger.Log(String.Format("[Delight] Content processed. {0}", DateTime.Now));
            }
        }

        /// <summary>
        /// Parses XML.
        /// </summary>
        private static void ParseXmlFile(XmlFile xumlFile)
        {
            //Debug.Log("Parsing " + xumlFile.Path);
            if (xumlFile.ContentType == XmlContentType.Unknown)
            {
                ConsoleLogger.LogWarning(String.Format("[Delight] Ignoring XML file \"{0}\" as it's not in a XML content type subdirectory (\"{1}\", \"{2}\" or \"{3}\").", xumlFile.Path, ViewsFolder, ScenesFolder, StylesFolder));
                return;
            }

            XElement rootXmlElement = null;
            try
            {
                rootXmlElement = XElement.Parse(xumlFile.Content, LoadOptions.SetLineInfo);
            }
            catch (Exception e)
            {
                ConsoleLogger.LogError(String.Format("[Delight] Error parsing XML file \"{0}\". Exception thrown: {1}", xumlFile.Content, e.Message + e.StackTrace));
                return;
            }

            // files are parsed in order style -> scene -> view
            if (xumlFile.ContentType == XmlContentType.View)
            {
                ParseViewXml(xumlFile, rootXmlElement);
            }
            else if (xumlFile.ContentType == XmlContentType.Scene)
            {
                ParseSceneXml(xumlFile, rootXmlElement);
            }
            else if (xumlFile.ContentType == XmlContentType.Style)
            {               
                ParseStyleXml(xumlFile, rootXmlElement);
            }
            else
            {
                ConsoleLogger.LogWarning(String.Format("[Delight] Ignoring XML file \"{0}\". Parsing of content type \"{1}\" not implemented.", xumlFile.Path, xumlFile.ContentType));
            }
        }

        /// <summary>
        /// Parses view XML.
        /// </summary>
        private static void ParseViewXml(XmlFile xumlFile, XElement rootXmlElement)
        {
            _currentXmlFile = xumlFile;
            var config = MasterConfig.GetInstance();
            var viewName = rootXmlElement.Name.LocalName;
            var module = rootXmlElement.Attribute("Module")?.Value;

            // if the view is in a module ignore it if the module isn't active
            if (!String.IsNullOrEmpty(module))
            {
                if (module.StartsWith("!"))
                {
                    if (config.Modules.Any(x => x == module.Substring(1)))
                    {
                        return;
                    }
                }
                else
                {
                    if (!config.Modules.Any(x => x == module))
                    {
                        return;
                    }
                }
            }

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

                // ignore XML schema and namespace attributes
                if (attributeName.IEquals("xmlns") || attributeName.IEquals("schemaLocation") || attributeName.IEquals("xsi"))
                    continue;

                if (attributeName.IEquals("Id"))
                {
                    ConsoleLogger.LogParseError(String.Format("[Delight] {0}: Id can't be specified on the root view element.", GetLineInfo(rootXmlElement)));
                    continue;
                }

                if (attributeName.IEquals("Namespace"))
                {
                    viewObject.Namespace = attributeValue;
                    continue;
                }

                if (attributeName.IEquals("Module"))
                {
                    viewObject.Module = attributeValue;
                    continue;
                }

                if (attributeName.IEquals("BasedOn"))
                {
                    // set default 
                    if (attributeValue.IEquals("View") && !String.IsNullOrEmpty(config.BaseView))
                    {
                        viewObject.BasedOn = _contentObjectModel.LoadViewObject(config.BaseView);
                    }
                    else
                    {
                        viewObject.BasedOn = _contentObjectModel.LoadViewObject(attributeValue);
                    }
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
                        ConsoleLogger.LogParseError(String.Format("[Delight] {0}: Invalid HasContentTemplate value \"{1}\". Should be either \"True\" or \"False\".", GetLineInfo(rootXmlElement), attributeValue));
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
                // set BasedOn as defined in config or use hard-coded default
                var defaultBasedOn = config.DefaultBasedOn;
                if (String.IsNullOrEmpty(defaultBasedOn) || defaultBasedOn == viewName)
                {
                    defaultBasedOn = DefaultViewType;
                }

                viewObject.BasedOn = _contentObjectModel.LoadViewObject(defaultBasedOn);
            }

            if (!String.IsNullOrEmpty(config.BaseView) && config.BaseView.IEquals(viewObject.Name))
            {
                // if this is new base view make sure it always inherits from View
                viewObject.BasedOn = _contentObjectModel.LoadViewObject("View");
            }

            // parse the view's children recursively
            List<ViewDeclaration> viewDeclarations = ParseViewDeclarations(viewObject, xumlFile.Path, rootXmlElement.Elements(), new Dictionary<string, int>(), null);

            // add property declarations for view declarations having IDs
            propertyExpressions.AddRange(GetPropertyDeclarations(viewDeclarations));

            viewObject.PropertyExpressions.AddRange(propertyExpressions);
            viewObject.ViewDeclarations.AddRange(viewDeclarations);
        }

        /// <summary>
        /// Parses scene XML.
        /// </summary>
        private static void ParseSceneXml(XmlFile xumlFile, XElement rootXmlElement)
        {
            _currentXmlFile = xumlFile;
            var config = MasterConfig.GetInstance();
            var sceneName = rootXmlElement.Name.LocalName;
            var module = rootXmlElement.Attribute("Module")?.Value;

            // if the scene is in a module ignore it if the module isn't active
            if (!String.IsNullOrEmpty(module))
            {
                if (module.StartsWith("!"))
                {
                    if (config.Modules.Any(x => x == module.Substring(1)))
                    {
                        return;
                    }
                }
                else
                {
                    if (!config.Modules.Any(x => x == module))
                    {
                        return;
                    }
                }
            }

            var sceneObject = _contentObjectModel.LoadSceneObject(sceneName);

            // clear view object 
            sceneObject.Clear();
            sceneObject.Name = sceneName;
            sceneObject.FilePath = xumlFile.Path;
            sceneObject.NeedUpdate = true;

            // parse scene view
            ParseViewXml(xumlFile, rootXmlElement);
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

                // ignore XML schema and namespace attributes
                if (attributeName.IEquals("xmlns") || attributeName.IEquals("schemaLocation") || attributeName.IEquals("xsi"))
                    continue;

                ConsoleLogger.LogParseError(String.Format("[Delight] {0}: Invalid attribute <{1} {2}=\"{3}\">. Attributes can't be specified on style root element.", GetLineInfo(rootXmlElement), styleName, attributeName, attributeValue));
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
                styleDeclaration.StylePath = path;
                styleDeclaration.ViewName = GetActualViewName(styleElement.Name.LocalName);
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
                        styleDeclaration.BasedOnName = attributeValue;
                        continue;
                    }

                    // parse property expressions
                    var propertyExpressions = ParsePropertyExpression(styleElement, attributeName, attributeValue);
                    foreach (var propertyExpression in propertyExpressions)
                    {
                        var propertyDeclaration = propertyExpression as PropertyDeclaration;
                        if (propertyDeclaration != null)
                        {
                            ConsoleLogger.LogParseError(String.Format("[Delight] {0}: Invalid style <{1} {2}=\"{3}\">. Property declarations can't be specified in the style.", GetLineInfo(styleElement), styleDeclaration.ViewName, attributeName, attributeValue));
                            continue;
                        }

                        var mappedViewDeclaration = propertyExpression as PropertyMapping;
                        if (mappedViewDeclaration != null)
                        {
                            ConsoleLogger.LogParseError(String.Format("[Delight] {0}: Invalid style <{1} {2}=\"{3}\">. Property mappings can't be specified in the style.", GetLineInfo(styleElement), styleDeclaration.ViewName, attributeName, attributeValue));
                            continue;
                        }

                        var propertyAssignment = propertyExpression as PropertyAssignment;
                        if (propertyAssignment != null)
                        {
                            propertyAssignment.StyleDeclaration = styleDeclaration;
                            styleDeclaration.PropertyAssignments.Add(propertyAssignment);
                            continue;
                        }

                        var propertyBinding = propertyExpression as PropertyBinding;
                        if (propertyBinding != null)
                        {
                            propertyBinding.StyleDeclaration = styleDeclaration;
                            styleDeclaration.PropertyBindings.Add(propertyBinding);
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
        /// Looks if view name is an alias and retrieves the actual view name.  
        /// </summary>
        public static string GetActualViewName(string name)
        {
            if (Aliases.ViewAliases.TryGetValue(name, out var actualName))
                return actualName;
            return name;
        }

        /// <summary>
        /// Parses view declarations.
        /// </summary>
        private static List<ViewDeclaration> ParseViewDeclarations(ViewObject viewObject, string path, IEnumerable<XElement> viewElements, Dictionary<string, int> viewIdCount, ViewDeclaration parentViewDeclaration)
        {
            var provider = CodeDomProvider.CreateProvider("C#");
            var viewDeclarations = new List<ViewDeclaration>();
            foreach (var viewElement in viewElements)
            {
                var viewDeclaration = new ViewDeclaration();
                viewDeclaration.ViewName = GetActualViewName(viewElement.Name.LocalName);
                viewDeclaration.LineNumber = viewElement.GetLineNumber();
                viewDeclaration.ParentDeclaration = parentViewDeclaration;

                // parse view's initialization attributes
                foreach (var attribute in viewElement.Attributes())
                {
                    string attributeName = attribute.Name.LocalName;
                    string attributeValue = attribute.Value;

                    if (attributeName.IEquals("Id"))
                    {                        
                        if (!provider.IsValidIdentifier(attributeValue))
                        {
                            // ignore invalid identifiers
                            //ConsoleLogger.LogParseError(String.Format("[Delight] {0}: Invalid view identifier <{1} {2}=\"{3}\">. Identifier must start with an letter or underscore, followed by letters, numbers or underscores.", GetLineInfo(viewElement), viewDeclaration.ViewName, attributeName, attributeValue));
                            continue;
                        }

                        if (viewIdCount.ContainsKey(attributeValue))
                        {
                            // ignore invalid identifiers
                            //ConsoleLogger.LogParseError(String.Format("[Delight] {0}: Invalid view identifier <{1} {2}=\"{3}\">. Identifiers in the file must be unique to avoid name conflicts, there is already a view with the same Id \"{3}\".", GetLineInfo(viewElement), viewDeclaration.ViewName, attributeName, attributeValue));
                            continue;
                        }

                        viewDeclaration.Id = attributeValue;
                        viewIdCount.Add(attributeValue, 0);
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
                            ConsoleLogger.LogParseError(String.Format("[Delight] {0}: Invalid property declaration <{1} {2}=\"{3}\">. Property declarations (like PropertyName=\"t:string\") can only be specified on the root view element.", GetLineInfo(viewElement), viewDeclaration.ViewName, attributeName, attributeValue));
                            continue;
                        }

                        var mappedViewDeclaration = propertyExpression as PropertyMapping;
                        if (mappedViewDeclaration != null)
                        {
                            ConsoleLogger.LogParseError(String.Format("[Delight] {0}: Invalid mapped view declaration <{1} {2}=\"{3}\">. Property declarations (like PropertyName=\"t:string\") can only be specified on the root view element.", GetLineInfo(viewElement), viewDeclaration.ViewName, attributeName, attributeValue));
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
                viewDeclaration.ChildDeclarations = ParseViewDeclarations(viewObject, path, viewElement.Elements(), viewIdCount, viewDeclaration);
                viewDeclarations.Add(viewDeclaration);
            }

            return viewDeclarations;
        }

        private static bool IsValidId(string attributeValue)
        {
            throw new NotImplementedException();
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
                    ConsoleLogger.LogParseError(String.Format("[Delight] {0}: Invalid property expression {1}=\"{2}\". Only a single dash \"-\" may be used to denote state property assignment.", GetLineInfo(element), attributeName, attributeValue));
                    return propertyExpressions;
                }

                hasStateName = true;

                int stateNameStartIndex = names[0].LastIndexOf('.');
                if (stateNameStartIndex < 0) stateNameStartIndex = 0;
                stateName = names[0].Substring(stateNameStartIndex);
                propertyName = attributeName.Replace(stateName + "-", "");
            }

            // action property declaration
            if (attributeValue.IEquals("t:Action"))
            {
                // validate
                if (dotCount > 0 || hasStateName)
                {
                    ConsoleLogger.LogParseError(String.Format("[Delight] {0}: Invalid property declaration {1}=\"{2}\". Make sure declaration contains a non-nested property name without state definition.", GetLineInfo(element), attributeName, attributeValue));
                    return propertyExpressions;
                }

                // action property declaration
                var propertyDeclaration = new PropertyDeclaration();
                propertyExpressions.Add(propertyDeclaration);

                propertyDeclaration.PropertyName = attributeName;
                propertyDeclaration.PropertyTypeName = "ViewAction";
                propertyDeclaration.PropertyTypeFullName = "ViewAction";
                propertyDeclaration.DeclarationType = PropertyDeclarationType.Action;
                propertyDeclaration.LineNumber = element.GetLineNumber();

                return propertyExpressions;
            }

            // attached property declaration
            if (attributeValue.IStartsWith("at:"))
            {
                // validate
                if (dotCount > 0 || hasStateName)
                {
                    ConsoleLogger.LogParseError(String.Format("[Delight] {0}: Invalid attached property declaration {1}=\"{2}\". Make sure declaration contains a non-nested property name without state definition.", GetLineInfo(element), attributeName, attributeValue));
                    return propertyExpressions;
                }

                int commaIndex = attributeValue.IndexOf(",");
                int assignmentIndex = attributeValue.IndexOf("=");

                if (assignmentIndex > 0)
                {
                    ConsoleLogger.LogParseError(String.Format("[Delight] {0}: Invalid attached property declaration {1}=\"{2}\". Assignment not allowed in declaration.", GetLineInfo(element), attributeName, attributeValue));
                    return propertyExpressions;
                }

                // parse property value if any
                var attachedProperty = new AttachedProperty();
                attachedProperty.LineNumber = element.GetLineNumber();
                propertyExpressions.Add(attachedProperty);

                Type propertyType = null;
                string propertyTypeName = attributeValue.Substring(3);
                string propertyNamespace = null;

                if (commaIndex > 0)
                {
                    // assembly qualified type is specified
                    propertyType = Type.GetType(propertyTypeName);
                }
                else
                {
                    // get type from specified name (and namespace)
                    GetTypeNameAndNamespace(propertyTypeName, out propertyTypeName, out propertyNamespace);
                    propertyType = MasterConfig.GetType(propertyTypeName, propertyNamespace);
                }

                if (propertyType == null)
                {
                    ConsoleLogger.LogParseError(String.Format("[Delight] {0}: Property type not found {1}=\"{2}\".", GetLineInfo(element), attributeName, attributeValue));
                    return new List<PropertyExpression>();
                }

                attachedProperty.AssemblyQualifiedType = propertyType.AssemblyQualifiedName;
                attachedProperty.PropertyName = attributeName;
                attachedProperty.PropertyTypeName = propertyType.Name;
                attachedProperty.PropertyTypeFullName = propertyType.FullName;

                return propertyExpressions;
            }

            // property declaration
            if (attributeValue.IStartsWith("t:"))
            {
                // validate
                if (dotCount > 0 || hasStateName)
                {
                    ConsoleLogger.LogParseError(String.Format("[Delight] {0}: Invalid property declaration {1}=\"{2}\". Make sure declaration contains a non-nested property name without state definition.", GetLineInfo(element), attributeName, attributeValue));
                    return propertyExpressions;
                }

                // regular property declaration
                var propertyDeclaration = new PropertyDeclaration();
                propertyExpressions.Add(propertyDeclaration);
                propertyDeclaration.LineNumber = element.GetLineNumber();

                int commaIndex = attributeValue.IndexOf(",");
                int assignmentIndex = attributeValue.IndexOf("=");
                bool isAssemblyQualifiedType = commaIndex > 0 && (assignmentIndex < 0 || (assignmentIndex > commaIndex));

                // parse property value if any
                if (assignmentIndex > 0 && !isAssemblyQualifiedType)
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
                    GetTypeNameAndNamespace(genericTypeName, out genericTypeName, out propertyNamespace);

                    // TODO validate generic type parameters, loop through each generic parameter and get their type and full name 
                    int endBracketIndex = propertyTypeName.IndexOf("]");
                    var genericParameterTypes = propertyTypeName.Substring(startBracketIndex + 1, endBracketIndex - startBracketIndex - 1).Split(',').Select(x => x.Trim());
                    var formattedGenericParameterTypes = new List<string>();
                    foreach (var genericParameterType in genericParameterTypes)
                    {
                        GetTypeNameAndNamespace(genericParameterType, out var genericParameterTypeName, out var genericParameterTypeNamespace);
                        var genericType = MasterConfig.GetType(genericParameterTypeName, genericParameterTypeNamespace);
                        if (genericType == null)
                        {
                            ConsoleLogger.LogParseError(String.Format("[Delight] {0}: Invalid property declaration {1}=\"{2}\". Unable to find generic type parameter \"{3}\".", GetLineInfo(element), attributeName, attributeValue, genericParameterType));
                            return new List<PropertyExpression>();
                        }

                        formattedGenericParameterTypes.Add(genericType.FullName);
                    }

                    int genericParameterCount = propertyTypeName.Count(x => x == ',') + 1;
                    var fullGenericTypeName = String.Format("{0}`{1}", genericTypeName, genericParameterCount);

                    propertyType = MasterConfig.GetType(fullGenericTypeName, propertyNamespace);
                    if (propertyType == null)
                    {
                        ConsoleLogger.LogParseError(String.Format("[Delight] {0}: Invalid property declaration {1}=\"{2}\". Unable to find generic type \"{3}\".", GetLineInfo(element), attributeName, attributeValue, genericTypeName));
                        return new List<PropertyExpression>();
                    }

                    propertyDeclaration.PropertyName = attributeName;
                    propertyDeclaration.PropertyTypeName = genericTypeName;

                    int genericTypeParameterCountIndex = propertyType.FullName.IndexOf('`');
                    string formattedPropertyTypeFullName = propertyType.FullName.Substring(0, genericTypeParameterCountIndex);
                    propertyDeclaration.PropertyTypeFullName = String.Format("{0}<{1}>", formattedPropertyTypeFullName, String.Join(", ", formattedGenericParameterTypes));

                    return propertyExpressions;
                }

                if (isAssemblyQualifiedType)
                {
                    // assembly qualified type is specified
                    propertyType = Type.GetType(propertyTypeName);
                }
                else
                {
                    // get type from specified name (and namespace)
                    GetTypeNameAndNamespace(propertyTypeName, out propertyTypeName, out propertyNamespace);
                    propertyType = MasterConfig.GetType(propertyTypeName, propertyNamespace);
                }

                if (propertyType == null)
                {
                    ConsoleLogger.LogParseError(String.Format("[Delight] {0}: Property type not found {1}=\"{2}\".", GetLineInfo(element), attributeName, attributeValue));
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

            // mapped property declaration
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

            // default property binding
            if (attributeName.IStartsWith("defaultBinding."))
            {
                // mapped view
                var defaultBinding = new DefaultPropertyBinding();
                propertyExpressions.Add(defaultBinding);

                defaultBinding.TargetPropertyName = attributeName.Substring(15);
                defaultBinding.IsTwoWay = attributeValue.IEquals("TwoWay");
                defaultBinding.LineNumber = element.GetLineNumber();
                return propertyExpressions;
            }

            // property rename
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

            bool attachedNeedUpdate = propertyName.Count(x => x == '.') == 1;

            // is the value a binding?
            if (ValueIsBinding(attributeValue))
            {
                // validate
                if (hasStateName)
                {
                    ConsoleLogger.LogParseError(String.Format("[Delight] {0}: Invalid property binding {1}=\"{2}\". Binding to state properties are not allowed.", GetLineInfo(element), attributeName, attributeValue));
                    return propertyExpressions;
                }

                // parse binding string
                var propertyBinding = ParseBinding(element, attributeName, attributeValue);
                propertyBinding.AttachedNeedUpdate = attachedNeedUpdate;
                propertyBinding.BindingNeedUpdate = true;
                propertyExpressions.Add(propertyBinding);
                return propertyExpressions;
            }

            propertyExpressions.Add(new PropertyAssignment { PropertyName = propertyName, StateName = stateName, PropertyValue = attributeValue, LineNumber = element.GetLineNumber(), AttachedNeedUpdate = attachedNeedUpdate });
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
        /// Extracts type name and namespace from string. 
        /// </summary>
        private static void GetTypeNameAndNamespace(string fullTypeName, out string propertyTypeName, out string propertyNamespace)
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
                    ConsoleLogger.LogParseError(String.Format("[Delight] {0}: Improperly formatted property binding {1}=\"{2}\".", GetLineInfo(element), propertyName, propertyBindingString));
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
                ConsoleLogger.LogParseError(String.Format("[Delight] {0}: Improperly formatted property binding {1}=\"{2}\". String contains no binding.", GetLineInfo(element), propertyName, propertyBindingString));
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
                bindingSource.Converter = match.Groups["converter"].Value.Trim();
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
                else if (viewField.StartsWith("#"))
                {
                    bindingSource.SourceTypes |= BindingSourceTypes.Internal;
                    viewField = viewField.Substring(1);
                }
                else if (viewField.StartsWith("-"))
                {
                    bindingSource.SourceTypes |= BindingSourceTypes.OneWayExplicit;
                    viewField = viewField.Substring(1);
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
            return String.Format("{0} ({1})", _currentXmlFile.Path, element.LineNumber);
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

        #region Models

        /// <summary>
        /// Parses all schema files.
        /// </summary>
        public static void ParseAllSchemaFiles()
        {
            var config = MasterConfig.GetInstance();

            // clear parsed model object from content model
            _contentObjectModel.ClearSchemaContent();

            // get all assets
            var ignoreFiles = new HashSet<string>();
            var schemaFiles = new List<string>();
            foreach (var localPath in config.ContentFolders)
            {
                string path = String.Format("{0}/{1}{2}", Application.dataPath,
                    localPath.StartsWith("Assets/") ? localPath.Substring(7) : localPath,
                    ModelsFolder.Substring(1));

                foreach (var schemaFile in GetSchemaFilesAtPath(path, ignoreFiles))
                {
                    schemaFiles.Add(schemaFile);
                    ignoreFiles.Add(schemaFile);
                }
            }

            var emptyList = new List<string>();
            ParseSchemaFiles(schemaFiles, emptyList, emptyList, emptyList);

            ConsoleLogger.Log("[Delight] Schema rebuild completed.");
        }

        /// <summary>
        /// Parses schema files. 
        /// </summary>
        public static void ParseSchemaFiles(List<string> addedOrUpdatedSchemaFiles, List<string> deletedSchemaFiles, List<string> movedSchemaFiles, List<string> movedFromSchemaFiles)
        {
            // parse schema files
            foreach (var newSchemaPath in addedOrUpdatedSchemaFiles.Concat(movedSchemaFiles))
            {
                var content = File.ReadAllLines(newSchemaPath);
                ParseSchemaFile(content, newSchemaPath);
            }

            // generate code for models
            CodeGenerator.GenerateModelCode();

            _contentObjectModel.SaveObjectModel();
        }

        /// <summary>
        /// Parses schema file. 
        /// </summary>
        public static void ParseSchemaFile(string[] fileContent, string path)
        {
            // clear all models belonging to schema file
            _contentObjectModel.ModelObjects.RemoveAll(x => x.SchemaFilePath.IEquals(path));

            ModelObject newModelObject = null;
            ModelObject insertModelObject = null;
            var filename = Path.GetFileName(path);
            bool inModelDeclaration = false;
            bool inDataInsertDeclaration = false;
            List<ModelProperty> insertProperties = new List<ModelProperty>();
            List<string> insertBuildTargets = new List<string>();

            // parse schema file
            for (int i = 0; i < fileContent.Length; ++i)
            {
                var line = fileContent[i].Trim().RemoveComments();
                if (String.IsNullOrWhiteSpace(line)) // ignore comments and empty lines
                    continue;

                if (line.StartsWith("="))
                {
                    inDataInsertDeclaration = false;
                    inModelDeclaration = false;

                    // parse model object declaration
                    var modelName = line.Substring(1).Trim();
                    newModelObject = _contentObjectModel.LoadModelObject(modelName);
                    newModelObject.Clear();
                    newModelObject.SchemaFilePath = path;
                    inModelDeclaration = true;
                    continue;
                }

                if (line.StartsWith("+"))
                {
                    inModelDeclaration = false;
                    inDataInsertDeclaration = false;

                    // parse data insert declaration
                    var insertDecl = line.Substring(1).Split(new char[] { ' ', '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (insertDecl.Length < 1)
                    {
                        ConsoleLogger.LogParseError(String.Format("[Delight] {0} ({1}): Unable to parse data insert declaration. No model object specified.\nError line:\n{2}", path, i + 1, line));
                        continue;
                    }

                    var insertModelName = insertDecl[0];
                    insertModelObject = _contentObjectModel.LoadModelObject(insertModelName, false);
                    if (insertModelObject == null)
                    {
                        ConsoleLogger.LogParseError(String.Format("[Delight] {0} ({1}): Unable to parse data insert declaration. Model object \"{2}\" not found. Make sure data inserts appears after model declaration.\nError line:\n{3}", path, i + 1, insertModelName, line));
                        continue;
                    }

                    insertProperties.Clear();
                    insertBuildTargets.Clear();

                    // parse insert properties
                    for (int j = 1; j < insertDecl.Length; ++j)
                    {
                        var propertyName = insertDecl[j];

                        if (propertyName.StartsWith("#"))
                        {
                            // build target declaration
                            insertBuildTargets.Add(propertyName.Substring(1));
                            continue;
                        }

                        var property = insertModelObject.Properties.FirstOrDefault(x => x.Name.IEquals(propertyName));
                        if (property == null)
                        {
                            ConsoleLogger.LogParseError(String.Format("[Delight] {0} ({1}): Unable to parse data insert declaration. Property \"{2}\" not found.\nError line:\n{3}", path, i + 1, propertyName, line));
                            continue;
                        }

                        insertProperties.Add(property);
                    }

                    inDataInsertDeclaration = true;
                    continue;
                }

                if (inModelDeclaration)
                {
                    // parse model property declaration
                    string[] args = line.Split(null);
                    if (args.Length > 2)
                    {
                        ConsoleLogger.LogParseError(String.Format("[Delight] {0} ({1}): Unable to parse property declaration. Declaration must follow the syntax: \"PropertyType PropertyName\" where PropertyName is optional.\nError line:\n{2}", path, i + 1, line));
                        continue;
                    }

                    var propertyName = args.Length == 2 ? args[1] : args[0];
                    var propertyType = args[0];
                    var property = newModelObject.Properties.FirstOrDefault(x => x.Name.IEquals(propertyName));
                    if (property == null)
                    {
                        property = new ModelProperty();
                        newModelObject.Properties.Add(property);
                    }
                    property.Name = propertyName;
                    property.TypeName = propertyType;
                    newModelObject.NeedUpdate = true;
                }
                else if (inDataInsertDeclaration)
                {
                    // parse data insert
                    var matches = _dataInsertRegex.Matches(line).OfType<Match>().ToList();
                    if (matches.Count <= 0)
                    {
                        ConsoleLogger.LogParseError(String.Format("[Delight] {0} ({1}): Unable to parse data insert. Specify a comma separated list of values with an optional ID and build target specifier, example: \"dataId: value, \"value string\", value3 #dev\". \nError line:\n{2}", path, i + 1, line));
                        continue;
                    }

                    ModelObjectData modelObjectData = new ModelObjectData();
                    modelObjectData.BuildTargets.AddRange(insertBuildTargets);

                    // see if first match contains id
                    var firstValue = matches[0].Value;
                    if (firstValue.EndsWith(":"))
                    {
                        var strGroup = matches[0].Groups["str"]?.Value;
                        modelObjectData.Id = String.IsNullOrWhiteSpace(strGroup) ? firstValue.Substring(0, firstValue.Length - 1) : strGroup;
                        matches.RemoveAt(0);
                    }

                    // get all build target specifiers
                    var buildTargetMatches = matches.Where(x => x.Value.StartsWith("#")).ToList();
                    foreach (var buildTargetMatch in buildTargetMatches)
                    {
                        modelObjectData.BuildTargets.Add(buildTargetMatch.Value.Substring(1));
                        matches.Remove(buildTargetMatch);
                    }

                    // the rest are property values
                    if (matches.Count > insertProperties.Count)
                    {
                        ConsoleLogger.LogParseError(String.Format("[Delight] {0} ({1}): Unable to parse data insert. Number of values greater than properties specified in the data insert declaration. \nError line:\n{2}", path, i + 1, line));
                        continue;
                    }

                    for (int j = 0; j < matches.Count; ++j)
                    {
                        var match = matches[j];
                        var strGroup = matches[j].Groups["str"]?.Value;
                        modelObjectData.PropertyData.Add(new ModelObjectPropertyData
                        {
                            Property = insertProperties[j],
                            PropertyValue = String.IsNullOrWhiteSpace(strGroup) ? match.Value : strGroup,
                            Line = i + 1
                        });
                    }

                    insertModelObject.Data.Add(modelObjectData);

                    insertModelObject.NeedUpdate = true;
                }
                else
                {
                    ConsoleLogger.LogParseError(String.Format("[Delight] {0} ({1}): Unable to parse line. Line is not in a valid model or data insert declaration.\nError line:\n{2}", path, i + 1, line));
                    continue;
                }
            }
        }

        /// <summary>
        /// Gets all schema files at a path.
        /// </summary>
        private static List<string> GetSchemaFilesAtPath(string path, HashSet<string> ignoreFiles = null)
        {
            var files = new List<string>();
            if (Directory.Exists(path))
            {
                string[] filePaths = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);
                foreach (string unformattedFilePath in filePaths)
                {
                    if (unformattedFilePath.EndsWith(".cs") || unformattedFilePath.EndsWith(".meta"))
                        continue;

                    if (!unformattedFilePath.IContains("Schema"))
                        continue;

                    var filePath = MasterConfig.GetFormattedPath(unformattedFilePath);
                    if (ignoreFiles != null && ignoreFiles.Contains(filePath))
                        continue;

                    files.Add(filePath);
                }
            }

            return files;
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

                //Debug.Log(String.Format("Adding asset \"{0}\" of type \"{1}\" to bundle \"{2}\".", asset.Name, asset.Type.Name, bundle.Name));
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

                //var assetName = Path.GetFileNameWithoutExtension(deletedAssetPath);
                //Debug.Log(String.Format("Removing asset \"{0}\" from bundle \"{1}\".", assetName, bundle.Name));
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
        public static void RebuildAssets(bool buildBundlesLater = false)
        {
            var config = MasterConfig.GetInstance();
            bool assetsNeedBuild = false;

            // clear parsed asset content from model
            _contentObjectModel.ClearAssetContent();

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
                bundle.NeedBuild = !bundle.IsResource;
                assetsNeedBuild |= bundle.NeedBuild;
            }

            _contentObjectModel.SaveObjectModel();

            if (!buildBundlesLater)
            {
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
                        ConsoleLogger.LogException(e);
                    }
                }

                // build asset bundles
                BuildAssetBundles(_contentObjectModel.AssetBundleObjects);
            }
            else
            {
                if (assetsNeedBuild && !config.AssetsNeedBuild)
                {
                    config.AssetsNeedBuild = true;
                    config.SaveConfig();
                }
            }

            // generate asset code
            CodeGenerator.GenerateAssetCode();

            _contentObjectModel.AssetsNeedUpdate = false;
            _contentObjectModel.SaveObjectModel();

            ConsoleLogger.Log("[Delight] Asset bundles rebuild completed.");
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
                ConsoleLogger.LogError(String.Format("[Delight] Unable to load asset at \"{0}\". Asset ignored.", assetFile));
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

            var config = MasterConfig.GetInstance();
            var streamedBundles = new List<AssetBundleBuild>();
            var remoteBundles = new List<AssetBundleBuild>();
            foreach (var bundle in bundles)
            {
                bundle.NeedBuild = false;
                if (bundle.IsResource)
                    continue;

                //ConsoleLogger.Log(String.Format("[Delight] Building asset bundle \"{0}\".", bundle.Name));

                var build = new AssetBundleBuild();
                build.assetBundleName = bundle.Name.ToLower();
                build.assetBundleVariant = String.Empty;
                build.assetNames = AssetDatabase.GetAssetPathsFromAssetBundle(build.assetBundleName);
                if (config.StreamedBundles.IContains(bundle.Name))
                {
                    streamedBundles.Add(build);
                }
                else
                {
                    remoteBundles.Add(build);
                }
            }

            _contentObjectModel.SaveObjectModel();
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

        #region Config

        /// <summary>
        /// Parses config files.
        /// </summary>
        public static ConfigParseResult ParseAllConfigFiles()
        {
            var config = MasterConfig.GetInstance();

            // store away old configurations for comparison
            var oldBuildTargets = config.BuildTargets.ToList();
            var oldStreamedBundles = config.StreamedBundles.ToList();
            var oldContentFolders = config.ContentFolders.ToList();
            var oldBasedOn = config.DefaultBasedOn;
            var oldModules = config.Modules.ToList();

            // clear configuration
            config.Clear();

            // get all assets
            var ignoreFiles = new HashSet<string>();
            var configFiles = new List<string>();
            foreach (var localPath in config.ContentFolders)
            {
                string path = String.Format("{0}/{1}", Application.dataPath,
                    localPath.StartsWith("Assets/") ? localPath.Substring(7) : localPath);

                foreach (var configFile in GetConfigFilesAtPath(path, ignoreFiles))
                {
                    configFiles.Add(configFile);
                    ignoreFiles.Add(configFile);
                }
            }

            ParseConfigFiles(configFiles);
            ConsoleLogger.Log("[Delight] Config rebuild completed.");

            // compare old settings with new
            ConfigParseResult result = ConfigParseResult.RebuildNothing;
            if (!oldBuildTargets.Same(config.BuildTargets))
            {
                // if build-targets change we need to rebuild schemas
                result |= ConfigParseResult.RebuildSchemas;
            }

            if (!oldStreamedBundles.Same(config.StreamedBundles))
            {
                result |= ConfigParseResult.RebuildBundles;
            }

            if (!oldContentFolders.Same(config.ContentFolders))
            {
                result |= ConfigParseResult.RebuildAll;
            }

            if (oldBasedOn != config.DefaultBasedOn)
            {
                result |= ConfigParseResult.RebuildAll;
            }

            if (!oldModules.Same(config.Modules))
            {
                result |= ConfigParseResult.RebuildAll;
                UpdateProjectSettings();
            }

            return result;
        }

        /// <summary>
        /// Parses config files. 
        /// </summary>
        public static void ParseConfigFiles(List<string> configFiles)
        {
            var config = MasterConfig.GetInstance();

            // parse config files
            foreach (var configFile in configFiles)
            {
                var content = File.ReadAllLines(configFile);
                ParseConfigFile(content, configFile);
            }

            // generate code for config
            CodeGenerator.GenerateConfigCode();
            config.SaveConfig();
        }

        /// <summary>
        /// Parses config file. 
        /// </summary>
        public static void ParseConfigFile(string[] fileContent, string path)
        {
            var config = MasterConfig.GetInstance();
            var filename = Path.GetFileName(path);

            // parse config file
            for (int i = 0; i < fileContent.Length; ++i)
            {
                // remove comments from file
                var line = fileContent[i].Trim().RemoveComments();
                if (String.IsNullOrWhiteSpace(line)) // ignore comments and empty lines
                    continue;

                var colonIndex = line.IndexOf(':');
                if (colonIndex < 0)
                {
                    ConsoleLogger.LogParseError(String.Format("[Delight] {0} ({1}): Unable to parse config option. Make sure to specify config option name followed by a colon (Example syntax: \"ServerUri:\").\nError line:\n{2}", path, i + 1, line));
                    continue;
                }

                var configOption = line.Substring(0, colonIndex).Trim();
                var configValue = line.Substring(colonIndex + 1).Trim();
                if (String.IsNullOrWhiteSpace(configOption))
                {
                    ConsoleLogger.LogParseError(String.Format("[Delight] {0} ({1}): Unable to parse config option. Make sure to specify config option name followed by a colon (Example syntax: \"ServerUri:\").\nError line:\n{2}", path, i + 1, line));
                    continue;
                }

                int linesParsed = 0;
                switch (configOption.ToLower())
                {
                    case "serveruri":
                        if (String.IsNullOrWhiteSpace(configValue))
                        {
                            // parse values
                            var values = ParseConfigValues(fileContent, i + 1, out linesParsed);
                            i += linesParsed;
                            if (values.Count() > 0)
                            {
                                config.ServerUri = values.FirstOrDefault();
                            }
                        }
                        else
                        {
                            config.ServerUri = configValue;
                        }
                        break;

                    case "usesimulateduriineditor":
                        var value = configValue;
                        if (String.IsNullOrWhiteSpace(value))
                        {
                            // parse values
                            var values = ParseConfigValues(fileContent, i + 1, out linesParsed);
                            i += linesParsed;
                            if (values.Count() > 0)
                            {
                                value = values.FirstOrDefault();
                            }
                        }

                        if (!String.IsNullOrWhiteSpace(value))
                        {
                            if (value.IEquals("true"))
                                config.UseSimulatedUriInEditor = true;
                            else if (value.IEquals("false"))
                                config.UseSimulatedUriInEditor = false;
                            else
                                ConsoleLogger.LogParseError(String.Format("[Delight] {0} ({1}): Unable to parse value of config option {2}. Value need to be either true or false.\nError line:\n{2}", path, i + 1, line, configOption));
                        }
                        break;

                    case "serverurilocator":
                        if (String.IsNullOrWhiteSpace(configValue))
                        {
                            // parse values
                            var values = ParseConfigValues(fileContent, i + 1, out linesParsed);
                            i += linesParsed;
                            if (values.Count() > 0)
                            {
                                config.ServerUriLocator = values.FirstOrDefault();
                            }
                        }
                        else
                        {
                            config.ServerUriLocator = configValue;
                        }
                        break;

                    case "buildtargets":
                        if (String.IsNullOrWhiteSpace(configValue))
                        {
                            // parse values
                            var values = ParseConfigValues(fileContent, i + 1, out linesParsed);
                            i += linesParsed;
                            if (values.Count() > 0)
                            {
                                config.BuildTargets.AddRange(values);
                            }
                        }
                        else
                        {
                            config.BuildTargets.Add(configValue);
                        }
                        break;

                    case "contentfolders":
                        if (String.IsNullOrWhiteSpace(configValue))
                        {
                            // parse values
                            var values = ParseConfigValues(fileContent, i + 1, out linesParsed);
                            i += linesParsed;
                            if (values.Count() > 0)
                            {
                                config.ContentFolders.AddRange(values);
                            }
                        }
                        else
                        {
                            config.ContentFolders.Add(configValue);
                        }
                        break;

                    case "streamedbundles":
                        if (String.IsNullOrWhiteSpace(configValue))
                        {
                            // parse values
                            var values = ParseConfigValues(fileContent, i + 1, out linesParsed);
                            i += linesParsed;
                            if (values.Count() > 0)
                            {
                                config.StreamedBundles.AddRange(values);
                            }
                        }
                        else
                        {
                            config.StreamedBundles.Add(configValue);
                        }
                        break;

                    case "namespaces":
                        if (String.IsNullOrWhiteSpace(configValue))
                        {
                            // parse values
                            var values = ParseConfigValues(fileContent, i + 1, out linesParsed);
                            i += linesParsed;
                            if (values.Count() > 0)
                            {
                                config.Namespaces.AddRange(values);
                            }
                        }
                        else
                        {
                            config.Namespaces.Add(configValue);
                        }
                        break;

                    case "delightpath":
                        if (String.IsNullOrWhiteSpace(configValue))
                        {
                            // parse values
                            var values = ParseConfigValues(fileContent, i + 1, out linesParsed);
                            i += linesParsed;
                            if (values.Count() > 0)
                            {
                                config.DelightPath = values.FirstOrDefault();
                            }
                        }
                        else
                        {
                            config.DelightPath = configValue;
                        }
                        break;

                    case "defaultbasedon":
                        if (String.IsNullOrWhiteSpace(configValue))
                        {
                            // parse values
                            var values = ParseConfigValues(fileContent, i + 1, out linesParsed);
                            i += linesParsed;
                            if (values.Count() > 0)
                            {
                                config.DefaultBasedOn = values.FirstOrDefault();
                            }
                        }
                        else
                        {
                            config.DefaultBasedOn = configValue;
                        }
                        break;

                    case "baseview":
                        if (String.IsNullOrWhiteSpace(configValue))
                        {
                            // parse values
                            var values = ParseConfigValues(fileContent, i + 1, out linesParsed);
                            i += linesParsed;
                            if (values.Count() > 0)
                            {
                                config.BaseView = values.FirstOrDefault();
                            }
                        }
                        else
                        {
                            config.BaseView = configValue;
                        }
                        break;

                    case "assetbundleversion":
                        var version = configValue;
                        if (String.IsNullOrWhiteSpace(version))
                        {
                            // parse values
                            var values = ParseConfigValues(fileContent, i + 1, out linesParsed);
                            i += linesParsed;
                            if (values.Count() > 0)
                            {
                                version = values.FirstOrDefault();
                            }
                        }

                        if (!String.IsNullOrWhiteSpace(version))
                        {
                            try
                            {
                                config.AssetBundleVersion = System.Convert.ToInt32(version, CultureInfo.InvariantCulture);
                            }
                            catch
                            {
                                ConsoleLogger.LogParseError(String.Format("[Delight] {0} ({1}): Unable to parse value of config option {2}. Value need to be an integer.\nError line:\n{2}", path, i + 1, line, configOption));
                            }
                        }
                        break;

                    case "modules":
                        if (String.IsNullOrWhiteSpace(configValue))
                        {
                            // parse values
                            var values = ParseConfigValues(fileContent, i + 1, out linesParsed);
                            i += linesParsed;
                            if (values.Count() > 0)
                            {
                                config.Modules.AddRange(values.Where(x => !String.IsNullOrWhiteSpace(x)));
                            }
                        }
                        else
                        {
                            config.Modules.Add(configValue);
                        }
                        break;


                    default:
                        ConsoleLogger.LogParseError(String.Format("[Delight] {0} ({1}): Unable to parse config option. Option \"{2}\" not recognized.\nError line:\n{3}", path, i + 1, configOption, line));
                        continue;
                }
            }
        }

        /// <summary>
        /// Parses config values from file.
        /// </summary>
        public static List<string> ParseConfigValues(string[] fileContent, int startIndex, out int linesParsed)
        {
            var values = new List<string>();
            linesParsed = 0;

            // parse config file
            for (int i = startIndex; i < fileContent.Length; ++i)
            {
                var line = fileContent[i].RemoveComments();
                if (String.IsNullOrWhiteSpace(line)) // ignore comments and empty lines
                {
                    ++linesParsed;
                    continue;
                }

                // values need to start with indentation 
                if (!line.StartsWith(" "))
                    break;

                values.Add(line.Trim());
                ++linesParsed;
            }

            return values;
        }

        /// <summary>
        /// Gets all config files at a path.
        /// </summary>
        private static List<string> GetConfigFilesAtPath(string path, HashSet<string> ignoreFiles = null)
        {
            var files = new List<string>();
            if (Directory.Exists(path))
            {
                string[] filePaths = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);
                foreach (string unformattedFilePath in filePaths)
                {
                    if (unformattedFilePath.EndsWith(".cs") || unformattedFilePath.EndsWith(".meta"))
                        continue;

                    if (!unformattedFilePath.IContains("Config"))
                        continue;

                    var filePath = MasterConfig.GetFormattedPath(unformattedFilePath);
                    if (ignoreFiles != null && ignoreFiles.Contains(filePath))
                        continue;

                    files.Add(filePath);
                }
            }

            return files;
        }

        #endregion
    }

    /// <summary>
    /// Specifies what needs to be rebuilt after config has been parsed. 
    /// </summary>
    [Flags]
    public enum ConfigParseResult
    {
        RebuildNothing = 0,
        RebuildAll = 1,
        RebuildSchemas = 2,
        RebuildBundles = 4
    }
}

