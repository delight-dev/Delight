#region Using Statements
using Delight.Editor.Parser;
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
    /// Editor window displaying the control panel and configuration of the framework.
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
            // rebuild views
            GUIContent rebuildViews = new GUIContent("Rebuild Views", "Rebuilds all views.");
            if (GUILayout.Button(rebuildViews))
            {
                ContentParser.RebuildViews();
            }

            // rebuild asset bundles
            GUIContent rebuildAssetBundles = new GUIContent("Rebuild Asset Bundles", "Rebuilds all asset bundles.");
            if (GUILayout.Button(rebuildAssetBundles))
            {
                ContentParser.RebuildAssetBundles();
            }

            // show list of asset bundles show name, version, storage mode, load mode and a rebuild button
        }

        #endregion
    }
}
