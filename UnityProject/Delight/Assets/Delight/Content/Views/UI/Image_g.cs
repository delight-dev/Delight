// Internal view logic generated from "Image.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Image : UIImageView
    {
        #region Constructors

        public Image(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? ImageTemplates.Default, initializer)
        {
            this.AfterInitializeInternal();
        }

        public Image() : this(null)
        {
        }

        static Image()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ImageTemplates.Default, dependencyProperties);
        }

        #endregion

        #region Properties

        #endregion
    }

    #region Data Templates

    public static class ImageTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return Image;
            }
        }

        private static Template _image;
        public static Template Image
        {
            get
            {
#if UNITY_EDITOR
                if (_image == null || _image.CurrentVersion != Template.Version)
#else
                if (_image == null)
#endif
                {
                    _image = new Template(UIImageViewTemplates.UIImageView);
                }
                return _image;
            }
        }

        #endregion
    }

    #endregion
}
