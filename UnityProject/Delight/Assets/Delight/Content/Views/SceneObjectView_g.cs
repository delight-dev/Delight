// Internal view logic generated from "SceneObjectView.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class SceneObjectView : View
    {
        #region Constructors

        public SceneObjectView(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? SceneObjectViewTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            this.AfterInitializeInternal();
        }

        public SceneObjectView() : this(null)
        {
        }

        static SceneObjectView()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(SceneObjectViewTemplates.Default, dependencyProperties);

            dependencyProperties.Add(GameObjectProperty);
            dependencyProperties.Add(EnableScriptEventsProperty);
            dependencyProperties.Add(IgnoreObjectProperty);
            dependencyProperties.Add(IsActiveProperty);
            dependencyProperties.Add(BeginDragProperty);
            dependencyProperties.Add(BeginDragSoundProperty);
            dependencyProperties.Add(CancelProperty);
            dependencyProperties.Add(CancelSoundProperty);
            dependencyProperties.Add(ClickProperty);
            dependencyProperties.Add(ClickSoundProperty);
            dependencyProperties.Add(DeselectProperty);
            dependencyProperties.Add(DeselectSoundProperty);
            dependencyProperties.Add(DragProperty);
            dependencyProperties.Add(DragSoundProperty);
            dependencyProperties.Add(DropProperty);
            dependencyProperties.Add(DropSoundProperty);
            dependencyProperties.Add(EndDragProperty);
            dependencyProperties.Add(EndDragSoundProperty);
            dependencyProperties.Add(InitializePotentialDragProperty);
            dependencyProperties.Add(InitializePotentialDragSoundProperty);
            dependencyProperties.Add(MoveProperty);
            dependencyProperties.Add(MoveSoundProperty);
            dependencyProperties.Add(MouseDownProperty);
            dependencyProperties.Add(MouseDownSoundProperty);
            dependencyProperties.Add(MouseEnterProperty);
            dependencyProperties.Add(MouseEnterSoundProperty);
            dependencyProperties.Add(MouseExitProperty);
            dependencyProperties.Add(MouseExitSoundProperty);
            dependencyProperties.Add(MouseUpProperty);
            dependencyProperties.Add(MouseUpSoundProperty);
            dependencyProperties.Add(ScrollProperty);
            dependencyProperties.Add(ScrollSoundProperty);
            dependencyProperties.Add(SelectProperty);
            dependencyProperties.Add(SelectSoundProperty);
            dependencyProperties.Add(SubmitProperty);
            dependencyProperties.Add(SubmitSoundProperty);
            dependencyProperties.Add(UpdateSelectedProperty);
            dependencyProperties.Add(UpdateSelectedSoundProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<UnityEngine.GameObject> GameObjectProperty = new DependencyProperty<UnityEngine.GameObject>("GameObject");
        /// <summary>GameObject in the hierarchy that corresponds to the view.</summary>
        public UnityEngine.GameObject GameObject
        {
            get { return GameObjectProperty.GetValue(this); }
            set { GameObjectProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> EnableScriptEventsProperty = new DependencyProperty<System.Boolean>("EnableScriptEvents");
        /// <summary>Boolean indicating if unity script events (Update, LateUpdate, Awake, etc) should be relayed to the view code-behind through the corresponding methods that can be overriden.</summary>
        public System.Boolean EnableScriptEvents
        {
            get { return EnableScriptEventsProperty.GetValue(this); }
            set { EnableScriptEventsProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IgnoreObjectProperty = new DependencyProperty<System.Boolean>("IgnoreObject");
        /// <summary>Boolean indicating if the view should be ignored. Ignored objects don't run any load logic and don't respond to property changed events.</summary>
        public System.Boolean IgnoreObject
        {
            get { return IgnoreObjectProperty.GetValue(this); }
            set { IgnoreObjectProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsActiveProperty = new DependencyProperty<System.Boolean>("IsActive");
        /// <summary>Boolean indicating if the view is active. Deactivated views deactivates corresponding game object, components, renderers and scripts.</summary>
        public System.Boolean IsActive
        {
            get { return IsActiveProperty.GetValue(this); }
            set { IsActiveProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> BeginDragProperty = new DependencyProperty<ViewAction>("BeginDrag", () => new ViewAction(BeginDragSoundProperty));
        /// <summary>Action called when the user begins to drag the view.</summary>
        public ViewAction BeginDrag
        {
            get { return BeginDragProperty.GetValue(this); }
            set { BeginDragProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<AudioClipAsset> BeginDragSoundProperty = new DependencyProperty<AudioClipAsset>("BeginDragSound");
        public AudioClipAsset BeginDragSound
        {
            get { return BeginDragSoundProperty.GetValue(this); }
            set { BeginDragSoundProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> CancelProperty = new DependencyProperty<ViewAction>("Cancel", () => new ViewAction(CancelSoundProperty));
        /// <summary>Action called when a cancel event occurs.</summary>
        public ViewAction Cancel
        {
            get { return CancelProperty.GetValue(this); }
            set { CancelProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<AudioClipAsset> CancelSoundProperty = new DependencyProperty<AudioClipAsset>("CancelSound");
        public AudioClipAsset CancelSound
        {
            get { return CancelSoundProperty.GetValue(this); }
            set { CancelSoundProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> ClickProperty = new DependencyProperty<ViewAction>("Click", () => new ViewAction(ClickSoundProperty));
        /// <summary>Action called when the user clicks on the view.</summary>
        public ViewAction Click
        {
            get { return ClickProperty.GetValue(this); }
            set { ClickProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<AudioClipAsset> ClickSoundProperty = new DependencyProperty<AudioClipAsset>("ClickSound");
        public AudioClipAsset ClickSound
        {
            get { return ClickSoundProperty.GetValue(this); }
            set { ClickSoundProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> DeselectProperty = new DependencyProperty<ViewAction>("Deselect", () => new ViewAction(DeselectSoundProperty));
        /// <summary>Action called when another view is selected.</summary>
        public ViewAction Deselect
        {
            get { return DeselectProperty.GetValue(this); }
            set { DeselectProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<AudioClipAsset> DeselectSoundProperty = new DependencyProperty<AudioClipAsset>("DeselectSound");
        public AudioClipAsset DeselectSound
        {
            get { return DeselectSoundProperty.GetValue(this); }
            set { DeselectSoundProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> DragProperty = new DependencyProperty<ViewAction>("Drag", () => new ViewAction(DragSoundProperty));
        /// <summary>Action called while the user drags the view.</summary>
        public ViewAction Drag
        {
            get { return DragProperty.GetValue(this); }
            set { DragProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<AudioClipAsset> DragSoundProperty = new DependencyProperty<AudioClipAsset>("DragSound");
        public AudioClipAsset DragSound
        {
            get { return DragSoundProperty.GetValue(this); }
            set { DragSoundProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> DropProperty = new DependencyProperty<ViewAction>("Drop", () => new ViewAction(DropSoundProperty));
        /// <summary>Action called when the view accepts a drop.</summary>
        public ViewAction Drop
        {
            get { return DropProperty.GetValue(this); }
            set { DropProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<AudioClipAsset> DropSoundProperty = new DependencyProperty<AudioClipAsset>("DropSound");
        public AudioClipAsset DropSound
        {
            get { return DropSoundProperty.GetValue(this); }
            set { DropSoundProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> EndDragProperty = new DependencyProperty<ViewAction>("EndDrag", () => new ViewAction(EndDragSoundProperty));
        /// <summary>Action called when the user stops dragging the view.</summary>
        public ViewAction EndDrag
        {
            get { return EndDragProperty.GetValue(this); }
            set { EndDragProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<AudioClipAsset> EndDragSoundProperty = new DependencyProperty<AudioClipAsset>("EndDragSound");
        public AudioClipAsset EndDragSound
        {
            get { return EndDragSoundProperty.GetValue(this); }
            set { EndDragSoundProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> InitializePotentialDragProperty = new DependencyProperty<ViewAction>("InitializePotentialDrag", () => new ViewAction(InitializePotentialDragSoundProperty));
        /// <summary>Called when the user initializes a potential drag on the view.</summary>
        public ViewAction InitializePotentialDrag
        {
            get { return InitializePotentialDragProperty.GetValue(this); }
            set { InitializePotentialDragProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<AudioClipAsset> InitializePotentialDragSoundProperty = new DependencyProperty<AudioClipAsset>("InitializePotentialDragSound");
        public AudioClipAsset InitializePotentialDragSound
        {
            get { return InitializePotentialDragSoundProperty.GetValue(this); }
            set { InitializePotentialDragSoundProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> MoveProperty = new DependencyProperty<ViewAction>("Move", () => new ViewAction(MoveSoundProperty));
        /// <summary>Action called when a move events occurs.</summary>
        public ViewAction Move
        {
            get { return MoveProperty.GetValue(this); }
            set { MoveProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<AudioClipAsset> MoveSoundProperty = new DependencyProperty<AudioClipAsset>("MoveSound");
        public AudioClipAsset MoveSound
        {
            get { return MoveSoundProperty.GetValue(this); }
            set { MoveSoundProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> MouseDownProperty = new DependencyProperty<ViewAction>("MouseDown", () => new ViewAction(MouseDownSoundProperty));
        /// <summary>Action called when the mouse/touch presses down over the view.</summary>
        public ViewAction MouseDown
        {
            get { return MouseDownProperty.GetValue(this); }
            set { MouseDownProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<AudioClipAsset> MouseDownSoundProperty = new DependencyProperty<AudioClipAsset>("MouseDownSound");
        public AudioClipAsset MouseDownSound
        {
            get { return MouseDownSoundProperty.GetValue(this); }
            set { MouseDownSoundProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> MouseEnterProperty = new DependencyProperty<ViewAction>("MouseEnter", () => new ViewAction(MouseEnterSoundProperty));
        /// <summary>Action called when the mouse enters the view.</summary>
        public ViewAction MouseEnter
        {
            get { return MouseEnterProperty.GetValue(this); }
            set { MouseEnterProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<AudioClipAsset> MouseEnterSoundProperty = new DependencyProperty<AudioClipAsset>("MouseEnterSound");
        public AudioClipAsset MouseEnterSound
        {
            get { return MouseEnterSoundProperty.GetValue(this); }
            set { MouseEnterSoundProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> MouseExitProperty = new DependencyProperty<ViewAction>("MouseExit", () => new ViewAction(MouseExitSoundProperty));
        /// <summary>Action called when the mouse exits the view.</summary>
        public ViewAction MouseExit
        {
            get { return MouseExitProperty.GetValue(this); }
            set { MouseExitProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<AudioClipAsset> MouseExitSoundProperty = new DependencyProperty<AudioClipAsset>("MouseExitSound");
        public AudioClipAsset MouseExitSound
        {
            get { return MouseExitSoundProperty.GetValue(this); }
            set { MouseExitSoundProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> MouseUpProperty = new DependencyProperty<ViewAction>("MouseUp", () => new ViewAction(MouseUpSoundProperty));
        /// <summary>Action called when the mouse/touch releases over the view.</summary>
        public ViewAction MouseUp
        {
            get { return MouseUpProperty.GetValue(this); }
            set { MouseUpProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<AudioClipAsset> MouseUpSoundProperty = new DependencyProperty<AudioClipAsset>("MouseUpSound");
        public AudioClipAsset MouseUpSound
        {
            get { return MouseUpSoundProperty.GetValue(this); }
            set { MouseUpSoundProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> ScrollProperty = new DependencyProperty<ViewAction>("Scroll", () => new ViewAction(ScrollSoundProperty));
        /// <summary>Action called when the user scrolls with mouse wheel or track pad over the view.</summary>
        public ViewAction Scroll
        {
            get { return ScrollProperty.GetValue(this); }
            set { ScrollProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<AudioClipAsset> ScrollSoundProperty = new DependencyProperty<AudioClipAsset>("ScrollSound");
        public AudioClipAsset ScrollSound
        {
            get { return ScrollSoundProperty.GetValue(this); }
            set { ScrollSoundProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> SelectProperty = new DependencyProperty<ViewAction>("Select", () => new ViewAction(SelectSoundProperty));
        /// <summary>Action called when the view is selected.</summary>
        public ViewAction Select
        {
            get { return SelectProperty.GetValue(this); }
            set { SelectProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<AudioClipAsset> SelectSoundProperty = new DependencyProperty<AudioClipAsset>("SelectSound");
        public AudioClipAsset SelectSound
        {
            get { return SelectSoundProperty.GetValue(this); }
            set { SelectSoundProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> SubmitProperty = new DependencyProperty<ViewAction>("Submit", () => new ViewAction(SubmitSoundProperty));
        /// <summary>Action called when a submit event occurs.</summary>
        public ViewAction Submit
        {
            get { return SubmitProperty.GetValue(this); }
            set { SubmitProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<AudioClipAsset> SubmitSoundProperty = new DependencyProperty<AudioClipAsset>("SubmitSound");
        public AudioClipAsset SubmitSound
        {
            get { return SubmitSoundProperty.GetValue(this); }
            set { SubmitSoundProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> UpdateSelectedProperty = new DependencyProperty<ViewAction>("UpdateSelected", () => new ViewAction(UpdateSelectedSoundProperty));
        /// <summary>Action called when theobject associated with this EventTrigger is updated.</summary>
        public ViewAction UpdateSelected
        {
            get { return UpdateSelectedProperty.GetValue(this); }
            set { UpdateSelectedProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<AudioClipAsset> UpdateSelectedSoundProperty = new DependencyProperty<AudioClipAsset>("UpdateSelectedSound");
        public AudioClipAsset UpdateSelectedSound
        {
            get { return UpdateSelectedSoundProperty.GetValue(this); }
            set { UpdateSelectedSoundProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class SceneObjectViewTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return SceneObjectView;
            }
        }

        private static Template _sceneObjectView;
        public static Template SceneObjectView
        {
            get
            {
#if UNITY_EDITOR
                if (_sceneObjectView == null || _sceneObjectView.CurrentVersion != Template.Version)
#else
                if (_sceneObjectView == null)
#endif
                {
                    _sceneObjectView = new Template(ViewTemplates.View);
#if UNITY_EDITOR
                    _sceneObjectView.Name = "SceneObjectView";
                    _sceneObjectView.LineNumber = 0;
                    _sceneObjectView.LinePosition = 0;
#endif
                    Delight.SceneObjectView.IsActiveProperty.SetDefault(_sceneObjectView, true);
                }
                return _sceneObjectView;
            }
        }

        #endregion
    }

    #endregion
}
