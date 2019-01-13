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
    /// Represents left, top, right and bottom margins.
    /// </summary>
    [Serializable]
    public class ElementMargin
    {
        #region Fields

        [SerializeField]
        private ElementSize _left;

        [SerializeField]
        private ElementSize _top;

        [SerializeField]
        private ElementSize _right;

        [SerializeField]
        private ElementSize _bottom;

        public static readonly ElementMargin Default = new ElementMargin();

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ElementMargin()
        {
            _left = new ElementSize();
            _top = new ElementSize();
            _right = new ElementSize();
            _bottom = new ElementSize();
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ElementMargin(ElementSize margin)
        {
            _left = margin;
            _top = margin;
            _right = margin;
            _bottom = margin;
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ElementMargin(ElementSize left, ElementSize top)
        {
            _left = left;
            _top = top;
            _right = new ElementSize();
            _bottom = new ElementSize();
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ElementMargin(ElementSize left, ElementSize top, ElementSize right)
            : this()
        {
            _left = left;
            _top = top;
            _right = right;
            _bottom = new ElementSize();
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ElementMargin(ElementSize left, ElementSize top, ElementSize right, ElementSize bottom)
        {
            _left = left;
            _top = top;
            _right = right;
            _bottom = bottom;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets left margin from left size.
        /// </summary>
        public static ElementMargin FromLeft(ElementSize left)
        {
            return new ElementMargin(left, new ElementSize(), new ElementSize(), new ElementSize());
        }

        /// <summary>
        /// Gets top margin from top size.
        /// </summary>
        public static ElementMargin FromTop(ElementSize top)
        {
            return new ElementMargin(new ElementSize(), top, new ElementSize(), new ElementSize());
        }

        /// <summary>
        /// Gets right margin from right size.
        /// </summary>
        public static ElementMargin FromRight(ElementSize right)
        {
            return new ElementMargin(new ElementSize(), new ElementSize(), right, new ElementSize());
        }

        /// <summary>
        /// Gets bottom margin from bottom size.
        /// </summary>
        public static ElementMargin FromBottom(ElementSize bottom)
        {
            return new ElementMargin(new ElementSize(), new ElementSize(), new ElementSize(), bottom);
        }

        /// <summary>
        /// Converts margin to string.
        /// </summary>
        public override string ToString()
        {
            return String.Format(CultureInfo.InvariantCulture, "{0},{1},{2},{3}", Left.ToString(), Top.ToString(), Right.ToString(), Bottom.ToString());
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets left margin.
        /// </summary>
        public ElementSize Left
        {
            get
            {
                return _left;
            }
            set
            {
                _left = value;
            }
        }

        /// <summary>
        /// Gets or sets top margin.
        /// </summary>
        public ElementSize Top
        {
            get
            {
                return _top;
            }
            set
            {
                _top = value;
            }
        }

        /// <summary>
        /// Gets or sets right margin.
        /// </summary>
        public ElementSize Right
        {
            get
            {
                return _right;
            }
            set
            {
                _right = value;
            }
        }

        /// <summary>
        /// Gets or sets bottom margin.
        /// </summary>
        public ElementSize Bottom
        {
            get
            {
                return _bottom;
            }
            set
            {
                _bottom = value;
            }
        }

        #endregion
    }
}
