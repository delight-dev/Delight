#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Xml.Linq;
using System.Reflection;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text.RegularExpressions;
using Delight.Parser;
#endregion

namespace Delight.Editor
{
    /// <summary>
    /// Processes content assets and generates code.
    /// </summary>
    internal class ContentAssetProcessor : AssetPostprocessor
    {
        #region Methods

        /// <summary>
        /// Processes XML assets that are added/changed and generates code-behind.
        /// </summary>
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            // don't process content assets while playing
            if (Application.isPlaying) 
                return; // TODO either process them or queue them to be processed when the editor is not playing

            // check if any views have been added or changed
            var configuration = Configuration.GetInstance();
            configuration.Sanitize();
            var changedAssets = new List<string>();

            foreach (var path in importedAssets)
            {
                // is the asset in a content folder?
                if (!configuration.ContentFolders.Any(x => path.IIndexOf(x) >= 0))
                    continue; // no.

                if (path.IIndexOf(".xml") >= 0)
                {
                    // content file changed               
                    changedAssets.Add(path);
                }
            }

            // any views updated? 
            if (changedAssets.Count() <= 0)
            {
                return; // no.
            }

            var sw = System.Diagnostics.Stopwatch.StartNew(); // TODO remove

            // parse changed content files and generate code
            ContentParser.ParseXmlFiles(changedAssets);

            // refresh generated scripts
            AssetDatabase.Refresh();

            Debug.Log(String.Format("Total view processing time: {0}", sw.ElapsedMilliseconds)); // TODO remove
        }

        #endregion
    }
}

