// Internal view logic generated from "SelectionIndicator.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class SelectionIndicator : UIImageView
    {
        #region Constructors

        public SelectionIndicator(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? SelectionIndicatorTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            this.AfterInitializeInternal();
        }

        public SelectionIndicator() : this(null)
        {
        }

        static SelectionIndicator()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(SelectionIndicatorTemplates.Default, dependencyProperties);

            dependencyProperties.Add(SelectedViewInfoProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.SelectedViewInfo> SelectedViewInfoProperty = new DependencyProperty<Delight.SelectedViewInfo>("SelectedViewInfo");
        public Delight.SelectedViewInfo SelectedViewInfo
        {
            get { return SelectedViewInfoProperty.GetValue(this); }
            set { SelectedViewInfoProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class SelectionIndicatorTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return SelectionIndicator;
            }
        }

        private static Template _selectionIndicator;
        public static Template SelectionIndicator
        {
            get
            {
#if UNITY_EDITOR
                if (_selectionIndicator == null || _selectionIndicator.CurrentVersion != Template.Version)
#else
                if (_selectionIndicator == null)
#endif
                {
                    _selectionIndicator = new Template(UIImageViewTemplates.UIImageView);
#if UNITY_EDITOR
                    _selectionIndicator.Name = "SelectionIndicator";
                    _selectionIndicator.LineNumber = 0;
                    _selectionIndicator.LinePosition = 0;
#endif
                    Delight.SelectionIndicator.EnableScriptEventsProperty.SetDefault(_selectionIndicator, true);
                    Delight.SelectionIndicator.DisableLayoutUpdateProperty.SetDefault(_selectionIndicator, true);
                    Delight.SelectionIndicator.IsVisibleProperty.SetDefault(_selectionIndicator, false);
                    Delight.SelectionIndicator.RaycastBlockModeProperty.SetDefault(_selectionIndicator, Delight.RaycastBlockMode.Never);
                    Delight.SelectionIndicator.BackgroundSpriteProperty.SetDefault(_selectionIndicator, Assets.Sprites["Selection"]);
                }
                return _selectionIndicator;
            }
        }

        #endregion
    }

    #endregion
}
