// Internal view logic generated from "TabPanel.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class TabPanel : Collection
    {
        #region Constructors

        public TabPanel(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? TabPanelTemplates.Default, initializer)
        {
            // constructing ViewSwitcher (TabSwitcher)
            TabSwitcher = new ViewSwitcher(this, this, "TabSwitcher", TabSwitcherTemplate);

            // constructing ToggleGroup (TabHeaderGroup)
            TabHeaderGroup = new ToggleGroup(this, this, "TabHeaderGroup", TabHeaderGroupTemplate);
            ContentContainer = TabSwitcher;
            this.AfterInitializeInternal();
        }

        public TabPanel() : this(null)
        {
        }

        static TabPanel()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(TabPanelTemplates.Default, dependencyProperties);

            dependencyProperties.Add(SelectedTabIndexProperty);
            dependencyProperties.Add(IsStaticProperty);
            dependencyProperties.Add(TabHeaderWidthProperty);
            dependencyProperties.Add(TabHeaderHeightProperty);
            dependencyProperties.Add(TabSelectedProperty);
            dependencyProperties.Add(TabSwitcherProperty);
            dependencyProperties.Add(TabSwitcherTemplateProperty);
            dependencyProperties.Add(TabHeaderGroupProperty);
            dependencyProperties.Add(TabHeaderGroupTemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<System.Int32> SelectedTabIndexProperty = new DependencyProperty<System.Int32>("SelectedTabIndex");
        public System.Int32 SelectedTabIndex
        {
            get { return SelectedTabIndexProperty.GetValue(this); }
            set { SelectedTabIndexProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsStaticProperty = new DependencyProperty<System.Boolean>("IsStatic");
        public System.Boolean IsStatic
        {
            get { return IsStaticProperty.GetValue(this); }
            set { IsStaticProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementSize> TabHeaderWidthProperty = new DependencyProperty<Delight.ElementSize>("TabHeaderWidth");
        public Delight.ElementSize TabHeaderWidth
        {
            get { return TabHeaderWidthProperty.GetValue(this); }
            set { TabHeaderWidthProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementSize> TabHeaderHeightProperty = new DependencyProperty<Delight.ElementSize>("TabHeaderHeight");
        public Delight.ElementSize TabHeaderHeight
        {
            get { return TabHeaderHeightProperty.GetValue(this); }
            set { TabHeaderHeightProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewAction> TabSelectedProperty = new DependencyProperty<ViewAction>("TabSelected", () => new ViewAction());
        public ViewAction TabSelected
        {
            get { return TabSelectedProperty.GetValue(this); }
            set { TabSelectedProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewSwitcher> TabSwitcherProperty = new DependencyProperty<ViewSwitcher>("TabSwitcher");
        public ViewSwitcher TabSwitcher
        {
            get { return TabSwitcherProperty.GetValue(this); }
            set { TabSwitcherProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> TabSwitcherTemplateProperty = new DependencyProperty<Template>("TabSwitcherTemplate");
        public Template TabSwitcherTemplate
        {
            get { return TabSwitcherTemplateProperty.GetValue(this); }
            set { TabSwitcherTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ToggleGroup> TabHeaderGroupProperty = new DependencyProperty<ToggleGroup>("TabHeaderGroup");
        public ToggleGroup TabHeaderGroup
        {
            get { return TabHeaderGroupProperty.GetValue(this); }
            set { TabHeaderGroupProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> TabHeaderGroupTemplateProperty = new DependencyProperty<Template>("TabHeaderGroupTemplate");
        public Template TabHeaderGroupTemplate
        {
            get { return TabHeaderGroupTemplateProperty.GetValue(this); }
            set { TabHeaderGroupTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty TabListSpacingProperty = ToggleGroup.SpacingProperty;
        public Delight.ElementSize TabListSpacing
        {
            get { return TabHeaderGroup.Spacing; }
            set { TabHeaderGroup.Spacing = value; }
        }

        public readonly static DependencyProperty TabListOrientationProperty = ToggleGroup.OrientationProperty;
        public Delight.ElementOrientation TabListOrientation
        {
            get { return TabHeaderGroup.Orientation; }
            set { TabHeaderGroup.Orientation = value; }
        }

        public readonly static DependencyProperty TabListContentAlignmentProperty = ToggleGroup.ContentAlignmentProperty;
        public Delight.ElementAlignment TabListContentAlignment
        {
            get { return TabHeaderGroup.ContentAlignment; }
            set { TabHeaderGroup.ContentAlignment = value; }
        }

        public readonly static DependencyProperty TabListBackgroundSpriteProperty = ToggleGroup.BackgroundSpriteProperty;
        public SpriteAsset TabListBackgroundSprite
        {
            get { return TabHeaderGroup.BackgroundSprite; }
            set { TabHeaderGroup.BackgroundSprite = value; }
        }

        public readonly static DependencyProperty TabListBackgroundOverrideSpriteProperty = ToggleGroup.BackgroundOverrideSpriteProperty;
        public SpriteAsset TabListBackgroundOverrideSprite
        {
            get { return TabHeaderGroup.BackgroundOverrideSprite; }
            set { TabHeaderGroup.BackgroundOverrideSprite = value; }
        }

        public readonly static DependencyProperty TabListBackgroundTypeProperty = ToggleGroup.BackgroundTypeProperty;
        public UnityEngine.UI.Image.Type TabListBackgroundType
        {
            get { return TabHeaderGroup.BackgroundType; }
            set { TabHeaderGroup.BackgroundType = value; }
        }

        public readonly static DependencyProperty TabListBackgroundPreserveAspectProperty = ToggleGroup.BackgroundPreserveAspectProperty;
        public System.Boolean TabListBackgroundPreserveAspect
        {
            get { return TabHeaderGroup.BackgroundPreserveAspect; }
            set { TabHeaderGroup.BackgroundPreserveAspect = value; }
        }

        public readonly static DependencyProperty TabListBackgroundFillCenterProperty = ToggleGroup.BackgroundFillCenterProperty;
        public System.Boolean TabListBackgroundFillCenter
        {
            get { return TabHeaderGroup.BackgroundFillCenter; }
            set { TabHeaderGroup.BackgroundFillCenter = value; }
        }

        public readonly static DependencyProperty TabListBackgroundFillMethodProperty = ToggleGroup.BackgroundFillMethodProperty;
        public UnityEngine.UI.Image.FillMethod TabListBackgroundFillMethod
        {
            get { return TabHeaderGroup.BackgroundFillMethod; }
            set { TabHeaderGroup.BackgroundFillMethod = value; }
        }

        public readonly static DependencyProperty TabListBackgroundFillAmountProperty = ToggleGroup.BackgroundFillAmountProperty;
        public System.Single TabListBackgroundFillAmount
        {
            get { return TabHeaderGroup.BackgroundFillAmount; }
            set { TabHeaderGroup.BackgroundFillAmount = value; }
        }

        public readonly static DependencyProperty TabListBackgroundFillClockwiseProperty = ToggleGroup.BackgroundFillClockwiseProperty;
        public System.Boolean TabListBackgroundFillClockwise
        {
            get { return TabHeaderGroup.BackgroundFillClockwise; }
            set { TabHeaderGroup.BackgroundFillClockwise = value; }
        }

        public readonly static DependencyProperty TabListBackgroundFillOriginProperty = ToggleGroup.BackgroundFillOriginProperty;
        public System.Int32 TabListBackgroundFillOrigin
        {
            get { return TabHeaderGroup.BackgroundFillOrigin; }
            set { TabHeaderGroup.BackgroundFillOrigin = value; }
        }

        public readonly static DependencyProperty TabListBackgroundAlphaHitTestMinimumThresholdProperty = ToggleGroup.BackgroundAlphaHitTestMinimumThresholdProperty;
        public System.Single TabListBackgroundAlphaHitTestMinimumThreshold
        {
            get { return TabHeaderGroup.BackgroundAlphaHitTestMinimumThreshold; }
            set { TabHeaderGroup.BackgroundAlphaHitTestMinimumThreshold = value; }
        }

        public readonly static DependencyProperty TabListBackgroundUseSpriteMeshProperty = ToggleGroup.BackgroundUseSpriteMeshProperty;
        public System.Boolean TabListBackgroundUseSpriteMesh
        {
            get { return TabHeaderGroup.BackgroundUseSpriteMesh; }
            set { TabHeaderGroup.BackgroundUseSpriteMesh = value; }
        }

        public readonly static DependencyProperty TabListBackgroundMaterialProperty = ToggleGroup.BackgroundMaterialProperty;
        public MaterialAsset TabListBackgroundMaterial
        {
            get { return TabHeaderGroup.BackgroundMaterial; }
            set { TabHeaderGroup.BackgroundMaterial = value; }
        }

        public readonly static DependencyProperty TabListBackgroundOnCullStateChangedProperty = ToggleGroup.BackgroundOnCullStateChangedProperty;
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent TabListBackgroundOnCullStateChanged
        {
            get { return TabHeaderGroup.BackgroundOnCullStateChanged; }
            set { TabHeaderGroup.BackgroundOnCullStateChanged = value; }
        }

        public readonly static DependencyProperty TabListBackgroundMaskableProperty = ToggleGroup.BackgroundMaskableProperty;
        public System.Boolean TabListBackgroundMaskable
        {
            get { return TabHeaderGroup.BackgroundMaskable; }
            set { TabHeaderGroup.BackgroundMaskable = value; }
        }

        public readonly static DependencyProperty TabListBackgroundColorProperty = ToggleGroup.BackgroundColorProperty;
        public UnityEngine.Color TabListBackgroundColor
        {
            get { return TabHeaderGroup.BackgroundColor; }
            set { TabHeaderGroup.BackgroundColor = value; }
        }

        public readonly static DependencyProperty TabListBackgroundRaycastTargetProperty = ToggleGroup.BackgroundRaycastTargetProperty;
        public System.Boolean TabListBackgroundRaycastTarget
        {
            get { return TabHeaderGroup.BackgroundRaycastTarget; }
            set { TabHeaderGroup.BackgroundRaycastTarget = value; }
        }

        public readonly static DependencyProperty TabListWidthProperty = ToggleGroup.WidthProperty;
        public Delight.ElementSize TabListWidth
        {
            get { return TabHeaderGroup.Width; }
            set { TabHeaderGroup.Width = value; }
        }

        public readonly static DependencyProperty TabListHeightProperty = ToggleGroup.HeightProperty;
        public Delight.ElementSize TabListHeight
        {
            get { return TabHeaderGroup.Height; }
            set { TabHeaderGroup.Height = value; }
        }

        public readonly static DependencyProperty TabListOverrideWidthProperty = ToggleGroup.OverrideWidthProperty;
        public Delight.ElementSize TabListOverrideWidth
        {
            get { return TabHeaderGroup.OverrideWidth; }
            set { TabHeaderGroup.OverrideWidth = value; }
        }

        public readonly static DependencyProperty TabListOverrideHeightProperty = ToggleGroup.OverrideHeightProperty;
        public Delight.ElementSize TabListOverrideHeight
        {
            get { return TabHeaderGroup.OverrideHeight; }
            set { TabHeaderGroup.OverrideHeight = value; }
        }

        public readonly static DependencyProperty TabListScaleProperty = ToggleGroup.ScaleProperty;
        public UnityEngine.Vector3 TabListScale
        {
            get { return TabHeaderGroup.Scale; }
            set { TabHeaderGroup.Scale = value; }
        }

        public readonly static DependencyProperty TabListAlignmentProperty = ToggleGroup.AlignmentProperty;
        public Delight.ElementAlignment TabListAlignment
        {
            get { return TabHeaderGroup.Alignment; }
            set { TabHeaderGroup.Alignment = value; }
        }

        public readonly static DependencyProperty TabListMarginProperty = ToggleGroup.MarginProperty;
        public Delight.ElementMargin TabListMargin
        {
            get { return TabHeaderGroup.Margin; }
            set { TabHeaderGroup.Margin = value; }
        }

        public readonly static DependencyProperty TabListOffsetProperty = ToggleGroup.OffsetProperty;
        public Delight.ElementMargin TabListOffset
        {
            get { return TabHeaderGroup.Offset; }
            set { TabHeaderGroup.Offset = value; }
        }

        public readonly static DependencyProperty TabListOffsetFromParentProperty = ToggleGroup.OffsetFromParentProperty;
        public Delight.ElementMargin TabListOffsetFromParent
        {
            get { return TabHeaderGroup.OffsetFromParent; }
            set { TabHeaderGroup.OffsetFromParent = value; }
        }

        public readonly static DependencyProperty TabListPivotProperty = ToggleGroup.PivotProperty;
        public UnityEngine.Vector2 TabListPivot
        {
            get { return TabHeaderGroup.Pivot; }
            set { TabHeaderGroup.Pivot = value; }
        }

        public readonly static DependencyProperty TabListLayoutRootProperty = ToggleGroup.LayoutRootProperty;
        public Delight.LayoutRoot TabListLayoutRoot
        {
            get { return TabHeaderGroup.LayoutRoot; }
            set { TabHeaderGroup.LayoutRoot = value; }
        }

        public readonly static DependencyProperty TabListDisableLayoutUpdateProperty = ToggleGroup.DisableLayoutUpdateProperty;
        public System.Boolean TabListDisableLayoutUpdate
        {
            get { return TabHeaderGroup.DisableLayoutUpdate; }
            set { TabHeaderGroup.DisableLayoutUpdate = value; }
        }

        public readonly static DependencyProperty TabListAlphaProperty = ToggleGroup.AlphaProperty;
        public System.Single TabListAlpha
        {
            get { return TabHeaderGroup.Alpha; }
            set { TabHeaderGroup.Alpha = value; }
        }

        public readonly static DependencyProperty TabListIsVisibleProperty = ToggleGroup.IsVisibleProperty;
        public System.Boolean TabListIsVisible
        {
            get { return TabHeaderGroup.IsVisible; }
            set { TabHeaderGroup.IsVisible = value; }
        }

        public readonly static DependencyProperty TabListRaycastBlockModeProperty = ToggleGroup.RaycastBlockModeProperty;
        public Delight.RaycastBlockMode TabListRaycastBlockMode
        {
            get { return TabHeaderGroup.RaycastBlockMode; }
            set { TabHeaderGroup.RaycastBlockMode = value; }
        }

        public readonly static DependencyProperty TabListUseFastShaderProperty = ToggleGroup.UseFastShaderProperty;
        public System.Boolean TabListUseFastShader
        {
            get { return TabHeaderGroup.UseFastShader; }
            set { TabHeaderGroup.UseFastShader = value; }
        }

        public readonly static DependencyProperty TabListBubbleNotifyChildLayoutChangedProperty = ToggleGroup.BubbleNotifyChildLayoutChangedProperty;
        public System.Boolean TabListBubbleNotifyChildLayoutChanged
        {
            get { return TabHeaderGroup.BubbleNotifyChildLayoutChanged; }
            set { TabHeaderGroup.BubbleNotifyChildLayoutChanged = value; }
        }

        public readonly static DependencyProperty TabListIgnoreFlipProperty = ToggleGroup.IgnoreFlipProperty;
        public System.Boolean TabListIgnoreFlip
        {
            get { return TabHeaderGroup.IgnoreFlip; }
            set { TabHeaderGroup.IgnoreFlip = value; }
        }

        public readonly static DependencyProperty TabListGameObjectProperty = ToggleGroup.GameObjectProperty;
        public UnityEngine.GameObject TabListGameObject
        {
            get { return TabHeaderGroup.GameObject; }
            set { TabHeaderGroup.GameObject = value; }
        }

        public readonly static DependencyProperty TabListEnableScriptEventsProperty = ToggleGroup.EnableScriptEventsProperty;
        public System.Boolean TabListEnableScriptEvents
        {
            get { return TabHeaderGroup.EnableScriptEvents; }
            set { TabHeaderGroup.EnableScriptEvents = value; }
        }

        public readonly static DependencyProperty TabListIgnoreObjectProperty = ToggleGroup.IgnoreObjectProperty;
        public System.Boolean TabListIgnoreObject
        {
            get { return TabHeaderGroup.IgnoreObject; }
            set { TabHeaderGroup.IgnoreObject = value; }
        }

        public readonly static DependencyProperty TabListIsActiveProperty = ToggleGroup.IsActiveProperty;
        public System.Boolean TabListIsActive
        {
            get { return TabHeaderGroup.IsActive; }
            set { TabHeaderGroup.IsActive = value; }
        }

        public readonly static DependencyProperty TabListLoadModeProperty = ToggleGroup.LoadModeProperty;
        public Delight.LoadMode TabListLoadMode
        {
            get { return TabHeaderGroup.LoadMode; }
            set { TabHeaderGroup.LoadMode = value; }
        }

        #endregion
    }

    #region Data Templates

    public static class TabPanelTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return TabPanel;
            }
        }

        private static Template _tabPanel;
        public static Template TabPanel
        {
            get
            {
#if UNITY_EDITOR
                if (_tabPanel == null || _tabPanel.CurrentVersion != Template.Version)
#else
                if (_tabPanel == null)
#endif
                {
                    _tabPanel = new Template(CollectionTemplates.Collection);
#if UNITY_EDITOR
                    _tabPanel.Name = "TabPanel";
#endif
                    Delight.TabPanel.SelectedTabIndexProperty.SetDefault(_tabPanel, 0);
                    Delight.TabPanel.TabSwitcherTemplateProperty.SetDefault(_tabPanel, TabPanelTabSwitcher);
                    Delight.TabPanel.TabHeaderGroupTemplateProperty.SetDefault(_tabPanel, TabPanelTabHeaderGroup);
                }
                return _tabPanel;
            }
        }

        private static Template _tabPanelTabSwitcher;
        public static Template TabPanelTabSwitcher
        {
            get
            {
#if UNITY_EDITOR
                if (_tabPanelTabSwitcher == null || _tabPanelTabSwitcher.CurrentVersion != Template.Version)
#else
                if (_tabPanelTabSwitcher == null)
#endif
                {
                    _tabPanelTabSwitcher = new Template(ViewSwitcherTemplates.ViewSwitcher);
#if UNITY_EDITOR
                    _tabPanelTabSwitcher.Name = "TabPanelTabSwitcher";
#endif
                }
                return _tabPanelTabSwitcher;
            }
        }

        private static Template _tabPanelTabHeaderGroup;
        public static Template TabPanelTabHeaderGroup
        {
            get
            {
#if UNITY_EDITOR
                if (_tabPanelTabHeaderGroup == null || _tabPanelTabHeaderGroup.CurrentVersion != Template.Version)
#else
                if (_tabPanelTabHeaderGroup == null)
#endif
                {
                    _tabPanelTabHeaderGroup = new Template(ToggleGroupTemplates.ToggleGroup);
#if UNITY_EDITOR
                    _tabPanelTabHeaderGroup.Name = "TabPanelTabHeaderGroup";
#endif
                    Delight.ToggleGroup.OrientationProperty.SetDefault(_tabPanelTabHeaderGroup, Delight.ElementOrientation.Horizontal);
                    Delight.ToggleGroup.AlignmentProperty.SetDefault(_tabPanelTabHeaderGroup, Delight.ElementAlignment.TopLeft);
                }
                return _tabPanelTabHeaderGroup;
            }
        }

        #endregion
    }

    #endregion
}
