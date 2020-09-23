// Internal view logic generated from "UIView.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class UIView : SceneObjectView
    {
        #region Constructors

        public UIView(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? UIViewTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            this.AfterInitializeInternal();
        }

        public UIView() : this(null)
        {
        }

        static UIView()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(UIViewTemplates.Default, dependencyProperties);

            dependencyProperties.Add(RectTransformProperty);
            dependencyProperties.Add(WidthProperty);
            dependencyProperties.Add(HeightProperty);
            dependencyProperties.Add(OverrideWidthProperty);
            dependencyProperties.Add(OverrideHeightProperty);
            dependencyProperties.Add(ScaleProperty);
            dependencyProperties.Add(AlignmentProperty);
            dependencyProperties.Add(MarginProperty);
            dependencyProperties.Add(OffsetProperty);
            dependencyProperties.Add(OffsetFromParentProperty);
            dependencyProperties.Add(PivotProperty);
            dependencyProperties.Add(DisableLayoutUpdateProperty);
            dependencyProperties.Add(AlphaProperty);
            dependencyProperties.Add(IsVisibleProperty);
            dependencyProperties.Add(RaycastBlockModeProperty);
            dependencyProperties.Add(IsInteractableProperty);
            dependencyProperties.Add(CanvasGroupProperty);
            dependencyProperties.Add(UseFastShaderProperty);
            dependencyProperties.Add(FastMaterialProperty);
            dependencyProperties.Add(BubbleNotifyChildLayoutChangedProperty);
            dependencyProperties.Add(IgnoreFlipProperty);
            dependencyProperties.Add(RotationProperty);
            dependencyProperties.Add(PositionProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<UnityEngine.RectTransform> RectTransformProperty = new DependencyProperty<UnityEngine.RectTransform>("RectTransform");
        public UnityEngine.RectTransform RectTransform
        {
            get { return RectTransformProperty.GetValue(this); }
            set { RectTransformProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementSize> WidthProperty = new DependencyProperty<Delight.ElementSize>("Width");
        /// <summary>The width of the view in pixels or percents.</summary>
        public Delight.ElementSize Width
        {
            get { return WidthProperty.GetValue(this); }
            set { WidthProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementSize> HeightProperty = new DependencyProperty<Delight.ElementSize>("Height");
        /// <summary>The height of the view in pixels or percents.</summary>
        public Delight.ElementSize Height
        {
            get { return HeightProperty.GetValue(this); }
            set { HeightProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementSize> OverrideWidthProperty = new DependencyProperty<Delight.ElementSize>("OverrideWidth");
        /// <summary>Overrides regular Width value. Used to e.g. automatically size items without changing the default Width value set.</summary>
        public Delight.ElementSize OverrideWidth
        {
            get { return OverrideWidthProperty.GetValue(this); }
            set { OverrideWidthProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementSize> OverrideHeightProperty = new DependencyProperty<Delight.ElementSize>("OverrideHeight");
        /// <summary>Overrides regular Height value. Used to e.g. automatically size items without changing the default Height value set.</summary>
        public Delight.ElementSize OverrideHeight
        {
            get { return OverrideHeightProperty.GetValue(this); }
            set { OverrideHeightProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<UnityEngine.Vector3> ScaleProperty = new DependencyProperty<UnityEngine.Vector3>("Scale");
        /// <summary>Scale of the view.</summary>
        public UnityEngine.Vector3 Scale
        {
            get { return ScaleProperty.GetValue(this); }
            set { ScaleProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementAlignment> AlignmentProperty = new DependencyProperty<Delight.ElementAlignment>("Alignment");
        /// <summary>Used to align the view relative to the layout parent region it resides in.</summary>
        public Delight.ElementAlignment Alignment
        {
            get { return AlignmentProperty.GetValue(this); }
            set { AlignmentProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementMargin> MarginProperty = new DependencyProperty<Delight.ElementMargin>("Margin");
        /// <summary>Adding margins to a view changes the size of the area in which its content resides, but it does not change the width or height of the view.</summary>
        public Delight.ElementMargin Margin
        {
            get { return MarginProperty.GetValue(this); }
            set { MarginProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementMargin> OffsetProperty = new DependencyProperty<Delight.ElementMargin>("Offset");
        /// <summary>Determines the offset of the view.</summary>
        public Delight.ElementMargin Offset
        {
            get { return OffsetProperty.GetValue(this); }
            set { OffsetProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementMargin> OffsetFromParentProperty = new DependencyProperty<Delight.ElementMargin>("OffsetFromParent");
        /// <summary>Offset set by a parent view. Used by views like Group to arrange children without changing their own Offset values.</summary>
        public Delight.ElementMargin OffsetFromParent
        {
            get { return OffsetFromParentProperty.GetValue(this); }
            set { OffsetFromParentProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<UnityEngine.Vector2> PivotProperty = new DependencyProperty<UnityEngine.Vector2>("Pivot");
        /// <summary>The pivot point of the view.</summary>
        public UnityEngine.Vector2 Pivot
        {
            get { return PivotProperty.GetValue(this); }
            set { PivotProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> DisableLayoutUpdateProperty = new DependencyProperty<System.Boolean>("DisableLayoutUpdate");
        /// <summary>Boolean indicating if automatic layout updates for this view should be disabled. When disabled the view doesn't call UpdateLayout() when properties such as Width, Height, etc. changes.</summary>
        public System.Boolean DisableLayoutUpdate
        {
            get { return DisableLayoutUpdateProperty.GetValue(this); }
            set { DisableLayoutUpdateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Single> AlphaProperty = new DependencyProperty<System.Single>("Alpha");
        /// <summary>Can be used to adjust the alpha color of this view and all its children. E.g. used for fade in/out animations. Is separate from and different from the background color of the view as it affects the children as well.</summary>
        public System.Single Alpha
        {
            get { return AlphaProperty.GetValue(this); }
            set { AlphaProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsVisibleProperty = new DependencyProperty<System.Boolean>("IsVisible");
        /// <summary>Boolean indicating if view is visible or hidden. Invisible views still take up space but aren't interactable and have their alpha set to 0.</summary>
        public System.Boolean IsVisible
        {
            get { return IsVisibleProperty.GetValue(this); }
            set { IsVisibleProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.RaycastBlockMode> RaycastBlockModeProperty = new DependencyProperty<Delight.RaycastBlockMode>("RaycastBlockMode");
        /// <summary>Enum indicating if raycasts should be blocked.</summary>
        public Delight.RaycastBlockMode RaycastBlockMode
        {
            get { return RaycastBlockModeProperty.GetValue(this); }
            set { RaycastBlockModeProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsInteractableProperty = new DependencyProperty<System.Boolean>("IsInteractable");
        public System.Boolean IsInteractable
        {
            get { return IsInteractableProperty.GetValue(this); }
            set { IsInteractableProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<UnityEngine.CanvasGroup> CanvasGroupProperty = new DependencyProperty<UnityEngine.CanvasGroup>("CanvasGroup");
        public UnityEngine.CanvasGroup CanvasGroup
        {
            get { return CanvasGroupProperty.GetValue(this); }
            set { CanvasGroupProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> UseFastShaderProperty = new DependencyProperty<System.Boolean>("UseFastShader");
        /// <summary>Boolean indicating if the default UI shader should be replaced by a simpler and faster one. The faster shader does not support masking and clipping.</summary>
        public System.Boolean UseFastShader
        {
            get { return UseFastShaderProperty.GetValue(this); }
            set { UseFastShaderProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<MaterialAsset> FastMaterialProperty = new DependencyProperty<MaterialAsset>("FastMaterial");
        /// <summary>Faster shader used to render the view when UseFastShader is set to True.</summary>
        public MaterialAsset FastMaterial
        {
            get { return FastMaterialProperty.GetValue(this); }
            set { FastMaterialProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> BubbleNotifyChildLayoutChangedProperty = new DependencyProperty<System.Boolean>("BubbleNotifyChildLayoutChanged");
        /// <summary>Boolean indicating if parent always should be notified when the child changes layout.</summary>
        public System.Boolean BubbleNotifyChildLayoutChanged
        {
            get { return BubbleNotifyChildLayoutChangedProperty.GetValue(this); }
            set { BubbleNotifyChildLayoutChangedProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IgnoreFlipProperty = new DependencyProperty<System.Boolean>("IgnoreFlip");
        /// <summary>Used when doing localization override default behavior of flipping the view Right to Left or Left to Rigth.</summary>
        public System.Boolean IgnoreFlip
        {
            get { return IgnoreFlipProperty.GetValue(this); }
            set { IgnoreFlipProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<UnityEngine.Quaternion> RotationProperty = new DependencyProperty<UnityEngine.Quaternion>("Rotation");
        /// <summary>Rotation of the view.</summary>
        public UnityEngine.Quaternion Rotation
        {
            get { return RotationProperty.GetValue(this); }
            set { RotationProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<UnityEngine.Vector3> PositionProperty = new DependencyProperty<UnityEngine.Vector3>("Position");
        /// <summary>Directly sets the local position of the view relative to parent. Position otherwise set using the Alignment and Offset properties.</summary>
        public UnityEngine.Vector3 Position
        {
            get { return PositionProperty.GetValue(this); }
            set { PositionProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class UIViewTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return UIView;
            }
        }

        private static Template _uIView;
        public static Template UIView
        {
            get
            {
#if UNITY_EDITOR
                if (_uIView == null || _uIView.CurrentVersion != Template.Version)
#else
                if (_uIView == null)
#endif
                {
                    _uIView = new Template(SceneObjectViewTemplates.SceneObjectView);
#if UNITY_EDITOR
                    _uIView.Name = "UIView";
                    _uIView.LineNumber = 0;
                    _uIView.LinePosition = 0;
#endif
                    Delight.UIView.PivotProperty.SetDefault(_uIView, new Vector2(0.5f, 0.5f));
                    Delight.UIView.IsVisibleProperty.SetDefault(_uIView, true);
                    Delight.UIView.IsInteractableProperty.SetDefault(_uIView, true);
                    Delight.UIView.FastMaterialProperty.SetDefault(_uIView, Assets.Materials["UI-Fast-Default"]);
                }
                return _uIView;
            }
        }

        #endregion
    }

    #endregion
}
