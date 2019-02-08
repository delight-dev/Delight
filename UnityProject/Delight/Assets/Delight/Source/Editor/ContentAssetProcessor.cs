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
using Delight.Editor.Parser;
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
        public static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssets)
        {
            // check if any views have been added or changed
            var contentModel = ContentObjectModel.GetInstance();
            var configuration = contentModel.MasterConfigObject;
            var addedOrUpdatedXmlAssets = new List<string>();
            var addedOrUpdatedAssetObjects = new List<string>();
            var deletedAssetObjects = new List<string>();
            var movedAssetObjects = new List<string>();
            var movedFromAssetObjects = new List<string>();
            bool rebuildViews = false;

            // process imported assets
            foreach (var path in importedAssets)
            {
                // is the asset in a content folder?
                var contentFolder = configuration.ContentFolders.FirstOrDefault(x => path.IIndexOf(x) >= 0);
                if (contentFolder == null)
                    continue; // no.

                // is the asset in the assets folder? 
                if (IsInAssetFolder(path, contentFolder))
                {
                    addedOrUpdatedAssetObjects.Add(path);
                    continue;
                }

                // is it an xml asset?
                if (path.IIndexOf(".xml") >= 0)
                {
                    addedOrUpdatedXmlAssets.Add(path);
                }
            }

            // process deleted assets
            foreach (var path in deletedAssets)
            {
                // is the asset in a content folder?
                var contentFolder = configuration.ContentFolders.FirstOrDefault(x => path.IIndexOf(x) >= 0);
                if (contentFolder == null)
                    continue; // no.

                // is the asset in the assets folder? 
                if (IsInAssetFolder(path, contentFolder))
                {
                    deletedAssetObjects.Add(path);
                    continue;
                }

                // is it an xml asset?
                if (path.IIndexOf(".xml") >= 0)
                {
                    rebuildViews = true;
                }
            }

            // process moved assets
            for (int i = 0; i < movedAssets.Length; ++i)
            {
                var movedToPath = movedAssets[i];
                var movedFromPath = movedFromAssets[i];

                // is the asset moved to or from a content folder?
                var toContentFolder = configuration.ContentFolders.FirstOrDefault(x => movedToPath.IIndexOf(x) >= 0);
                var fromContentFolder = configuration.ContentFolders.FirstOrDefault(x => movedFromPath.IIndexOf(x) >= 0);
                if (toContentFolder == null && fromContentFolder == null)
                    continue; // no.

                // is the asset in the assets folder? 
                bool movedFromAssetFolder = IsInAssetFolder(movedFromPath, fromContentFolder);
                if (IsInAssetFolder(movedToPath, toContentFolder) || movedFromAssetFolder)
                {
                    movedAssetObjects.Add(movedToPath);
                    if (movedFromAssetFolder)
                    {
                        movedFromAssetObjects.Add(movedFromPath);
                    }
                    continue;
                }

                // is it an xml asset?
                if (movedToPath.IIndexOf(".xml") >= 0)
                {
                    rebuildViews = true;
                }
            }

            bool assetsChanged = addedOrUpdatedAssetObjects.Count() > 0 || deletedAssetObjects.Count() > 0 || movedAssetObjects.Count() > 0;
            bool viewsChanged = addedOrUpdatedXmlAssets.Count() > 0;
            bool contentChanged = assetsChanged || rebuildViews || viewsChanged;

            // if editor is playing queue assets to be processed after exiting play mode
            if (Application.isPlaying)
            {
                if (contentChanged)
                {
                    Debug.Log("[Delight] ContentAssetProcessor: Content changed while editor is playing. Content will be processed after editor exits play mode.");
                    EditorEventListener.AddPostProcessBatch(importedAssets, deletedAssets, movedAssets, movedFromAssets);
                }
                return;
            }

            var sw = System.Diagnostics.Stopwatch.StartNew(); // TODO for tracking processing time

            // any asset objects added, moved or deleted?
            if (assetsChanged)
            {
                ContentParser.ParseAssetFiles(addedOrUpdatedAssetObjects, deletedAssetObjects, movedAssetObjects, movedFromAssetObjects);
            }

            // any xml content moved or deleted? 
            if (rebuildViews)
            {
                // yes. rebuild all views
                ContentParser.RebuildViews();
            }
            else if (viewsChanged)
            {
                // parse new content and generate code
                ContentParser.ParseXmlFiles(addedOrUpdatedXmlAssets);

                // refresh generated scripts
                AssetDatabase.Refresh();
            }

            // TODO for tracking processing time
            if (contentChanged)
            {
                Debug.Log(String.Format("Total content processing time: {0}", sw.ElapsedMilliseconds)); 
            }
        }

        public static bool IsInAssetFolder(string path, string contentFolder)
        {
            if (contentFolder == null)
                return false;

            int assetFolderIndex = path.ILastIndexOf(ContentParser.AssetsFolder);
            int contentFolderIndex = path.IIndexOf(contentFolder);
            return assetFolderIndex >= 0 && assetFolderIndex >= contentFolderIndex;
        }

        #endregion
    }
}

