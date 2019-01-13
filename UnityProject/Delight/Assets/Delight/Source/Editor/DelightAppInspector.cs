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

            // parse all XUML
            GUIContent parseXumlContent = new GUIContent("Parse all XUML files", "Parses all XUML files and generates code.");
            if (GUILayout.Button(parseXumlContent))
            {
                // wait for any uncompiled scripts to be compiled first
                AssetDatabase.Refresh(ImportAssetOptions.ForceSynchronousImport);

                // parse all XUML assets
                XumlParser.ParseAllXumlFiles();

                // refresh generated scripts
                AssetDatabase.Refresh();
            }
        }

        #endregion
    }
}
