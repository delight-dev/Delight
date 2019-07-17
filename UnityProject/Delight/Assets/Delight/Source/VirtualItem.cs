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
    /// Represents a virtual item. Contains information about its size, offset and alignment. Used by virtualized lists to keep track of list items that are yet to be realized.
    /// </summary>
    public class VirtualItem : BindableObject
    {
        #region Properties

        public ElementSize Width { get; set; }
        public ElementSize Height { get; set; }
        public ElementMargin Offset { get; set; }
        public ElementAlignment Alignment { get; set; }
        public ContentTemplate ContentTemplate { get; set; }
        public BindableObject Item { get; set; }
        public ListItem RealizedItem { get; set; }
        public bool IsSelected { get; set; }

        public static readonly VirtualItem Default = new VirtualItem();

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public VirtualItem()
        {
            Width = ElementSize.FromPercents(1);
            Height = ElementSize.FromPercents(1);
            Offset = new ElementMargin();
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public VirtualItem(ElementSize width)
        {
            Width = width != null ? new ElementSize(width) : ElementSize.FromPercents(1);
            Height = ElementSize.FromPercents(1);
            Offset = new ElementMargin();
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public VirtualItem(ElementSize width, ElementSize height)
        {
            Width = width != null ? new ElementSize(width) : ElementSize.FromPercents(1);
            Height = height != null ? new ElementSize(height) : ElementSize.FromPercents(1);
            Offset = new ElementMargin();
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public VirtualItem(ElementSize width, ElementSize height, ContentTemplate contentTemplate)
            : this(width, height)
        {
            ContentTemplate = contentTemplate;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets element sizes from width.
        /// </summary>
        public static VirtualItem FromWidth(ElementSize width)
        {
            return new VirtualItem(width);
        }

        /// <summary>
        /// Gets element sizes from height.
        /// </summary>
        public static VirtualItem FromHeight(ElementSize height)
        {
            return new VirtualItem(null, height);
        }

        /// <summary>
        /// Converts element sizes to string.
        /// </summary>
        public override string ToString()
        {
            return String.Format(CultureInfo.InvariantCulture, "{0},{1}", Width.ToString(), Height.ToString());
        }

        /// <summary>
        /// Compares element sizes.
        /// </summary>
        public override bool Equals(object obj)
        {
            var elementSizes = obj as VirtualItem;
            return (elementSizes != null) && Width.Equals(elementSizes.Width) && Height.Equals(elementSizes.Height) && Offset.Equals(elementSizes.Offset) && Alignment == elementSizes.Alignment;
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
