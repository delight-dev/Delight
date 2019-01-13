// Internal view logic generated from "SceneView.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class SceneView : View
    {
        #region Constructors

        public SceneView(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? SceneViewTemplates.Default, initializer)
        {
        }

        public SceneView() : this(null)
        {
        }

        static SceneView()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(SceneViewTemplates.Default, dependencyProperties);

            dependencyProperties.Add(GameObjectProperty);
            dependencyProperties.Add(EnableScriptEventsProperty);
            dependencyProperties.Add(BeginDragProperty);
            dependencyProperties.Add(CancelProperty);
            dependencyProperties.Add(ClickProperty);
            dependencyProperties.Add(DeselectProperty);
            dependencyProperties.Add(DragProperty);
            dependencyProperties.Add(DropProperty);
            dependencyProperties.Add(EndDragProperty);
            dependencyProperties.Add(InitializePotentialDragProperty);
            dependencyProperties.Add(MoveProperty);
            dependencyProperties.Add(PointerDownProperty);
            dependencyProperties.Add(PointerEnterProperty);
            dependencyProperties.Add(PointerExitProperty);
            dependencyProperties.Add(PointerUpProperty);
            dependencyProperties.Add(ScrollProperty);
            dependencyProperties.Add(SelectProperty);
            dependencyProperties.Add(SubmitProperty);
            dependencyProperties.Add(UpdateSelectedProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<UnityEngine.GameObject> GameObjectProperty = new DependencyProperty<UnityEngine.GameObject>();
        public UnityEngine.GameObject GameObject
        {
            get { return GameObjectProperty.GetValue(this); }
            set { GameObjectProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> EnableScriptEventsProperty = new DependencyProperty<System.Boolean>();
        public System.Boolean EnableScriptEvents
        {
            get { return EnableScriptEventsProperty.GetValue(this); }
            set { EnableScriptEventsProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> BeginDragProperty = new DependencyProperty<ViewAction>();
        public ViewAction BeginDrag
        {
            get { return BeginDragProperty.GetValue(this); }
            set { BeginDragProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> CancelProperty = new DependencyProperty<ViewAction>();
        public ViewAction Cancel
        {
            get { return CancelProperty.GetValue(this); }
            set { CancelProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> ClickProperty = new DependencyProperty<ViewAction>();
        public ViewAction Click
        {
            get { return ClickProperty.GetValue(this); }
            set { ClickProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> DeselectProperty = new DependencyProperty<ViewAction>();
        public ViewAction Deselect
        {
            get { return DeselectProperty.GetValue(this); }
            set { DeselectProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> DragProperty = new DependencyProperty<ViewAction>();
        public ViewAction Drag
        {
            get { return DragProperty.GetValue(this); }
            set { DragProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> DropProperty = new DependencyProperty<ViewAction>();
        public ViewAction Drop
        {
            get { return DropProperty.GetValue(this); }
            set { DropProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> EndDragProperty = new DependencyProperty<ViewAction>();
        public ViewAction EndDrag
        {
            get { return EndDragProperty.GetValue(this); }
            set { EndDragProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> InitializePotentialDragProperty = new DependencyProperty<ViewAction>();
        public ViewAction InitializePotentialDrag
        {
            get { return InitializePotentialDragProperty.GetValue(this); }
            set { InitializePotentialDragProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> MoveProperty = new DependencyProperty<ViewAction>();
        public ViewAction Move
        {
            get { return MoveProperty.GetValue(this); }
            set { MoveProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> PointerDownProperty = new DependencyProperty<ViewAction>();
        public ViewAction PointerDown
        {
            get { return PointerDownProperty.GetValue(this); }
            set { PointerDownProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> PointerEnterProperty = new DependencyProperty<ViewAction>();
        public ViewAction PointerEnter
        {
            get { return PointerEnterProperty.GetValue(this); }
            set { PointerEnterProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> PointerExitProperty = new DependencyProperty<ViewAction>();
        public ViewAction PointerExit
        {
            get { return PointerExitProperty.GetValue(this); }
            set { PointerExitProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> PointerUpProperty = new DependencyProperty<ViewAction>();
        public ViewAction PointerUp
        {
            get { return PointerUpProperty.GetValue(this); }
            set { PointerUpProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> ScrollProperty = new DependencyProperty<ViewAction>();
        public ViewAction Scroll
        {
            get { return ScrollProperty.GetValue(this); }
            set { ScrollProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> SelectProperty = new DependencyProperty<ViewAction>();
        public ViewAction Select
        {
            get { return SelectProperty.GetValue(this); }
            set { SelectProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> SubmitProperty = new DependencyProperty<ViewAction>();
        public ViewAction Submit
        {
            get { return SubmitProperty.GetValue(this); }
            set { SubmitProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> UpdateSelectedProperty = new DependencyProperty<ViewAction>();
        public ViewAction UpdateSelected
        {
            get { return UpdateSelectedProperty.GetValue(this); }
            set { UpdateSelectedProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class SceneViewTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return SceneView;
            }
        }

        private static Template _sceneView;
        public static Template SceneView
        {
            get
            {
#if UNITY_EDITOR
                if (_sceneView == null || _sceneView.CurrentVersion != Template.Version)
#else
                if (_sceneView == null)
#endif
                {
                    _sceneView = new Template(ViewTemplates.View);
                }
                return _sceneView;
            }
        }

        #endregion
    }

    #endregion
}
