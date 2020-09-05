// Internal view logic generated from "Slider.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Slider : UIImageView
    {
        #region Constructors

        public Slider(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? SliderTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Region (SliderRegion)
            SliderRegion = new Region(this, this, "SliderRegion", SliderRegionTemplate);
            SliderBackgroundImageView = new Image(this, SliderRegion.Content, "SliderBackgroundImageView", SliderBackgroundImageViewTemplate);
            SliderFillRegion = new Region(this, SliderRegion.Content, "SliderFillRegion", SliderFillRegionTemplate);
            SliderFillImageView = new Image(this, SliderFillRegion.Content, "SliderFillImageView", SliderFillImageViewTemplate);
            SliderHandleImageView = new Image(this, SliderRegion.Content, "SliderHandleImageView", SliderHandleImageViewTemplate);
            Drag.RegisterHandler(this, "SliderDrag");
            BeginDrag.RegisterHandler(this, "SliderBeginDrag");
            EndDrag.RegisterHandler(this, "SliderEndDrag");
            InitializePotentialDrag.RegisterHandler(this, "SliderInitializePotentialDrag");
            this.AfterInitializeInternal();
        }

        public Slider() : this(null)
        {
        }

        static Slider()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(SliderTemplates.Default, dependencyProperties);

            dependencyProperties.Add(LengthProperty);
            dependencyProperties.Add(BreadthProperty);
            dependencyProperties.Add(OrientationProperty);
            dependencyProperties.Add(MinProperty);
            dependencyProperties.Add(MaxProperty);
            dependencyProperties.Add(ValueProperty);
            dependencyProperties.Add(CanSlideProperty);
            dependencyProperties.Add(SetValueOnDragEndedProperty);
            dependencyProperties.Add(IsReversedProperty);
            dependencyProperties.Add(StepsProperty);
            dependencyProperties.Add(ValueChangedProperty);
            dependencyProperties.Add(SliderRegionProperty);
            dependencyProperties.Add(SliderRegionTemplateProperty);
            dependencyProperties.Add(SliderBackgroundImageViewProperty);
            dependencyProperties.Add(SliderBackgroundImageViewTemplateProperty);
            dependencyProperties.Add(SliderFillRegionProperty);
            dependencyProperties.Add(SliderFillRegionTemplateProperty);
            dependencyProperties.Add(SliderFillImageViewProperty);
            dependencyProperties.Add(SliderFillImageViewTemplateProperty);
            dependencyProperties.Add(SliderHandleImageViewProperty);
            dependencyProperties.Add(SliderHandleImageViewTemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.ElementSize> LengthProperty = new DependencyProperty<Delight.ElementSize>("Length");
        /// <summary>The length of the slider. Corresponds to Width if horizontal and Height if vertical.</summary>
        public Delight.ElementSize Length
        {
            get { return LengthProperty.GetValue(this); }
            set { LengthProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementSize> BreadthProperty = new DependencyProperty<Delight.ElementSize>("Breadth");
        /// <summary>The breadth of the slider. Corresponds to Height if horizontal and Width if vertical.</summary>
        public Delight.ElementSize Breadth
        {
            get { return BreadthProperty.GetValue(this); }
            set { BreadthProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementOrientation> OrientationProperty = new DependencyProperty<Delight.ElementOrientation>("Orientation");
        /// <summary>Orientation of the slider (horizontal or vertical).</summary>
        public Delight.ElementOrientation Orientation
        {
            get { return OrientationProperty.GetValue(this); }
            set { OrientationProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Single> MinProperty = new DependencyProperty<System.Single>("Min");
        /// <summary>Minimum value of the slider.</summary>
        public System.Single Min
        {
            get { return MinProperty.GetValue(this); }
            set { MinProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Single> MaxProperty = new DependencyProperty<System.Single>("Max");
        /// <summary>Maximum value of the slider.</summary>
        public System.Single Max
        {
            get { return MaxProperty.GetValue(this); }
            set { MaxProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Single> ValueProperty = new DependencyProperty<System.Single>("Value");
        /// <summary>Current value of the slider.</summary>
        public System.Single Value
        {
            get { return ValueProperty.GetValue(this); }
            set { ValueProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> CanSlideProperty = new DependencyProperty<System.Boolean>("CanSlide");
        /// <summary>Boolean indicating if the user can interact with the slider.</summary>
        public System.Boolean CanSlide
        {
            get { return CanSlideProperty.GetValue(this); }
            set { CanSlideProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> SetValueOnDragEndedProperty = new DependencyProperty<System.Boolean>("SetValueOnDragEnded");
        /// <summary>Boolean indicating that the slider value is set when the user releases the handle.</summary>
        public System.Boolean SetValueOnDragEnded
        {
            get { return SetValueOnDragEndedProperty.GetValue(this); }
            set { SetValueOnDragEndedProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsReversedProperty = new DependencyProperty<System.Boolean>("IsReversed");
        /// <summary>Boolean indicating if slider direction is reversed.</summary>
        public System.Boolean IsReversed
        {
            get { return IsReversedProperty.GetValue(this); }
            set { IsReversedProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Single> StepsProperty = new DependencyProperty<System.Single>("Steps");
        /// <summary>Specifies the number of steps there should be between min and max slider value.</summary>
        public System.Single Steps
        {
            get { return StepsProperty.GetValue(this); }
            set { StepsProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> ValueChangedProperty = new DependencyProperty<ViewAction>("ValueChanged", () => new ViewAction());
        /// <summary>Action called when the slider value changes.</summary>
        public ViewAction ValueChanged
        {
            get { return ValueChangedProperty.GetValue(this); }
            set { ValueChangedProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> SliderRegionProperty = new DependencyProperty<Region>("SliderRegion");
        public Region SliderRegion
        {
            get { return SliderRegionProperty.GetValue(this); }
            set { SliderRegionProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> SliderRegionTemplateProperty = new DependencyProperty<Template>("SliderRegionTemplate");
        public Template SliderRegionTemplate
        {
            get { return SliderRegionTemplateProperty.GetValue(this); }
            set { SliderRegionTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Image> SliderBackgroundImageViewProperty = new DependencyProperty<Image>("SliderBackgroundImageView");
        public Image SliderBackgroundImageView
        {
            get { return SliderBackgroundImageViewProperty.GetValue(this); }
            set { SliderBackgroundImageViewProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> SliderBackgroundImageViewTemplateProperty = new DependencyProperty<Template>("SliderBackgroundImageViewTemplate");
        public Template SliderBackgroundImageViewTemplate
        {
            get { return SliderBackgroundImageViewTemplateProperty.GetValue(this); }
            set { SliderBackgroundImageViewTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> SliderFillRegionProperty = new DependencyProperty<Region>("SliderFillRegion");
        public Region SliderFillRegion
        {
            get { return SliderFillRegionProperty.GetValue(this); }
            set { SliderFillRegionProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> SliderFillRegionTemplateProperty = new DependencyProperty<Template>("SliderFillRegionTemplate");
        public Template SliderFillRegionTemplate
        {
            get { return SliderFillRegionTemplateProperty.GetValue(this); }
            set { SliderFillRegionTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Image> SliderFillImageViewProperty = new DependencyProperty<Image>("SliderFillImageView");
        public Image SliderFillImageView
        {
            get { return SliderFillImageViewProperty.GetValue(this); }
            set { SliderFillImageViewProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> SliderFillImageViewTemplateProperty = new DependencyProperty<Template>("SliderFillImageViewTemplate");
        public Template SliderFillImageViewTemplate
        {
            get { return SliderFillImageViewTemplateProperty.GetValue(this); }
            set { SliderFillImageViewTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Image> SliderHandleImageViewProperty = new DependencyProperty<Image>("SliderHandleImageView");
        public Image SliderHandleImageView
        {
            get { return SliderHandleImageViewProperty.GetValue(this); }
            set { SliderHandleImageViewProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> SliderHandleImageViewTemplateProperty = new DependencyProperty<Template>("SliderHandleImageViewTemplate");
        public Template SliderHandleImageViewTemplate
        {
            get { return SliderHandleImageViewTemplateProperty.GetValue(this); }
            set { SliderHandleImageViewTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty SliderSpriteProperty = Image.SpriteProperty;
        public SpriteAsset SliderSprite
        {
            get { return SliderBackgroundImageView.Sprite; }
            set { SliderBackgroundImageView.Sprite = value; }
        }

        public readonly static DependencyProperty SliderOverrideSpriteProperty = Image.OverrideSpriteProperty;
        public SpriteAsset SliderOverrideSprite
        {
            get { return SliderBackgroundImageView.OverrideSprite; }
            set { SliderBackgroundImageView.OverrideSprite = value; }
        }

        public readonly static DependencyProperty SliderTypeProperty = Image.TypeProperty;
        public UnityEngine.UI.Image.Type SliderType
        {
            get { return SliderBackgroundImageView.Type; }
            set { SliderBackgroundImageView.Type = value; }
        }

        public readonly static DependencyProperty SliderPreserveAspectProperty = Image.PreserveAspectProperty;
        public System.Boolean SliderPreserveAspect
        {
            get { return SliderBackgroundImageView.PreserveAspect; }
            set { SliderBackgroundImageView.PreserveAspect = value; }
        }

        public readonly static DependencyProperty SliderFillCenterProperty = Image.FillCenterProperty;
        public System.Boolean SliderFillCenter
        {
            get { return SliderBackgroundImageView.FillCenter; }
            set { SliderBackgroundImageView.FillCenter = value; }
        }

        public readonly static DependencyProperty SliderFillMethodProperty = Image.FillMethodProperty;
        public UnityEngine.UI.Image.FillMethod SliderFillMethod
        {
            get { return SliderBackgroundImageView.FillMethod; }
            set { SliderBackgroundImageView.FillMethod = value; }
        }

        public readonly static DependencyProperty SliderFillAmountProperty = Image.FillAmountProperty;
        public System.Single SliderFillAmount
        {
            get { return SliderBackgroundImageView.FillAmount; }
            set { SliderBackgroundImageView.FillAmount = value; }
        }

        public readonly static DependencyProperty SliderFillClockwiseProperty = Image.FillClockwiseProperty;
        public System.Boolean SliderFillClockwise
        {
            get { return SliderBackgroundImageView.FillClockwise; }
            set { SliderBackgroundImageView.FillClockwise = value; }
        }

        public readonly static DependencyProperty SliderFillOriginProperty = Image.FillOriginProperty;
        public System.Int32 SliderFillOrigin
        {
            get { return SliderBackgroundImageView.FillOrigin; }
            set { SliderBackgroundImageView.FillOrigin = value; }
        }

        public readonly static DependencyProperty SliderAlphaHitTestMinimumThresholdProperty = Image.AlphaHitTestMinimumThresholdProperty;
        public System.Single SliderAlphaHitTestMinimumThreshold
        {
            get { return SliderBackgroundImageView.AlphaHitTestMinimumThreshold; }
            set { SliderBackgroundImageView.AlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty SliderUseSpriteMeshProperty = Image.UseSpriteMeshProperty;
        public System.Boolean SliderUseSpriteMesh
        {
            get { return SliderBackgroundImageView.UseSpriteMesh; }
            set { SliderBackgroundImageView.UseSpriteMesh = value; }
        }

        public readonly static DependencyProperty SliderPixelsPerUnitMultiplierProperty = Image.PixelsPerUnitMultiplierProperty;
        public System.Single SliderPixelsPerUnitMultiplier
        {
            get { return SliderBackgroundImageView.PixelsPerUnitMultiplier; }
            set { SliderBackgroundImageView.PixelsPerUnitMultiplier = value; }
        }

        public readonly static DependencyProperty SliderMaterialProperty = Image.MaterialProperty;
        public MaterialAsset SliderMaterial
        {
            get { return SliderBackgroundImageView.Material; }
            set { SliderBackgroundImageView.Material = value; }
        }

        public readonly static DependencyProperty SliderOnCullStateChangedProperty = Image.OnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent SliderOnCullStateChanged
        {
            get { return SliderBackgroundImageView.OnCullStateChanged; }
            set { SliderBackgroundImageView.OnCullStateChanged = value; }
        }

        public readonly static DependencyProperty SliderMaskableProperty = Image.MaskableProperty;
        public System.Boolean SliderMaskable
        {
            get { return SliderBackgroundImageView.Maskable; }
            set { SliderBackgroundImageView.Maskable = value; }
        }

        public readonly static DependencyProperty SliderIsMaskingGraphicProperty = Image.IsMaskingGraphicProperty;
        public System.Boolean SliderIsMaskingGraphic
        {
            get { return SliderBackgroundImageView.IsMaskingGraphic; }
            set { SliderBackgroundImageView.IsMaskingGraphic = value; }
        }

        public readonly static DependencyProperty SliderColorProperty = Image.ColorProperty;
        public UnityEngine.Color SliderColor
        {
            get { return SliderBackgroundImageView.Color; }
            set { SliderBackgroundImageView.Color = value; }
        }

        public readonly static DependencyProperty SliderRaycastTargetProperty = Image.RaycastTargetProperty;
        public System.Boolean SliderRaycastTarget
        {
            get { return SliderBackgroundImageView.RaycastTarget; }
            set { SliderBackgroundImageView.RaycastTarget = value; }
        }

        public readonly static DependencyProperty SliderWidthProperty = Image.WidthProperty;
        public Delight.ElementSize SliderWidth
        {
            get { return SliderBackgroundImageView.Width; }
            set { SliderBackgroundImageView.Width = value; }
        }

        public readonly static DependencyProperty SliderHeightProperty = Image.HeightProperty;
        public Delight.ElementSize SliderHeight
        {
            get { return SliderBackgroundImageView.Height; }
            set { SliderBackgroundImageView.Height = value; }
        }

        public readonly static DependencyProperty SliderOverrideWidthProperty = Image.OverrideWidthProperty;
        public Delight.ElementSize SliderOverrideWidth
        {
            get { return SliderBackgroundImageView.OverrideWidth; }
            set { SliderBackgroundImageView.OverrideWidth = value; }
        }

        public readonly static DependencyProperty SliderOverrideHeightProperty = Image.OverrideHeightProperty;
        public Delight.ElementSize SliderOverrideHeight
        {
            get { return SliderBackgroundImageView.OverrideHeight; }
            set { SliderBackgroundImageView.OverrideHeight = value; }
        }

        public readonly static DependencyProperty SliderScaleProperty = Image.ScaleProperty;
        public UnityEngine.Vector3 SliderScale
        {
            get { return SliderBackgroundImageView.Scale; }
            set { SliderBackgroundImageView.Scale = value; }
        }

        public readonly static DependencyProperty SliderAlignmentProperty = Image.AlignmentProperty;
        public Delight.ElementAlignment SliderAlignment
        {
            get { return SliderBackgroundImageView.Alignment; }
            set { SliderBackgroundImageView.Alignment = value; }
        }

        public readonly static DependencyProperty SliderMarginProperty = Image.MarginProperty;
        public Delight.ElementMargin SliderMargin
        {
            get { return SliderBackgroundImageView.Margin; }
            set { SliderBackgroundImageView.Margin = value; }
        }

        public readonly static DependencyProperty SliderOffsetProperty = Image.OffsetProperty;
        public Delight.ElementMargin SliderOffset
        {
            get { return SliderBackgroundImageView.Offset; }
            set { SliderBackgroundImageView.Offset = value; }
        }

        public readonly static DependencyProperty SliderOffsetFromParentProperty = Image.OffsetFromParentProperty;
        public Delight.ElementMargin SliderOffsetFromParent
        {
            get { return SliderBackgroundImageView.OffsetFromParent; }
            set { SliderBackgroundImageView.OffsetFromParent = value; }
        }

        public readonly static DependencyProperty SliderPivotProperty = Image.PivotProperty;
        public UnityEngine.Vector2 SliderPivot
        {
            get { return SliderBackgroundImageView.Pivot; }
            set { SliderBackgroundImageView.Pivot = value; }
        }

        public readonly static DependencyProperty SliderDisableLayoutUpdateProperty = Image.DisableLayoutUpdateProperty;
        public System.Boolean SliderDisableLayoutUpdate
        {
            get { return SliderBackgroundImageView.DisableLayoutUpdate; }
            set { SliderBackgroundImageView.DisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty SliderAlphaProperty = Image.AlphaProperty;
        public System.Single SliderAlpha
        {
            get { return SliderBackgroundImageView.Alpha; }
            set { SliderBackgroundImageView.Alpha = value; }
        }

        public readonly static DependencyProperty SliderIsVisibleProperty = Image.IsVisibleProperty;
        public System.Boolean SliderIsVisible
        {
            get { return SliderBackgroundImageView.IsVisible; }
            set { SliderBackgroundImageView.IsVisible = value; }
        }

        public readonly static DependencyProperty SliderRaycastBlockModeProperty = Image.RaycastBlockModeProperty;
        public Delight.RaycastBlockMode SliderRaycastBlockMode
        {
            get { return SliderBackgroundImageView.RaycastBlockMode; }
            set { SliderBackgroundImageView.RaycastBlockMode = value; }
        }

        public readonly static DependencyProperty SliderIsInteractableProperty = Image.IsInteractableProperty;
        public System.Boolean SliderIsInteractable
        {
            get { return SliderBackgroundImageView.IsInteractable; }
            set { SliderBackgroundImageView.IsInteractable = value; }
        }

        public readonly static DependencyProperty SliderUseFastShaderProperty = Image.UseFastShaderProperty;
        public System.Boolean SliderUseFastShader
        {
            get { return SliderBackgroundImageView.UseFastShader; }
            set { SliderBackgroundImageView.UseFastShader = value; }
        }

        public readonly static DependencyProperty SliderBubbleNotifyChildLayoutChangedProperty = Image.BubbleNotifyChildLayoutChangedProperty;
        public System.Boolean SliderBubbleNotifyChildLayoutChanged
        {
            get { return SliderBackgroundImageView.BubbleNotifyChildLayoutChanged; }
            set { SliderBackgroundImageView.BubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty SliderIgnoreFlipProperty = Image.IgnoreFlipProperty;
        public System.Boolean SliderIgnoreFlip
        {
            get { return SliderBackgroundImageView.IgnoreFlip; }
            set { SliderBackgroundImageView.IgnoreFlip = value; }
        }

        public readonly static DependencyProperty SliderRotationProperty = Image.RotationProperty;
        public UnityEngine.Quaternion SliderRotation
        {
            get { return SliderBackgroundImageView.Rotation; }
            set { SliderBackgroundImageView.Rotation = value; }
        }

        public readonly static DependencyProperty SliderPositionProperty = Image.PositionProperty;
        public UnityEngine.Vector3 SliderPosition
        {
            get { return SliderBackgroundImageView.Position; }
            set { SliderBackgroundImageView.Position = value; }
        }

        public readonly static DependencyProperty SliderGameObjectProperty = Image.GameObjectProperty;
        public UnityEngine.GameObject SliderGameObject
        {
            get { return SliderBackgroundImageView.GameObject; }
            set { SliderBackgroundImageView.GameObject = value; }
        }

        public readonly static DependencyProperty SliderEnableScriptEventsProperty = Image.EnableScriptEventsProperty;
        public System.Boolean SliderEnableScriptEvents
        {
            get { return SliderBackgroundImageView.EnableScriptEvents; }
            set { SliderBackgroundImageView.EnableScriptEvents = value; }
        }

        public readonly static DependencyProperty SliderIgnoreObjectProperty = Image.IgnoreObjectProperty;
        public System.Boolean SliderIgnoreObject
        {
            get { return SliderBackgroundImageView.IgnoreObject; }
            set { SliderBackgroundImageView.IgnoreObject = value; }
        }

        public readonly static DependencyProperty SliderIsActiveProperty = Image.IsActiveProperty;
        public System.Boolean SliderIsActive
        {
            get { return SliderBackgroundImageView.IsActive; }
            set { SliderBackgroundImageView.IsActive = value; }
        }

        public readonly static DependencyProperty SliderLoadModeProperty = Image.LoadModeProperty;
        public Delight.LoadMode SliderLoadMode
        {
            get { return SliderBackgroundImageView.LoadMode; }
            set { SliderBackgroundImageView.LoadMode = value; }
        }

        public readonly static DependencyProperty SliderFillSpriteProperty = Image.SpriteProperty;
        public SpriteAsset SliderFillSprite
        {
            get { return SliderFillImageView.Sprite; }
            set { SliderFillImageView.Sprite = value; }
        }

        public readonly static DependencyProperty SliderFillOverrideSpriteProperty = Image.OverrideSpriteProperty;
        public SpriteAsset SliderFillOverrideSprite
        {
            get { return SliderFillImageView.OverrideSprite; }
            set { SliderFillImageView.OverrideSprite = value; }
        }

        public readonly static DependencyProperty SliderFillTypeProperty = Image.TypeProperty;
        public UnityEngine.UI.Image.Type SliderFillType
        {
            get { return SliderFillImageView.Type; }
            set { SliderFillImageView.Type = value; }
        }

        public readonly static DependencyProperty SliderFillPreserveAspectProperty = Image.PreserveAspectProperty;
        public System.Boolean SliderFillPreserveAspect
        {
            get { return SliderFillImageView.PreserveAspect; }
            set { SliderFillImageView.PreserveAspect = value; }
        }

        public readonly static DependencyProperty SliderFillFillCenterProperty = Image.FillCenterProperty;
        public System.Boolean SliderFillFillCenter
        {
            get { return SliderFillImageView.FillCenter; }
            set { SliderFillImageView.FillCenter = value; }
        }

        public readonly static DependencyProperty SliderFillFillMethodProperty = Image.FillMethodProperty;
        public UnityEngine.UI.Image.FillMethod SliderFillFillMethod
        {
            get { return SliderFillImageView.FillMethod; }
            set { SliderFillImageView.FillMethod = value; }
        }

        public readonly static DependencyProperty SliderFillFillAmountProperty = Image.FillAmountProperty;
        public System.Single SliderFillFillAmount
        {
            get { return SliderFillImageView.FillAmount; }
            set { SliderFillImageView.FillAmount = value; }
        }

        public readonly static DependencyProperty SliderFillFillClockwiseProperty = Image.FillClockwiseProperty;
        public System.Boolean SliderFillFillClockwise
        {
            get { return SliderFillImageView.FillClockwise; }
            set { SliderFillImageView.FillClockwise = value; }
        }

        public readonly static DependencyProperty SliderFillFillOriginProperty = Image.FillOriginProperty;
        public System.Int32 SliderFillFillOrigin
        {
            get { return SliderFillImageView.FillOrigin; }
            set { SliderFillImageView.FillOrigin = value; }
        }

        public readonly static DependencyProperty SliderFillAlphaHitTestMinimumThresholdProperty = Image.AlphaHitTestMinimumThresholdProperty;
        public System.Single SliderFillAlphaHitTestMinimumThreshold
        {
            get { return SliderFillImageView.AlphaHitTestMinimumThreshold; }
            set { SliderFillImageView.AlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty SliderFillUseSpriteMeshProperty = Image.UseSpriteMeshProperty;
        public System.Boolean SliderFillUseSpriteMesh
        {
            get { return SliderFillImageView.UseSpriteMesh; }
            set { SliderFillImageView.UseSpriteMesh = value; }
        }

        public readonly static DependencyProperty SliderFillPixelsPerUnitMultiplierProperty = Image.PixelsPerUnitMultiplierProperty;
        public System.Single SliderFillPixelsPerUnitMultiplier
        {
            get { return SliderFillImageView.PixelsPerUnitMultiplier; }
            set { SliderFillImageView.PixelsPerUnitMultiplier = value; }
        }

        public readonly static DependencyProperty SliderFillMaterialProperty = Image.MaterialProperty;
        public MaterialAsset SliderFillMaterial
        {
            get { return SliderFillImageView.Material; }
            set { SliderFillImageView.Material = value; }
        }

        public readonly static DependencyProperty SliderFillOnCullStateChangedProperty = Image.OnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent SliderFillOnCullStateChanged
        {
            get { return SliderFillImageView.OnCullStateChanged; }
            set { SliderFillImageView.OnCullStateChanged = value; }
        }

        public readonly static DependencyProperty SliderFillMaskableProperty = Image.MaskableProperty;
        public System.Boolean SliderFillMaskable
        {
            get { return SliderFillImageView.Maskable; }
            set { SliderFillImageView.Maskable = value; }
        }

        public readonly static DependencyProperty SliderFillIsMaskingGraphicProperty = Image.IsMaskingGraphicProperty;
        public System.Boolean SliderFillIsMaskingGraphic
        {
            get { return SliderFillImageView.IsMaskingGraphic; }
            set { SliderFillImageView.IsMaskingGraphic = value; }
        }

        public readonly static DependencyProperty SliderFillColorProperty = Image.ColorProperty;
        public UnityEngine.Color SliderFillColor
        {
            get { return SliderFillImageView.Color; }
            set { SliderFillImageView.Color = value; }
        }

        public readonly static DependencyProperty SliderFillRaycastTargetProperty = Image.RaycastTargetProperty;
        public System.Boolean SliderFillRaycastTarget
        {
            get { return SliderFillImageView.RaycastTarget; }
            set { SliderFillImageView.RaycastTarget = value; }
        }

        public readonly static DependencyProperty SliderFillWidthProperty = Image.WidthProperty;
        public Delight.ElementSize SliderFillWidth
        {
            get { return SliderFillImageView.Width; }
            set { SliderFillImageView.Width = value; }
        }

        public readonly static DependencyProperty SliderFillHeightProperty = Image.HeightProperty;
        public Delight.ElementSize SliderFillHeight
        {
            get { return SliderFillImageView.Height; }
            set { SliderFillImageView.Height = value; }
        }

        public readonly static DependencyProperty SliderFillOverrideWidthProperty = Image.OverrideWidthProperty;
        public Delight.ElementSize SliderFillOverrideWidth
        {
            get { return SliderFillImageView.OverrideWidth; }
            set { SliderFillImageView.OverrideWidth = value; }
        }

        public readonly static DependencyProperty SliderFillOverrideHeightProperty = Image.OverrideHeightProperty;
        public Delight.ElementSize SliderFillOverrideHeight
        {
            get { return SliderFillImageView.OverrideHeight; }
            set { SliderFillImageView.OverrideHeight = value; }
        }

        public readonly static DependencyProperty SliderFillScaleProperty = Image.ScaleProperty;
        public UnityEngine.Vector3 SliderFillScale
        {
            get { return SliderFillImageView.Scale; }
            set { SliderFillImageView.Scale = value; }
        }

        public readonly static DependencyProperty SliderFillAlignmentProperty = Image.AlignmentProperty;
        public Delight.ElementAlignment SliderFillAlignment
        {
            get { return SliderFillImageView.Alignment; }
            set { SliderFillImageView.Alignment = value; }
        }

        public readonly static DependencyProperty SliderFillMarginProperty = Image.MarginProperty;
        public Delight.ElementMargin SliderFillMargin
        {
            get { return SliderFillImageView.Margin; }
            set { SliderFillImageView.Margin = value; }
        }

        public readonly static DependencyProperty SliderFillOffsetProperty = Image.OffsetProperty;
        public Delight.ElementMargin SliderFillOffset
        {
            get { return SliderFillImageView.Offset; }
            set { SliderFillImageView.Offset = value; }
        }

        public readonly static DependencyProperty SliderFillOffsetFromParentProperty = Image.OffsetFromParentProperty;
        public Delight.ElementMargin SliderFillOffsetFromParent
        {
            get { return SliderFillImageView.OffsetFromParent; }
            set { SliderFillImageView.OffsetFromParent = value; }
        }

        public readonly static DependencyProperty SliderFillPivotProperty = Image.PivotProperty;
        public UnityEngine.Vector2 SliderFillPivot
        {
            get { return SliderFillImageView.Pivot; }
            set { SliderFillImageView.Pivot = value; }
        }

        public readonly static DependencyProperty SliderFillDisableLayoutUpdateProperty = Image.DisableLayoutUpdateProperty;
        public System.Boolean SliderFillDisableLayoutUpdate
        {
            get { return SliderFillImageView.DisableLayoutUpdate; }
            set { SliderFillImageView.DisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty SliderFillAlphaProperty = Image.AlphaProperty;
        public System.Single SliderFillAlpha
        {
            get { return SliderFillImageView.Alpha; }
            set { SliderFillImageView.Alpha = value; }
        }

        public readonly static DependencyProperty SliderFillIsVisibleProperty = Image.IsVisibleProperty;
        public System.Boolean SliderFillIsVisible
        {
            get { return SliderFillImageView.IsVisible; }
            set { SliderFillImageView.IsVisible = value; }
        }

        public readonly static DependencyProperty SliderFillRaycastBlockModeProperty = Image.RaycastBlockModeProperty;
        public Delight.RaycastBlockMode SliderFillRaycastBlockMode
        {
            get { return SliderFillImageView.RaycastBlockMode; }
            set { SliderFillImageView.RaycastBlockMode = value; }
        }

        public readonly static DependencyProperty SliderFillIsInteractableProperty = Image.IsInteractableProperty;
        public System.Boolean SliderFillIsInteractable
        {
            get { return SliderFillImageView.IsInteractable; }
            set { SliderFillImageView.IsInteractable = value; }
        }

        public readonly static DependencyProperty SliderFillUseFastShaderProperty = Image.UseFastShaderProperty;
        public System.Boolean SliderFillUseFastShader
        {
            get { return SliderFillImageView.UseFastShader; }
            set { SliderFillImageView.UseFastShader = value; }
        }

        public readonly static DependencyProperty SliderFillBubbleNotifyChildLayoutChangedProperty = Image.BubbleNotifyChildLayoutChangedProperty;
        public System.Boolean SliderFillBubbleNotifyChildLayoutChanged
        {
            get { return SliderFillImageView.BubbleNotifyChildLayoutChanged; }
            set { SliderFillImageView.BubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty SliderFillIgnoreFlipProperty = Image.IgnoreFlipProperty;
        public System.Boolean SliderFillIgnoreFlip
        {
            get { return SliderFillImageView.IgnoreFlip; }
            set { SliderFillImageView.IgnoreFlip = value; }
        }

        public readonly static DependencyProperty SliderFillRotationProperty = Image.RotationProperty;
        public UnityEngine.Quaternion SliderFillRotation
        {
            get { return SliderFillImageView.Rotation; }
            set { SliderFillImageView.Rotation = value; }
        }

        public readonly static DependencyProperty SliderFillPositionProperty = Image.PositionProperty;
        public UnityEngine.Vector3 SliderFillPosition
        {
            get { return SliderFillImageView.Position; }
            set { SliderFillImageView.Position = value; }
        }

        public readonly static DependencyProperty SliderFillGameObjectProperty = Image.GameObjectProperty;
        public UnityEngine.GameObject SliderFillGameObject
        {
            get { return SliderFillImageView.GameObject; }
            set { SliderFillImageView.GameObject = value; }
        }

        public readonly static DependencyProperty SliderFillEnableScriptEventsProperty = Image.EnableScriptEventsProperty;
        public System.Boolean SliderFillEnableScriptEvents
        {
            get { return SliderFillImageView.EnableScriptEvents; }
            set { SliderFillImageView.EnableScriptEvents = value; }
        }

        public readonly static DependencyProperty SliderFillIgnoreObjectProperty = Image.IgnoreObjectProperty;
        public System.Boolean SliderFillIgnoreObject
        {
            get { return SliderFillImageView.IgnoreObject; }
            set { SliderFillImageView.IgnoreObject = value; }
        }

        public readonly static DependencyProperty SliderFillIsActiveProperty = Image.IsActiveProperty;
        public System.Boolean SliderFillIsActive
        {
            get { return SliderFillImageView.IsActive; }
            set { SliderFillImageView.IsActive = value; }
        }

        public readonly static DependencyProperty SliderFillLoadModeProperty = Image.LoadModeProperty;
        public Delight.LoadMode SliderFillLoadMode
        {
            get { return SliderFillImageView.LoadMode; }
            set { SliderFillImageView.LoadMode = value; }
        }

        public readonly static DependencyProperty SliderHandleSpriteProperty = Image.SpriteProperty;
        public SpriteAsset SliderHandleSprite
        {
            get { return SliderHandleImageView.Sprite; }
            set { SliderHandleImageView.Sprite = value; }
        }

        public readonly static DependencyProperty SliderHandleOverrideSpriteProperty = Image.OverrideSpriteProperty;
        public SpriteAsset SliderHandleOverrideSprite
        {
            get { return SliderHandleImageView.OverrideSprite; }
            set { SliderHandleImageView.OverrideSprite = value; }
        }

        public readonly static DependencyProperty SliderHandleTypeProperty = Image.TypeProperty;
        public UnityEngine.UI.Image.Type SliderHandleType
        {
            get { return SliderHandleImageView.Type; }
            set { SliderHandleImageView.Type = value; }
        }

        public readonly static DependencyProperty SliderHandlePreserveAspectProperty = Image.PreserveAspectProperty;
        public System.Boolean SliderHandlePreserveAspect
        {
            get { return SliderHandleImageView.PreserveAspect; }
            set { SliderHandleImageView.PreserveAspect = value; }
        }

        public readonly static DependencyProperty SliderHandleFillCenterProperty = Image.FillCenterProperty;
        public System.Boolean SliderHandleFillCenter
        {
            get { return SliderHandleImageView.FillCenter; }
            set { SliderHandleImageView.FillCenter = value; }
        }

        public readonly static DependencyProperty SliderHandleFillMethodProperty = Image.FillMethodProperty;
        public UnityEngine.UI.Image.FillMethod SliderHandleFillMethod
        {
            get { return SliderHandleImageView.FillMethod; }
            set { SliderHandleImageView.FillMethod = value; }
        }

        public readonly static DependencyProperty SliderHandleFillAmountProperty = Image.FillAmountProperty;
        public System.Single SliderHandleFillAmount
        {
            get { return SliderHandleImageView.FillAmount; }
            set { SliderHandleImageView.FillAmount = value; }
        }

        public readonly static DependencyProperty SliderHandleFillClockwiseProperty = Image.FillClockwiseProperty;
        public System.Boolean SliderHandleFillClockwise
        {
            get { return SliderHandleImageView.FillClockwise; }
            set { SliderHandleImageView.FillClockwise = value; }
        }

        public readonly static DependencyProperty SliderHandleFillOriginProperty = Image.FillOriginProperty;
        public System.Int32 SliderHandleFillOrigin
        {
            get { return SliderHandleImageView.FillOrigin; }
            set { SliderHandleImageView.FillOrigin = value; }
        }

        public readonly static DependencyProperty SliderHandleAlphaHitTestMinimumThresholdProperty = Image.AlphaHitTestMinimumThresholdProperty;
        public System.Single SliderHandleAlphaHitTestMinimumThreshold
        {
            get { return SliderHandleImageView.AlphaHitTestMinimumThreshold; }
            set { SliderHandleImageView.AlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty SliderHandleUseSpriteMeshProperty = Image.UseSpriteMeshProperty;
        public System.Boolean SliderHandleUseSpriteMesh
        {
            get { return SliderHandleImageView.UseSpriteMesh; }
            set { SliderHandleImageView.UseSpriteMesh = value; }
        }

        public readonly static DependencyProperty SliderHandlePixelsPerUnitMultiplierProperty = Image.PixelsPerUnitMultiplierProperty;
        public System.Single SliderHandlePixelsPerUnitMultiplier
        {
            get { return SliderHandleImageView.PixelsPerUnitMultiplier; }
            set { SliderHandleImageView.PixelsPerUnitMultiplier = value; }
        }

        public readonly static DependencyProperty SliderHandleMaterialProperty = Image.MaterialProperty;
        public MaterialAsset SliderHandleMaterial
        {
            get { return SliderHandleImageView.Material; }
            set { SliderHandleImageView.Material = value; }
        }

        public readonly static DependencyProperty SliderHandleOnCullStateChangedProperty = Image.OnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent SliderHandleOnCullStateChanged
        {
            get { return SliderHandleImageView.OnCullStateChanged; }
            set { SliderHandleImageView.OnCullStateChanged = value; }
        }

        public readonly static DependencyProperty SliderHandleMaskableProperty = Image.MaskableProperty;
        public System.Boolean SliderHandleMaskable
        {
            get { return SliderHandleImageView.Maskable; }
            set { SliderHandleImageView.Maskable = value; }
        }

        public readonly static DependencyProperty SliderHandleIsMaskingGraphicProperty = Image.IsMaskingGraphicProperty;
        public System.Boolean SliderHandleIsMaskingGraphic
        {
            get { return SliderHandleImageView.IsMaskingGraphic; }
            set { SliderHandleImageView.IsMaskingGraphic = value; }
        }

        public readonly static DependencyProperty SliderHandleColorProperty = Image.ColorProperty;
        public UnityEngine.Color SliderHandleColor
        {
            get { return SliderHandleImageView.Color; }
            set { SliderHandleImageView.Color = value; }
        }

        public readonly static DependencyProperty SliderHandleRaycastTargetProperty = Image.RaycastTargetProperty;
        public System.Boolean SliderHandleRaycastTarget
        {
            get { return SliderHandleImageView.RaycastTarget; }
            set { SliderHandleImageView.RaycastTarget = value; }
        }

        public readonly static DependencyProperty SliderHandleWidthProperty = Image.WidthProperty;
        public Delight.ElementSize SliderHandleWidth
        {
            get { return SliderHandleImageView.Width; }
            set { SliderHandleImageView.Width = value; }
        }

        public readonly static DependencyProperty SliderHandleHeightProperty = Image.HeightProperty;
        public Delight.ElementSize SliderHandleHeight
        {
            get { return SliderHandleImageView.Height; }
            set { SliderHandleImageView.Height = value; }
        }

        public readonly static DependencyProperty SliderHandleOverrideWidthProperty = Image.OverrideWidthProperty;
        public Delight.ElementSize SliderHandleOverrideWidth
        {
            get { return SliderHandleImageView.OverrideWidth; }
            set { SliderHandleImageView.OverrideWidth = value; }
        }

        public readonly static DependencyProperty SliderHandleOverrideHeightProperty = Image.OverrideHeightProperty;
        public Delight.ElementSize SliderHandleOverrideHeight
        {
            get { return SliderHandleImageView.OverrideHeight; }
            set { SliderHandleImageView.OverrideHeight = value; }
        }

        public readonly static DependencyProperty SliderHandleScaleProperty = Image.ScaleProperty;
        public UnityEngine.Vector3 SliderHandleScale
        {
            get { return SliderHandleImageView.Scale; }
            set { SliderHandleImageView.Scale = value; }
        }

        public readonly static DependencyProperty SliderHandleAlignmentProperty = Image.AlignmentProperty;
        public Delight.ElementAlignment SliderHandleAlignment
        {
            get { return SliderHandleImageView.Alignment; }
            set { SliderHandleImageView.Alignment = value; }
        }

        public readonly static DependencyProperty SliderHandleMarginProperty = Image.MarginProperty;
        public Delight.ElementMargin SliderHandleMargin
        {
            get { return SliderHandleImageView.Margin; }
            set { SliderHandleImageView.Margin = value; }
        }

        public readonly static DependencyProperty SliderHandleOffsetProperty = Image.OffsetProperty;
        public Delight.ElementMargin SliderHandleOffset
        {
            get { return SliderHandleImageView.Offset; }
            set { SliderHandleImageView.Offset = value; }
        }

        public readonly static DependencyProperty SliderHandleOffsetFromParentProperty = Image.OffsetFromParentProperty;
        public Delight.ElementMargin SliderHandleOffsetFromParent
        {
            get { return SliderHandleImageView.OffsetFromParent; }
            set { SliderHandleImageView.OffsetFromParent = value; }
        }

        public readonly static DependencyProperty SliderHandlePivotProperty = Image.PivotProperty;
        public UnityEngine.Vector2 SliderHandlePivot
        {
            get { return SliderHandleImageView.Pivot; }
            set { SliderHandleImageView.Pivot = value; }
        }

        public readonly static DependencyProperty SliderHandleDisableLayoutUpdateProperty = Image.DisableLayoutUpdateProperty;
        public System.Boolean SliderHandleDisableLayoutUpdate
        {
            get { return SliderHandleImageView.DisableLayoutUpdate; }
            set { SliderHandleImageView.DisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty SliderHandleAlphaProperty = Image.AlphaProperty;
        public System.Single SliderHandleAlpha
        {
            get { return SliderHandleImageView.Alpha; }
            set { SliderHandleImageView.Alpha = value; }
        }

        public readonly static DependencyProperty SliderHandleIsVisibleProperty = Image.IsVisibleProperty;
        public System.Boolean SliderHandleIsVisible
        {
            get { return SliderHandleImageView.IsVisible; }
            set { SliderHandleImageView.IsVisible = value; }
        }

        public readonly static DependencyProperty SliderHandleRaycastBlockModeProperty = Image.RaycastBlockModeProperty;
        public Delight.RaycastBlockMode SliderHandleRaycastBlockMode
        {
            get { return SliderHandleImageView.RaycastBlockMode; }
            set { SliderHandleImageView.RaycastBlockMode = value; }
        }

        public readonly static DependencyProperty SliderHandleIsInteractableProperty = Image.IsInteractableProperty;
        public System.Boolean SliderHandleIsInteractable
        {
            get { return SliderHandleImageView.IsInteractable; }
            set { SliderHandleImageView.IsInteractable = value; }
        }

        public readonly static DependencyProperty SliderHandleUseFastShaderProperty = Image.UseFastShaderProperty;
        public System.Boolean SliderHandleUseFastShader
        {
            get { return SliderHandleImageView.UseFastShader; }
            set { SliderHandleImageView.UseFastShader = value; }
        }

        public readonly static DependencyProperty SliderHandleBubbleNotifyChildLayoutChangedProperty = Image.BubbleNotifyChildLayoutChangedProperty;
        public System.Boolean SliderHandleBubbleNotifyChildLayoutChanged
        {
            get { return SliderHandleImageView.BubbleNotifyChildLayoutChanged; }
            set { SliderHandleImageView.BubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty SliderHandleIgnoreFlipProperty = Image.IgnoreFlipProperty;
        public System.Boolean SliderHandleIgnoreFlip
        {
            get { return SliderHandleImageView.IgnoreFlip; }
            set { SliderHandleImageView.IgnoreFlip = value; }
        }

        public readonly static DependencyProperty SliderHandleRotationProperty = Image.RotationProperty;
        public UnityEngine.Quaternion SliderHandleRotation
        {
            get { return SliderHandleImageView.Rotation; }
            set { SliderHandleImageView.Rotation = value; }
        }

        public readonly static DependencyProperty SliderHandlePositionProperty = Image.PositionProperty;
        public UnityEngine.Vector3 SliderHandlePosition
        {
            get { return SliderHandleImageView.Position; }
            set { SliderHandleImageView.Position = value; }
        }

        public readonly static DependencyProperty SliderHandleGameObjectProperty = Image.GameObjectProperty;
        public UnityEngine.GameObject SliderHandleGameObject
        {
            get { return SliderHandleImageView.GameObject; }
            set { SliderHandleImageView.GameObject = value; }
        }

        public readonly static DependencyProperty SliderHandleEnableScriptEventsProperty = Image.EnableScriptEventsProperty;
        public System.Boolean SliderHandleEnableScriptEvents
        {
            get { return SliderHandleImageView.EnableScriptEvents; }
            set { SliderHandleImageView.EnableScriptEvents = value; }
        }

        public readonly static DependencyProperty SliderHandleIgnoreObjectProperty = Image.IgnoreObjectProperty;
        public System.Boolean SliderHandleIgnoreObject
        {
            get { return SliderHandleImageView.IgnoreObject; }
            set { SliderHandleImageView.IgnoreObject = value; }
        }

        public readonly static DependencyProperty SliderHandleIsActiveProperty = Image.IsActiveProperty;
        public System.Boolean SliderHandleIsActive
        {
            get { return SliderHandleImageView.IsActive; }
            set { SliderHandleImageView.IsActive = value; }
        }

        public readonly static DependencyProperty SliderHandleLoadModeProperty = Image.LoadModeProperty;
        public Delight.LoadMode SliderHandleLoadMode
        {
            get { return SliderHandleImageView.LoadMode; }
            set { SliderHandleImageView.LoadMode = value; }
        }

        #endregion
    }

    #region Data Templates

    public static class SliderTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return Slider;
            }
        }

        private static Template _slider;
        public static Template Slider
        {
            get
            {
#if UNITY_EDITOR
                if (_slider == null || _slider.CurrentVersion != Template.Version)
#else
                if (_slider == null)
#endif
                {
                    _slider = new Template(UIImageViewTemplates.UIImageView);
#if UNITY_EDITOR
                    _slider.Name = "Slider";
                    _slider.LineNumber = 0;
                    _slider.LinePosition = 0;
#endif
                    Delight.Slider.LengthProperty.SetDefault(_slider, new ElementSize(160f, ElementSizeUnit.Pixels));
                    Delight.Slider.BreadthProperty.SetDefault(_slider, new ElementSize(40f, ElementSizeUnit.Pixels));
                    Delight.Slider.OrientationProperty.SetDefault(_slider, Delight.ElementOrientation.Horizontal);
                    Delight.Slider.MinProperty.SetDefault(_slider, 0f);
                    Delight.Slider.MaxProperty.SetDefault(_slider, 100f);
                    Delight.Slider.CanSlideProperty.SetDefault(_slider, true);
                    Delight.Slider.BackgroundColorProperty.SetDefault(_slider, new UnityEngine.Color(0.3843137f, 0.3843137f, 0.3843137f, 1f));
                    Delight.Slider.BreadthProperty.SetDefault(_slider, new ElementSize(12f, ElementSizeUnit.Pixels));
                    Delight.Slider.SliderRegionTemplateProperty.SetDefault(_slider, SliderSliderRegion);
                    Delight.Slider.SliderBackgroundImageViewTemplateProperty.SetDefault(_slider, SliderSliderBackgroundImageView);
                    Delight.Slider.SliderFillRegionTemplateProperty.SetDefault(_slider, SliderSliderFillRegion);
                    Delight.Slider.SliderFillImageViewTemplateProperty.SetDefault(_slider, SliderSliderFillImageView);
                    Delight.Slider.SliderHandleImageViewTemplateProperty.SetDefault(_slider, SliderSliderHandleImageView);
                }
                return _slider;
            }
        }

        private static Template _sliderSliderRegion;
        public static Template SliderSliderRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_sliderSliderRegion == null || _sliderSliderRegion.CurrentVersion != Template.Version)
#else
                if (_sliderSliderRegion == null)
#endif
                {
                    _sliderSliderRegion = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _sliderSliderRegion.Name = "SliderSliderRegion";
                    _sliderSliderRegion.LineNumber = 11;
                    _sliderSliderRegion.LinePosition = 4;
#endif
                }
                return _sliderSliderRegion;
            }
        }

        private static Template _sliderSliderBackgroundImageView;
        public static Template SliderSliderBackgroundImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_sliderSliderBackgroundImageView == null || _sliderSliderBackgroundImageView.CurrentVersion != Template.Version)
#else
                if (_sliderSliderBackgroundImageView == null)
#endif
                {
                    _sliderSliderBackgroundImageView = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _sliderSliderBackgroundImageView.Name = "SliderSliderBackgroundImageView";
                    _sliderSliderBackgroundImageView.LineNumber = 12;
                    _sliderSliderBackgroundImageView.LinePosition = 6;
#endif
                    Delight.Image.WidthProperty.SetDefault(_sliderSliderBackgroundImageView, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Image.HeightProperty.SetDefault(_sliderSliderBackgroundImageView, new ElementSize(1f, ElementSizeUnit.Percents));
                }
                return _sliderSliderBackgroundImageView;
            }
        }

        private static Template _sliderSliderFillRegion;
        public static Template SliderSliderFillRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_sliderSliderFillRegion == null || _sliderSliderFillRegion.CurrentVersion != Template.Version)
#else
                if (_sliderSliderFillRegion == null)
#endif
                {
                    _sliderSliderFillRegion = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _sliderSliderFillRegion.Name = "SliderSliderFillRegion";
                    _sliderSliderFillRegion.LineNumber = 13;
                    _sliderSliderFillRegion.LinePosition = 6;
#endif
                    Delight.Region.MarginProperty.SetDefault(_sliderSliderFillRegion, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels)));
                }
                return _sliderSliderFillRegion;
            }
        }

        private static Template _sliderSliderFillImageView;
        public static Template SliderSliderFillImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_sliderSliderFillImageView == null || _sliderSliderFillImageView.CurrentVersion != Template.Version)
#else
                if (_sliderSliderFillImageView == null)
#endif
                {
                    _sliderSliderFillImageView = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _sliderSliderFillImageView.Name = "SliderSliderFillImageView";
                    _sliderSliderFillImageView.LineNumber = 14;
                    _sliderSliderFillImageView.LinePosition = 8;
#endif
                    Delight.Image.AlignmentProperty.SetDefault(_sliderSliderFillImageView, Delight.ElementAlignment.Left);
                    Delight.Image.WidthProperty.SetDefault(_sliderSliderFillImageView, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Image.HeightProperty.SetDefault(_sliderSliderFillImageView, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Image.ColorProperty.SetDefault(_sliderSliderFillImageView, new UnityEngine.Color(0.9372549f, 0.4392157f, 0.4156863f, 1f));
                }
                return _sliderSliderFillImageView;
            }
        }

        private static Template _sliderSliderHandleImageView;
        public static Template SliderSliderHandleImageView
        {
            get
            {
#if UNITY_EDITOR
                if (_sliderSliderHandleImageView == null || _sliderSliderHandleImageView.CurrentVersion != Template.Version)
#else
                if (_sliderSliderHandleImageView == null)
#endif
                {
                    _sliderSliderHandleImageView = new Template(ImageTemplates.Image);
#if UNITY_EDITOR
                    _sliderSliderHandleImageView.Name = "SliderSliderHandleImageView";
                    _sliderSliderHandleImageView.LineNumber = 16;
                    _sliderSliderHandleImageView.LinePosition = 6;
#endif
                    Delight.Image.AlignmentProperty.SetDefault(_sliderSliderHandleImageView, Delight.ElementAlignment.Left);
                    Delight.Image.WidthProperty.SetDefault(_sliderSliderHandleImageView, new ElementSize(20f, ElementSizeUnit.Pixels));
                    Delight.Image.HeightProperty.SetDefault(_sliderSliderHandleImageView, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Image.ColorProperty.SetDefault(_sliderSliderHandleImageView, new UnityEngine.Color(0.972549f, 0.9647059f, 0.9529412f, 1f));
                    Delight.Image.WidthProperty.SetDefault(_sliderSliderHandleImageView, new ElementSize(11f, ElementSizeUnit.Pixels));
                    Delight.Image.HeightProperty.SetDefault(_sliderSliderHandleImageView, new ElementSize(22f, ElementSizeUnit.Pixels));
                }
                return _sliderSliderHandleImageView;
            }
        }

        #endregion
    }

    #endregion
}
