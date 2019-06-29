// Internal view logic generated from "Frame.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Frame : UIImageView
    {
        #region Constructors

        public Frame(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? FrameTemplates.Default, initializer)
        {
            this.AfterInitializeInternal();
        }

        public Frame() : this(null)
        {
        }

        static Frame()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(FrameTemplates.Default, dependencyProperties);

            dependencyProperties.Add(AutoSizeToContentProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<System.Boolean> AutoSizeToContentProperty = new DependencyProperty<System.Boolean>("AutoSizeToContent");
        public System.Boolean AutoSizeToContent
        {
            get { return AutoSizeToContentProperty.GetValue(this); }
            set { AutoSizeToContentProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class FrameTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return Frame;
            }
        }

        private static Template _frame;
        public static Template Frame
        {
            get
            {
#if UNITY_EDITOR
                if (_frame == null || _frame.CurrentVersion != Template.Version)
#else
                if (_frame == null)
#endif
                {
                    _frame = new Template(UIImageViewTemplates.UIImageView);
#if UNITY_EDITOR
                    _frame.Name = "Frame";
#endif
                    Delight.Frame.AutoSizeToContentProperty.SetDefault(_frame, true);
                }
                return _frame;
            }
        }

        #endregion
    }

    #endregion
}
