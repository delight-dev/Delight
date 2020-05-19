// add module "TextMeshPro" to Config.txt to enable TextMeshPro integration
#if DELIGHT_MODULE_TEXTMESHPRO

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// View that presents text. Based on TextMeshPro text component.
    /// </summary>
    public partial class Label
    {
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
            base.BeforeLoad();

            TextMeshProUGUI = GameObject.AddComponent<TMPro.TextMeshProUGUI>();
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
                    TextMeshProUGUI.enabled = false;
                }
            }

            if (AutoSize != AutoSize.None)
            {
                // adjust size initially to text
                TextChanged();
            }

            //Debug.Log( "#Delight# Loading Label " + Name );
        }

        /// <summary>
        /// Enables font when loaded.
        /// </summary>
        public virtual void FontChanged()
        {
            if (!IsActive)
                return;

            if (LoadMode.HasFlag(LoadMode.HiddenWhileLoading))
            {
                if (Font != null && Font.IsLoaded)
                {
                    TextMeshProUGUI.enabled = true;
                }
            }

            //Debug.Log( "#Delight# Loading Font: " + Name );
            //TextMeshProUGUI.ForceMeshUpdate();
        }

        /// <summary>
        /// Called when label text changes.
        /// </summary>
        public virtual void TextChanged()
        {
            try
            {
                if (AutoSize != AutoSize.None && EnableWordWrappingProperty.IsUndefined(this))
                {
                    // when autosizing disable wordwrapping so PreferredWidth is calculated correctly
                    EnableWordWrapping = false;
                }

                var margin = Margin ?? new ElementMargin();

                // adjust label size to text
                if (AutoSize == AutoSize.Width)
                {
                    Width = new ElementSize(PreferredWidth + margin.Left + margin.Right);
                }
                else if (AutoSize == AutoSize.Height)
                {
                    Height = new ElementSize(PreferredHeight + margin.Top + margin.Bottom);
                }
                else if (AutoSize == AutoSize.WidthAndHeight || AutoSize == AutoSize.Default)
                {                    
                    if (MaxWidth != null)
                    {
                        // if MaxWidth is set we want the label to expand and then wrap when reaching the max width                        
                        float actualPreferredWidth = PreferredWidth + margin.Left + margin.Right;
                        if (actualPreferredWidth > MaxWidth)
                        {
                            EnableWordWrapping = true;
                            Width = new ElementSize(MaxWidth);
                        }
                        else
                        {
                            EnableWordWrapping = false;
                            Width = new ElementSize(actualPreferredWidth);                            
                        }

                        UpdateLayout(false);
                        Height = new ElementSize(PreferredHeight + margin.Top + margin.Bottom);
                    }
                    else
                    {
                        Width = new ElementSize(PreferredWidth + margin.Left + margin.Right);
                        Height = new ElementSize(PreferredHeight + margin.Top + margin.Bottom);
                    }
                }
            }
            catch
            {
                // bugfix of older version of TextMeshPro bug where PreferredWidth / PreferredHeight throws exceptions
            }
        }

        /// <summary>
        /// Sets text alignment.
        /// </summary>
        public void SetTextAlignment(ElementAlignment textAlignment)
        {
            switch (textAlignment)
            {
                case ElementAlignment.Center:
                    TextAlignment = TMPro.TextAlignmentOptions.Center;
                    break;
                case ElementAlignment.Left:
                    TextAlignment = TMPro.TextAlignmentOptions.Left;
                    break;
                case ElementAlignment.Top:
                    TextAlignment = TMPro.TextAlignmentOptions.Top;
                    break;
                case ElementAlignment.Right:
                    TextAlignment = TMPro.TextAlignmentOptions.Right;
                    break;
                case ElementAlignment.Bottom:
                    TextAlignment = TMPro.TextAlignmentOptions.Left;
                    break;
                case ElementAlignment.TopLeft:
                    TextAlignment = TMPro.TextAlignmentOptions.TopLeft;
                    break;
                case ElementAlignment.TopRight:
                    TextAlignment = TMPro.TextAlignmentOptions.TopRight;
                    break;
                case ElementAlignment.BottomLeft:
                    TextAlignment = TMPro.TextAlignmentOptions.BottomLeft;
                    break;
                case ElementAlignment.BottomRight:
                    TextAlignment = TMPro.TextAlignmentOptions.BottomRight;
                    break;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Preferred width of text.
        /// </summary>
        public virtual float PreferredWidth
        {
            get
            {
                return TextMeshProUGUI != null ? TextMeshProUGUI.preferredWidth : 0;
            }
        }

        /// <summary>
        /// Preferred height of text.
        /// </summary>
        public virtual float PreferredHeight
        {
            get
            {
                return TextMeshProUGUI != null ? TextMeshProUGUI.preferredHeight : 0;
            }
        }

        #endregion
    }
}

#endif