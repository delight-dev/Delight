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

            // rebuild all
            GUIContent rebuildAll = new GUIContent("Rebuild All", "Rebuilds all delight content (views, assets, etc).");
            if (GUILayout.Button(rebuildAll))
            {
                ContentParser.RebuildAll(buildAssetBundles);
            }

            var newBuildAssetBundles = EditorGUILayout.Toggle("Build Asset Bundles", EditorPrefs.GetBool("Delight_BuildAssetBundles"));
            if (newBuildAssetBundles != buildAssetBundles)
            {
                EditorPrefs.SetBool("Delight_BuildAssetBundles", newBuildAssetBundles);
            }

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

            // open designer
            //GUIContent openDesigner = new GUIContent("Open Designer", "Opens delight designer.");
            //if (GUILayout.Button(openDesigner))
            //{
            //    EditorSceneManager.OpenScene("Assets/Delight/Scenes/DelightDesigner.unity");
            //}

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
