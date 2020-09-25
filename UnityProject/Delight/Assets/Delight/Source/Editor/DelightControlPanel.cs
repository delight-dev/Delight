#region Using Statements
using Delight.Editor.Parser;
using System;
using System.Collections.Generic;
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
    /// Unity editor window displaying the control panel.
    /// </summary>
    public class DelightControlPanel : UnityEditor.EditorWindow
    {
        #region Fields
        #endregion

        #region Methods

        /// <summary>
        /// Displays the window.
        /// </summary>
        [MenuItem("Window/Delight")]
        public static void ShowWindow()
        {
            GetWindow(typeof(DelightControlPanel), false, "Delight");
        }

        /// <summary>
        /// Called when GUI is to be rendered.
        /// </summary>
        public void OnGUI()
        {
            bool buildAssetBundles = EditorPrefs.GetBool("Delight_BuildAssetBundles");
            bool deployBuild = EditorPrefs.GetBool("Delight_DeployBuild");

            // rebuild all
            GUIContent rebuildAll = new GUIContent("Rebuild All", "Rebuilds all delight content (views, assets, etc).");
            if (GUILayout.Button(rebuildAll))
            {
                ContentParser.RebuildAll(buildAssetBundles || deployBuild);
            }

            var newBuildAssetBundles = EditorGUILayout.Toggle("Build Asset Bundles", EditorPrefs.GetBool("Delight_BuildAssetBundles"));
            if (newBuildAssetBundles != buildAssetBundles)
            {
                EditorPrefs.SetBool("Delight_BuildAssetBundles", newBuildAssetBundles);
            }

            //var newDeployBuild = EditorGUILayout.Toggle("Rivality Deploy Build", EditorPrefs.GetBool("Delight_DeployBuild"));
            //if (newDeployBuild != deployBuild)
            //{
            //    EditorPrefs.SetBool("Delight_DeployBuild", newDeployBuild);
            //}

            bool disableAutoGenerateViews = EditorPrefs.GetBool("Delight_DisableAutoGenerateViews");
            var newDisableAutoGenerateViews = EditorGUILayout.Toggle("Disable view autogen", disableAutoGenerateViews);
            if (newDisableAutoGenerateViews != disableAutoGenerateViews)
            {
                EditorPrefs.SetBool("Delight_DisableAutoGenerateViews", newDisableAutoGenerateViews);
            }

            bool disableAutoGenerateHandlers = EditorPrefs.GetBool("Delight_DisableAutoGenerateHandlers");
            var newDisableAutoGenerateHandlers = EditorGUILayout.Toggle("Disable handler autogen", disableAutoGenerateHandlers);
            if (newDisableAutoGenerateHandlers != disableAutoGenerateHandlers)
            {
                EditorPrefs.SetBool("Delight_DisableAutoGenerateHandlers", newDisableAutoGenerateHandlers);
            }

            bool disableContentParser = EditorPrefs.GetBool("Delight_DisableAutoContentParser");
            var newDisableContentParser = EditorGUILayout.Toggle("Disable content parser", disableContentParser);
            if (newDisableContentParser != disableContentParser)
            {
                EditorPrefs.SetBool("Delight_DisableAutoContentParser", newDisableContentParser);
            }

            // open designer
            GUIContent openDesigner = new GUIContent("Open Designer", "Opens delight designer.");
            if (GUILayout.Button(openDesigner))
            {
                // check if designer is activated
                var config = MasterConfig.GetInstance();
                if (!config.Modules.Contains("TextMeshPro"))
                {
                    // open window explaining designer need to be activated
                    string message = "The designer need to be activated by enabling TextMeshPro in the project. https://delight-dev.github.io/Tutorials/Designer.html#enabling-the-designer";
                    Application.OpenURL("https://delight-dev.github.io/Tutorials/Designer.html#enabling-the-designer");
                    EditorUtility.DisplayDialog("Enabling the designer", message, "Ok");
                }
                else
                {
                    EditorSceneManager.OpenScene("Assets/Delight/Content/Scenes/DelightDesigner.unity");
                    EditorApplication.isPlaying = true;
                }
            }

            // TODO cleanup
            //GUIContent test = new GUIContent("Test", "");
            //if (GUILayout.Button(test))
            //{
            //    //var config = MasterConfig.GetInstance();
            //    //config.SaveConfig();
            //}
        }

        #endregion
    }
}
