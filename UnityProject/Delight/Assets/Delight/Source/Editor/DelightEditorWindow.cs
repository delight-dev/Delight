#region Using Statements
using Delight.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight.Editor
{
    /// <summary>
    /// Editor window displaying the control panel for the framework.
    /// </summary>
    public class DelightEditorWindow : UnityEditor.EditorWindow
    {
        #region Methods

        /// <summary>
        /// Displays the window.
        /// </summary>
        [MenuItem("Window/Delight")]
        public static void ShowWindow()
        {
            GetWindow(typeof(DelightEditorWindow), false, "Delight");
        }

        /// <summary>
        /// Called when GUI is to be rendered.
        /// </summary>
        public void OnGUI()
        {
            // reload views
            GUIContent reloadViews = new GUIContent("Reload Views", "Parses all views and generates code.");
            if (GUILayout.Button(reloadViews))
            {
                // wait for any uncompiled scripts to be compiled first
                AssetDatabase.Refresh(ImportAssetOptions.ForceSynchronousImport);

                // parse all XML assets
                ContentParser.ParseAllXmlFiles();

                // refresh generated scripts
                AssetDatabase.Refresh();
            }

            // reload asset bundles
            GUIContent generateAssetBundles = new GUIContent("Reload Asset Bundles", "Recreates all asset bundles.");
            if (GUILayout.Button(generateAssetBundles))
            {
            }
        }

        #endregion
    }
}
