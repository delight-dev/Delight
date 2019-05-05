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

namespace Delight.Editor.Parser
{
    /// <summary>
    /// Generates code from content object model.
    /// </summary>
    public static class CodeGenerator
    {
        #region Fields

        public static string DefaultViewType = "UIView";
        public static string DefaultNamespace = "Delight";
        private static ContentObjectModel _contentObjectModel = ContentObjectModel.GetInstance();

        #endregion

        #region Views

        /// <summary>
        /// Generates view code from object model.
        /// </summary>
        public static void GenerateViewCode()
        {
            var viewsChecked = new Dictionary<string, bool>();
            var viewObjects = _contentObjectModel.ViewObjects.ToList();

            // update views that contain children that needs update
            foreach (var viewObject in viewObjects)
            {
                if (viewObject.NeedUpdate)
                    continue;

                viewObject.NeedUpdate = AnyChildNeedUpdate(viewObject, viewsChecked);
            }

            // update views that are based on views that needs update
            foreach (var viewObject in viewObjects)
            {
                viewObject.NeedUpdate = AnyParentNeedUpdate(viewObject);
                viewObject.HasContentTemplate = AnyParentHasContentTemplate(viewObject);

                // update view property declarations with view type data
                var viewPropertyDeclarations = viewObject.PropertyExpressions.OfType<PropertyDeclaration>().Where(x => x.DeclarationType == PropertyDeclarationType.View);
                foreach (var viewPropertyDeclaration in viewPropertyDeclarations)
                {
                    var childViewObject = _contentObjectModel.LoadViewObject(viewPropertyDeclaration.PropertyTypeName);
                    viewPropertyDeclaration.PropertyTypeFullName = childViewObject.TypeName;
                }
            }

            // validate and update view declarations - template content, attached properties, etc.
            foreach (var viewObject in viewObjects)
            {
                UpdateViewDeclarations(viewObject, viewObject.ViewDeclarations);
            }

            // update all view objects that are changed            
            foreach (var viewObject in viewObjects)
            {
                if (!viewObject.NeedUpdate)
                    continue;

                // update properties in view object model
                UpdateMappedProperties(viewObject);

                // generate view code    
                GenerateViewCode(viewObject);

                viewObject.NeedUpdate = false;
            }

#if UNITY_EDITOR
            ++Template.Version;
#endif
        }

        /// <summary>
        /// Generates code from XML view object.
        /// </summary>
        private static void GenerateViewCode(ViewObject viewObject)
        {
            Debug.Log("Generating code for " + viewObject.FilePath);

            var viewTypeName = viewObject.TypeName;
            bool isBaseView = viewObject.TypeName.IEquals("View");
            string basedOn = string.Empty;
            if (!isBaseView)
            {
                basedOn = String.Format(" : {0}", viewObject.BasedOn != null ? viewObject.BasedOn.TypeName : "View");
            }
            var ns = !String.IsNullOrEmpty(viewObject.Namespace) ? viewObject.Namespace : DefaultNamespace;

            // build the internal codebehind for the view
            var sb = new StringBuilder();
            var templateSb = new StringBuilder();

            // start by generating data template as we update property assignment expressions with property declaration information as we do
            GenerateDataTemplate(templateSb, viewObject, string.Empty, string.Empty, string.Empty, null, null, viewObject.FilePath);

            // open the view class
            sb.AppendLine("// Internal view logic generated from \"{0}.xml\"", viewObject.Name);
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
            sb.AppendLine("    public partial class {0}{1}", viewTypeName, basedOn);
            sb.AppendLine("    {");

            // generate constructors

            var propertyDeclarations = viewObject.PropertyExpressions.OfType<PropertyDeclaration>();
            var mappedDeclarations = GetMappedPropertyDeclarations(viewObject);
            var attachedProperties = viewObject.PropertyExpressions.OfType<AttachedProperty>();

            sb.AppendLine("        #region Constructors");
            sb.AppendLine();
            if (!isBaseView)
            {
                sb.AppendLine("        public {0}(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :", viewTypeName);
                sb.AppendLine("            base(parent, layoutParent, id, template ?? {0}Templates.Default, initializer)", viewTypeName);
                sb.AppendLine("        {");
                GenerateChildViewDeclarations(viewObject.FilePath, viewObject, sb, viewTypeName, null, viewObject.ViewDeclarations);

                // do we have action handlers specified on the root element?
                var actionAssignments = viewObject.GetPropertyAssignmentsWithStyle()
                    .Where(x => x.PropertyDeclarationInfo != null &&
                                x.PropertyDeclarationInfo.Declaration.DeclarationType == PropertyDeclarationType.Action).ToList();

                // yes. attach handlers
                foreach (var actionAssignment in actionAssignments)
                {
                    sb.AppendLine("            {0} += ResolveActionHandler(this, \"{1}\");", actionAssignment.PropertyName, actionAssignment.PropertyValue);
                }

                // initialize any attached properties                
                foreach (var attachedProperty in attachedProperties)
                {
                    sb.AppendLine("            {0} = new AttachedProperty<{1}>(this, \"{0}\");", attachedProperty.PropertyName, attachedProperty.PropertyTypeFullName);
                }

                // set content container
                if (viewObject.ContentContainer != null)
                {
                    sb.AppendLine("            ContentContainer = {0};", viewObject.ContentContainer.Id);
                }

                sb.AppendLine("            this.AfterInitializeInternal();");
                sb.AppendLine("        }");
                sb.AppendLine();
                sb.AppendLine("        public {0}() : this(null)", viewTypeName);
                sb.AppendLine("        {");
                sb.AppendLine("        }");
                sb.AppendLine();
            }
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
                var typeName = declaration.DeclarationType == PropertyDeclarationType.Asset ? declaration.AssetType.FormattedTypeName : declaration.PropertyTypeFullName;

                sb.AppendLine();
                sb.AppendLine("        public readonly static DependencyProperty<{0}> {1}Property = new DependencyProperty<{0}>(\"{1}\");", typeName, declaration.PropertyName);
                sb.AppendLine("        public {0} {1}", typeName, declaration.PropertyName);
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
                    var typeName = mappedDeclaration.IsAssetReference ? mappedDeclaration.AssetType.FormattedTypeName : mappedDeclaration.TargetPropertyTypeFullName;

                    // the property maps to a dependency property in another view
                    sb.AppendLine();
                    sb.AppendLine("        public readonly static DependencyProperty {0}Property = {1}.{2}Property;", mappedDeclaration.PropertyName, mappedDeclaration.TargetObjectType, mappedDeclaration.TargetPropertyName);
                    sb.AppendLine("        public {0} {1}", typeName, mappedDeclaration.PropertyName);
                    sb.AppendLine("        {");
                    sb.AppendLine("            get {{ return {0}.{1}; }}", mappedDeclaration.TargetObjectName, mappedDeclaration.TargetPropertyName);
                    sb.AppendLine("            set {{ {0}.{1} = value; }}", mappedDeclaration.TargetObjectName, mappedDeclaration.TargetPropertyName);
                    sb.AppendLine("        }");
                }
                else if (mappedDeclaration.IsAssetReference)
                {
                    // the property maps to a unity asset in another object (e.g. unity component)
                    sb.AppendLine();
                    sb.AppendLine("        public readonly static MappedAssetDependencyProperty<{0}, {1}, {4}> {2}Property = new MappedAssetDependencyProperty<{0}, {1}, {4}>(\"{2}\", x => x.{5}, (x, y) => x.{3} = y?.UnityObject);",
                        mappedDeclaration.AssetType.FormattedTypeName, mappedDeclaration.TargetObjectType, mappedDeclaration.PropertyName, mappedDeclaration.TargetPropertyName, viewTypeName, mappedDeclaration.TargetObjectName);
                    sb.AppendLine("        public {0} {1}", mappedDeclaration.AssetType.FormattedTypeName, mappedDeclaration.PropertyName);
                    sb.AppendLine("        {");
                    sb.AppendLine("            get {{ return {0}Property.GetValue(this); }}", mappedDeclaration.PropertyName);
                    sb.AppendLine("            set {{ {0}Property.SetValue(this, value); }}", mappedDeclaration.PropertyName);
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

            // generate attached properties

            foreach (var attachedProperty in attachedProperties)
            {
                sb.AppendLine();
                sb.AppendLine("        public AttachedProperty<{0}> {1} {{ get; private set; }}", attachedProperty.PropertyTypeFullName, attachedProperty.PropertyName);
            }

            sb.AppendLine();
            sb.AppendLine("        #endregion");

            // close the view class
            sb.AppendLine("    }");

            // generate templates
            sb.AppendLine();
            sb.AppendLine("    #region Data Templates");
            sb.AppendLine();

            sb.AppendLine("    public static class {0}Templates", viewObject.TypeName);
            sb.AppendLine("    {");

            // generate template fields
            sb.AppendLine("        #region Properties");
            sb.AppendLine();

            sb.AppendLine("        public static Template Default");
            sb.AppendLine("        {");
            sb.AppendLine("            get");
            sb.AppendLine("            {");
            sb.AppendLine("                return {0};", viewObject.TypeName);
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine();

            sb.Append(templateSb);

            sb.AppendLine("        #endregion");
            sb.AppendLine("    }");

            sb.AppendLine();
            sb.AppendLine("    #endregion");

            // close namespace
            sb.AppendLine("}");

            // write file
            var dir = MasterConfig.GetFormattedPath(Path.GetDirectoryName(viewObject.FilePath));
            var sourceFile = String.Format("{0}/{1}_g.cs", dir, viewObject.Name);

            Debug.Log("Creating " + sourceFile);
            File.WriteAllText(sourceFile, sb.ToString());
        }

        /// <summary>
        /// Validates view declarations in the view object.
        /// </summary>
        private static void UpdateViewDeclarations(ViewObject viewObject, List<ViewDeclaration> childViewDeclarations)
        {
            foreach (var childViewDeclaration in childViewDeclarations)
            {
                // update attached assignments 
                var attachedAssignmentsNeedUpdate = childViewDeclaration.PropertyAssignments.Where(x => x.AttachedNeedUpdate).ToList();
                foreach (var attachedAssignment in attachedAssignmentsNeedUpdate)
                {
                    attachedAssignment.AttachedNeedUpdate = false;
                    int indexOfDot = attachedAssignment.PropertyName.IndexOf('.');
                    var parentViewName = attachedAssignment.PropertyName.Substring(0, indexOfDot);
                    var parentPropertyName = attachedAssignment.PropertyName.Substring(indexOfDot + 1);

                    // see if we can find a view object of specified type as a parent to this view
                    var parentViewDeclaration = childViewDeclaration.ParentDeclaration;
                    while (parentViewDeclaration != null)
                    {
                        if (parentViewDeclaration.ViewName.IEquals(parentViewName))
                        {
                            // see if view actually has attached property declared
                            var parentViewObject = _contentObjectModel.LoadViewObject(parentViewDeclaration.ViewName);
                            var attachedPropertyDeclaration = parentViewObject.PropertyExpressions.OfType<AttachedProperty>().FirstOrDefault(x => x.PropertyName.IEquals(parentPropertyName));
                            if (attachedPropertyDeclaration != null)
                            {
                                // remove property assignment and add attached property assignment to declaration
                                childViewDeclaration.PropertyAssignments.Remove(attachedAssignment);
                                childViewDeclaration.AttachedPropertyAssignments.Add(new AttachedPropertyAssignment
                                {
                                    LineNumber = attachedAssignment.LineNumber,
                                    PropertyName = parentPropertyName,
                                    PropertyValue = attachedAssignment.PropertyValue,
                                    ParentId = parentViewDeclaration.Id,
                                    PropertyTypeName = attachedPropertyDeclaration.PropertyTypeName,
                                    ParentViewName = parentViewName
                                });

                                break;
                            }
                        }

                        parentViewDeclaration = parentViewDeclaration.ParentDeclaration;
                    }
                }

                // validate template content
                var childViewObject = _contentObjectModel.LoadViewObject(childViewDeclaration.ViewName);
                bool templateContent = childViewObject.HasContentTemplate;
                if (templateContent)
                {
                    var childId = childViewDeclaration.Id;
                    var contentTemplateType = childViewObject.ContentTemplate?.TypeName;
                    bool wrapContent = false;

                    // see if template child is of appropriate type
                    if (!String.IsNullOrEmpty(contentTemplateType) && childViewDeclaration.ChildDeclarations.Count() == 1)
                    {
                        var templateChildObject = _contentObjectModel.LoadViewObject(childViewDeclaration.ChildDeclarations[0].ViewName);
                        wrapContent = true;
                        while (templateChildObject != null)
                        {
                            if (templateChildObject.TypeName.IEquals(contentTemplateType))
                            {
                                wrapContent = false;
                                break;
                            }

                            templateChildObject = templateChildObject.BasedOn;
                        }
                    }

                    if (wrapContent)
                    {
                        // children is not of appropriate type, so we need to wrap them
                        string viewName = !String.IsNullOrEmpty(contentTemplateType) ? contentTemplateType : "Region";
                        var wrappingRegionDeclaration = new ViewDeclaration
                        {
                            Id = childId + "Content",
                            ViewName = viewName,
                            ChildDeclarations = childViewDeclaration.ChildDeclarations,
                            ParentDeclaration = childViewDeclaration
                        };
                        wrappingRegionDeclaration.ChildDeclarations.ForEach(x => x.ParentDeclaration = wrappingRegionDeclaration);

                        childViewDeclaration.ChildDeclarations = new List<ViewDeclaration>();
                        childViewDeclaration.ChildDeclarations.Add(wrappingRegionDeclaration);

                        // add property declarations for the wrapping region
                        viewObject.PropertyExpressions.AddRange(ContentParser.GetPropertyDeclarations(wrappingRegionDeclaration));
                    }
                }

                UpdateViewDeclarations(viewObject, childViewDeclaration.ChildDeclarations);
            }
        }

        /// <summary>
        /// Updates view object properties and generates data template.
        /// </summary>
        private static void GenerateDataTemplate(StringBuilder sb, ViewObject viewObject, string idPath, string basedOnPath, string basedOnViewName, ViewDeclaration viewDeclaration,
            List<PropertyExpression> nestedPropertyExpressions, string fileName)
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

            var ns = !String.IsNullOrEmpty(viewObject.Namespace) ? viewObject.Namespace : DefaultNamespace;
            var fullViewTypeName = String.Format("{0}.{1}", ns, viewObject.TypeName);

            // declare template property
            var localId = idPath.ToPrivateMemberName();
            sb.AppendLine("        private static Template {0};", localId);
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

            var basedOnParameter = viewObject.TypeName.IEquals("View") ? "null" :
                String.Format("{0}Templates.{1}", templateBasedOnViewTypeName, templateBasedOn);

            // initialize and instantiate template instance 
            sb.AppendLine("                    {0} = new Template({1});", localId, basedOnParameter);

            // add name in editor so we can easy track which template is used where in the debugger
            sb.AppendLine("#if UNITY_EDITOR");
            sb.AppendLine("                    {0}.Name = \"{1}\";", localId, idPath);
            sb.AppendLine("#endif");

            // get property declarations, initializers and assignment expressions
            var initializerProperties = GetPropertyInitializers(viewObject);
            var propertyDeclarations = GetPropertyDeclarations(viewObject, true, true, true);
            var propertyAssignments = new List<PropertyAssignment>();
            if (isParent)
            {
                // if this is a parent we add the property assignments in the root element
                propertyAssignments.AddRange(viewObject.GetPropertyAssignmentsWithStyle());
            }

            if (viewDeclaration != null)
            {
                // add assignments set by parent <Parent><ThisView Property="Value"></Parent>
                propertyAssignments.AddRange(viewDeclaration.GetPropertyAssignmentsWithStyle());
            }

            if (nestedPropertyExpressions != null)
            {
                // add nested assignments set by parent (that would be expressions like <Button Label.Text="Value">)
                propertyAssignments.AddRange(nestedPropertyExpressions.OfType<PropertyAssignment>());
            }

            var nestedChildViewPropertyExpressions = new Dictionary<string, List<PropertyExpression>>();

            // generate value initializers for the property assignments
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

                    childPropertyExpressions.Add(new PropertyAssignment { PropertyName = childViewPropertyName, PropertyValue = propertyAssignment.PropertyValue, StateName = propertyAssignment.StateName, LineNumber = propertyAssignment.LineNumber });
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
                            viewObject.Name, propertyAssignment.PropertyName, propertyAssignment.PropertyValue));
                        continue;
                    }

                    // this assignment is to an initializer property - create new property assignments
                    var splitter = propertyAssignment.PropertyValue.Contains(";") ? ';' : ',';
                    var assignmentValues = propertyAssignment.PropertyValue.Split(splitter);
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

                var propertyTypeName = decl.IsAssetReference ? decl.AssetType.FormattedTypeName : decl.Declaration.PropertyTypeFullName;
                var typeValueInitializer = ValueConverters.GetInitializer(propertyTypeName, propertyAssignment.PropertyValue);
                if (String.IsNullOrEmpty(typeValueInitializer))
                {
                    if (decl.IsAssetReference)
                    {
                        // if asset initializer not found, use default initializer for asset types
                        typeValueInitializer = String.Format("Assets.{0}[\"{1}\"]", decl.AssetType.Name.Pluralize(), propertyAssignment.PropertyValue);
                    }
                    else
                    {
                        // see if type is enum 
                        Type type = null;
                        if (!String.IsNullOrEmpty(decl.Declaration.AssemblyQualifiedType))
                        {
                            type = Type.GetType(decl.Declaration.AssemblyQualifiedType);
                        }

                        if (type != null && type.IsEnum)
                        {
                            // generate generic initializer for enum type
                            typeValueInitializer = String.Format("{0}.{1}", type.FullName.Replace('+', '.'), Enum.Parse(type, propertyAssignment.PropertyValue, true));
                        }
                        else
                        {
                            // no initializer found for the type being assigned to
                            Debug.LogError(String.Format("[Delight] {0}: Unable to assign value to property <{1} {2}=\"{3}\">. Unable to convert value to property of type \"{4}\".",
                                GetLineInfo(fileName, propertyAssignment),
                                viewObject.Name, propertyAssignment.PropertyName, propertyAssignment.PropertyValue, decl.Declaration.PropertyTypeFullName));
                            continue;
                        }
                    }
                }

                // set property value
                if (String.IsNullOrEmpty(propertyAssignment.StateName))
                {
                    sb.AppendLine("                    {0}.{1}Property.SetDefault({2}, {3});", fullViewTypeName, propertyName, localId, typeValueInitializer);
                }
                else
                {
                    sb.AppendLine("                    {0}.{1}Property.SetStateDefault(\"{2}\", {3}, {4});", fullViewTypeName, propertyName, propertyAssignment.StateName, localId, typeValueInitializer);
                }
            }

            // set sub-template properties
            var viewDeclarations = viewObject.GetViewDeclarations(true);
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

                var childViewObject = _contentObjectModel.LoadViewObject(declaration.Declaration.ViewName);
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
        private static List<MappedPropertyDeclaration> GetMappedPropertyDeclarations(ViewObject viewObject)
        {
            if (!viewObject.HasUpdatedItsMappedProperties)
            {
                UpdateMappedProperties(viewObject);
            }

            return viewObject.MappedPropertyDeclarations;
        }

        /// <summary>
        /// Generates view construction logic from view declaration.
        /// </summary>
        private static void GenerateChildViewDeclarations(string fileName, ViewObject viewObject, StringBuilder sb, string parentViewType, ViewDeclaration parentViewDeclaration, List<ViewDeclaration> childViewDeclarations, string localParentId = null, int templateDepth = 0, List<TemplateItemInfo> templateItems = null, string firstTemplateChild = null)
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
                var childViewObject = _contentObjectModel.LoadViewObject(childViewDeclaration.ViewName);
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
                var parentReference = parentViewDeclaration == null ? "this" : localParentId + ".Content";
                sb.AppendLine(indent, String.Format("{3} = new {1}(this, {2}, \"{0}\", {0}Template);", childId, childViewObject.TypeName, parentReference, inTemplate ? "var " + childIdVar : childIdVar));

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
                    foreach (var actionAssignment in actionAssignments)
                    {
                        sb.AppendLine(indent, "{0}.{1} += ResolveActionHandler(this, \"{2}\");", childId, actionAssignment.PropertyName, actionAssignment.PropertyValue);
                    }
                }

                // do we have attached properties?
                foreach (var attachedProperty in childViewDeclaration.AttachedPropertyAssignments)
                {
                    // yes. add initializer for attached property
                    var typeValueInitializer = ValueConverters.GetInitializer(attachedProperty.PropertyTypeName, attachedProperty.PropertyValue);
                    if (String.IsNullOrEmpty(typeValueInitializer))
                    {
                        Debug.LogError(String.Format("[Delight] {0}: Unable to assign value to attached property <{1} {5}.{2}=\"{3}\">. Unable to convert value to property of type \"{4}\". Makes sure to include the namespace in the attached property declaration.",
                            GetLineInfo(fileName, attachedProperty),
                            viewObject.Name, attachedProperty.PropertyName, attachedProperty.PropertyValue, attachedProperty.PropertyTypeName, attachedProperty.ParentViewName));
                        continue;
                    }

                    var attachedParentIdVar = inTemplate ? attachedProperty.ParentId.ToLocalVariableName() : attachedProperty.ParentId;
                    sb.AppendLine(indent, "{0}.{1}.SetValue({2}, {3});", attachedParentIdVar, attachedProperty.PropertyName, childIdVar, typeValueInitializer);
                }

                // generate bindings
                if (childViewDeclaration.PropertyBindings.Any())
                {
                    foreach (var propertyBinding in childViewDeclaration.PropertyBindings)
                    {
                        // generate binding path to source
                        var sourceBindingPathObjects = new List<string>();
                        var convertedSourceProperties = new List<string>();
                        var sourceProperties = new List<string>();
                        foreach (var bindingSource in propertyBinding.Sources)
                        {
                            // generate binding path to source
                            var sourcePath = new List<string>();
                            sourcePath.AddRange(bindingSource.BindingPath.Split('.'));

                            // get property names along path
                            var templateItemInfo = templateItems != null
                                ? templateItems.FirstOrDefault(x => x.Name == sourcePath[0])
                                : null;
                            bool isTemplateItemSource = templateItemInfo != null;

                            if (isTemplateItemSource)
                            {
                                if (templateItemInfo.ItemType == null)
                                    continue; // item type was not inferred so ignore binding

                                sourcePath[0] = templateItemInfo.VariableName;
                                sourcePath.Insert(1, "Item");
                            }

                            bool isModelSource = bindingSource.SourceTypes.HasFlag(BindingSourceTypes.Model);
                            string sourcePropertiesStr = string.Join(", ",
                                sourcePath.Skip(isModelSource ? 2 : (isTemplateItemSource ? 1 : 0))
                                    .Select(x => "\"" + x + "\""));

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
                                sourceGetters.Add(String.Format("() => {0}",
                                    string.Join(".", sourcePath.Take(i + sourcePathTake))));
                            }

                            if (isTemplateItemSource)
                            {
                                // in source getters for template items make sure item is cast: () => (tiItem.Item as ItemType).Property
                                sourcePath = sourcePath.Skip(2).ToList();
                                sourcePath.Insert(0,
                                    String.Format("({0}.Item as {1})", templateItemInfo.VariableName,
                                        templateItemInfo.ItemType));
                            }

                            string sourceGettersString = string.Join(", ", sourceGetters);
                            string sourceProperty = string.Join(".", sourcePath);
                            string convertedSourceProperty = sourceProperty;

                            // add converter
                            if (!String.IsNullOrEmpty(bindingSource.Converter))
                            {
                                convertedSourceProperty = String.Format("ValueConverters.{0}.ConvertTo({1})", bindingSource.Converter, sourceProperty);
                            }

                            convertedSourceProperties.Add(convertedSourceProperty);
                            sourceProperties.Add(sourceProperty);
                            sourceBindingPathObjects.Add(String.Format("new BindingPath(new List<string> {{ {0} }}, new List<Func<BindableObject>> {{ {1} }})", sourcePropertiesStr, sourceGettersString));
                        }

                        // generate binding path to target
                        var targetPath = new List<string>();
                        targetPath.Add(childIdVar);
                        targetPath.AddRange(propertyBinding.PropertyName.Split('.'));
                        string targetProperties = string.Join(", ", targetPath.Skip(inTemplate ? 1 : 0).Select(x => "\"" + x + "\""));

                        List<string> targetGetters = new List<string>();
                        if (!inTemplate)
                        {
                            targetGetters.Add("() => this");
                        }
                        for (int i = 0; i < targetPath.Count - 1; ++i)
                        {
                            targetGetters.Add(String.Format("() => {0}", string.Join(".", targetPath.Take(i + 1))));
                        }

                        string targetGettersString = string.Join(", ", targetGetters);
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
                                convertedTargetProperty = String.Format("ValueConverters.{0}.ConvertTo({1})", bindingSource.Converter, targetProperty);
                            }
                        }

                        string sourceToTarget = "";
                        string targetToSource = "{ }";
                        switch (propertyBinding.BindingType)
                        {
                            case BindingType.SingleBinding:
                            default:
                                sourceToTarget = String.Format("{0} = {1}", targetProperty, convertedSourceProperties.First());
                                targetToSource = isTwoWay ? string.Format("{0} = {1}", sourceProperties.First(), convertedTargetProperty) : "{ }";
                                break;

                            case BindingType.MultiBindingTransform:
                                sourceToTarget = string.Format("{0} = {1}({2})", targetProperty, propertyBinding.TransformMethod, string.Join(", ", convertedSourceProperties));
                                break;

                            case BindingType.MultiBindingFormatString:
                                sourceToTarget = string.Format("{0} = String.Format(\"{1}\", {2})", targetProperty, propertyBinding.FormatString, string.Join(", ", convertedSourceProperties));
                                break;
                        }

                        // print smart binding
                        sb.AppendLine();
                        sb.AppendLine(indent, "// binding <{0} {1}=\"{2}\">", childViewDeclaration.ViewName, propertyBinding.PropertyName, propertyBinding.PropertyBindingString);
                        sb.AppendLine(indent,
                            "{0}Bindings.Add(new Binding(new List<BindingPath> {{ {1} }}, {2}, () => {3}, () => {4}, {5}));",
                            inTemplate ? firstTemplateChild + "." : "",
                            string.Join(", ", sourceBindingPathObjects),
                            String.Format(
                                "new BindingPath(new List<string> {{ {0} }}, new List<Func<BindableObject>> {{ {1} }})",
                                targetProperties, targetGettersString),
                            sourceToTarget,
                            targetToSource,
                            isTwoWay ? "true" : "false");
                    }
                }

                var childTemplateDepth = templateDepth;
                if (templateContent)
                {
                    ++childTemplateDepth;

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

                        ti.ItemType = GetItemTypeFromDeclaration(fileName, viewObject, itemIdDeclaration, templateItems, childViewDeclaration);
                    }

                    sb.AppendLine();
                    sb.AppendLine(indent, "// Template for {0}", childIdVar);
                    sb.AppendLine(indent, "{0}.ContentTemplate = new ContentTemplate({1} => ", childIdVar, ti != null ? ti.VariableName : "x" + templateDepth.ToString());
                    sb.AppendLine(indent, "{{");
                }

                var firstChildInTemplate = childViewDeclaration.ChildDeclarations.FirstOrDefault();
                var childFirstTemplateChild = firstTemplateChild;
                if (templateContent && firstChildInTemplate != null)
                {
                    childFirstTemplateChild = firstChildInTemplate.Id.ToLocalVariableName();
                }

                // print child view declaration
                GenerateChildViewDeclarations(viewObject.FilePath, viewObject, sb, parentViewType, childViewDeclaration, childViewDeclaration.ChildDeclarations, childIdVar, childTemplateDepth, templateItems, childFirstTemplateChild);

                if (templateContent)
                {
                    sb.AppendLine(indent, "    return {0};", firstChildInTemplate != null ? childFirstTemplateChild : "null");
                    sb.AppendLine(indent, "}});");
                }
            }
        }

        /// <summary>
        /// Gets item type from item declaration.
        /// </summary>
        private static string GetItemTypeFromDeclaration(string fileName, ViewObject viewObject, PropertyBinding itemIdDeclaration, List<TemplateItemInfo> templateIdInfo, ViewDeclaration viewDeclaration)
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
            int startIndex = 1;
            if (sourcePath[0] != "Models")
            {
                sourceType = TypeHelper.GetType(viewObject.TypeName);
                startIndex = 0;
            }

            // loop through each property and infer their type
            var bindableCollectionBase = typeof(BindableCollection);
            for (int i = startIndex; i < sourcePath.Count; ++i)
            {
                var memberInfo = sourceType.GetMemberInfo(sourcePath[i], BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
                if (memberInfo == null)
                {
                    Debug.LogError(String.Format("[Delight] {0}: Unable to infer item type in binding <{1} {2}=\"{3}\">. Member \"{4}\" not found in type \"{5}\".",
                        GetLineInfo(fileName, itemIdDeclaration),
                        viewDeclaration.ViewName, itemIdDeclaration.PropertyName, itemIdDeclaration.PropertyBindingString,
                        sourcePath[i], sourceType.Name));
                    return null;
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
        public static List<InitializerProperty> GetPropertyInitializers(ViewObject viewObject)
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
        public static List<PropertyDeclarationInfo> GetPropertyDeclarations(ViewObject viewObject, bool includeInheritedDeclarations, bool includeMappedProperties, bool includeNonDefaultProperties)
        {
            // gets all dependency property declarations in the view
            var propertyDeclarations = new List<PropertyDeclarationInfo>();
            foreach (var declaration in viewObject.PropertyExpressions.OfType<PropertyDeclaration>())
            {
                if (!includeNonDefaultProperties && declaration.DeclarationType != PropertyDeclarationType.Default)
                {
                    continue;
                }

                propertyDeclarations.Add(new PropertyDeclarationInfo
                {
                    Declaration = declaration,
                    IsAssetReference = declaration.DeclarationType == PropertyDeclarationType.Asset,
                    AssetType = declaration.AssetType
                });
            }

            if (includeMappedProperties)
            {
                UpdateMappedProperties(viewObject);
                foreach (var mappedProperty in viewObject.MappedPropertyDeclarations)
                {
                    propertyDeclarations.Add(new PropertyDeclarationInfo
                    {
                        IsMapped = true,
                        IsAssetReference = mappedProperty.IsAssetReference,
                        AssetType = mappedProperty.AssetType,
                        TargetObjectName = mappedProperty.TargetObjectName,
                        TargetPropertyName = mappedProperty.TargetPropertyName,
                        Declaration = new PropertyDeclaration
                        {
                            PropertyName = mappedProperty.PropertyName,
                            PropertyTypeName = mappedProperty.TargetPropertyTypeFullName,
                            PropertyTypeFullName = mappedProperty.TargetPropertyTypeFullName,
                            DeclarationType = mappedProperty.IsViewReference ? PropertyDeclarationType.View : PropertyDeclarationType.Default,
                            AssemblyQualifiedType = mappedProperty.TargetAssemblyQualifiedType
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
        /// Updates property information in the view object.
        /// </summary>
        private static void UpdateMappedProperties(ViewObject viewObject)
        {
            if (viewObject.HasUpdatedItsMappedProperties)
                return;

            viewObject.HasUpdatedItsMappedProperties = true;
            var propertyDeclarations = GetPropertyDeclarations(viewObject, true, false, true);
            var propertyNames = propertyDeclarations.Select(x => x.Declaration.PropertyName).ToList();
            var propertyMappings = viewObject.PropertyExpressions.OfType<PropertyMapping>();
            var propertyRenames = viewObject.PropertyExpressions.OfType<PropertyRename>();

            // calculate mapped dependency properties
            foreach (var propertyMapping in propertyMappings)
            {
                // find property declaration
                var propertyDeclaration = propertyDeclarations.FirstOrDefault(x => x.Declaration.PropertyName.IEquals(propertyMapping.TargetObjectName));
                if (propertyDeclaration == null)
                {
                    Debug.LogError(String.Format("[Delight] {0}: Invalid property mapping <{1} m.{2}=\"{3}\">. The property \"{2}\" does not exist in this view.", GetLineInfo(viewObject.FilePath, propertyMapping), viewObject.Name, propertyMapping.TargetObjectName, propertyMapping.MapPattern));
                    continue;
                }

                // generate property declarations for the mapping
                if (propertyDeclaration.Declaration.DeclarationType == PropertyDeclarationType.View)
                {
                    // get view reference and generate mappings for its declarations
                    var childViewObject = _contentObjectModel.LoadViewObject(propertyDeclaration.Declaration.PropertyTypeName);
                    var declarations = GetPropertyDeclarations(childViewObject, true, true, false);
                    foreach (var declaration in declarations)
                    {
                        // check if this declaration conflicts with any of the properties in this view, if so add the view-object as a prefix
                        var nonConflictedPropertyName = GetNonConflictedPropertyName(declaration.Declaration.PropertyName,
                            propertyMapping, propertyNames);
                        if (nonConflictedPropertyName == null)
                            continue;
                        propertyNames.Add(nonConflictedPropertyName);

                        // add new mapped property declaration
                        viewObject.MappedPropertyDeclarations.Add(new MappedPropertyDeclaration
                        {
                            TargetPropertyName = declaration.Declaration.PropertyName,
                            TargetPropertyTypeFullName = declaration.Declaration.PropertyTypeFullName,
                            PropertyName = nonConflictedPropertyName,
                            TargetObjectName = propertyMapping.TargetObjectName,
                            TargetObjectType = childViewObject.TypeName, // TODO unsure if this is correct
                            IsViewReference = true,
                            IsAssetReference = declaration.IsAssetReference,
                            AssetType = declaration.AssetType,
                            TargetAssemblyQualifiedType = declaration.Declaration.AssemblyQualifiedType
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
                        Debug.LogError(String.Format("[Delight] {0}: Invalid property mapping <{1} m.{2}=\"{3}\">. The mapped target object of type \"{4}\" could not be found. Make sure the namespace is included in the type name and if the type exist in a separate assembly specify a assembly qualified type name.", GetLineInfo(viewObject.FilePath, propertyMapping), viewObject.Name, propertyMapping.TargetObjectName, propertyMapping.MapPattern, propertyDeclaration.Declaration.PropertyName));
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

                        // check if field is referencing an asset 
                        bool isAssetReference = ContentParser.IsUnityAssetType(field.FieldType);
                        propertyNames.Add(nonConflictedPropertyName);

                        // add new mapped property declaration for field
                        viewObject.MappedPropertyDeclarations.Add(new MappedPropertyDeclaration
                        {
                            TargetPropertyName = field.Name,
                            TargetPropertyTypeFullName = field.FieldTypeName(),
                            PropertyName = nonConflictedPropertyName,
                            TargetObjectName = propertyMapping.TargetObjectName,
                            TargetObjectType = targetObjectType.FullName,
                            IsViewReference = false,
                            IsAssetReference = isAssetReference,
                            AssetType = isAssetReference ? _contentObjectModel.LoadAssetType(field.FieldType, false) : null,
                            TargetAssemblyQualifiedType = field.FieldType.AssemblyQualifiedName
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

                        // check if property is referencing an asset 
                        bool isAssetReference = ContentParser.IsUnityAssetType(property.PropertyType);
                        propertyNames.Add(nonConflictedPropertyName);

                        // add new mapped property declaration for property
                        viewObject.MappedPropertyDeclarations.Add(new MappedPropertyDeclaration
                        {
                            TargetPropertyName = property.Name,
                            TargetPropertyTypeFullName = property.FieldTypeName(),
                            PropertyName = nonConflictedPropertyName,
                            TargetObjectName = propertyMapping.TargetObjectName,
                            TargetObjectType = targetObjectType.FullName,
                            IsViewReference = false,
                            IsAssetReference = isAssetReference,
                            AssetType = isAssetReference ? _contentObjectModel.LoadAssetType(property.PropertyType, false) : null,
                            TargetAssemblyQualifiedType = property.PropertyType.AssemblyQualifiedName
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
        private static bool AnyChildNeedUpdate(ViewObject viewObject, Dictionary<string, bool> viewsChecked)
        {
            var declarations = GetPropertyDeclarations(viewObject, true, false, true);
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
                    var childViewObject = _contentObjectModel.LoadViewObject(declaration.Declaration.PropertyTypeName);
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
        private static bool AnyParentNeedUpdate(ViewObject viewObject)
        {
            if (viewObject.NeedUpdate)
                return true;

            return viewObject.BasedOn != null ? AnyParentNeedUpdate(viewObject.BasedOn) : false;
        }

        /// <summary>
        /// Check if any of the view's parents need to be updated.
        /// </summary>
        private static bool AnyParentHasContentTemplate(ViewObject viewObject)
        {
            if (viewObject.HasContentTemplate)
                return true;

            return viewObject.BasedOn != null ? AnyParentHasContentTemplate(viewObject.BasedOn) : false;
        }

        private class TemplateItemInfo
        {
            public string Name;
            public string VariableName;
            public string ItemType;
            public PropertyBinding ItemIdDeclaration;
        }

        #endregion

        #region Assets

        /// <summary>
        /// Generates asset code. 
        /// </summary>
        public static void GenerateAssetCode()
        {
            Debug.Log("Generating asset code.");
            var sb = new StringBuilder();

            // open the view class
            sb.AppendLine("// Asset data and providers generated from asset content");
            sb.AppendLine("#region Using Statements");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Runtime.CompilerServices;");
            sb.AppendLine("using UnityEngine;");
            sb.AppendLine("using UnityEngine.UI;");
            // TODO allow configuration of namespaces to be included
            sb.AppendLine("#endregion");
            sb.AppendLine();
            sb.AppendLine("namespace {0}", DefaultNamespace);
            sb.AppendLine("{");

            // generate asset bundle data

            var config = MasterConfig.GetInstance();
            var bundles = _contentObjectModel.AssetBundleObjects.Where(x => !x.IsResource).OrderBy(x => x.Name).ToList();
            if (bundles.Count() > 0)
            {
                sb.AppendLine("    #region Asset Bundles");
                sb.AppendLine();
                sb.AppendLine("    public partial class AssetBundleData : DataProvider<AssetBundle>");
                sb.AppendLine("    {");
                sb.AppendLine("        #region Fields");
                sb.AppendLine();

                foreach (var assetBundle in bundles)
                {
                    sb.AppendLine("        public readonly AssetBundle {0};", assetBundle.Name.ToPropertyName());
                }

                sb.AppendLine();
                sb.AppendLine("        #endregion");
                sb.AppendLine();
                sb.AppendLine("        #region Constructor");
                sb.AppendLine();
                sb.AppendLine("        public AssetBundleData()");
                sb.AppendLine("        {");

                foreach (var assetBundle in bundles)
                {
                    bool isStreamed = config.StreamedBundles.IContains(assetBundle.Name);
                    sb.AppendLine("            {0} = new AssetBundle {{ Id = \"{1}\", StorageMode = StorageMode.{2} }};", assetBundle.Name.ToPropertyName(), assetBundle.Name, isStreamed ? "Local" : "Remote");
                }
                sb.AppendLine();
                foreach (var assetBundle in bundles)
                {
                    sb.AppendLine("            Add({0});", assetBundle.Name.ToPropertyName());
                }

                sb.AppendLine("        }");
                sb.AppendLine();
                sb.AppendLine("        #endregion");
                sb.AppendLine("    }");
                sb.AppendLine();
                sb.AppendLine("    #endregion");
            }

            // generate asset object data
            List<UnityAssetObject> assetObjects = _contentObjectModel.AssetBundleObjects.SelectMany(x => x.AssetObjects).ToList();
            foreach (var assetType in _contentObjectModel.AssetTypes)
            {
                if (assetType.Name == "DefaultAsset")
                    continue; // ignore default assets

                var assetObjectsOfType = assetObjects.Where(x => x.Type == assetType).ToList();
                var assetTypeName = assetType.FormattedTypeName;
                var assetTypeNamePlural = assetType.Name.Pluralize();

                sb.AppendLine();
                sb.AppendLine("    #region {0}", assetTypeNamePlural);
                sb.AppendLine();
                sb.AppendLine("    public partial class {0} : AssetObject<{1}>", assetTypeName, assetType.FullName);
                sb.AppendLine("    {");
                sb.AppendLine("    }");
                sb.AppendLine();
                sb.AppendLine("    public partial class {0}Data : DataProvider<{0}>", assetTypeName);
                sb.AppendLine("    {");

                if (assetObjectsOfType.Count > 0)
                {

                    sb.AppendLine("        #region Fields");
                    sb.AppendLine();

                    foreach (var assetObject in assetObjectsOfType)
                    {
                        sb.AppendLine("        public readonly {0} {1};", assetTypeName, assetObject.Name.ToPropertyName());
                    }

                    sb.AppendLine();
                    sb.AppendLine("        #endregion");
                    sb.AppendLine();
                    sb.AppendLine("        #region Constructor");
                    sb.AppendLine();
                    sb.AppendLine("        public {0}Data()", assetTypeName);
                    sb.AppendLine("        {");

                    foreach (var assetObject in assetObjectsOfType)
                    {
                        if (!assetObject.IsResource)
                        {
                            sb.AppendLine("            {0} = new {2} {{ Id = \"{1}\", AssetBundleId = \"{3}\", RelativePath = \"{4}\" }};", assetObject.Name.ToPropertyName(), assetObject.Name, assetTypeName, assetObject.AssetBundleName, assetObject.RelativePath);
                        }
                        else
                        {
                            sb.AppendLine("            {0} = new {2} {{ Id = \"{1}\", IsResource = true, RelativePath = \"{3}\" }};", assetObject.Name.ToPropertyName(), assetObject.Name, assetTypeName, assetObject.RelativePath);
                        }
                    }
                    sb.AppendLine();
                    foreach (var assetObject in assetObjectsOfType)
                    {
                        sb.AppendLine("            Add({0});", assetObject.Name.ToPropertyName());
                    }

                    sb.AppendLine("        }");
                    sb.AppendLine();
                    sb.AppendLine("        #endregion");
                }
                sb.AppendLine("    }");
                sb.AppendLine();

                sb.AppendLine("    public static partial class Assets");
                sb.AppendLine("    {");
                sb.AppendLine("        public static {0}Data {1} = new {0}Data();", assetTypeName, assetTypeNamePlural);
                sb.AppendLine("    }");
                sb.AppendLine();
                sb.AppendLine("    #endregion");
            }

            // close namespace
            sb.AppendLine("}");

            // write file
            string path = String.Format("{0}/Delight/Content{1}", Application.dataPath, ContentParser.AssetsFolder);
            var sourceFile = String.Format("{0}Assets_g.cs", path);

            Debug.Log("Creating " + sourceFile);
            File.WriteAllText(sourceFile, sb.ToString());
        }

        #endregion

        #region Models

        /// <summary>
        /// Generates model code.
        /// </summary>
        public static void GenerateModelCode()
        {
            // update all model objects that are changed            
            foreach (var modelObject in _contentObjectModel.ModelObjects)
            {
                if (!modelObject.NeedUpdate)
                    continue;

                // generate model code    
                GenerateModelCode(modelObject);

                modelObject.NeedUpdate = false;
            }
        }

        /// <summary>
        /// Generates model code.
        /// </summary>
        public static void GenerateModelCode(ModelObject modelObject)
        {
            Debug.Log("Generating code for model \"" + modelObject.Name + "\"");

            string schemaFilename = Path.GetFileName(modelObject.SchemaFilePath);
            var ns = !String.IsNullOrEmpty(modelObject.Namespace) ? modelObject.Namespace : DefaultNamespace;

            // build the internal codebehind for the view
            var sb = new StringBuilder();

            // open the view class
            sb.AppendLine("// Model generated from \"{0}\"", schemaFilename);
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
            sb.AppendLine("    public partial class {0} : ModelObject", modelObject.Name);
            sb.AppendLine("    {");

            // generate model properties

            sb.AppendLine("        #region Properties");

            foreach (var property in modelObject.Properties)
            {
                var field = property.Name.ToPrivateMemberName();
                var typeName = property.TypeName;

                // see if property references a model or collection of models
                bool isModelReference = _contentObjectModel.ModelObjects.Any(x => x.Name.IEquals(typeName));
                var modelCollectionObject = _contentObjectModel.ModelObjects.FirstOrDefault(x => x.PluralName.IEquals(typeName));
                bool isAssetReference = _contentObjectModel.AssetTypes.Any(x => x.Name.IEquals(typeName));
                property.IsModelReference = isModelReference;

                if (isModelReference)
                {
                    sb.AppendLine();
                    sb.AppendLine("        public string {0}Id {{ get; set; }}", property.Name);
                    sb.AppendLine("        public {0} {1}", typeName, property.Name);
                    sb.AppendLine("        {");
                    sb.AppendLine("            get {{ return Models.{0}[{1}Id]; }}", typeName.Pluralize(), property.Name);
                    sb.AppendLine("            set {{ {0}Id = value?.Id; }}", property.Name);
                    sb.AppendLine("        }");
                }
                else if (modelCollectionObject != null)
                {
                    sb.AppendLine();
                    sb.AppendLine("        public BindableCollection<{0}> {1}", modelCollectionObject.Name, property.Name);
                    sb.AppendLine("        {");
                    sb.AppendLine("            get {{ return Models.{0}.Get(this); }}", property.Name);
                    sb.AppendLine("        }");
                }
                else if (isAssetReference)
                {
                    sb.AppendLine();
                    sb.AppendLine("        public string {0}Id {{ get; set; }}", property.Name);
                    sb.AppendLine("        public {0}Asset {1}", typeName, property.Name);
                    sb.AppendLine("        {");
                    sb.AppendLine("            get {{ return Assets.{0}[{1}Id]; }}", typeName.Pluralize(), property.Name);
                    sb.AppendLine("            set {{ {0}Id = value?.Id; }}", property.Name);
                    sb.AppendLine("        }");
                }
                else
                {
                    sb.AppendLine();
                    sb.AppendLine("        private {0} {1};", typeName, field);
                    sb.AppendLine("        public {0} {1}", typeName, property.Name);
                    sb.AppendLine("        {");
                    sb.AppendLine("            get {{ return {0}; }}", field);
                    sb.AppendLine("            set {{ SetProperty(ref {0}, value); }}", field);
                    sb.AppendLine("        }");
                }
            }

            sb.AppendLine();
            sb.AppendLine("        #endregion");

            // close the view class
            sb.AppendLine("    }");

            // generate data provider
            sb.AppendLine();
            sb.AppendLine("    #region Data Provider");
            sb.AppendLine();

            sb.AppendLine("    public partial class {0}Data : DataProvider<{0}>", modelObject.Name);
            sb.AppendLine("    {");

            if (modelObject.Data.Any())
            {
                // generate data inserts
                sb.AppendLine("        #region Constructor");
                sb.AppendLine();

                sb.AppendLine("        public {0}Data()", modelObject.Name);
                sb.AppendLine("        {");

                var config = MasterConfig.GetInstance();
                foreach (var modelData in modelObject.Data)
                {
                    // make sure data applies to active build target
                    if (modelData.BuildTargets.Any())
                    {
                        if (!config.BuildTargets.Any(x => modelData.BuildTargets.IContains(x)))
                        {
                            continue; // build target don't match
                        }
                    }

                    // add data
                    var propertySetters = new List<string>();
                    if (!String.IsNullOrEmpty(modelData.Id))
                    {
                        propertySetters.Add(String.Format("Id = \"{0}\"", modelData.Id));
                    }

                    foreach (var propertyData in modelData.PropertyData)
                    {
                        if (propertyData.Property.IsModelReference)
                        {
                            propertySetters.Add(String.Format("{0}Id = \"{1}\"", propertyData.Property.Name, propertyData.PropertyValue));
                            continue;
                        }

                        // get initializer for property type
                        string typeInitializer = GetInitializerForType(propertyData.Property.TypeName, propertyData.PropertyValue);
                        if (typeInitializer == null)
                        {
                            // no initializer found for the type being assigned to
                            Debug.LogError(String.Format("[Delight] {0} ({1}): Unable to insert data for property \"{2}\". No value initializer found for property type \"{3}\".",
                                modelObject.SchemaFilePath, propertyData.Line, propertyData.Property.Name, propertyData.Property.TypeName));
                            continue;
                        }

                        propertySetters.Add(String.Format("{0} = {1}", propertyData.Property.Name, typeInitializer));
                    }

                    sb.AppendLine("            Add(new {0} {{ {1} }});", modelObject.Name, String.Join(", ", propertySetters));
                }

                sb.AppendLine("        }");
                sb.AppendLine();

                sb.AppendLine("        #endregion");
            }

            var sb2 = new StringBuilder();
            if (modelObject.Data.Any()) sb2.AppendLine();
            sb2.AppendLine("        #region Methods");
            sb2.AppendLine();
            bool referencedInOtherModels = false;

            // check if this data model is referenced in other models, if so add Get methods retrieve a collection subset
            var modelReferences = new List<ModelObject>();
            foreach (var model in _contentObjectModel.ModelObjects)
            {
                var sourceProperty = model.Properties.FirstOrDefault(x => x.TypeName.IEquals(modelObject.PluralName));
                if (sourceProperty == null)
                    continue;

                referencedInOtherModels = true;
                var localModelName = model.Name.ToLocalVariableName();
                var localCollectionSubsetName = String.Format("{0}{1}", localModelName, modelObject.PluralName);
                var collectionSubsetName = String.Format("_{0}", localCollectionSubsetName);

                // TODO see if filter method or target property is specified

                var targetProperty = modelObject.Properties.FirstOrDefault(x => x.TypeName.IEquals(model.Name));
                string targetPropertyFilter = targetProperty != null ?
                    String.Format("x.{0}Id == {1}Id", targetProperty.Name, localModelName) : "true";
                string targetPropertySetter = targetProperty != null ?
                    String.Format("x.{0}Id = {1}Id", targetProperty.Name, localModelName) : "{{ }}";

                sb2.AppendLine(2, "protected Dictionary<string, BindableCollectionSubset<{0}>> {1} = new Dictionary<string, BindableCollectionSubset<{0}>>();", modelObject.Name, collectionSubsetName);
                sb2.AppendLine(2, "public virtual BindableCollectionSubset<{0}> Get({1} {2})", modelObject.Name, model.Name, model.Name.ToLocalVariableName());
                sb2.AppendLine(2, "{{");
                sb2.AppendLine(2, "    if ({0} == null)", localModelName);
                sb2.AppendLine(2, "        return null;");
                sb2.AppendLine();
                sb2.AppendLine(2, "    string {0}Id = {0}.Id;", localModelName);
                sb2.AppendLine(2, "    BindableCollectionSubset<{0}> {1};", modelObject.Name, localCollectionSubsetName);
                sb2.AppendLine(2, "    if ({0}.TryGetValue({1}Id, out {2}))", collectionSubsetName, localModelName, localCollectionSubsetName);
                sb2.AppendLine(2, "        return {0};", localCollectionSubsetName);
                sb2.AppendLine();
                sb2.AppendLine(2, "    {0} = new BindableCollectionSubset<{1}>(this, x => {2}, x => {3});", localCollectionSubsetName, modelObject.Name,
                    targetPropertyFilter, targetPropertySetter);
                sb2.AppendLine(2, "    {0}.Add({1}Id, {2});", collectionSubsetName, localModelName, localCollectionSubsetName);
                sb2.AppendLine(2, "    return {0};", localCollectionSubsetName);
                sb2.AppendLine(2, "}}");
                sb2.AppendLine();
            }


            sb2.AppendLine("        #endregion");

            if (referencedInOtherModels)
                sb.Append(sb2.ToString());

            // TODO generate Get methods by checking if any other model references this one 

            sb.AppendLine("    }");

            sb.AppendLine();
            sb.AppendLine("    public static partial class Models", modelObject.Name);
            sb.AppendLine("    {");
            sb.AppendLine("        public static {0}Data {1} = new {0}Data();", modelObject.Name, modelObject.PluralName);
            sb.AppendLine("    }");

            sb.AppendLine();
            sb.AppendLine("    #endregion");

            // close namespace
            sb.AppendLine("}");

            // write file
            var dir = MasterConfig.GetFormattedPath(Path.GetDirectoryName(modelObject.SchemaFilePath));
            var sourceFile = String.Format("{0}/{1}_g.cs", dir, modelObject.Name);

            Debug.Log("Creating " + sourceFile);
            File.WriteAllText(sourceFile, sb.ToString());
        }

        /// <summary>
        /// Gets initializer for the specified type.
        /// </summary>
        private static string GetInitializerForType(string typeName, string propertyValue)
        {
            var typeValueInitializer = ValueConverters.GetInitializer(typeName, propertyValue);
            if (!String.IsNullOrEmpty(typeValueInitializer))
                return typeValueInitializer;

            // see if type name refers to an asset type
            var assetType = _contentObjectModel.AssetTypes.FirstOrDefault(x => x.Name.IEquals(typeName));
            if (assetType != null)
            {
                // use default initializer for asset types
                return String.Format("Assets.{0}[\"{1}\"]", assetType.Name.Pluralize(), propertyValue);
            }

            // see if type is enum
            var type = TypeHelper.GetType(typeName);
            if (type != null && type.IsEnum)
            {
                // generate generic initializer for enum type
                return String.Format("{0}.{1}", typeName, Enum.Parse(type, propertyValue, true));
            }

            return null; // no initializer found for type
        }

        #endregion

        #region Config

        /// <summary>
        /// Generates model code.
        /// </summary>
        public static void GenerateConfigCode()
        {
            Debug.Log("Generating config code.");

            var sb = new StringBuilder();
            var config = MasterConfig.GetInstance();

            // generate the config class
            sb.AppendLine("// Configuration generated from config files");
            sb.AppendLine("#region Using Statements");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Runtime.CompilerServices;");
            sb.AppendLine("using UnityEngine;");
            sb.AppendLine("using UnityEngine.UI;");
            sb.AppendLine("#endregion");
            sb.AppendLine();
            sb.AppendLine("namespace {0}", DefaultNamespace);
            sb.AppendLine("{");
            sb.AppendLine("    public static partial class Config");
            sb.AppendLine("    {");
            sb.AppendLine("        static Config()");
            sb.AppendLine("        {");

            if (!String.IsNullOrEmpty(config.ServerUri))
            {
                sb.AppendLine("            ServerUri = \"{0}\";", config.ServerUri);
            }

            if (!String.IsNullOrEmpty(config.ServerUriLocator))
            {
                sb.AppendLine("            ServerUriLocator = new {0}();", config.ServerUriLocator);
            }

            sb.AppendLine("            UseSimulatedUriInEditor = {0};", config.UseSimulatedUriInEditor.ToString().ToLower());

            sb.AppendLine("        }");
            sb.AppendLine("    }");

            // close namespace
            sb.AppendLine("}");

            // write file
            string path = String.Format("{0}/Delight/Content/", Application.dataPath);
            var sourceFile = String.Format("{0}Config_g.cs", path);

            Debug.Log("Creating " + sourceFile);
            File.WriteAllText(sourceFile, sb.ToString());
        }

        #endregion
    }
}

