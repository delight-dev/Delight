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
#endregion

namespace Delight.Parser
{
    /// <summary>
    /// Parses XUML assets.
    /// </summary>
    public static class XumlParser
    {
        #region Fields

        private const string ViewModelFolder = "/ViewModels/";
        private const string ViewFolder = "/Views/";
        private const string StylesFolder = "/Styles/";
        private const string ScenesFolder = "/Scenes/";
        private const string DefaultViewType = "UIView";
        private const string DefaultNamespace = "Delight";
        private const string ModelsClassName = "Models";
        private static readonly char[] BindingDelimiterChars = { ' ', ',', '$', '(', ')', '{', '}' };

        private static XumlObjectModel _xumlObjectModel;
        private static XumlFile _currentXumlFile;
        private static Regex _bindingRegex = new Regex(@"{(?<field>[A-Za-z0-9_#!=@\.\[\]]+)(?<format>:[^}]+)?}");

        #endregion

        #region Methods

        /// <summary>
        /// Processes XUML assets and generates code.
        /// </summary>
        public static void ParseAllXumlFiles()
        {
            var configuration = Configuration.GetInstance();
            configuration.Sanitize();

            // create new object model
            _xumlObjectModel = new XumlObjectModel();

            // get all XUML assets
            var ignoreFiles = new HashSet<string>();
            var xumlFiles = new List<XumlFile>();
            foreach (var localPath in configuration.XumlFolders)
            {
                string path = String.Format("{0}/{1}", Application.dataPath,
                    localPath.StartsWith("Assets/") ? localPath.Substring(7) : localPath);

                foreach (var xumlFile in GetXumlFilesAtPath(path, ignoreFiles))
                {
                    xumlFiles.Add(xumlFile);
                    ignoreFiles.Add(xumlFile.Path);
                }
            }

            // parse and generate code for the xuml files
            ParseXumlFiles(xumlFiles);
        }

        /// <summary>
        /// Parses XUML assets and generates code.
        /// </summary>
        public static void ParseXumlFiles(IEnumerable<string> paths)
        {
            // load object model 
            if (_xumlObjectModel == null)
            {
                LoadObjectModel();
            }

            // parse and generate code for the xuml files
            var files = new List<XumlFile>();
            foreach (var path in paths)
            {
                var xumlFile = GetXumlFileAtPath(path);
                files.Add(xumlFile);
            }

            ParseXumlFiles(files);
        }

        /// <summary>
        /// Parses XUML files. 
        /// </summary>
        private static void ParseXumlFiles(List<XumlFile> xumlFiles)
        {
            foreach (var file in xumlFiles)
            {
                ParseXumlFile(file);
            }

            XumlCodeGenerator.GenerateCode(_xumlObjectModel);
            SaveObjectModel();
            Debug.Log(String.Format("[Delight] XUML processed. {0}", DateTime.Now));
        }

        /// <summary>
        /// Parses XUML and generates code.
        /// </summary>
        private static void ParseXumlFile(XumlFile xumlFile)
        {
            Debug.Log("Parsing " + xumlFile.Path);
            if (xumlFile.ContentType == XumlContentType.Unknown)
            {
                Debug.LogWarning(String.Format("[Delight] Ignoring XUML file \"{0}\" as it's not in a XUML content type subdirectory (\"{1}\", \"{2}\" or \"{3}\").", xumlFile.Path, ViewFolder, ViewModelFolder, StylesFolder));
                return;
            }

            XElement rootXumlElement = null;
            try
            {
                rootXumlElement = XElement.Parse(xumlFile.Content, LoadOptions.SetLineInfo);
            }
            catch (Exception e)
            {
                Debug.LogError(String.Format("[Delight] Error parsing XUML file \"{0}\". Exception thrown: {1}", xumlFile.Content, e.Message + e.StackTrace));
                return;
            }

            if (xumlFile.ContentType == XumlContentType.View)
            {
                ParseViewXuml(xumlFile, rootXumlElement);                
            }
            else if (xumlFile.ContentType == XumlContentType.ViewModel)
            {
                //ParseStylesXuml(xumlFile, rootXumlElement);
            }
            else
            {
                //ParseViewModelXuml(xumlFile, rootXumlElement);
            }
        }

        /// <summary>
        /// Parses view XUML and generates code-behind.
        /// </summary>
        private static void ParseViewXuml(XumlFile xumlFile, XElement rootXumlElement)
        {
            _currentXumlFile = xumlFile;
            var viewName = rootXumlElement.Name.LocalName;
            var viewObject = _xumlObjectModel.GetViewObject(viewName);

            // clear view object 
            viewObject.Clear();
            viewObject.Name = viewName;
            viewObject.TypeName = viewName;
            viewObject.FilePath = xumlFile.Path;
            viewObject.NeedUpdate = true;            

            var propertyExpressions = new List<PropertyExpression>();

            // parse view's initialization attributes
            foreach (var attribute in rootXumlElement.Attributes())
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
                    viewObject.BasedOn = _xumlObjectModel.GetViewObject(attributeValue);
                    continue;
                }

                if (attributeName.IEquals("TypeName"))
                {
                    viewObject.TypeName = attributeValue;
                    continue;
                }

                // parse property expression
                var result = ParsePropertyExpression(rootXumlElement, attributeName, attributeValue);
                propertyExpressions.AddRange(result);
            }

            if (viewObject.BasedOn == null)
            {
                viewObject.BasedOn = _xumlObjectModel.GetViewObject(DefaultViewType);
            }

            // parse the view's children recursively
            List<ViewDeclaration> viewDeclarations = ParseViewDeclarations(xumlFile.Path, rootXumlElement.Elements(), new Dictionary<string, int>());

            // add property declarations for view declarations having IDs
            propertyExpressions.AddRange(GetPropertyDeclarations(viewDeclarations));

            viewObject.PropertyExpressions.AddRange(propertyExpressions);
            viewObject.ViewDeclarations.AddRange(viewDeclarations);
        }

        /// <summary>
        /// Parses specified theme XUML file.
        /// </summary>
        private static void ParseStylesXuml(XumlFile xumlFile, XElement rootXumlElement)
        {
            _currentXumlFile = xumlFile;
            var themeNameAttr = rootXumlElement.Attribute("Theme");
            if (themeNameAttr == null)
            {
                Debug.LogError(String.Format("[Delight] {0}: Name attribute missing.", GetLineInfo(rootXumlElement)));
                return;
            }

            var themeName = themeNameAttr.Value;
            var themeObject = _xumlObjectModel.GetThemeObject(themeName);

            // clear theme object 
            themeObject.Clear();
            themeObject.Name = themeName;
            themeObject.FilePath = xumlFile.Path;
            themeObject.NeedUpdate = true;

            var baseDirectoryAttr = rootXumlElement.Attribute("BaseDirectory");
            if (baseDirectoryAttr != null)
            {
                themeObject.BaseDirectory = baseDirectoryAttr.Value;
            }

            var namespaceAttr = rootXumlElement.Attribute("Namespace");
            if (namespaceAttr != null)
            {
                themeObject.Namespace = namespaceAttr.Value;
            }

            var basedOnAttr = rootXumlElement.Attribute("BasedOn");
            if (basedOnAttr != null)
            {
                themeObject.BasedOn = _xumlObjectModel.GetThemeObject(basedOnAttr.Value);
            }

            // parse view declarations
            var viewDeclarations = ParseViewDeclarations(xumlFile.Path, rootXumlElement.Elements(), new Dictionary<string, int>());
            themeObject.ViewDeclarations.AddRange(viewDeclarations);
        }

        /// <summary>
        /// Gets property declarations from view declarations.
        /// </summary>
        private static IEnumerable<PropertyExpression> GetPropertyDeclarations(List<ViewDeclaration> viewDeclarations)
        {
            var propertyExpressions = new List<PropertyExpression>();
            foreach (var viewDeclaration in viewDeclarations)
            {
                if (!String.IsNullOrEmpty(viewDeclaration.Id))
                {
                    // TODO get the type of the view and create a proper full property name, note that the view might not exist yet though since its code hasn't been generated
                    propertyExpressions.Add(new PropertyDeclaration { PropertyName = viewDeclaration.Id, PropertyTypeFullName = viewDeclaration.ViewName, PropertyTypeName = viewDeclaration.ViewName, DeclarationType = PropertyDeclarationType.View });
                    propertyExpressions.Add(new PropertyDeclaration { PropertyName = String.Format("{0}Template", viewDeclaration.Id), PropertyTypeName = "Template", PropertyTypeFullName = "Template", DeclarationType = PropertyDeclarationType.Template });
                }
                propertyExpressions.AddRange(GetPropertyDeclarations(viewDeclaration.ChildDeclarations));
            }

            return propertyExpressions;
        }

        /// <summary>
        /// Parses view declarations.
        /// </summary>
        private static List<ViewDeclaration> ParseViewDeclarations(string path, IEnumerable<XElement> viewElements, Dictionary<string, int> viewIdList)
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
                    if (!viewIdList.ContainsKey(viewDeclaration.ViewName))
                    {
                        viewIdList.Add(viewDeclaration.ViewName, 0);
                    }

                    ++viewIdList[viewDeclaration.ViewName];
                    viewDeclaration.Id = viewDeclaration.ViewName + viewIdList[viewDeclaration.ViewName];
                }

                // parse child elements
                viewDeclaration.ChildDeclarations = ParseViewDeclarations(path, viewElement.Elements(), viewIdList);
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

            if (attributeValue.IEquals("t:Action"))
            {
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
                // regular property declaration
                var propertyDeclaration = new PropertyDeclaration();
                propertyExpressions.Add(propertyDeclaration);
                propertyDeclaration.LineNumber = element.GetLineNumber();

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

                if (typeof(UnityEngine.Component).IsAssignableFrom(propertyType))
                {
                    propertyDeclaration.DeclarationType = PropertyDeclarationType.UnityComponent;
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
                // parse binding string
                propertyExpressions.Add(ParseBinding(element, attributeName, attributeValue));
                return propertyExpressions;
            }

            propertyExpressions.Add(new PropertyAssignment { PropertyName = attributeName, PropertyValue = attributeValue, LineNumber = element.GetLineNumber() });
            return propertyExpressions;
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
                if (viewField.StartsWith("#"))
                {
                    bindingSource.SourceTypes |= BindingSourceTypes.Local;
                    viewField = viewField.Substring(1);
                }
                else if (viewField.StartsWith("!"))
                {
                    bindingSource.SourceTypes |= BindingSourceTypes.Negated;
                    viewField = viewField.Substring(1);
                }
                else if (viewField.StartsWith("="))
                {
                    bindingSource.SourceTypes |= BindingSourceTypes.OneWay;
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
            return String.Format("{0}.xml ({1})", _currentXumlFile.Name, element.LineNumber);
        }

        /// <summary>
        /// Gets all XUML assets at a path.
        /// </summary>
        private static List<XumlFile> GetXumlFilesAtPath(string path, HashSet<string> ignoreFiles = null)
        {
            var assets = new List<XumlFile>();
            if (Directory.Exists(path))
            {
                string[] filePaths = Directory.GetFiles(path, "*.xml", SearchOption.AllDirectories);
                foreach (string unformattedFilePath in filePaths)
                {
                    var filePath = Configuration.GetFormattedPath(unformattedFilePath);
                    if (ignoreFiles != null && ignoreFiles.Contains(filePath))
                        continue;

                    assets.Add(GetXumlFileAtPath(filePath));
                }
            }

            return assets;
        }

        /// <summary>
        /// Gets XUML asset at path.
        /// </summary>
        private static XumlFile GetXumlFileAtPath(string path)
        {
            var filename = Path.GetFileNameWithoutExtension(path);
            var xumlContentType = GetXumlContentType(path);
            return new XumlFile
            {
                Name = filename,
                Path = path,
                Content = File.ReadAllText(path),
                ContentType = xumlContentType
            };
        }

        /// <summary>
        /// Gets XUML content type based on path.
        /// </summary>
        private static XumlContentType GetXumlContentType(string path)
        {
            if (path.IContains(ViewFolder))
            {
                return XumlContentType.View;
            }
            else if (path.IContains(ViewModelFolder))
            {
                return XumlContentType.ViewModel;
            }
            else if (path.IContains(StylesFolder))
            {
                return XumlContentType.Styles;
            }
            else
            {
                return XumlContentType.Unknown;
            }
        }

        /// <summary>
        /// Loads object model if it's not already loaded.
        /// </summary>
        private static void LoadObjectModel()
        {
            var configuration = Configuration.GetInstance();

            // check if file exist
            var modelFilePath = configuration.GetObjectModelFilePath();
            if (!File.Exists(modelFilePath))
            {
                _xumlObjectModel = new XumlObjectModel();
                return;
            }

            using (var file = File.OpenRead(modelFilePath))
            {
                Debug.Log("Deserializing " + modelFilePath);
                _xumlObjectModel = Serializer.Deserialize<XumlObjectModel>(file);
            }
        }

        /// <summary>
        /// Saves object model if it's not already loaded.
        /// </summary>
        private static void SaveObjectModel()
        {
            var configuration = Configuration.GetInstance();
            var modelFilePath = configuration.GetObjectModelFilePath();

            using (var file = File.Open(modelFilePath, FileMode.Create))
            {
                Debug.Log("Serializing " + modelFilePath);
                Serializer.Serialize(file, _xumlObjectModel);
            }
        }

        /// <summary>
        /// XUML file.
        /// </summary>
        private struct XumlFile
        {
            public string Name;
            public string Path;
            public string Content;
            public XumlContentType ContentType;
        }

        /// <summary>
        /// XUML content type.
        /// </summary>
        private enum XumlContentType
        {
            View,
            ViewModel,
            Styles,
            Unknown
        }

        #endregion
    }
}

