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
#endregion

namespace Delight.Editor
{
    /// <summary>
    /// Editor menu items for Delight. 
    /// </summary>
    public class DelightMenuItems
    {
        #region Methods

        [MenuItem("Assets/Create/Delight Scene", false, -20)]
        private static void CreateSceneXml()
        {
            var contentObjectModel = ContentObjectModel.GetInstance();
            var path = ContentParser.GetContentFolderPathFromSelectedFile(ContentParser.ScenesFolder);
            var filename = "";
            int i = 0;
            do
            {
                var sceneName = String.Format("NewScene{0}", i == 0 ? string.Empty : i.ToString());
                filename = String.Format("{0}{1}.xml", path, sceneName);
                ++i;

                // find unique name
                if (!File.Exists(filename))
                {
                    // check if view name exists
                    if (!contentObjectModel.SceneObjects.Any(x => x.Name == sceneName))
                    {
                        // name is valid
                        break;
                    }
                }
            } while (true);

            ProjectWindowUtil.CreateAssetWithContent(filename, string.Empty);
        }

        [MenuItem("Assets/Create/Delight View", false, -19)]
        private static void CreateViewXml()
        {
            CreateViewXml(true);
        }

        //[MenuItem("Assets/Create/Delight View + Code-behind", false, -19)]
        //private static void CreateViewXmlAndCodeBehind()
        //{
        //    CreateViewXml(true);
        //}

        private static void CreateViewXml(bool generateCodeBehind)
        {
            var contentObjectModel = ContentObjectModel.GetInstance();
            var path = ContentParser.GetContentFolderPathFromSelectedFile(ContentParser.ViewsFolder);
            var filename = "";
            int i = 0;
            string viewName = "";
            do
            {
                viewName = String.Format("NewView{0}", i == 0 ? string.Empty : i.ToString());
                filename = String.Format("{0}{1}.xml", path, viewName);
                ++i;

                // find unique name
                if (!File.Exists(filename))
                {
                    // check if view name exists
                    if (!contentObjectModel.ViewObjects.Any(x => x.Name == viewName))
                    {
                        // name is valid
                        break;
                    }
                }
            } while (true);

            // set indicator to generate code-behind once file is renamed
            if (generateCodeBehind)
            {
                var config = MasterConfig.GetInstance();
                config.GenerateBlankCodeBehind = true;
                config.SaveConfig();
            }

            // create XML file that the user will be allowed to name, once created the XML parser will generate the content
            ProjectWindowUtil.CreateAssetWithContent(filename, string.Empty);
        }

        #endregion
    }
}
