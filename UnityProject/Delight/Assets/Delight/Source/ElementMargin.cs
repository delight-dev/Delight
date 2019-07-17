#region Using Statements
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Represents left, top, right and bottom margins or offset of an element.
    /// </summary>
    [Serializable]
    public class ElementMargin : AtomicBindableObject
    {
        #region Properties

        [SerializeField]
        private ElementSize _left;
        public ElementSize Left
        {
            get { return _left; }
            set
            {
                AttachListeners(_left, value);
                SetProperty(ref _left, value);
            }
        }

        [SerializeField]
        private ElementSize _top;
        public ElementSize Top
        {
            get { return _top; }
            set
            {
                AttachListeners(_top, value);
                SetProperty(ref _top, value);
            }
        }

        [SerializeField]
        private ElementSize _right;
        public ElementSize Right
        {
            get { return _right; }
            set
            {
                AttachListeners(_right, value);
                SetProperty(ref _right, value);
            }
        }

        [SerializeField]
        private ElementSize _bottom;
        public ElementSize Bottom
        {
            get { return _bottom; }
            set
            {
                AttachListeners(_bottom, value);
                SetProperty(ref _bottom, value);
            }
        }

        public static readonly ElementMargin Default = new ElementMargin();

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ElementMargin()
        {
            Left = new ElementSize();
            Top = new ElementSize();
            Right = new ElementSize();
            Bottom = new ElementSize();
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ElementMargin(ElementSize margin)
        {
            Left = new ElementSize(margin);
            Top = new ElementSize(margin);
            Right = new ElementSize(margin);
            Bottom = new ElementSize(margin);
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ElementMargin(ElementSize left, ElementSize top)
        {
            Left = new ElementSize(left);
            Top = new ElementSize(top);
            Right = new ElementSize();
            Bottom = new ElementSize();
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ElementMargin(ElementSize left, ElementSize top, ElementSize right)
            : this()
        {
            Left = new ElementSize(left);
            Top = new ElementSize(top);
            Right = new ElementSize(right);
            Bottom = new ElementSize();
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ElementMargin(ElementSize left, ElementSize top, ElementSize right, ElementSize bottom)
        {
            Left = new ElementSize(left);
            Top = new ElementSize(top);
            Right = new ElementSize(right);
            Bottom = new ElementSize(bottom);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Attaches listeners to internal objects.
        /// </summary>
        public void AttachListeners(AtomicBindableObject oldValue, AtomicBindableObject newValue)
        {
            if (oldValue != null) oldValue.PropertyChanged -= OnInternalPropertyChanged;
            if (newValue != null) newValue.PropertyChanged += OnInternalPropertyChanged;
        }

        /// <summary>
        /// Called when an internal object changes.
        /// </summary>
        private void OnInternalPropertyChanged(object source, string propertyName)
        {
            OnPropertyChanged("ElementMargin");
        }

        /// <summary>
        /// Gets left margin from left size.
        /// </summary>
        public static ElementMargin FromLeft(ElementSize left)
        {
            return new ElementMargin(left, null, null, null);
        }

        /// <summary>
        /// Gets top margin from top size.
        /// </summary>
        public static ElementMargin FromTop(ElementSize top)
        {
            return new ElementMargin(null, top, null, null);
        }

        /// <summary>
        /// Gets right margin from right size.
        /// </summary>
        public static ElementMargin FromRight(ElementSize right)
        {
            return new ElementMargin(null, null, right, null);
        }

        /// <summary>
        /// Gets bottom margin from bottom size.
        /// </summary>
        public static ElementMargin FromBottom(ElementSize bottom)
        {
            return new ElementMargin(null, null, null, bottom);
        }

        /// <summary>
        /// Converts margin to string.
        /// </summary>
        public override string ToString()
        {
            return String.Format(CultureInfo.InvariantCulture, "{0},{1},{2},{3}", Left.ToString(), Top.ToString(), Right.ToString(), Bottom.ToString());
        }

        /// <summary>
        /// Compares element margins.
        /// </summary>
        public override bool Equals(object obj)
        {
            var margin = obj as ElementMargin;
            return (margin != null) && Left.Equals(margin.Left) && Top.Equals(margin.Top) && Right.Equals(margin.Right) && Bottom.Equals(margin.Bottom);
        }

        /// <summary>
        /// Gets hashcode.
        /// </summary>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
