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
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#endregion

namespace Delight.Editor
{
    [InitializeOnLoad]
    public static class EditorEventListener
    {
        public static bool QueuedAssetsToBeProcessed = false;
        public static PostprocessAllAssetsBatch PostprocessBatch = new PostprocessAllAssetsBatch();

        static EditorEventListener()
        {
            EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }

        private static void OnPlayModeStateChanged(PlayModeStateChange state)
        {
            switch (state)
            {
                case PlayModeStateChange.EnteredEditMode:
                    // call any queued code processing methods
                    if (!QueuedAssetsToBeProcessed)
                        break;

                    QueuedAssetsToBeProcessed = false;

                    var importedAssets = PostprocessBatch.ImportedAssets.ToArray();
                    var deletedAssets = PostprocessBatch.DeletedAssets.ToArray();
                    var movedAssets = PostprocessBatch.MovedAssets.ToArray();
                    var movedFromAssets = PostprocessBatch.MovedFromAssets.ToArray();
                    PostprocessBatch.Clear();

                    ContentAssetProcessor.OnPostprocessAllAssets(importedAssets, deletedAssets, movedAssets, movedFromAssets);
                    break;

                case PlayModeStateChange.ExitingEditMode:
                    // generate bundles if necessary
                    var bundles = ContentObjectModel.GetInstance().AssetBundleObjects.Where(x => x.NeedBuild).ToList();
                    if (bundles.Count > 0)
                    {
                        ContentParser.BuildAssetBundles(bundles);
                    }
                    break;

                case PlayModeStateChange.EnteredPlayMode:
                    // add sub-scene
                    //var activeScene = SceneManager.GetActiveScene();

                    var scene = SceneManager.CreateScene("DelightEditor");

                    // try create a game object in scene
                    break;

                case PlayModeStateChange.ExitingPlayMode:
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
