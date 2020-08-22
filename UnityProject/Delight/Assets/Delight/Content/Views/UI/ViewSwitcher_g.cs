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

        public ViewSwitcher(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? ViewSwitcherTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

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
        /// <summary>Enum indicating view switch mode, e.g. if views should be loaded on-demand or be pre-loaded.</summary>
        public Delight.SwitchMode SwitchMode
        {
            get { return SwitchModeProperty.GetValue(this); }
            set { SwitchModeProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.String> StartViewProperty = new DependencyProperty<System.String>("StartView");
        /// <summary>Sets the ID of the view that should be displayed initially.</summary>
        public System.String StartView
        {
            get { return StartViewProperty.GetValue(this); }
            set { StartViewProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> ShowFirstByDefaultProperty = new DependencyProperty<System.Boolean>("ShowFirstByDefault");
        /// <summary>Boolean indicating if the first view in the view switcher should be displayed initially by default.</summary>
        public System.Boolean ShowFirstByDefault
        {
            get { return ShowFirstByDefaultProperty.GetValue(this); }
            set { ShowFirstByDefaultProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.LoadMode> ChildLoadModeProperty = new DependencyProperty<Delight.LoadMode>("ChildLoadMode");
        /// <summary>Sets the default LoadMode flag on children. Some flags may be overriden depending on the SwitchMode setting.</summary>
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
                    _viewSwitcher.LineNumber = 0;
                    _viewSwitcher.LinePosition = 0;
#endif
                    Delight.ViewSwitcher.SwitchModeProperty.SetDefault(_viewSwitcher, Delight.SwitchMode.Enable);
                    Delight.ViewSwitcher.ShowFirstByDefaultProperty.SetDefault(_viewSwitcher, true);
                }
                return _viewSwitcher;
            }
        }

        #endregion
    }

    #endregion
}
