#region Using Statements
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor;
#endregion

namespace Delight
{
    /// <summary>
    /// MonoBehavior for live editing.
    /// </summary>
    public class DelightLiveEditor : MonoBehaviour
    {
        #region Fields        

        private ViewPresenter _viewPresenter;

        public EventSystem _eventSystem;
        public EventSystem EventSystem
        {
            get
            {
                if (_eventSystem == null)
                {
                     _eventSystem = FindObjectOfType<EventSystem>();
                }

                return _eventSystem;
            }
        }

        private int _selectedIndex = 0;
        private List<GameObject> _selectedObjects = new List<GameObject>();

        #endregion

        #region Methods

        private void Start()
        {
            _viewPresenter = GetComponent<ViewPresenter>();
        }

        void Update()
        {
            if (!Application.isEditor) // TODO add option to enable outside editor through Config.IncludeLiveEditorInDeploy.
                return;

            bool ctrlDown = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
            if (Input.GetMouseButtonDown(0) && ctrlDown)
            {
                if (EventSystem == null)
                    return;

                var pointerEventData = new PointerEventData(EventSystem);
                pointerEventData.position = Input.mousePosition;                               

                List<RaycastResult> results = new List<RaycastResult>();
                EventSystem.RaycastAll(pointerEventData, results);

                // deselect all if same object is selected 
                var newSelectedObjects = results.Select(x => x.gameObject).ToList();
                if (!newSelectedObjects.SequenceEqual(_selectedObjects) || _selectedIndex <= 0)
                {                    
                    ClearSelection();
                }

                _selectedObjects = newSelectedObjects;
                SelectObject(0);
            }

            if (Input.mouseScrollDelta.y > 0 && ctrlDown)
            {
                SelectObject(_selectedIndex + 1);
            }
            else if (Input.mouseScrollDelta.y < 0 && ctrlDown)
            {
                SelectObject(_selectedIndex - 1);
            }           
        }

        public void ClearSelection()
        {
            foreach (var obj in _selectedObjects)
            {
                if (obj == null)
                    continue;

                var selection = obj.GetComponent<SelectionIndicatorScript>();
                if (selection != null)
                {
                    Destroy(selection);
                }
            }
            _selectedIndex = 0;
            _selectedObjects.Clear();
        }

        public void SelectObject(int index)
        {            
            if (index < 0 || index >= _selectedObjects.Count)
                return;

            // select new object
            var obj = _selectedObjects[index];
            var selection = obj.GetComponent<SelectionIndicatorScript>();
            if (selection == null)
            {
                obj.AddComponent<SelectionIndicatorScript>();
            }

            // deselect old object
            if (index != _selectedIndex)
            {
                var oldObj = _selectedObjects[_selectedIndex];
                var oldSelection = oldObj.GetComponent<SelectionIndicatorScript>();
                if (oldSelection != null)
                {
                    Destroy(oldSelection);
                }
            }

            _selectedIndex = index;

            // highlight it in editor
#if UNITY_EDITOR
            Selection.activeObject = obj;
            EditorGUIUtility.PingObject(obj);
#endif
        }

        #endregion
    }
}
