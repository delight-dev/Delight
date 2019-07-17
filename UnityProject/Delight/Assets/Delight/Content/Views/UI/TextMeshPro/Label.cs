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
            // adjust label size to text
            if (AutoSize == AutoSize.Width)
            {
                Width = new ElementSize(PreferredWidth);
            }
            else if (AutoSize == AutoSize.Height)
            {
                Height = new ElementSize(PreferredHeight);
            }
            else if (AutoSize == AutoSize.WidthAndHeight || AutoSize == AutoSize.Default)
            {
                Width = new ElementSize(PreferredWidth);
                Height = new ElementSize(PreferredHeight);
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