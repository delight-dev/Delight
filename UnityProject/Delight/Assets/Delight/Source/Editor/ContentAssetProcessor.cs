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
        #region Fields

        public static bool IgnoreChanges = true;

        #endregion

        #region Methods

        /// <summary>
        /// Processes XML assets that are added/changed and generates code-behind.
        /// </summary>
        public static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssets)
        {
            // check if any views have been added or changed
            var config = MasterConfig.GetInstance();

            // xml content
            var addedOrUpdatedXmlAssets = new List<string>();

            // assets
            var addedOrUpdatedAssetObjects = new List<string>();
            var deletedAssetObjects = new List<string>();
            var movedAssetObjects = new List<string>();
            var movedFromAssetObjects = new List<string>();

            // data schemas
            var addedOrUpdatedSchemaObjects = new List<string>();
            var deletedSchemaObjects = new List<string>();
            var movedSchemaObjects = new List<string>();
            var movedFromSchemaObjects = new List<string>();

            bool rebuildConfig = false;
            bool rebuildViews = false;

            // process imported assets
            foreach (var path in importedAssets)
            {
                // is the asset in a content folder?
                var contentFolder = config.ContentFolders.FirstOrDefault(x => path.IIndexOf(x) >= 0);
                if (contentFolder == null)
                    continue; // no.

                // is it an cs file?
                if (path.IIndexOf(".cs") >= 0)
                {
                    continue; // yes. ignore
                }

                // is the asset in the assets folder? 
                if (IsInAssetsFolder(path, contentFolder))
                {
                    addedOrUpdatedAssetObjects.Add(path);
                    continue;
                }

                // is the asset in the models folder?
                if (IsInContentTypeFolder(path, contentFolder, ContentParser.ModelsFolder))
                {
                    if (!path.IContains("Schema"))
                        continue;

                    addedOrUpdatedSchemaObjects.Add(path);
                    continue;
                }

                // is the asset a config file? 
                if (path.IContains(".txt") && path.IContains("Config"))
                {
                    // rebuild config
                    rebuildConfig = true;
                    continue;
                }

                // is the asset in a styles folder?
                if (IsInStylesFolder(path, contentFolder))
                {
                    // yes. rebuild all views
                    rebuildViews = true;
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
                var contentFolder = config.ContentFolders.FirstOrDefault(x => path.IIndexOf(x) >= 0);
                if (contentFolder == null)
                    continue; // no.

                // is it an cs file?
                if (path.IIndexOf(".cs") >= 0)
                {
                    continue; // yes. ignore
                }

                // is the asset in the assets folder? 
                if (IsInAssetsFolder(path, contentFolder))
                {
                    deletedAssetObjects.Add(path);
                    continue;
                }

                // is the asset in the models folder?
                if (IsInContentTypeFolder(path, contentFolder, ContentParser.ModelsFolder))
                {
                    if (!path.IContains("Schema"))
                        continue;

                    deletedSchemaObjects.Add(path);
                    continue;
                }

                // is the asset a config file? 
                if (path.IContains(".txt") && path.IContains("Config"))
                {
                    // rebuild config
                    rebuildConfig = true;
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

                // is it an cs file?
                if (movedToPath.IIndexOf(".cs") >= 0)
                {
                    continue; // yes. ignore
                }

                // is the asset moved to or from a content folder?
                var toContentFolder = config.ContentFolders.FirstOrDefault(x => movedToPath.IIndexOf(x) >= 0);
                var fromContentFolder = config.ContentFolders.FirstOrDefault(x => movedFromPath.IIndexOf(x) >= 0);
                if (toContentFolder == null && fromContentFolder == null)
                    continue; // no.

                // is the asset in the assets folder? 
                bool movedFromAssetFolder = IsInAssetsFolder(movedFromPath, fromContentFolder);
                if (IsInAssetsFolder(movedToPath, toContentFolder) || movedFromAssetFolder)
                {
                    movedAssetObjects.Add(movedToPath);
                    if (movedFromAssetFolder)
                    {
                        movedFromAssetObjects.Add(movedFromPath);
                    }
                    continue;
                }

                // is the asset in the models folder?
                if (IsInContentTypeFolder(movedToPath, toContentFolder, ContentParser.ModelsFolder))
                {
                    if (!movedToPath.IContains("Schema"))
                        continue;

                    movedSchemaObjects.Add(movedToPath);
                    if (IsInContentTypeFolder(movedFromPath, fromContentFolder, ContentParser.ModelsFolder))
                    {
                        movedFromSchemaObjects.Add(movedFromPath);
                    }
                    continue;
                }

                // is the asset a config file? 
                if (movedToPath.IContains(".txt") && movedToPath.IContains("Config"))
                {
                    // rebuild config
                    rebuildConfig = true;
                    continue;
                }

                // is it an xml asset?
                if (movedToPath.IIndexOf(".xml") >= 0)
                {
                    rebuildViews = true;
                }
            }

            bool viewsChanged = addedOrUpdatedXmlAssets.Count() > 0;
            bool assetsChanged = addedOrUpdatedAssetObjects.Count() > 0 || deletedAssetObjects.Count() > 0 || movedAssetObjects.Count() > 0;
            bool schemasChanged = addedOrUpdatedSchemaObjects.Count() > 0 || deletedSchemaObjects.Count() > 0 || movedSchemaObjects.Count() > 0;
            bool contentChanged = assetsChanged || rebuildViews || viewsChanged || schemasChanged || rebuildConfig;
            bool refreshScripts = false;
            bool generateXsdSchema = false;

            // if editor is playing queue assets to be processed after exiting play mode
            if (Application.isPlaying)
            {
                if (contentChanged)
                {
                    Debug.Log("#Delight# Content (View, Assets, etc) changed while editor is playing. Content will be processed after editor exits play mode.");
                    EditorEventListener.AddPostProcessBatch(importedAssets, deletedAssets, movedAssets, movedFromAssets);
                }
                return;
            }

            var sw = System.Diagnostics.Stopwatch.StartNew(); // TODO for tracking processing time

            // check if model file is new, then rebuild all content
            var contentObjectModel = ContentObjectModel.GetInstance();
            if (contentObjectModel.NeedRebuild)
            {
                ContentParser.RebuildAll(true, true, true);
                assetsChanged = false;
                schemasChanged = false;
                rebuildViews = false;
                generateXsdSchema = false;
                viewsChanged = false;
                rebuildConfig = false;
            }

            // any config changed? 
            if (rebuildConfig)
            {
                var result = ContentParser.ParseAllConfigFiles();
                if (result.HasFlag(ConfigParseResult.RebuildAll))
                {
                    ContentParser.RebuildAll(true, true, false);
                    assetsChanged = false;
                    schemasChanged = false;
                    rebuildViews = false;
                    generateXsdSchema = false;
                    viewsChanged = false;
                }
                else 
                {
                    if (result.HasFlag(ConfigParseResult.RebuildSchemas))
                    {
                        ContentParser.ParseAllSchemaFiles();
                        schemasChanged = false;
                    }

                    if (result.HasFlag(ConfigParseResult.RebuildBundles))
                    {
                        ContentParser.RebuildAssets(true);
                        assetsChanged = false;
                        generateXsdSchema = true;
                    }
                }

                refreshScripts = true;
            }

            // any asset objects added, moved or deleted?
            if (assetsChanged)
            {
                ContentParser.ParseAssetFiles(addedOrUpdatedAssetObjects, deletedAssetObjects, movedAssetObjects, movedFromAssetObjects);
                refreshScripts = true;
                generateXsdSchema = true;
            }

            // any schema files added, moved or deleted?
            if (schemasChanged)
            {
                ContentParser.ParseSchemaFiles(addedOrUpdatedSchemaObjects, deletedSchemaObjects, movedSchemaObjects, movedFromSchemaObjects);
                refreshScripts = true;
                generateXsdSchema = true;
            }

            // any xml content moved or deleted? 
            if (rebuildViews)
            {
                // yes. rebuild all views
                ContentParser.RebuildViews();
                refreshScripts = false;
                generateXsdSchema = false;
            }
            else if (viewsChanged)
            {
                // parse new content and generate code
                ContentParser.ParseXmlFiles(addedOrUpdatedXmlAssets);
                refreshScripts = true;
                generateXsdSchema = true;
            }

            if (refreshScripts)
            {
                // refresh generated scripts
                AssetDatabase.Refresh();
            }

            if (generateXsdSchema)
            {
                CodeGenerator.GenerateXsdSchema();
            }

            // TODO for tracking processing time
            if (contentChanged)
            {
                Debug.Log(String.Format("Total content processing time: {0}", sw.ElapsedMilliseconds)); 
            }
        }

        /// <summary>
        /// Returns boolean indicating if file is in assets folder.
        /// </summary>
        public static bool IsInAssetsFolder(string path, string contentFolder)
        {
            if (contentFolder == null)
                return false;

            int assetsFolderIndex = path.ILastIndexOf(ContentParser.AssetsFolder);
            int contentFolderIndex = path.IIndexOf(contentFolder);
            return assetsFolderIndex >= 0 && assetsFolderIndex >= contentFolderIndex;
        }

        /// <summary>
        /// Returns boolean indiciating if file is in styles folder.
        /// </summary>
        public static bool IsInStylesFolder(string path, string contentFolder)
        {
            if (contentFolder == null)
                return false;

            int stylesFolderIndex = path.ILastIndexOf(ContentParser.StylesFolder);
            int contentFolderIndex = path.IIndexOf(contentFolder);
            return stylesFolderIndex >= 0 && stylesFolderIndex >= contentFolderIndex;
        }

        /// <summary>
        /// Returns boolean indiciating if file is in the specified content type folder.
        /// </summary>
        public static bool IsInContentTypeFolder(string path, string contentFolder, string contentTypeFolder)
        {
            if (contentFolder == null)
                return false;

            int contentTypeFolderIndex = path.ILastIndexOf(contentTypeFolder);
            int contentFolderIndex = path.IIndexOf(contentFolder);
            return contentTypeFolderIndex >= 0 && contentTypeFolderIndex >= contentFolderIndex;
        }

        #endregion
    }
}

