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
    /// Unity editor window displaying the control panel.
    /// </summary>
    public class DelightControlPanel : UnityEditor.EditorWindow
    {
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

            // open editor
            GUIContent openEditor = new GUIContent("Open Editor", "Opens delight editor.");
            if (GUILayout.Button(openEditor))
            {
                DelightEditor.Open();
            }

            // TODO show list of asset bundles show name, version, storage mode, load mode and a rebuild button
        }

        #endregion
    }
}
