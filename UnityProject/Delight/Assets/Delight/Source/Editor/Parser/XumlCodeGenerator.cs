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
#endregion

namespace Delight.Parser
{
    /// <summary>
    /// Generates code from XUML object model.
    /// </summary>
    public static class XumlCodeGenerator
    {
        #region Fields

        public static string DefaultViewType = "UIView";
        public static string DefaultNamespace = "Delight";
        private static XumlObjectModel _xumlObjectModel;

        #endregion

        #region Methods

        /// <summary>
        /// Generates code from XUML object model.
        /// </summary>
        public static void GenerateCode(XumlObjectModel xumlObjectModel)
        {
            _xumlObjectModel = xumlObjectModel;

            var viewsChecked = new Dictionary<string, bool>();

            // update views that contain children that needs update
            foreach (var xumlViewObject in xumlObjectModel.ViewObjects)
            {
                if (xumlViewObject.NeedUpdate)
                    continue;

                xumlViewObject.NeedUpdate = AnyChildNeedUpdate(xumlViewObject, viewsChecked);
            }

            // update views that are based on views that needs update
            foreach (var xumlViewObject in xumlObjectModel.ViewObjects)
            {
                xumlViewObject.NeedUpdate = AnyParentNeedUpdate(xumlViewObject);
                xumlViewObject.HasContentTemplate = AnyParentHasContentTemplate(xumlViewObject);

                // update view property declarations with view type data
                var viewPropertyDeclarations = xumlViewObject.PropertyExpressions.OfType<PropertyDeclaration>().Where(x => x.DeclarationType == PropertyDeclarationType.View);
                foreach (var viewPropertyDeclaration in viewPropertyDeclarations)
                {
                    var viewObject = _xumlObjectModel.GetViewObject(viewPropertyDeclaration.PropertyTypeName);
                    viewPropertyDeclaration.PropertyTypeFullName = viewObject.TypeName;
                }
            }

            // update all view objects that are changed            
            foreach (var xumlViewObject in xumlObjectModel.ViewObjects)
            {
                if (!xumlViewObject.NeedUpdate)
                    continue;

                // update properties in view object model
                UpdateMappedProperties(xumlViewObject);

                // generate view code
                GenerateViewCode(xumlViewObject);
                xumlViewObject.NeedUpdate = false;
            }

            // update all theme objects that are changed
            foreach (var xumlThemeObject in xumlObjectModel.ThemeObjects)
            {
                if (!xumlThemeObject.NeedUpdate)
                    continue;

                GenerateThemeCode(xumlThemeObject);
                xumlThemeObject.NeedUpdate = false;
            }

#if UNITY_EDITOR
            ++Template.Version;
#endif
        }

        /// <summary>
        /// Generates code from XUML view object.
        /// </summary>
        private static void GenerateViewCode(XumlViewObject xumlViewObject)
        {
            Debug.Log("Generating code for " + xumlViewObject.FilePath);

            var viewTypeName = xumlViewObject.TypeName;
            var basedOn = xumlViewObject.BasedOn != null ? xumlViewObject.BasedOn.TypeName : "View";
            var ns = !String.IsNullOrEmpty(xumlViewObject.Namespace) ? xumlViewObject.Namespace : DefaultNamespace;

            // build the internal codebehind for the view
            var sb = new StringBuilder();
            var templateSb = new StringBuilder();

            // start by generating data template as we update property assignment expressions with property declaration information as we do
            GenerateDataTemplate(templateSb, xumlViewObject, string.Empty, string.Empty, string.Empty, null, null, xumlViewObject.FilePath);

            // open the view class
            sb.AppendLine("// Internal view logic generated from \"{0}.xml\"", xumlViewObject.Name);
            sb.AppendLine("#region Using Statements");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Runtime.CompilerServices;");
            sb.AppendLine("using UnityEngine;");
            sb.AppendLine("using UnityEngine.UI;");
            // TODO allow configuration of namespaces to be included
            sb.AppendLine("#endregion");
            sb.AppendLine();
            sb.AppendLine("namespace {0}", ns);
            sb.AppendLine("{");
            sb.AppendLine("    public partial class {0} : {1}", viewTypeName, basedOn);
            sb.AppendLine("    {");

            // generate constructors

            var propertyDeclarations = xumlViewObject.PropertyExpressions.OfType<PropertyDeclaration>();
            var mappedDeclarations = GetMappedPropertyDeclarations(xumlViewObject);

            sb.AppendLine("        #region Constructors");
            sb.AppendLine();
            sb.AppendLine("        public {0}(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :", viewTypeName);
            sb.AppendLine("            base(parent, layoutParent, id, template ?? {0}Templates.Default, initializer)", viewTypeName);
            sb.AppendLine("        {");
            GenerateChildViewDeclarations(xumlViewObject.FilePath, xumlViewObject, sb, viewTypeName, null, xumlViewObject.ViewDeclarations);
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine("        public {0}() : this(null)", viewTypeName);
            sb.AppendLine("        {");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine("        static {0}()", viewTypeName);
            sb.AppendLine("        {");
            sb.AppendLine("            var dependencyProperties = new List<DependencyProperty>();");
            sb.AppendLine("            DependencyProperties.Add({0}Templates.Default, dependencyProperties);", viewTypeName);

            if (propertyDeclarations.Any())
            {
                sb.AppendLine();
                foreach (var declaration in propertyDeclarations)
                {
                    sb.AppendLine("            dependencyProperties.Add({0}Property);", declaration.PropertyName);
                }
            }

            foreach (var mappedDeclaration in mappedDeclarations)
            {
                if (mappedDeclaration.IsViewReference)
                    continue; // properties that references dependency properties in other views aren't included

                sb.AppendLine("            dependencyProperties.Add({0}Property);", mappedDeclaration.PropertyName);
            }
            sb.AppendLine("        }");

            sb.AppendLine();
            sb.AppendLine("        #endregion");
            sb.AppendLine();

            // generate dependency properties

            sb.AppendLine("        #region Properties");

            foreach (var declaration in propertyDeclarations)
            {
                sb.AppendLine();
                sb.AppendLine("        public readonly static DependencyProperty<{0}> {1}Property = new DependencyProperty<{0}>(\"{1}\");", declaration.PropertyTypeFullName, declaration.PropertyName);
                sb.AppendLine("        public {0} {1}", declaration.PropertyTypeFullName, declaration.PropertyName);
                sb.AppendLine("        {");
                sb.AppendLine("            get {{ return {0}Property.GetValue(this); }}", declaration.PropertyName);
                sb.AppendLine("            set {{ {0}Property.SetValue(this, value); }}", declaration.PropertyName);
                sb.AppendLine("        }");
            }

            // generate mapped dependency properties

            foreach (var mappedDeclaration in mappedDeclarations)
            {
                if (mappedDeclaration.IsViewReference)
                {
                    // the property maps to a dependency property in another view
                    sb.AppendLine();
                    sb.AppendLine("        public readonly static DependencyProperty {0}Property = {1}.{2}Property;", mappedDeclaration.PropertyName, mappedDeclaration.TargetObjectType, mappedDeclaration.TargetPropertyName);
                    sb.AppendLine("        public {0} {1}", mappedDeclaration.TargetPropertyTypeFullName, mappedDeclaration.PropertyName);
                    sb.AppendLine("        {");
                    sb.AppendLine("            get {{ return {0}.{1}; }}", mappedDeclaration.TargetObjectName, mappedDeclaration.TargetPropertyName);
                    sb.AppendLine("            set {{ {0}.{1} = value; }}", mappedDeclaration.TargetObjectName, mappedDeclaration.TargetPropertyName);
                    sb.AppendLine("        }");
                }
                else
                {
                    // the property maps to a custom object
                    sb.AppendLine();
                    sb.AppendLine("        public readonly static MappedDependencyProperty<{0}, {1}, {4}> {2}Property = new MappedDependencyProperty<{0}, {1}, {4}>(\"{2}\", x => x.{5}, x => x.{3}, (x, y) => x.{3} = y);",
                        mappedDeclaration.TargetPropertyTypeFullName, mappedDeclaration.TargetObjectType, mappedDeclaration.PropertyName, mappedDeclaration.TargetPropertyName, viewTypeName, mappedDeclaration.TargetObjectName);
                    sb.AppendLine("        public {0} {1}", mappedDeclaration.TargetPropertyTypeFullName, mappedDeclaration.PropertyName);
                    sb.AppendLine("        {");
                    sb.AppendLine("            get {{ return {0}Property.GetValue(this); }}", mappedDeclaration.PropertyName);
                    sb.AppendLine("            set {{ {0}Property.SetValue(this, value); }}", mappedDeclaration.PropertyName);
                    sb.AppendLine("        }");
                }
            }

            sb.AppendLine();
            sb.AppendLine("        #endregion");

            // close the view class
            sb.AppendLine("    }");

            // generate templates
            sb.AppendLine();
            sb.AppendLine("    #region Data Templates");
            sb.AppendLine();

            sb.AppendLine("    public static class {0}Templates", xumlViewObject.TypeName);
            sb.AppendLine("    {");

            // generate template fields
            sb.AppendLine("        #region Properties");
            sb.AppendLine();

            sb.AppendLine("        public static Template Default");
            sb.AppendLine("        {");
            sb.AppendLine("            get");
            sb.AppendLine("            {");
            sb.AppendLine("                return {0};", xumlViewObject.TypeName);
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine();

            sb.Append(templateSb);
            //PrintDataTemplateProperties(sb, xumlViewObject, string.Empty, string.Empty, string.Empty, null, null);

            sb.AppendLine("        #endregion");
            sb.AppendLine("    }");

            sb.AppendLine();
            sb.AppendLine("    #endregion");

            // close namespace
            sb.AppendLine("}");

            // write file
            var dir = Configuration.GetFormattedPath(Path.GetDirectoryName(xumlViewObject.FilePath));
            var sourceFile = String.Format("{0}/{1}_g.cs", dir, xumlViewObject.Name);

            Debug.Log("Creating " + sourceFile);
            File.WriteAllText(sourceFile, sb.ToString());
        }

        /// <summary>
        /// Generates code from XUML view object.
        /// </summary>
        private static void GenerateThemeCode(XumlThemeObject xumlThemeObject)
        {
            Debug.Log("Generating code for " + xumlThemeObject.FilePath);

            var themeName = xumlThemeObject.Name;
            var basedOn = xumlThemeObject.BasedOn != null ? xumlThemeObject.BasedOn.Name : "Theme";
            var ns = !String.IsNullOrEmpty(xumlThemeObject.Namespace) ? xumlThemeObject.Namespace : DefaultNamespace;

            // build the internal codebehind for the view
            var sb = new StringBuilder();

            // open the view class
            sb.AppendLine("// Internal view logic generated from \"{0}.xml\"", xumlThemeObject.Name);
            sb.AppendLine("#region Using Statements");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Runtime.CompilerServices;");
            sb.AppendLine("using UnityEngine;");
            sb.AppendLine("using UnityEngine.UI;");
            // TODO allow configuration of namespaces to be included
            sb.AppendLine("#endregion");
            sb.AppendLine();
            sb.AppendLine("namespace {0}", ns);
            sb.AppendLine("{");
            sb.AppendLine("    public partial class {0} : {1}", themeName, basedOn);
            sb.AppendLine("    {");

            // generate constructor

            // generate methods

            bool hasMethods = xumlThemeObject.ViewDeclarations.Any();
            if (hasMethods)
            {
                sb.AppendLine();
                sb.AppendLine("        #region Methods");
            }

            if (hasMethods)
            {
                sb.AppendLine();
                sb.AppendLine("        #endregion");
            }

            // close the theme class
            sb.AppendLine("    }");

            // close namespace
            sb.AppendLine("}");

            // write file
            var dir = Configuration.GetFormattedPath(Path.GetDirectoryName(xumlThemeObject.FilePath));
            var sourceFile = String.Format("{0}/{1}_g.cs", dir, xumlThemeObject.Name);

            Debug.Log("Creating " + sourceFile);
            File.WriteAllText(sourceFile, sb.ToString());
        }

        /// <summary>
        /// Updates view object properties and generates data template.
        /// </summary>
        private static void GenerateDataTemplate(StringBuilder sb, XumlViewObject xumlViewObject, string idPath, string basedOnPath, string basedOnViewName, ViewDeclaration viewDeclaration,
            List<PropertyExpression> nestedPropertyExpressions, string fileName)
        {
            if (xumlViewObject.TypeName == "View")
            {
                return;
            }

            if (String.IsNullOrEmpty(idPath))
            {
                idPath = xumlViewObject.TypeName;
            }

            var isParent = String.IsNullOrEmpty(basedOnPath);

            var templateBasedOn = isParent ?
                xumlViewObject.BasedOn != null ? xumlViewObject.BasedOn.TypeName : "View" :
                basedOnPath;
            var templateBasedOnViewTypeName = isParent ?
                xumlViewObject.BasedOn != null ? xumlViewObject.BasedOn.TypeName : "View" :
                basedOnViewName;

            var ns = !String.IsNullOrEmpty(xumlViewObject.Namespace) ? xumlViewObject.Namespace : DefaultNamespace;
            var fullViewTypeName = String.Format("{0}.{1}", ns, xumlViewObject.TypeName);

            // declare template property
            var localId = idPath.ToPrivateMemberName();
            sb.AppendLine("        private static Template {0};", idPath.ToPrivateMemberName());
            sb.AppendLine("        public static Template {0}", idPath);
            sb.AppendLine("        {");
            sb.AppendLine("            get");
            sb.AppendLine("            {");
            sb.AppendLine("#if UNITY_EDITOR");
            sb.AppendLine("                if ({0} == null || {0}.CurrentVersion != Template.Version)", localId);
            sb.AppendLine("#else");
            sb.AppendLine("                if ({0} == null)", localId);
            sb.AppendLine("#endif");
            sb.AppendLine("                {");

            // initialize and instantiate template instance 
            sb.AppendLine("                    {0} = new Template({1}Templates.{2});", localId, templateBasedOnViewTypeName, templateBasedOn);

            // get property declarations, initializers and assignment expressions
            var initializerProperties = GetPropertyInitializers(xumlViewObject);
            var propertyDeclarations = GetPropertyDeclarations(xumlViewObject, true, true, true);
            var propertyExpressions = new List<PropertyExpression>();
            if (isParent)
            {
                // if this is a parent we add the property assignments in the root element
                propertyExpressions.AddRange(xumlViewObject.PropertyExpressions);
            }

            if (viewDeclaration != null)
            {
                // add assignments set by parent <Parent><ThisView Property="Value"></Parent>
                propertyExpressions.AddRange(viewDeclaration.PropertyAssignments.Cast<PropertyExpression>());
            }

            if (nestedPropertyExpressions != null)
            {
                // add nested assignments set by parent (that would be expressions like <Button Label.Text="Value">)
                propertyExpressions.AddRange(nestedPropertyExpressions);
            }

            var nestedChildViewPropertyExpressions = new Dictionary<string, List<PropertyExpression>>();

            // generate value initializers for the property assignments
            var propertyAssignments = propertyExpressions.OfType<PropertyAssignment>().ToList();
            for (int i = 0; i < propertyAssignments.Count; ++i)
            {
                var propertyAssignment = propertyAssignments[i];
                if (String.IsNullOrEmpty(propertyAssignment.PropertyValue))
                    continue;

                // if property name contains '.' it refers to a child view property
                var propertyName = propertyAssignment.PropertyName;
                int indexOfDot = propertyName.IndexOf('.');

                // if it's not a nested property, check if property-name refers to a mapped property
                if (indexOfDot <= 0)
                {
                    var mappedProperty = propertyDeclarations.FirstOrDefault(x => x.IsMapped && x.Declaration.PropertyName == propertyName);
                    if (mappedProperty != null)
                    {
                        if (mappedProperty.Declaration.DeclarationType == PropertyDeclarationType.View)
                        {
                            propertyName = mappedProperty.FullTargetPropertyPath;
                            indexOfDot = propertyName.IndexOf('.');
                        }
                        else
                        {
                            // mapped properties on non-view objects has a dependency property generated for it so continue as usual
                        }
                    }
                }

                if (indexOfDot > 0)
                {
                    // pass expression to relevant child
                    var childViewName = propertyName.Substring(0, indexOfDot);
                    var childViewPropertyName = propertyName.Substring(indexOfDot + 1);

                    List<PropertyExpression> childPropertyExpressions;
                    if (!nestedChildViewPropertyExpressions.TryGetValue(childViewName, out childPropertyExpressions))
                    {
                        childPropertyExpressions = new List<PropertyExpression>();
                        nestedChildViewPropertyExpressions.Add(childViewName, childPropertyExpressions);
                    }

                    childPropertyExpressions.Add(new PropertyAssignment { PropertyName = childViewPropertyName, PropertyValue = propertyAssignment.PropertyValue });
                    continue;
                }

                // look for property declaration belonging to expression
                var decl = propertyDeclarations.FirstOrDefault(x => x.Declaration.PropertyName == propertyName);
                if (decl == null)
                {
                    // no declaration found for property assignment                    
                    var initializerProperty = initializerProperties.FirstOrDefault(x => x.PropertyName == propertyAssignment.PropertyName);

                    // check if assignment is to an initializer property
                    if (initializerProperty == null)
                    {
                        // no. which means this is an invalid assignment
                        // value is set for a property that isn't declared, 
                        Debug.LogError(String.Format("[Delight] {0}: Invalid property assignment <{1} {2}=\"{3}\">. The property \"{2}\" does not exist in this view.",
                            GetLineInfo(fileName, propertyAssignment),
                            xumlViewObject.Name, propertyAssignment.PropertyName, propertyAssignment.PropertyValue));
                        continue;
                    }

                    // this assignment is to an initializer property - create new property assignments
                    var assignmentValues = propertyAssignment.PropertyValue.Split(',');
                    for (int k = 0; k < initializerProperty.Properties.Count; ++k)
                    {
                        if (assignmentValues.Length == 1)
                        {
                            // if we have one value assigned, set all initializer properties to that value
                            var newPropertyAssignment = new PropertyAssignment
                            {
                                PropertyName = initializerProperty.Properties[k],
                                PropertyValue = assignmentValues[0]
                            };
                            propertyAssignments.Add(newPropertyAssignment);
                        }
                        else if (k < assignmentValues.Length)
                        {
                            // assign value to property
                            var newPropertyAssignment = new PropertyAssignment
                            {
                                PropertyName = initializerProperty.Properties[k],
                                PropertyValue = assignmentValues[k]
                            };
                            propertyAssignments.Add(newPropertyAssignment);
                        }
                        else
                        {
                            // no more values assigned
                            break;
                        }
                    }
                    continue;
                }

                // update property assignment data with declaration information
                propertyAssignment.PropertyDeclarationInfo = decl;

                // ignore action assignments as they are always set as run-time values
                if (decl.Declaration.DeclarationType == PropertyDeclarationType.Action)
                    continue;

                var typeValueInitializer = ValueConverters.GetInitializer(decl.Declaration.PropertyTypeFullName, propertyAssignment.PropertyValue);
                if (String.IsNullOrEmpty(typeValueInitializer))
                {
                    // no initializer found for the type being assigned to
                    Debug.LogError(String.Format("[Delight] {0}: Unable to assign value to property <{1} {2}=\"{3}\">. Unable to convert value to property of type \"{4}\".",
                        GetLineInfo(fileName, propertyAssignment),
                        xumlViewObject.Name, propertyAssignment.PropertyName, propertyAssignment.PropertyValue, decl.Declaration.PropertyTypeFullName));
                    continue;
                }

                sb.AppendLine("                    {0}.{1}Property.SetDefault({2}, {3});", fullViewTypeName, propertyName, localId, typeValueInitializer);
            }

            // set sub-template properties
            var viewDeclarations = xumlViewObject.GetViewDeclarations(true);
            foreach (var declaration in viewDeclarations)
            {
                if (String.IsNullOrEmpty(declaration.Declaration.Id))
                    continue;

                sb.AppendLine("                    {0}.{1}TemplateProperty.SetDefault({2}, {3}{1});", fullViewTypeName, declaration.Declaration.Id, localId, idPath);
            }

            sb.AppendLine("                }");
            sb.AppendLine("                return {0};", localId);
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine();

            // print child view templates
            foreach (var declaration in viewDeclarations)
            {
                if (String.IsNullOrEmpty(declaration.Declaration.Id))
                    continue;


                var childViewObject = _xumlObjectModel.GetViewObject(declaration.Declaration.ViewName);
                var childIdPath = idPath + declaration.Declaration.Id;
                var childBasedOnPath = String.IsNullOrEmpty(basedOnPath) ? childViewObject.TypeName
                    : basedOnPath + declaration.Declaration.Id;
                var childBasedOnViewName = isParent ? childViewObject.TypeName : basedOnViewName;

                List<PropertyExpression> childPropertyAssignments = null;
                nestedChildViewPropertyExpressions.TryGetValue(declaration.Declaration.Id, out childPropertyAssignments);

                GenerateDataTemplate(sb, childViewObject, childIdPath, childBasedOnPath, childBasedOnViewName,
                    isParent && !declaration.IsInherited ? declaration.Declaration : null,
                    childPropertyAssignments, fileName);
            }
        }

        /// <summary>
        /// Gets formatted line information from element.
        /// </summary>
        private static string GetLineInfo(string fileName, PropertyExpression property)
        {
            return String.Format("{0} ({1})", fileName, property.LineNumber);
        }

        /// <summary>
        /// Gets mapped property declarations for a view object.
        /// </summary>
        private static List<MappedPropertyDeclaration> GetMappedPropertyDeclarations(XumlViewObject xumlViewObject)
        {
            if (!xumlViewObject.HasUpdatedItsMappedProperties)
            {
                UpdateMappedProperties(xumlViewObject);
            }

            return xumlViewObject.MappedPropertyDeclarations;
        }

        /// <summary>
        /// Generates view construction logic from view declaration.
        /// </summary>
        private static void GenerateChildViewDeclarations(string fileName, XumlViewObject xumlViewObject, StringBuilder sb, string parentViewType, ViewDeclaration parentViewDeclaration, List<ViewDeclaration> childViewDeclarations, string localParentId = null, int templateDepth = 0, List<TemplateItemInfo> templateItems = null, string firstTemplateChild = null)
        {
            bool isFirst = true;
            int indent = 3 + templateDepth;
            bool inTemplate = templateDepth > 0;

            // so we need to loop through all child views, print their construction logic
            foreach (var childViewDeclaration in childViewDeclarations)
            {
                // get identifier for view declaration
                var childId = childViewDeclaration.Id;
                var childIdVar = inTemplate ? childId.ToLocalVariableName() : childId;
                var childViewObject = _xumlObjectModel.GetViewObject(childViewDeclaration.ViewName);
                bool templateContent = childViewObject.HasContentTemplate;

                // put a comment if we are creating top-level views
                if (parentViewDeclaration == null)
                {
                    if (!isFirst)
                    {
                        sb.AppendLine();
                    }
                    isFirst = false;
                    sb.AppendLine(indent, "// constructing {0} {1}", childViewDeclaration.ViewName, "(" + childViewDeclaration.Id + ")");
                }

                // print view declaration: _view = new View(this, layoutParent, id, initializer);
                var parentReference = parentViewDeclaration == null ? "this" : localParentId;
                sb.Append(indent, String.Format("{3} = new {1}(this, {2}, \"{0}\", {0}Template", childId, childViewObject.TypeName, parentReference, inTemplate ? "var " + childIdVar : childIdVar));

                // do we have action handlers?
                var actionAssignments = childViewDeclaration.PropertyAssignments.Where(x =>
                {
                    if (x.PropertyDeclarationInfo == null)
                        return false;
                    return x.PropertyDeclarationInfo.Declaration.DeclarationType == PropertyDeclarationType.Action;
                });
                if (actionAssignments.Any())
                {
                    // yes. add initializer for action handlers
                    sb.AppendLine(", x => ");
                    sb.AppendLine(indent, "{{");
                    sb.AppendLine(indent, "    var source = x as {0};", childViewDeclaration.ViewName);
                    foreach (var actionAssignment in actionAssignments)
                    {
                        sb.AppendLine(indent, "    source.{0} = ResolveActionHandler(this, \"{1}\");", actionAssignment.PropertyName, actionAssignment.PropertyValue);
                    }
                    sb.AppendLine(indent, "}});");
                }
                else
                {
                    sb.AppendLine(");");
                }

                // generate bindings
                if (childViewDeclaration.PropertyBindings.Any())
                {
                    foreach (var propertyBinding in childViewDeclaration.PropertyBindings)
                    {
                        if (propertyBinding.BindingType != BindingType.SingleBinding)
                        {
                            Debug.LogError(String.Format("[Delight] {0}: Unable to generate binding to property <{1} {2}=\"{3}\">. Multi-binding not implemented.",
                                GetLineInfo(fileName, propertyBinding),
                                xumlViewObject.Name, propertyBinding.PropertyName, propertyBinding.PropertyBindingString));
                            continue;
                        }

                        var bindingSource = propertyBinding.Sources.First();
                        var targetPath = new List<string>();
                        targetPath.Add(childIdVar);
                        targetPath.AddRange(propertyBinding.PropertyName.Split('.'));
                        var sourcePath = new List<string>();
                        sourcePath.AddRange(bindingSource.BindingPath.Split('.'));

                        // get property names along path
                        var templateItemInfo = templateItems != null ? templateItems.FirstOrDefault(x => x.Name == sourcePath[0]) : null;
                        bool isTemplateItemSource = templateItemInfo != null;
                        if (isTemplateItemSource)
                        {
                            sourcePath[0] = templateItemInfo.VariableName;
                            sourcePath.Insert(1, "Item");
                        }
                        bool isModelSource = bindingSource.SourceTypes.HasFlag(BindingSourceTypes.Model);
                        string sourceProperties = string.Join(", ", sourcePath.Skip(isModelSource ? 2 : (isTemplateItemSource ? 1 : 0)).Select(x => "\"" + x + "\""));
                        string targetProperties = string.Join(", ", targetPath.Skip(inTemplate ? 1 : 0).Select(x => "\"" + x + "\""));

                        // get object getters along path
                        List<string> sourceGetters = new List<string>();
                        int sourcePathCount = isModelSource ? sourcePath.Count - 2 : sourcePath.Count - 1;
                        int sourcePathTake = isModelSource ? 2 : 1;
                        if (!isModelSource && !isTemplateItemSource)
                        {
                            sourceGetters.Add("() => this");
                        }

                        for (int i = 0; i < sourcePathCount; ++i)
                        {
                            sourceGetters.Add(String.Format("() => {0}", string.Join(".", sourcePath.Take(i + sourcePathTake))));
                        }

                        if (isTemplateItemSource)
                        {
                            // in source getters for template items make sure item is cast: () => (tiItem.Item as ItemType).Property
                            sourcePath = sourcePath.Skip(2).ToList();
                            sourcePath.Insert(0, String.Format("({0}.Item as {1})", templateItemInfo.VariableName, templateItemInfo.ItemType));
                        }

                        List<string> targetGetters = new List<string>();
                        if (!inTemplate)
                        {
                            targetGetters.Add("() => this");
                        }
                        for (int i = 0; i < targetPath.Count - 1; ++i)
                        {
                            targetGetters.Add(String.Format("() => {0}", string.Join(".", targetPath.Take(i + 1))));
                        }

                        string sourceGettersString = string.Join(", ", sourceGetters);
                        string targetGettersString = string.Join(", ", targetGetters);

                        string sourceProperty = string.Join(".", sourcePath);
                        string targetProperty = string.Join(".", targetPath);

                        string targetToSource = bindingSource.SourceTypes.HasFlag(BindingSourceTypes.TwoWay) ?
                            String.Format("{0} = {1}", sourceProperty, targetProperty) : "{ }";

                        // TODO in one-way bindings we don't need to listen to changes in target object

                        // print smart binding
                        sb.AppendLine();
                        sb.AppendLine(indent, "// binding <{0} {1}=\"{2}\">", childViewDeclaration.ViewName, propertyBinding.PropertyName, propertyBinding.PropertyBindingString);
                        sb.AppendLine(indent, "{0}Bindings.Add(new Binding(", inTemplate ? firstTemplateChild + "." : "");
                        sb.AppendLine(indent, "    new List<string> {{ {0} }},", sourceProperties);
                        sb.AppendLine(indent, "    new List<string> {{ {0} }},", targetProperties);
                        sb.AppendLine(indent, "    new List<Func<BindableObject>> {{ {0} }},", sourceGettersString);
                        sb.AppendLine(indent, "    new List<Func<BindableObject>> {{ {0} }},", targetGettersString);
                        sb.AppendLine(indent, "    () => {0} = {1},", targetProperty, sourceProperty);
                        sb.AppendLine(indent, "    () => {0}", targetToSource);
                        sb.AppendLine(indent, "));");
                    }
                }

                if (templateContent)
                {
                    ++templateDepth;

                    if (templateItems == null)
                    {
                        templateItems = new List<TemplateItemInfo>();
                    }

                    TemplateItemInfo ti = null;
                    var itemIdDeclaration = childViewDeclaration.PropertyBindings.FirstOrDefault(x => !String.IsNullOrEmpty(x.ItemId));
                    if (itemIdDeclaration != null)
                    {
                        ti = new TemplateItemInfo();
                        ti.Name = itemIdDeclaration.ItemId;
                        ti.VariableName = String.Format("ti{0}", ti.Name.ToPropertyName());
                        ti.ItemIdDeclaration = itemIdDeclaration;
                        templateItems.Add(ti);

                        // TODO get item type
                        ti.ItemType = GetItemTypeFromDeclaration(fileName, xumlViewObject, itemIdDeclaration, templateItems, childViewDeclaration);
                    }

                    sb.AppendLine();
                    sb.AppendLine(indent, "// Template for {0}", childIdVar);
                    sb.AppendLine(indent, "{0}.ContentTemplate = new ContentTemplate({1} => ", childIdVar, ti != null ? ti.VariableName : templateDepth.ToString());
                    sb.AppendLine(indent, "{{");
                }

                var firstChildInTemplate = childViewDeclaration.ChildDeclarations.FirstOrDefault();
                if (templateContent && firstChildInTemplate != null)
                {
                    firstTemplateChild = firstChildInTemplate.Id.ToLocalVariableName();
                }

                // print child view declaration
                GenerateChildViewDeclarations(xumlViewObject.FilePath, xumlViewObject, sb, parentViewType, childViewDeclaration, childViewDeclaration.ChildDeclarations, childIdVar, templateDepth, templateItems, firstTemplateChild);

                if (templateContent)
                {
                    sb.AppendLine(indent, "    return {0};", firstChildInTemplate != null ? firstTemplateChild : "null");
                    sb.AppendLine(indent, "}});");
                }
            }
        }

        /// <summary>
        /// Gets item type from item declaration.
        /// </summary>
        private static string GetItemTypeFromDeclaration(string fileName, XumlViewObject xumlViewObject, PropertyBinding itemIdDeclaration, List<TemplateItemInfo> templateIdInfo, ViewDeclaration viewDeclaration)
        {
            var bindingSource = itemIdDeclaration.Sources.FirstOrDefault();
            if (bindingSource == null)
                return nameof(BindableObject);

            var sourcePath = new List<string>();
            sourcePath.AddRange(bindingSource.BindingPath.Split('.'));

            // see if source refers to another template id, e.g. in nested lists <List Items="{item in player.Achievements}">
            var idInfo = templateIdInfo.FirstOrDefault(x => x.Name == sourcePath[0]);
            if (idInfo != null)
            {
                var source = idInfo.ItemIdDeclaration.Sources.FirstOrDefault();
                sourcePath.RemoveAt(0);
                sourcePath.InsertRange(0, source.BindingPath.Split('.'));
            }

            // go through source path and find the item type 
            Type sourceType = typeof(Models);
            if (sourcePath[0] != "Models")
            {
                sourceType = TypeHelper.GetType(xumlViewObject.TypeName);
            }

            // loop through each property and infer their type
            var bindableCollectionBase = typeof(BindableCollection);
            for (int i = 1; i < sourcePath.Count; ++i)
            {
                var memberInfo = sourceType.GetMemberInfo(sourcePath[i], BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
                if (memberInfo == null)
                {
                    Debug.LogError(String.Format("[Delight] {0}: Unable to infer item type in binding <{1} {2}=\"{3}\">. Member \"{4}\" not found in type \"{5}\".",
                        GetLineInfo(fileName, itemIdDeclaration),
                        viewDeclaration.ViewName, itemIdDeclaration.PropertyName, itemIdDeclaration.PropertyBindingString,
                        sourcePath[i], sourceType.Name));
                    return nameof(BindableObject);
                }

                // if it's a bindable collection get the type from the generic argument
                sourceType = memberInfo.GetMemberType();
                if (bindableCollectionBase.IsAssignableFrom(sourceType))
                {
                    while (!sourceType.IsGenericType)
                    {
                        if (sourceType == bindableCollectionBase)
                        {
                            return nameof(BindableObject);
                        }
                        sourceType = sourceType.BaseType;
                    }

                    sourceType = sourceType.GetGenericArguments()[0];                    
                }
            }

            return sourceType.FullName;
        }

        /// <summary>
        /// Gets all property initializers from view object.
        /// </summary>
        public static List<InitializerProperty> GetPropertyInitializers(XumlViewObject viewObject)
        {
            var propertyInitializers = new List<InitializerProperty>();
            foreach (var initializer in viewObject.PropertyExpressions.OfType<InitializerProperty>())
            {
                propertyInitializers.Add(initializer);
            }

            if (viewObject.BasedOn != null)
            {
                propertyInitializers.AddRange(GetPropertyInitializers(viewObject.BasedOn));
            }

            return propertyInitializers;
        }

        /// <summary>
        /// Gets property declarations from view object. 
        /// </summary>
        public static List<PropertyDeclarationInfo> GetPropertyDeclarations(XumlViewObject viewObject, bool includeInheritedDeclarations, bool includeMappedProperties, bool includeNonDefaultProperties)
        {
            // gets all dependency property declarations in the view
            var propertyDeclarations = new List<PropertyDeclarationInfo>();
            foreach (var declaration in viewObject.PropertyExpressions.OfType<PropertyDeclaration>())
            {
                if (!includeNonDefaultProperties && declaration.DeclarationType != PropertyDeclarationType.Default)
                {
                    continue;
                }

                propertyDeclarations.Add(new PropertyDeclarationInfo { Declaration = declaration });
            }

            if (includeMappedProperties)
            {
                UpdateMappedProperties(viewObject);
                foreach (var mappedProperty in viewObject.MappedPropertyDeclarations)
                {
                    propertyDeclarations.Add(new PropertyDeclarationInfo
                    {
                        IsMapped = true,
                        TargetObjectName = mappedProperty.TargetObjectName,
                        TargetPropertyName = mappedProperty.TargetPropertyName,
                        Declaration = new PropertyDeclaration
                        {
                            PropertyName = mappedProperty.PropertyName,
                            PropertyTypeName = mappedProperty.TargetPropertyTypeFullName,
                            PropertyTypeFullName = mappedProperty.TargetPropertyTypeFullName,
                            DeclarationType = mappedProperty.IsViewReference ? PropertyDeclarationType.View : PropertyDeclarationType.Default
                        }
                    });
                }
            }

            if (includeInheritedDeclarations && viewObject.BasedOn != null)
            {
                foreach (var declaration in GetPropertyDeclarations(viewObject.BasedOn, true, includeMappedProperties, includeNonDefaultProperties))
                {
                    declaration.IsInherited = true;
                    propertyDeclarations.Add(declaration);
                }
            }

            return propertyDeclarations;
        }

        /// <summary>
        /// Updates property information in the xuml view object.
        /// </summary>
        private static void UpdateMappedProperties(XumlViewObject xumlViewObject)
        {
            if (xumlViewObject.HasUpdatedItsMappedProperties)
                return;

            xumlViewObject.HasUpdatedItsMappedProperties = true;
            var propertyDeclarations = GetPropertyDeclarations(xumlViewObject, true, false, true);
            var propertyNames = propertyDeclarations.Select(x => x.Declaration.PropertyName).ToList();
            var propertyMappings = xumlViewObject.PropertyExpressions.OfType<PropertyMapping>();
            var propertyRenames = xumlViewObject.PropertyExpressions.OfType<PropertyRename>();

            // calculate mapped dependency properties
            foreach (var propertyMapping in propertyMappings)
            {
                // find property declaration
                var propertyDeclaration = propertyDeclarations.FirstOrDefault(x => x.Declaration.PropertyName.IEquals(propertyMapping.TargetObjectName));
                if (propertyDeclaration == null)
                {
                    Debug.LogError(String.Format("[Delight] {0}: Invalid property mapping <{1} m.{2}=\"{3}\">. The property \"{2}\" does not exist in this view.", GetLineInfo(xumlViewObject.FilePath, propertyMapping), xumlViewObject.Name, propertyMapping.TargetObjectName, propertyMapping.MapPattern));
                    continue;
                }

                // generate property declarations for the mapping
                if (propertyDeclaration.Declaration.DeclarationType == PropertyDeclarationType.View)
                {
                    // get view reference and generate mappings for its declarations
                    var viewObject = _xumlObjectModel.GetViewObject(propertyDeclaration.Declaration.PropertyTypeName);
                    var declarations = GetPropertyDeclarations(viewObject, true, true, false);
                    foreach (var declaration in declarations)
                    {
                        // check if this declaration conflicts with any of the properties in this view, if so add the view-object as a prefix
                        var nonConflictedPropertyName = GetNonConflictedPropertyName(declaration.Declaration.PropertyName,
                            propertyMapping, propertyNames);
                        if (nonConflictedPropertyName == null)
                            continue;
                        propertyNames.Add(nonConflictedPropertyName);

                        // add new mapped property declaration
                        xumlViewObject.MappedPropertyDeclarations.Add(new MappedPropertyDeclaration
                        {
                            TargetPropertyName = declaration.Declaration.PropertyName,
                            TargetPropertyTypeFullName = declaration.Declaration.PropertyTypeFullName,
                            PropertyName = nonConflictedPropertyName,
                            TargetObjectName = propertyMapping.TargetObjectName,
                            TargetObjectType = viewObject.TypeName, // TODO unsure if this is correct
                            IsViewReference = true
                        });
                    }
                }
                else
                {
                    // if we are mapping to a non-view we need to generate mapped dependency properties
                    // get type object from type name
                    var targetObjectType = Type.GetType(propertyDeclaration.Declaration.AssemblyQualifiedType);
                    if (targetObjectType == null)
                    {
                        Debug.LogError(String.Format("[Delight] {0}: Invalid property mapping <{1} m.{2}=\"{3}\">. The mapped target object of type \"{4}\" could not be found. Make sure the namespace is included in the type name and if the type exist in a separate assembly specify a assembly qualified type name.", GetLineInfo(xumlViewObject.FilePath, propertyMapping), xumlViewObject.Name, propertyMapping.TargetObjectName, propertyMapping.MapPattern, propertyDeclaration.Declaration.PropertyName));
                        continue;
                    }

                    // handle special cases for UnityEngine objects
                    bool isUnityObject = typeof(UnityEngine.Object).IsAssignableFrom(targetObjectType);

                    // get public fields and properties declarations for type and generate mappings
                    var fields = targetObjectType.GetFields(BindingFlags.Public | BindingFlags.Instance);
                    foreach (var field in fields)
                    {
                        // ignore obsolete fields
                        if (field.GetCustomAttributes(typeof(ObsoleteAttribute), true).Length > 0)
                            continue;

                        var fieldPropertyName = field.Name.ToPropertyName();
                        var nonConflictedPropertyName = GetNonConflictedPropertyName(fieldPropertyName, propertyMapping, propertyNames);
                        if (nonConflictedPropertyName == null)
                            continue;

                        // check if the property should be renamed
                        var rename = propertyRenames.FirstOrDefault(x => x.TargetPropertyName == nonConflictedPropertyName);
                        if (rename != null)
                        {
                            nonConflictedPropertyName = GetNonConflictedPropertyName(rename.NewPropertyName, propertyMapping, propertyNames);
                            if (nonConflictedPropertyName == null)
                                continue;
                        }

                        propertyNames.Add(nonConflictedPropertyName);

                        // add new mapped property declaration for field
                        xumlViewObject.MappedPropertyDeclarations.Add(new MappedPropertyDeclaration
                        {
                            TargetPropertyName = field.Name,
                            TargetPropertyTypeFullName = field.FieldTypeName(),
                            PropertyName = nonConflictedPropertyName,
                            TargetObjectName = propertyMapping.TargetObjectName,
                            TargetObjectType = targetObjectType.FullName,
                            IsViewReference = false
                        });
                    }

                    var properties = targetObjectType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    foreach (var property in properties)
                    {
                        // ignore obsolete properties
                        if (property.GetCustomAttributes(typeof(ObsoleteAttribute), true).Length > 0)
                            continue;

                        var setMethod = property.GetSetMethod();
                        if (setMethod == null)
                            continue;

                        // ignore certain common properties for unity objects
                        if (isUnityObject && (property.Name == "enabled" || property.Name == "tag" || property.Name == "name" || property.Name == "hideFlags"
                            || property.Name == "useGUILayout" || property.Name == "runInEditMode"))
                            continue;

                        var propertyName = property.Name.ToPropertyName();
                        var nonConflictedPropertyName = GetNonConflictedPropertyName(propertyName, propertyMapping, propertyNames);
                        if (nonConflictedPropertyName == null)
                            continue;

                        // check if the property should be renamed
                        var rename = propertyRenames.FirstOrDefault(x => x.TargetPropertyName == nonConflictedPropertyName);
                        if (rename != null)
                        {
                            nonConflictedPropertyName = GetNonConflictedPropertyName(rename.NewPropertyName, propertyMapping, propertyNames);
                            if (nonConflictedPropertyName == null)
                                continue;
                        }

                        propertyNames.Add(nonConflictedPropertyName);

                        // add new mapped property declaration for property
                        xumlViewObject.MappedPropertyDeclarations.Add(new MappedPropertyDeclaration
                        {
                            TargetPropertyName = property.Name,
                            TargetPropertyTypeFullName = property.FieldTypeName(),
                            PropertyName = nonConflictedPropertyName,
                            TargetObjectName = propertyMapping.TargetObjectName,
                            TargetObjectType = targetObjectType.FullName,
                            IsViewReference = false
                        });
                    }
                }
            }
        }

        /// <summary>
        /// Gets name for mapped property that doesn't conflict with other property names.
        /// </summary>
        private static string GetNonConflictedPropertyName(string originalPropertyName, PropertyMapping propertyMapping, List<string> propertyNames)
        {
            var propertyName = String.Format("{0}{1}", propertyMapping.MapPattern, originalPropertyName);
            bool nameConflict = propertyNames.Any(x => x == propertyName);
            if (nameConflict)
            {
                propertyName = propertyMapping.TargetObjectName + propertyName;
                if (propertyNames.Any(x => x == propertyName))
                {
                    // TODO print warning that the mapped property conflicts with a name and is ignored
                    return null;
                }
            }

            return propertyName;
        }

        /// <summary>
        /// Check if any of the view object's children need to be updated.
        /// </summary>
        private static bool AnyChildNeedUpdate(XumlViewObject xumlViewObject, Dictionary<string, bool> viewsChecked)
        {
            var declarations = GetPropertyDeclarations(xumlViewObject, true, false, true);
            foreach (var declaration in declarations)
            {
                if (declaration.Declaration.DeclarationType != PropertyDeclarationType.View)
                    continue;

                bool needUpdate = false;
                var name = declaration.Declaration.PropertyTypeName;
                if (viewsChecked.ContainsKey(name))
                {
                    needUpdate = viewsChecked[name];
                }
                else
                {
                    var childViewObject = _xumlObjectModel.GetViewObject(declaration.Declaration.PropertyTypeName);
                    if (childViewObject.NeedUpdate)
                    {
                        needUpdate = true;
                    }
                    else
                    {
                        needUpdate = AnyChildNeedUpdate(childViewObject, viewsChecked);
                    }

                    viewsChecked.Add(name, needUpdate);
                }

                if (needUpdate)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check if any of the view's parents need to be updated.
        /// </summary>
        private static bool AnyParentNeedUpdate(XumlViewObject xumlViewObject)
        {
            if (xumlViewObject.NeedUpdate)
                return true;

            return xumlViewObject.BasedOn != null ? AnyParentNeedUpdate(xumlViewObject.BasedOn) : false;
        }

        /// <summary>
        /// Check if any of the view's parents need to be updated.
        /// </summary>
        private static bool AnyParentHasContentTemplate(XumlViewObject xumlViewObject)
        {
            if (xumlViewObject.HasContentTemplate)
                return true;

            return xumlViewObject.BasedOn != null ? AnyParentHasContentTemplate(xumlViewObject.BasedOn) : false;
        }

        private class TemplateItemInfo
        {
            public string Name;
            public string VariableName;
            public string ItemType;
            public PropertyBinding ItemIdDeclaration;
        }

        #endregion
    }
}

