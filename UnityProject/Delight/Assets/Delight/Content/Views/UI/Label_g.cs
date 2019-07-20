#if !DELIGHT_MODULE_TEXTMESHPRO

// Internal view logic generated from "Label.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Label : UIView
    {
        #region Constructors

        public Label(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? LabelTemplates.Default, initializer)
        {
            this.AfterInitializeInternal();
        }

        public Label() : this(null)
        {
        }

        static Label()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(LabelTemplates.Default, dependencyProperties);

            dependencyProperties.Add(TextComponentProperty);
            dependencyProperties.Add(TextAlignmentProperty);
            dependencyProperties.Add(EnableWordWrappingProperty);
            dependencyProperties.Add(AutoSizeProperty);
            dependencyProperties.Add(OverflowModeProperty);
            dependencyProperties.Add(ExtraPaddingProperty);
            dependencyProperties.Add(FontProperty);
            dependencyProperties.Add(TextProperty);
            dependencyProperties.Add(SupportRichTextProperty);
            dependencyProperties.Add(ResizeTextForBestFitProperty);
            dependencyProperties.Add(ResizeTextMinSizeProperty);
            dependencyProperties.Add(ResizeTextMaxSizeProperty);
            dependencyProperties.Add(TextComponentTextAlignmentProperty);
            dependencyProperties.Add(AlignByGeometryProperty);
            dependencyProperties.Add(FontSizeProperty);
            dependencyProperties.Add(HorizontalOverflowProperty);
            dependencyProperties.Add(VerticalOverflowProperty);
            dependencyProperties.Add(LineSpacingProperty);
            dependencyProperties.Add(FontStyleProperty);
            dependencyProperties.Add(OnCullStateChangedProperty);
            dependencyProperties.Add(MaskableProperty);
            dependencyProperties.Add(FontColorProperty);
            dependencyProperties.Add(RaycastTargetProperty);
            dependencyProperties.Add(MaterialProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<UnityEngine.UI.Text> TextComponentProperty = new DependencyProperty<UnityEngine.UI.Text>("TextComponent");
        public UnityEngine.UI.Text TextComponent
        {
            get { return TextComponentProperty.GetValue(this); }
            set { TextComponentProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.ElementAlignment> TextAlignmentProperty = new DependencyProperty<Delight.ElementAlignment>("TextAlignment");
        public Delight.ElementAlignment TextAlignment
        {
            get { return TextAlignmentProperty.GetValue(this); }
            set { TextAlignmentProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> EnableWordWrappingProperty = new DependencyProperty<System.Boolean>("EnableWordWrapping");
        public System.Boolean EnableWordWrapping
        {
            get { return EnableWordWrappingProperty.GetValue(this); }
            set { EnableWordWrappingProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.AutoSize> AutoSizeProperty = new DependencyProperty<Delight.AutoSize>("AutoSize");
        public Delight.AutoSize AutoSize
        {
            get { return AutoSizeProperty.GetValue(this); }
            set { AutoSizeProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.String> OverflowModeProperty = new DependencyProperty<System.String>("OverflowMode");
        public System.String OverflowMode
        {
            get { return OverflowModeProperty.GetValue(this); }
            set { OverflowModeProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> ExtraPaddingProperty = new DependencyProperty<System.Boolean>("ExtraPadding");
        public System.Boolean ExtraPadding
        {
            get { return ExtraPaddingProperty.GetValue(this); }
            set { ExtraPaddingProperty.SetValue(this, value); }
        }

        public readonly static MappedAssetDependencyProperty<FontAsset, UnityEngine.UI.Text, Label> FontProperty = new MappedAssetDependencyProperty<FontAsset, UnityEngine.UI.Text, Label>("Font", x => x.TextComponent, (x, y) => x.font = y?.UnityObject);
        public FontAsset Font
        {
            get { return FontProperty.GetValue(this); }
            set { FontProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.String, UnityEngine.UI.Text, Label> TextProperty = new MappedDependencyProperty<System.String, UnityEngine.UI.Text, Label>("Text", x => x.TextComponent, x => x.text, (x, y) => x.text = y);
        public System.String Text
        {
            get { return TextProperty.GetValue(this); }
            set { TextProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.UI.Text, Label> SupportRichTextProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.UI.Text, Label>("SupportRichText", x => x.TextComponent, x => x.supportRichText, (x, y) => x.supportRichText = y);
        public System.Boolean SupportRichText
        {
            get { return SupportRichTextProperty.GetValue(this); }
            set { SupportRichTextProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.UI.Text, Label> ResizeTextForBestFitProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.UI.Text, Label>("ResizeTextForBestFit", x => x.TextComponent, x => x.resizeTextForBestFit, (x, y) => x.resizeTextForBestFit = y);
        public System.Boolean ResizeTextForBestFit
        {
            get { return ResizeTextForBestFitProperty.GetValue(this); }
            set { ResizeTextForBestFitProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, UnityEngine.UI.Text, Label> ResizeTextMinSizeProperty = new MappedDependencyProperty<System.Int32, UnityEngine.UI.Text, Label>("ResizeTextMinSize", x => x.TextComponent, x => x.resizeTextMinSize, (x, y) => x.resizeTextMinSize = y);
        public System.Int32 ResizeTextMinSize
        {
            get { return ResizeTextMinSizeProperty.GetValue(this); }
            set { ResizeTextMinSizeProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, UnityEngine.UI.Text, Label> ResizeTextMaxSizeProperty = new MappedDependencyProperty<System.Int32, UnityEngine.UI.Text, Label>("ResizeTextMaxSize", x => x.TextComponent, x => x.resizeTextMaxSize, (x, y) => x.resizeTextMaxSize = y);
        public System.Int32 ResizeTextMaxSize
        {
            get { return ResizeTextMaxSizeProperty.GetValue(this); }
            set { ResizeTextMaxSizeProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.TextAnchor, UnityEngine.UI.Text, Label> TextComponentTextAlignmentProperty = new MappedDependencyProperty<UnityEngine.TextAnchor, UnityEngine.UI.Text, Label>("TextComponentTextAlignment", x => x.TextComponent, x => x.alignment, (x, y) => x.alignment = y);
        public UnityEngine.TextAnchor TextComponentTextAlignment
        {
            get { return TextComponentTextAlignmentProperty.GetValue(this); }
            set { TextComponentTextAlignmentProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.UI.Text, Label> AlignByGeometryProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.UI.Text, Label>("AlignByGeometry", x => x.TextComponent, x => x.alignByGeometry, (x, y) => x.alignByGeometry = y);
        public System.Boolean AlignByGeometry
        {
            get { return AlignByGeometryProperty.GetValue(this); }
            set { AlignByGeometryProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, UnityEngine.UI.Text, Label> FontSizeProperty = new MappedDependencyProperty<System.Int32, UnityEngine.UI.Text, Label>("FontSize", x => x.TextComponent, x => x.fontSize, (x, y) => x.fontSize = y);
        public System.Int32 FontSize
        {
            get { return FontSizeProperty.GetValue(this); }
            set { FontSizeProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.HorizontalWrapMode, UnityEngine.UI.Text, Label> HorizontalOverflowProperty = new MappedDependencyProperty<UnityEngine.HorizontalWrapMode, UnityEngine.UI.Text, Label>("HorizontalOverflow", x => x.TextComponent, x => x.horizontalOverflow, (x, y) => x.horizontalOverflow = y);
        public UnityEngine.HorizontalWrapMode HorizontalOverflow
        {
            get { return HorizontalOverflowProperty.GetValue(this); }
            set { HorizontalOverflowProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.VerticalWrapMode, UnityEngine.UI.Text, Label> VerticalOverflowProperty = new MappedDependencyProperty<UnityEngine.VerticalWrapMode, UnityEngine.UI.Text, Label>("VerticalOverflow", x => x.TextComponent, x => x.verticalOverflow, (x, y) => x.verticalOverflow = y);
        public UnityEngine.VerticalWrapMode VerticalOverflow
        {
            get { return VerticalOverflowProperty.GetValue(this); }
            set { VerticalOverflowProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Single, UnityEngine.UI.Text, Label> LineSpacingProperty = new MappedDependencyProperty<System.Single, UnityEngine.UI.Text, Label>("LineSpacing", x => x.TextComponent, x => x.lineSpacing, (x, y) => x.lineSpacing = y);
        public System.Single LineSpacing
        {
            get { return LineSpacingProperty.GetValue(this); }
            set { LineSpacingProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.FontStyle, UnityEngine.UI.Text, Label> FontStyleProperty = new MappedDependencyProperty<UnityEngine.FontStyle, UnityEngine.UI.Text, Label>("FontStyle", x => x.TextComponent, x => x.fontStyle, (x, y) => x.fontStyle = y);
        public UnityEngine.FontStyle FontStyle
        {
            get { return FontStyleProperty.GetValue(this); }
            set { FontStyleProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.UI.MaskableGraphic.CullStateChangedEvent, UnityEngine.UI.Text, Label> OnCullStateChangedProperty = new MappedDependencyProperty<UnityEngine.UI.MaskableGraphic.CullStateChangedEvent, UnityEngine.UI.Text, Label>("OnCullStateChanged", x => x.TextComponent, x => x.onCullStateChanged, (x, y) => x.onCullStateChanged = y);
        public UnityEngine.UI.MaskableGraphic.CullStateChangedEvent OnCullStateChanged
        {
            get { return OnCullStateChangedProperty.GetValue(this); }
            set { OnCullStateChangedProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.UI.Text, Label> MaskableProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.UI.Text, Label>("Maskable", x => x.TextComponent, x => x.maskable, (x, y) => x.maskable = y);
        public System.Boolean Maskable
        {
            get { return MaskableProperty.GetValue(this); }
            set { MaskableProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<UnityEngine.Color, UnityEngine.UI.Text, Label> FontColorProperty = new MappedDependencyProperty<UnityEngine.Color, UnityEngine.UI.Text, Label>("FontColor", x => x.TextComponent, x => x.color, (x, y) => x.color = y);
        public UnityEngine.Color FontColor
        {
            get { return FontColorProperty.GetValue(this); }
            set { FontColorProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.UI.Text, Label> RaycastTargetProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.UI.Text, Label>("RaycastTarget", x => x.TextComponent, x => x.raycastTarget, (x, y) => x.raycastTarget = y);
        public System.Boolean RaycastTarget
        {
            get { return RaycastTargetProperty.GetValue(this); }
            set { RaycastTargetProperty.SetValue(this, value); }
        }

        public readonly static MappedAssetDependencyProperty<MaterialAsset, UnityEngine.UI.Text, Label> MaterialProperty = new MappedAssetDependencyProperty<MaterialAsset, UnityEngine.UI.Text, Label>("Material", x => x.TextComponent, (x, y) => x.material = y?.UnityObject);
        public MaterialAsset Material
        {
            get { return MaterialProperty.GetValue(this); }
            set { MaterialProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class LabelTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return Label;
            }
        }

        private static Template _label;
        public static Template Label
        {
            get
            {
#if UNITY_EDITOR
                if (_label == null || _label.CurrentVersion != Template.Version)
#else
                if (_label == null)
#endif
                {
                    _label = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _label.Name = "Label";
#endif
                    Delight.Label.TextAlignmentProperty.SetDefault(_label, Delight.ElementAlignment.Left);
                    Delight.Label.WidthProperty.SetDefault(_label, new ElementSize(180f, ElementSizeUnit.Pixels));
                    Delight.Label.HeightProperty.SetDefault(_label, new ElementSize(40f, ElementSizeUnit.Pixels));
                    Delight.Label.FontColorProperty.SetDefault(_label, new UnityEngine.Color(0f, 0f, 0f, 1f));
                    Delight.Label.FontSizeProperty.SetDefault(_label, 24);
                    Delight.Label.VerticalOverflowProperty.SetDefault(_label, UnityEngine.VerticalWrapMode.Overflow);
                }
                return _label;
            }
        }

        #endregion
    }

    #endregion
}

#endif
