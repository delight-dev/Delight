// Internal view logic generated from "ViewSwitcher.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ViewSwitcher : UIView
    {
        #region Constructors

        public ViewSwitcher(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? ViewSwitcherTemplates.Default, initializer)
        {
            this.AfterInitializeInternal();
        }

        public ViewSwitcher() : this(null)
        {
        }

        static ViewSwitcher()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ViewSwitcherTemplates.Default, dependencyProperties);

            dependencyProperties.Add(SwitchModeProperty);
            dependencyProperties.Add(StartViewProperty);
            dependencyProperties.Add(ShowFirstByDefaultProperty);
            dependencyProperties.Add(ChildLoadModeProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.SwitchMode> SwitchModeProperty = new DependencyProperty<Delight.SwitchMode>("SwitchMode");
        public Delight.SwitchMode SwitchMode
        {
            get { return SwitchModeProperty.GetValue(this); }
            set { SwitchModeProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.String> StartViewProperty = new DependencyProperty<System.String>("StartView");
        public System.String StartView
        {
            get { return StartViewProperty.GetValue(this); }
            set { StartViewProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> ShowFirstByDefaultProperty = new DependencyProperty<System.Boolean>("ShowFirstByDefault");
        public System.Boolean ShowFirstByDefault
        {
            get { return ShowFirstByDefaultProperty.GetValue(this); }
            set { ShowFirstByDefaultProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.LoadMode> ChildLoadModeProperty = new DependencyProperty<Delight.LoadMode>("ChildLoadMode");
        public Delight.LoadMode ChildLoadMode
        {
            get { return ChildLoadModeProperty.GetValue(this); }
            set { ChildLoadModeProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class ViewSwitcherTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ViewSwitcher;
            }
        }

        private static Template _viewSwitcher;
        public static Template ViewSwitcher
        {
            get
            {
#if UNITY_EDITOR
                if (_viewSwitcher == null || _viewSwitcher.CurrentVersion != Template.Version)
#else
                if (_viewSwitcher == null)
#endif
                {
                    _viewSwitcher = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _viewSwitcher.Name = "ViewSwitcher";
#endif
                    Delight.ViewSwitcher.SwitchModeProperty.SetDefault(_viewSwitcher, Delight.SwitchMode.Load);
                    Delight.ViewSwitcher.ShowFirstByDefaultProperty.SetDefault(_viewSwitcher, true);
                }
                return _viewSwitcher;
            }
        }

        #endregion
    }

    #endregion
}
