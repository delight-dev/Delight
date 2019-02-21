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

        public SceneObjectView(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? SceneObjectViewTemplates.Default, initializer)
        {
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
            dependencyProperties.Add(IsActiveProperty);
            dependencyProperties.Add(BeginDragProperty);
            dependencyProperties.Add(CancelProperty);
            dependencyProperties.Add(ClickProperty);
            dependencyProperties.Add(DeselectProperty);
            dependencyProperties.Add(DragProperty);
            dependencyProperties.Add(DropProperty);
            dependencyProperties.Add(EndDragProperty);
            dependencyProperties.Add(InitializePotentialDragProperty);
            dependencyProperties.Add(MoveProperty);
            dependencyProperties.Add(MouseDownProperty);
            dependencyProperties.Add(MouseEnterProperty);
            dependencyProperties.Add(MouseExitProperty);
            dependencyProperties.Add(MouseUpProperty);
            dependencyProperties.Add(ScrollProperty);
            dependencyProperties.Add(SelectProperty);
            dependencyProperties.Add(SubmitProperty);
            dependencyProperties.Add(UpdateSelectedProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<UnityEngine.GameObject> GameObjectProperty = new DependencyProperty<UnityEngine.GameObject>("GameObject");
        public UnityEngine.GameObject GameObject
        {
            get { return GameObjectProperty.GetValue(this); }
            set { GameObjectProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> EnableScriptEventsProperty = new DependencyProperty<System.Boolean>("EnableScriptEvents");
        public System.Boolean EnableScriptEvents
        {
            get { return EnableScriptEventsProperty.GetValue(this); }
            set { EnableScriptEventsProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsActiveProperty = new DependencyProperty<System.Boolean>("IsActive");
        public System.Boolean IsActive
        {
            get { return IsActiveProperty.GetValue(this); }
            set { IsActiveProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> BeginDragProperty = new DependencyProperty<ViewAction>("BeginDrag");
        public ViewAction BeginDrag
        {
            get { return BeginDragProperty.GetValue(this); }
            set { BeginDragProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> CancelProperty = new DependencyProperty<ViewAction>("Cancel");
        public ViewAction Cancel
        {
            get { return CancelProperty.GetValue(this); }
            set { CancelProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> ClickProperty = new DependencyProperty<ViewAction>("Click");
        public ViewAction Click
        {
            get { return ClickProperty.GetValue(this); }
            set { ClickProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> DeselectProperty = new DependencyProperty<ViewAction>("Deselect");
        public ViewAction Deselect
        {
            get { return DeselectProperty.GetValue(this); }
            set { DeselectProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> DragProperty = new DependencyProperty<ViewAction>("Drag");
        public ViewAction Drag
        {
            get { return DragProperty.GetValue(this); }
            set { DragProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> DropProperty = new DependencyProperty<ViewAction>("Drop");
        public ViewAction Drop
        {
            get { return DropProperty.GetValue(this); }
            set { DropProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> EndDragProperty = new DependencyProperty<ViewAction>("EndDrag");
        public ViewAction EndDrag
        {
            get { return EndDragProperty.GetValue(this); }
            set { EndDragProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> InitializePotentialDragProperty = new DependencyProperty<ViewAction>("InitializePotentialDrag");
        public ViewAction InitializePotentialDrag
        {
            get { return InitializePotentialDragProperty.GetValue(this); }
            set { InitializePotentialDragProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> MoveProperty = new DependencyProperty<ViewAction>("Move");
        public ViewAction Move
        {
            get { return MoveProperty.GetValue(this); }
            set { MoveProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> MouseDownProperty = new DependencyProperty<ViewAction>("MouseDown");
        public ViewAction MouseDown
        {
            get { return MouseDownProperty.GetValue(this); }
            set { MouseDownProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> MouseEnterProperty = new DependencyProperty<ViewAction>("MouseEnter");
        public ViewAction MouseEnter
        {
            get { return MouseEnterProperty.GetValue(this); }
            set { MouseEnterProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> MouseExitProperty = new DependencyProperty<ViewAction>("MouseExit");
        public ViewAction MouseExit
        {
            get { return MouseExitProperty.GetValue(this); }
            set { MouseExitProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> MouseUpProperty = new DependencyProperty<ViewAction>("MouseUp");
        public ViewAction MouseUp
        {
            get { return MouseUpProperty.GetValue(this); }
            set { MouseUpProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> ScrollProperty = new DependencyProperty<ViewAction>("Scroll");
        public ViewAction Scroll
        {
            get { return ScrollProperty.GetValue(this); }
            set { ScrollProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> SelectProperty = new DependencyProperty<ViewAction>("Select");
        public ViewAction Select
        {
            get { return SelectProperty.GetValue(this); }
            set { SelectProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> SubmitProperty = new DependencyProperty<ViewAction>("Submit");
        public ViewAction Submit
        {
            get { return SubmitProperty.GetValue(this); }
            set { SubmitProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> UpdateSelectedProperty = new DependencyProperty<ViewAction>("UpdateSelected");
        public ViewAction UpdateSelected
        {
            get { return UpdateSelectedProperty.GetValue(this); }
            set { UpdateSelectedProperty.SetValue(this, value); }
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
#endif
                }
                return _sceneObjectView;
            }
        }

        #endregion
    }

    #endregion
}
