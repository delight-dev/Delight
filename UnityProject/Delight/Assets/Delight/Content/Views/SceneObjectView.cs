#region Using Statements
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
#endregion

namespace Delight
{
    /// <summary>
    /// Scene object view.
    /// </summary>
    public partial class SceneObjectView : View
    {

        #region Methods

        /// <summary>
        /// Called before the view is loaded.
        /// </summary>
        protected override void BeforeLoad()
        {
            base.BeforeLoad();
            if (IgnoreObject)
                return;

            // create game-object and parent it with first scene object parent (that is not set to be ignored)           
            const int GuidIdLength = 36;
            var go = new UnityEngine.GameObject(String.Format("{0}{1}", GetType().Name, Id.Length != GuidIdLength ? " (" + Id + ")" : ""));
            var parent = this.FindParent<SceneObjectView>(x => !x.IgnoreObject);
            if (parent != null)
            {
                go.transform.SetParent(parent.GameObject.transform);
            }
            GameObject = go;

            // if script events are enabled add component that relays the events
            if (EnableScriptEvents)
            {
                var eventListener = go.AddComponent<UnityScriptEventRelay>();
                eventListener.SceneObjectView = this;
            }
        }

        /// <summary>
        /// Called after the view is loaded.
        /// </summary>
        protected override void AfterLoad()
        {
            base.AfterLoad();
            if (IgnoreObject)
                return;

            // add unity event system triggers
            GameObject.AddEventTrigger(this, BeginDrag, EventTriggerType.BeginDrag);
            GameObject.AddEventTrigger(this, Cancel, EventTriggerType.Cancel);
            GameObject.AddEventTrigger(this, Deselect, EventTriggerType.Deselect);
            GameObject.AddEventTrigger(this, Drag, EventTriggerType.Drag);
            GameObject.AddEventTrigger(this, Drop, EventTriggerType.Drop);
            GameObject.AddEventTrigger(this, EndDrag, EventTriggerType.EndDrag);
            GameObject.AddEventTrigger(this, InitializePotentialDrag, EventTriggerType.InitializePotentialDrag);
            GameObject.AddEventTrigger(this, Move, EventTriggerType.Move);
            GameObject.AddEventTrigger(this, Click, EventTriggerType.PointerClick);
            GameObject.AddEventTrigger(this, MouseDown, EventTriggerType.PointerDown);
            GameObject.AddEventTrigger(this, MouseEnter, EventTriggerType.PointerEnter);
            GameObject.AddEventTrigger(this, MouseExit, EventTriggerType.PointerExit);
            GameObject.AddEventTrigger(this, MouseUp, EventTriggerType.PointerUp);
            GameObject.AddEventTrigger(this, Scroll, EventTriggerType.Scroll);
            GameObject.AddEventTrigger(this, Select, EventTriggerType.Select);
            GameObject.AddEventTrigger(this, Submit, EventTriggerType.Submit);
            GameObject.AddEventTrigger(this, UpdateSelected, EventTriggerType.UpdateSelected);
        }

        /// <summary>
        /// Called before the view is unloaded.
        /// </summary>
        protected override void AfterUnload()
        {
            base.AfterUnload();
            if (IgnoreObject)
                return;

            // destroy game-object
#if UNITY_EDITOR
            if (!Application.isPlaying)
                UnityEngine.GameObject.DestroyImmediate(GameObject);
            else
#endif
                UnityEngine.GameObject.Destroy(GameObject);

        }

        /// <summary>
        /// Called when a property has been changed. 
        /// </summary>
        public override void OnPropertyChanged(object source, string property)
        {
            if (IgnoreObject)
                return;

            base.OnPropertyChanged(source, property);
            switch (property)
            {
                case nameof(IsActive):
                    IsActiveChanged();
                    break;
            }
        }

        /// <summary>
        /// Called when IsActive property has been changed.
        /// </summary>
        public virtual void IsActiveChanged()
        {
            GameObject?.SetActive(IsActive);
        }

        /// <summary>
        /// Called once per frame if EnableScriptEvents is true.
        /// </summary>
        public virtual void Update()
        {
        }

        /// <summary>
        /// Called once per frame if EnableScriptEvents is true.
        /// </summary>
        public virtual void LateUpdate()
        {
        }

        /// <summary>
        /// Sets view to be ignored (must be called before load). Ignored objects are disabled/ignored in the object hierarchy (but their children aren't).
        /// </summary>
        public virtual void Ignore()
        {
            IgnoreObject = true;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Name of the scene view game object.
        /// </summary>
        public string Name
        {
            get
            {
                return GameObject != null ? GameObject.name : Id;
            }
            set
            {
                if (GameObject != null)
                {
                    GameObject.name = value;
                }
            }
        }

        #endregion
    }

    /// <summary>
    /// Simple unity component that relays script events (Awake, Update, etc) to scene view.
    /// </summary>
    public class UnityScriptEventRelay : MonoBehaviour
    {
        #region Fields

        public SceneObjectView SceneObjectView;

        #endregion

        #region Methods

        public void Update()
        {
            SceneObjectView?.Update();
        }

        public void LateUpdate()
        {
            SceneObjectView?.LateUpdate();
        }

        #endregion
    }
}
