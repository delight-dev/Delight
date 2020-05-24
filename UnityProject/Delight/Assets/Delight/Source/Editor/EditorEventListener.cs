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
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#endregion

namespace Delight.Editor
{
    /// <summary>
    /// Listens to editor application events and synchronizes things in the scene.
    /// </summary>
    [InitializeOnLoad]
    public static class EditorEventListener
    {
        #region Fields

        public static bool QueuedAssetsToBeProcessed = false;
        public static PostprocessAllAssetsBatch PostprocessBatch = new PostprocessAllAssetsBatch();
        public static bool IsInDelightDesigner = false;

        #endregion

        static EditorEventListener()
        {
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
            EditorApplication.hierarchyChanged += OnHierarchyChanged;
        }

        private static void OnHierarchyChanged()
        {
            var activeScene = EditorSceneManager.GetActiveScene();
            if (activeScene.name == "DelightDesigner")
            {
                IsInDelightDesigner = true;
            }
            else
            {
                IsInDelightDesigner = false;
            }
        }

        private static void OnEditorUpdate()
        {
            if (Application.isPlaying)
                return;

            // TODO perform live updates, etc. in edit mode
        }

        private static void OnPlayModeStateChanged(PlayModeStateChange state)
        {
            switch (state)
            {
                case PlayModeStateChange.EnteredEditMode:
                    break;

                case PlayModeStateChange.ExitingEditMode:
                    // generate bundles if necessary
                    var config = MasterConfig.GetInstance();
                    var needBuild = config.AssetsNeedBuild;
                    if (!needBuild)
                        break;

                    var bundles = ContentObjectModel.GetInstance().AssetBundleObjects.Where(x => x.NeedBuild).ToList();
                    if (bundles.Count > 0)
                    {
                        try
                        {
                            ContentAssetProcessor.IgnoreChanges = true;
                            ContentParser.BuildAssetBundles(bundles);
                        }
                        finally
                        {
                            ContentAssetProcessor.IgnoreChanges = false;
                        }
                    }
                    break;

                case PlayModeStateChange.EnteredPlayMode:
                    break;

                case PlayModeStateChange.ExitingPlayMode:
                    bool exitInterrupted = false;
#if DELIGHT_MODULE_TEXTMESHPRO
                    if (IsInDelightDesigner)
                    {
                        //var activeScene = EditorSceneManager.GetActiveScene(); // TODO cleanup

                        // check if delight designer has unsaved progress
                        var viewPresenter = GameObject.Find("/Delight")?.GetComponent<ViewPresenter>();
                        if (viewPresenter == null)
                            break;

                        var delightDesignerView = viewPresenter.PresentedView as DelightDesigner;
                        if (delightDesignerView == null)
                            break;

                        if (delightDesignerView.CheckForUnsavedChanges())
                        {
                            EditorApplication.isPlaying = true;
                            exitInterrupted = true;
                        }
                    }
#endif

                    if (!exitInterrupted && QueuedAssetsToBeProcessed)
                    {
                        // call any queued code processing methods
                        var importedAssets = PostprocessBatch.ImportedAssets.ToArray();
                        var deletedAssets = PostprocessBatch.DeletedAssets.ToArray();
                        var movedAssets = PostprocessBatch.MovedAssets.ToArray();
                        var movedFromAssets = PostprocessBatch.MovedFromAssets.ToArray();
                        PostprocessBatch.Clear();
                        QueuedAssetsToBeProcessed = false;

                        ContentAssetProcessor.ForceProcessing = true;
                        ContentAssetProcessor.OnPostprocessAllAssets(importedAssets, deletedAssets, movedAssets, movedFromAssets);
                        ContentAssetProcessor.ForceProcessing = false;                        
                    }

                    break;
            }
        }

        public static void AddPostProcessBatch(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssets)
        {
            PostprocessBatch.ImportedAssets.AddRange(importedAssets);
            PostprocessBatch.DeletedAssets.AddRange(deletedAssets);
            PostprocessBatch.MovedAssets.AddRange(movedAssets);
            PostprocessBatch.MovedFromAssets.AddRange(movedFromAssets);
            QueuedAssetsToBeProcessed = true;
        }
    }

    public class PostprocessAllAssetsBatch
    {
        public HashSet<string> ImportedAssets = new HashSet<string>();
        public HashSet<string> DeletedAssets = new HashSet<string>();
        public HashSet<string> MovedAssets = new HashSet<string>();
        public HashSet<string> MovedFromAssets = new HashSet<string>();

        public void Clear()
        {
            ImportedAssets.Clear();
            DeletedAssets.Clear();
            MovedAssets.Clear();
            MovedFromAssets.Clear();
        }
    }
}
