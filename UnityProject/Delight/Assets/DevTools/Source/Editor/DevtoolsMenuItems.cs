#region Using Statements
using Delight.Editor.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Delight;
using UnityEditor.Graphs;
#endregion

namespace Delight.Editor
{
    /// <summary>
    /// Editor menu items for Delight developer tools. 
    /// </summary>
    public class DevToolsMenuItems
    {
        #region Methods

        /// <summary>
        /// Generates API .md docs from documentation XML, for the delight-dev.github.io website.
        /// </summary>
        [MenuItem("Window/Delight - Generate Documentation", false, 0)]
        public static void GenerateDocumentation()
        {
            // Creates API documentation from documentation XML. 
            // To generate the documenation XML add the following to the Assembly-CSharp.csproj file in first PropertyGroup:
            // <DocumentationFile>Assets\DevTools\Docs\Documentation.XML</DocumentationFile>
            // And build the solution to generate the documentation XML. 
            // If the docs aren't built you might need to enable full builds by setting Tools -> Options -> Tools for Unity -> Disable the full build for unity, to false
            // Then the API docs can be built through the Delight menu item.

            // parse Assets\DevTools\Docs\Documentation.XML
            var docFile = "Assets/DevTools/Docs/Documentation.XML";
            var basePath = @"C:\Projects\GitProjects\delight-dev.github.io";
            var outputPath = basePath + @"\Api";
            var examplesPath = basePath + @"\_includes\Examples";

            if (!File.Exists(docFile))
            {
                Debug.Log(String.Format("#Delight# Unable to generate API documentation. Couldn't find XML docs at \"{0}\". To generate XML docs add the following to the Assembly-CSharp.csproj file in first PropertyGroup:{1}{1}<DocumentationFile>Assets\\DevTools\\Docs\\Documentation.XML</DocumentationFile>{1}{1}And build the solution to generate the documentation XML, then the API docs can be generated.", docFile, Environment.NewLine));
                return;
            }

            var documentationXml = File.ReadAllText("Assets/DevTools/Docs/Documentation.XML");
            XElement xmlElement = null;
            try
            {
                xmlElement = XElement.Parse(documentationXml);
            }
            catch (Exception e)
            {
                Debug.Log(String.Format("#Delight# Unable to generate API documentation. Couldn't parse the XML docs at \"{0}\". Exception thrown: " + e.ToString()));
                return;
            }

            var docData = new List<DocData>();
            var contentObjectModel = ContentObjectModel.GetInstance();

            // parse XML comments and create document data objects
            foreach (var element in xmlElement.Descendants("member").Where(x => x.Attribute("name").Value.StartsWith("T:")))
            {
                var data = new DocData();
                data.FullTypeName = element.Attribute("name").Value.Substring(2);
                data.TypeName = data.FullTypeName.Substring(data.FullTypeName.LastIndexOf(".") + 1);
                data.HtmlTypeName = data.TypeName.Replace("`1", "<T>");
                data.View = contentObjectModel.ViewObjects?.FirstOrDefault(x => x.TypeName == data.TypeName);
                data.IsType = true;
                data.FileName = String.Format("{0}", data.TypeName.Replace("`1", "T"));

                // add summary
                data.Summary = element.Element("summary").Value.Trim();

                // add description
                var description = element.Element("d");
                if (description != null)
                {
                    data.Description = description.Value.Trim();
                }

                // find all fields associated with this type
                var fields = xmlElement.Descendants("member").Where(x => x.Attribute("name").Value.StartsWith(String.Format("F:{0}.", data.FullTypeName)) ||
                         x.Attribute("name").Value.StartsWith(String.Format("P:{0}.", data.FullTypeName)));
                foreach (var field in fields)
                {
                    string fieldName = string.Empty;

                    try
                    {
                        // get field summaries and descriptions
                        fieldName = field.Attribute("name").Value.Substring(2 + data.FullTypeName.Length + 1);
                        if (fieldName.Count(x => x == '.') > 0)
                            continue;

                        data.FieldSummaries.Add(fieldName, field.Element("summary").Value.Trim());

                        var fieldDescription = field.Element("d");
                        if (fieldDescription != null)
                        {
                            data.FieldDescriptions.Add(fieldName, fieldDescription.Value.Trim());
                        }

                        var fieldActionData = field.Element("actionData");
                        if (fieldActionData != null)
                        {
                            data.FieldActionData.Add(fieldName, fieldActionData.Value.Trim());
                        }

                        // get mapped view field summaries and descriptions
                        foreach (var mappedSummary in field.Elements("maps"))
                        {
                            var mapField = mappedSummary.Attribute("field").Value;
                            data.FieldSummaries.Add(mapField, mappedSummary.Value.Trim());
                            data.MappedFields.Add(mapField);
                        }

                        foreach (var mappedDescription in field.Elements("mapd"))
                        {
                            var mapField = mappedDescription.Attribute("field").Value;
                            data.FieldDescriptions.Add(mapField, mappedDescription.Value.Trim());
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.LogError(String.Format("#Delight# Error generating documentation for {0}, when processing field {1}. {2}", data.HtmlTypeName, fieldName, e.ToString()));
                    }
                }

                docData.Add(data);
                //Debug.LogFormat("{0}: {1}", data.FileName, data.HtmlTypeName);
            }

            System.IO.Directory.CreateDirectory(outputPath);

            // sort by name
            docData = docData.OrderBy(x => x.TypeName).ToList();

            // generate TOC for views and types
            var viewDocs = docData.Where(x => x.IsView);
            var typesDocs = docData.Where(x => !x.IsView);

            // generate view content documentation
            int viewCount = 0;
            foreach (var viewDoc in viewDocs)
            {
                var sb = new StringBuilder();

                // section: header
                sb.AppendLine("---");
                sb.AppendLine("title: {0}", viewDoc.View.Name);
                sb.AppendLine("parent: Views");
                sb.AppendLine("grand_parent: API");
                sb.AppendLine("nav_order: {0}", viewCount);
                sb.AppendLine("---");

                // section: title
                sb.AppendLine();
                sb.AppendLine("# {0}", viewDoc.View.Name);

                // section: based on
                if (!String.IsNullOrEmpty(viewDoc.View.BasedOn?.Name))
                {
                    sb.AppendLine();
                    sb.AppendLine("Based on [{0}]({0})", viewDoc.View.BasedOn?.Name);
                }

                // section: description
                if (!String.IsNullOrEmpty(viewDoc.Summary))
                {
                    sb.AppendLine();
                    sb.AppendLine("## Description");
                    sb.AppendLine();
                    sb.AppendLine("{0}", !String.IsNullOrEmpty(viewDoc.Description) ? viewDoc.Description : viewDoc.Summary);
                }

                // section: examples
                // check if example .md file exist for view
                if (File.Exists(String.Format("{0}/Views/{1}Examples.md", examplesPath, viewDoc.FileName)))
                {
                    // create markdown file include
                    sb.AppendLine();
                    sb.AppendLine("{{% capture {0}Examples %}}{{% include Examples/Views/{0}Examples.md %}}{{% endcapture %}}", viewDoc.FileName);
                    sb.AppendLine("{{{{ {0}Examples | markdownify }}}}", viewDoc.FileName);
                }

                // section: dependency properties
                var propertyDeclarations = CodeGenerator.GetPropertyDeclarations(viewDoc.View, true, true, true);
                if (propertyDeclarations.Count > 0)
                {
                    var dependencyProperties = propertyDeclarations.Where(x => x.Declaration.DeclarationType == PropertyDeclarationType.Default).OrderBy(x => x.Declaration.PropertyName).ToList();
                    if (dependencyProperties.Count > 0)
                    {
                        sb.AppendLine();
                        sb.AppendLine("## Dependency Properties");
                        sb.AppendLine();
                        sb.AppendLine("| Name | Type | Description |");
                        sb.AppendLine("| --- | --- | --- |");

                        foreach (var dependencyProperty in dependencyProperties)
                        {
                            var propertyName = dependencyProperty.Declaration.PropertyName;
                            var propertyTypeName = dependencyProperty.Declaration.PropertyTypeName;
                            int indexOfDot = propertyTypeName.LastIndexOf(".");
                            if (indexOfDot > 0)
                            {
                                propertyTypeName = propertyTypeName.Substring(indexOfDot + 1);
                            }
                            var propertyTypeFullName = dependencyProperty.Declaration.PropertyTypeFullName;
                            var propertyDescription = viewDoc.GetFieldSummary(propertyName);
                            var propertyTypeDoc = docData.FirstOrDefault(x => x.TypeName == propertyTypeName);

                            // get type name
                            if (propertyTypeDoc != null)
                            {
                                propertyTypeName = String.Format("[{0}]({1}{2})", propertyTypeName, propertyTypeDoc.IsView ? "" : "../Types/", propertyTypeDoc.FileName);
                            }
                            else   
                            {
                                // check if it's a unity type
                                // check if the type is a Unity type
                                if (propertyTypeFullName.StartsWith("UnityEngine"))
                                {
                                    // reference the unity docs
                                    propertyTypeName = String.Format("[{0}](http://docs.unity3d.com/ScriptReference/{0}.html)", propertyTypeName);
                                }
                                else
                                {
                                    // replace Boolean, String, Single, Object, etc.
                                    if (propertyTypeName == "Boolean")
                                        propertyTypeName = "bool";
                                    else if (propertyTypeName == "Int32")
                                        propertyTypeName = "int";
                                    else if (propertyTypeName == "Single")
                                        propertyTypeName = "float";
                                    else if (propertyTypeName == "String")
                                        propertyTypeName = "string";
                                    else if (propertyTypeName == "Object")
                                        propertyTypeName = "object";
                                }
                            }

                            // get summary
                            if (String.IsNullOrEmpty(propertyDescription))
                            {
                                // check if summary exist in any of the base types
                                var basedOn = viewDoc.View.BasedOn;
                                while (basedOn != null)
                                {
                                    var basedOnViewDoc = docData.FirstOrDefault(x => x.TypeName == basedOn.TypeName);
                                    if (basedOnViewDoc != null)
                                    {
                                        var basedOnSummary = basedOnViewDoc.GetFieldSummary(propertyName);
                                        if (!String.IsNullOrEmpty(basedOnSummary))
                                        {
                                            propertyDescription = basedOnSummary;
                                            break;
                                        }
                                    }
                                    basedOn = basedOn.BasedOn;
                                }
                            }

                            // print row PropertyName | PropertyType | Description
                            sb.AppendLine("| {0} | {1} | {2} |", propertyName, propertyTypeName, propertyDescription);
                        }
                    }
                }

                viewDoc.DocContent = sb.ToString();
                ++viewCount;
            }

            // generate type content documentation
            int typeCount = 0;
            foreach (var typeDoc in typesDocs)
            {
                var sb = new StringBuilder();

                // section: header
                sb.AppendLine("---");
                sb.AppendLine("title: {0}", typeDoc.HtmlTypeName);
                sb.AppendLine("parent: Types");
                sb.AppendLine("grand_parent: API");
                sb.AppendLine("nav_order: {0}", typeCount);
                sb.AppendLine("---");

                // section: title
                sb.AppendLine();
                sb.AppendLine("# {0}", typeDoc.HtmlTypeName);

                // section: description
                if (!String.IsNullOrEmpty(typeDoc.Summary))
                {
                    sb.AppendLine();
                    sb.AppendLine("## Description");
                    sb.AppendLine();
                    sb.AppendLine("{0}", !String.IsNullOrEmpty(typeDoc.Description) ? typeDoc.Description : typeDoc.Summary);
                }

                typeDoc.DocContent = sb.ToString();
                ++typeCount;
            }

            // generate .md files
            foreach (var doc in docData)
            {
                // write text to file
                File.WriteAllText(String.Format("{0}/{1}/{2}.md", outputPath, doc.IsView ? "Views" : "Types", doc.FileName),
                    doc.DocContent);
            }

            Debug.Log("#Delight# Documentation generated");
        }

        /// <summary>
        /// Generates API doc template file that is used to define XML comments to be added to the dependency properties generated in code-behind.
        /// </summary>
        [MenuItem("Window/Delight - Generate API docs template", false, 0)]
        public static void GenerateApiDocTemplate()
        {
            var sb = new StringBuilder();
            var apiDocsTemplateFile = "Assets/DevTools/Docs/ApiDocs-Template.txt";
            var contentObjectModel = ContentObjectModel.GetInstance();
            var config = MasterConfig.GetInstance();

            // iterate through all views and their dependency properties
            foreach (var viewObject in contentObjectModel.ViewObjects.OrderBy(x => x.Name))
            {
                var docObject = config.DocObjects.FirstOrDefault(x => x.Name == viewObject.Name);
                var propertyDeclarations = CodeGenerator.GetPropertyDeclarations(viewObject, false, true, true).Where(x => x.Declaration.DeclarationType != PropertyDeclarationType.Template &&
                        x.Declaration.DeclarationType != PropertyDeclarationType.View && x.Declaration.DeclarationType != PropertyDeclarationType.UnityComponent).OrderBy(x => x.Declaration.PropertyName);

                string docObjectComment = docObject?.Comment ?? string.Empty;
                sb.AppendLine("{0}: {1}", viewObject.Name, docObjectComment);

                if (!propertyDeclarations.Any())
                    continue;

                foreach (var propertyDeclaration in propertyDeclarations)
                {
                    if (propertyDeclaration.Declaration.DeclarationType == PropertyDeclarationType.Template ||
                        propertyDeclaration.Declaration.DeclarationType == PropertyDeclarationType.View || 
                        propertyDeclaration.Declaration.DeclarationType == PropertyDeclarationType.UnityComponent)
                        continue; // ignore component, template and view properties as we'll generate default docs for those

                    var docProperty = docObject?.Properties.FirstOrDefault(x => x.Name == propertyDeclaration.Declaration.PropertyName);
                    string comment = docProperty?.Comment ?? string.Empty;

                    sb.AppendLine("- {0}: {1}", propertyDeclaration.Declaration.PropertyName, comment);
                }

                sb.AppendLine();
            }

            // write text to file
            File.WriteAllText(apiDocsTemplateFile, sb.ToString());
            Debug.Log(String.Format("#Delight# Documentation generated at \"{0}\"", apiDocsTemplateFile));
        }

        #endregion
    }
}
