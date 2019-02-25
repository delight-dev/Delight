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
using UnityEngine.UI;
#endregion

namespace Delight.Editor
{
    /// <summary>
    /// Custom inspector for ViewPresenter component.
    /// </summary>
    [CustomEditor(typeof(ViewPresenter))]
    public class ViewPresenterInspector : UnityEditor.Editor
    {
        #region Methods

        /// <summary>
        /// Called when inspector GUI is to be rendered.
        /// </summary>
        public override async void OnInspectorGUI()
        {
            var viewPresenter = (ViewPresenter)target;
            var config = MasterConfig.GetInstance();

            // currently presented view
            int selectedViewIndex = config.Views.IndexOf(viewPresenter.ViewTypeName) + 1;

            // .. add empty selection
            var viewList = new List<string>(config.Views);
            viewList.Insert(0, "-- none --");

            int newSelectedViewIndex = EditorGUILayout.Popup("View", selectedViewIndex, viewList.ToArray());
            viewPresenter.ViewTypeName = newSelectedViewIndex > 0 ? config.Views[newSelectedViewIndex - 1] : String.Empty;
            if (newSelectedViewIndex != selectedViewIndex)
            {
                EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
            }

            // TODO here we can look up assembly qualified name to make instantiation quicker

            DrawDefaultInspector();

            // loads view
            GUI.enabled = Application.isPlaying;
            GUIContent load = new GUIContent("Load", "Instantiates and loads the view.");
            if (GUILayout.Button(load))
            {
                await viewPresenter.Load();
            }

            // unloads view
            GUIContent unload = new GUIContent("Unload", "Unloads the view.");
            if (GUILayout.Button(unload))
            {
                viewPresenter.Unload();
            }
            GUI.enabled = true;
        }

        #endregion
    }
}
