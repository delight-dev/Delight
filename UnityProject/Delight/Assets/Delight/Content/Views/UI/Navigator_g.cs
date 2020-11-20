// Internal view logic generated from "Navigator.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Navigator : UIView
    {
        #region Constructors

        public Navigator(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? NavigatorTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            Path = new AttachedProperty<System.String>(this, "Path");
            this.AfterInitializeInternal();
        }

        public Navigator() : this(null)
        {
        }

        static Navigator()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(NavigatorTemplates.Default, dependencyProperties);

            dependencyProperties.Add(SwitchModeProperty);
            dependencyProperties.Add(StartPathProperty);
            dependencyProperties.Add(IsDisabledProperty);
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

        public readonly static DependencyProperty<System.String> StartPathProperty = new DependencyProperty<System.String>("StartPath");
        public System.String StartPath
        {
            get { return StartPathProperty.GetValue(this); }
            set { StartPathProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<System.Boolean> IsDisabledProperty = new DependencyProperty<System.Boolean>("IsDisabled");
        public System.Boolean IsDisabled
        {
            get { return IsDisabledProperty.GetValue(this); }
            set { IsDisabledProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Delight.LoadMode> ChildLoadModeProperty = new DependencyProperty<Delight.LoadMode>("ChildLoadMode");
        public Delight.LoadMode ChildLoadMode
        {
            get { return ChildLoadModeProperty.GetValue(this); }
            set { ChildLoadModeProperty.SetValue(this, value); }
        }

        public AttachedProperty<System.String> Path { get; private set; }

        #endregion
    }

    #region Data Templates

    public static class NavigatorTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return Navigator;
            }
        }

        private static Template _navigator;
        public static Template Navigator
        {
            get
            {
#if UNITY_EDITOR
                if (_navigator == null || _navigator.CurrentVersion != Template.Version)
#else
                if (_navigator == null)
#endif
                {
                    _navigator = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _navigator.Name = "Navigator";
                    _navigator.LineNumber = 0;
                    _navigator.LinePosition = 0;
#endif
                    Delight.Navigator.SwitchModeProperty.SetDefault(_navigator, Delight.SwitchMode.Enable);
                }
                return _navigator;
            }
        }

        #endregion
    }

    #endregion
}
