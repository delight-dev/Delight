#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
#endregion

namespace Delight
{
    /// <summary>
    /// Label view.
    /// </summary>
    public partial class Label
    {
        /// <summary>
        /// Called when a property has been changed. 
        /// </summary>
        public override void OnPropertyChanged(object source, string property)
        {
            if (IgnoreObject)
                return;

            base.OnPropertyChanged(source, property);
            switch (property)
            {
                case nameof(AutoSize):
                case nameof(Text):
                    TextChanged();
                    break;
            }
        }

        protected override void BeforeLoad()
        {
            base.BeforeLoad();

            TextMeshProUGUI = GameObject.AddComponent<TMPro.TextMeshProUGUI>();
            if (AutoSize != AutoSize.None)
            {
                // adjust size initially to text
                TextChanged();
            }
        }

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
    }
}
