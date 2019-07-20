#if !DELIGHT_MODULE_TEXTMESHPRO

#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    /// <summary>
    /// Presents text. Based on the UGUI text component.
    /// </summary>
    public partial class Label
    {
        #region Fields

        private ContentSizeFitter _contentSizeFitter;

        #endregion

        #region Methods

        /// <summary>
        /// Called when a property has been changed. 
        /// </summary>
        public override void OnChanged(string property)
        {
            base.OnChanged(property);
            switch (property)
            {
                case nameof(Font):
                    FontChanged();
                    break;

                case nameof(AutoSize):
                case nameof(Text):
                    TextChanged();
                    break;
            }
        }

        /// <summary>
        /// Called before the view is loaded.
        /// </summary>
        protected override void BeforeLoad()
        {
            if (IgnoreObject)
                return;

            if (AutoSize != AutoSize.None)
            {
                EnableScriptEvents = true;
            }
                       
            base.BeforeLoad();

            TextComponent = GameObject.AddComponent<UnityEngine.UI.Text>();

            var defaultHorizontalOverflow = HorizontalWrapMode.Wrap;
            if (AutoSize != AutoSize.None)
            {
                // add content size fitter
                _contentSizeFitter = GameObject.AddComponent<ContentSizeFitter>();
                if (AutoSize == AutoSize.Width || AutoSize == AutoSize.WidthAndHeight || AutoSize == AutoSize.True)
                {
                    // overflow by default if we autosize
                    defaultHorizontalOverflow = HorizontalWrapMode.Overflow;
                    _contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
                }

                if (AutoSize == AutoSize.Height || AutoSize == AutoSize.WidthAndHeight || AutoSize == AutoSize.True)
                {
                    _contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
                }
            }

            // set overflow defualt
            if (HorizontalOverflowProperty.IsUndefined(this))
            {
                HorizontalOverflow = defaultHorizontalOverflow;                
            }
        }

        /// <summary>
        /// When AutoSize adjust size of label to content size fitter.
        /// </summary>
        public override void Update()
        {
            base.Update();
            SetSize(ActualWidth, ActualHeight);
        }

        /// <summary>
        /// Called after the view is loaded.
        /// </summary>
        protected override void AfterLoad()
        {
            if (IgnoreObject)
                return;
            base.AfterLoad();

            // enable to have fonts pop in instead
            if (LoadMode.HasFlag(LoadMode.HiddenWhileLoading))
            {
                if (Font != null && !Font.IsLoaded)
                {
                    // hide text while loading
                    TextComponent.enabled = false;
                }
            }

            // adjust size initially to text
            TextChanged();
        }

        /// <summary>
        /// Enables font when loaded.
        /// </summary>
        public virtual void FontChanged()
        {
            if (LoadMode.HasFlag(LoadMode.HiddenWhileLoading))
            {
                if (Font != null && Font.IsLoaded)
                {
                    TextComponent.enabled = true;
                }
            }
        }

        /// <summary>
        /// Called when label text changes.
        /// </summary>
        public virtual void TextChanged()
        {
            TextComponent.alignment = TextAnchor;
            if (Font == null && TextComponent.font == null)
            {
                TextComponent.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            }
        }

        #endregion

        #region Properties

        public ContentSizeFitter ContentSizeFitter { get; set; }

        public float PreferredWidth
        {
            get { return Width != null && Width.Unit == ElementSizeUnit.Pixels ? Width : 120; }
        }

        public float PreferredHeight
        {
            get { return Height != null && Height.Unit == ElementSizeUnit.Pixels ? Height : 40; }
        }

        public TextAnchor TextAnchor
        {
            get
            {
                switch (TextAlignment)
                {
                    case ElementAlignment.TopLeft:
                        return TextAnchor.UpperLeft;
                    case ElementAlignment.Top:
                        return TextAnchor.UpperCenter;
                    case ElementAlignment.TopRight:
                        return TextAnchor.UpperRight;
                    case ElementAlignment.Left:
                        return TextAnchor.MiddleLeft;
                    case ElementAlignment.Right:
                        return TextAnchor.MiddleRight;
                    case ElementAlignment.BottomLeft:
                        return TextAnchor.LowerLeft;
                    case ElementAlignment.Bottom:
                        return TextAnchor.LowerCenter;
                    case ElementAlignment.BottomRight:
                        return TextAnchor.LowerRight;
                    case ElementAlignment.Center:
                    default:
                        return TextAnchor.MiddleCenter;
                }
            }
        }

        #endregion
    }
}

#endif