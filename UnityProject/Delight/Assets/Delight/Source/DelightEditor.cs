#region Using Statements
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

namespace Delight
{
    /// <summary>
    /// Delight editor.
    /// </summary>
    [ExecuteInEditMode]
    public class DelightEditor : MonoBehaviour
    {
        #region Fields
        #endregion

        #region Methods

        void Awake()
        {
    
        }

        public static void Open()
        {
        }

        //private static void OnEditorUpdate()
        //{
        //    if (DelightEditor == null)
        //    {
        //        Debug.Log("Finding the scene");

        //        // try find the scene
        //        DelightEditor = EditorSceneManager.GetSceneByName("DelightEditor");
        //        if (DelightEditor == null)
        //        {
        //            Debug.Log("Creating new scene");

        //            // create new scene
        //            DelightEditor = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
        //        }
        //    }
        //}

        #endregion
    }
}
