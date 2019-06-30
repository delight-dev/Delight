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
            var path = GetContentFolderPathFromSelectedFile(ContentParser.ScenesFolder);
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
            CreateViewXml(false);
        }

        [MenuItem("Assets/Create/Delight View + Code-behind", false, -19)]
        private static void CreateViewXmlAndCodeBehind()
        {
            CreateViewXml(true);
        }

        private static void CreateViewXml(bool generateCodeBehind)
        {
            var contentObjectModel = ContentObjectModel.GetInstance();
            var path = GetContentFolderPathFromSelectedFile(ContentParser.ViewsFolder);
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

            ProjectWindowUtil.CreateAssetWithContent(filename, string.Empty);
            if (generateCodeBehind)
            {
                CodeGenerator.GenerateBlankCodeBehind(viewName, filename);
            }
        }

        public static string GetContentFolderPathFromSelectedFile(string contentFolder)
        {
            // rules: 
            //   1. if we are in the correct specific content subfolder, create the file at that path
            //   2. if we are in a content folder but not in the right specific content subfolder, create the file in that content folder in the right specific subfolder
            //   3. if we aren't in a content folder create the file in the default specific content folder

            var config = MasterConfig.GetInstance();
            string defaultPath = config.ContentFolders.FirstOrDefault() + contentFolder.Substring(1);

            var obj = Selection.activeObject;
            if (obj == null)
                return defaultPath;

            string path = AssetDatabase.GetAssetPath(obj.GetInstanceID());
            if (!Directory.Exists(path))
            {
                // remove filename from path
                path = path.Substring(0, path.LastIndexOf("/") + 1);
            }
            else
            {
                // make sure path ends with "/"
                path = MasterConfig.SanitizePath(path);
            }

            // is the asset in a content folder?
            var inContentFolder = config.ContentFolders.FirstOrDefault(x => path.IIndexOf(x) >= 0);
            if (inContentFolder == null)
                return defaultPath; // no. return default path

            // is the asset in the correct subfolder?
            if (!ContentAssetProcessor.IsInContentTypeFolder(path, inContentFolder, contentFolder))
            {
                // no. adjust path to correct subfolder
                path = inContentFolder + ContentParser.ViewsFolder.Substring(1);
            }

            return path;
        }

        #endregion
    }
}
