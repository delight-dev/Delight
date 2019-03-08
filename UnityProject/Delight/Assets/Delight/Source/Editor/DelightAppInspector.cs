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
    /// Custom inspector for DelightApp component.
    /// </summary>
    [CustomEditor(typeof(DelightApp))]
    public class DelightAppInspector : UnityEditor.Editor
    {
        #region Methods

        /// <summary>
        /// Called when inspector GUI is to be rendered.
        /// </summary>
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

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
                ContentParser.RebuildAssets();
            }
        }

        #endregion
    }
}
