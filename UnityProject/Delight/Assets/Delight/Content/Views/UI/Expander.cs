#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#endregion

namespace Delight
{
    /// <summary>
    /// Expandable view with a header and content. When header is clicked the view expands to show content or collapses to hide it.
    /// </summary>
    public partial class Expander
    {
        #region Fields

        private BindableCollection<ContentTemplate> _contentTemplates = new BindableCollection<ContentTemplate>();
        public override BindableCollection<ContentTemplate> ContentTemplates
        {
            get
            {
                return _contentTemplates;
            }
        }

        private ExpanderContent _expanderContent;
        private ExpanderHeader _expanderHeader;

        #endregion

        #region Methods

        /// <summary>
        /// Called when a property has been changed. 
        /// </summary>
        public override void OnChanged(string property)
        {
            base.OnChanged(property);
            switch (property)
            {
                case nameof(IsExpanded):
                    IsExpandedChanged();
                    break;

                case nameof(IsDisabled):
                    IsDisabledChanged();
                    break;

                case nameof(Text):
                    if (_expanderHeader != null)
                    {
                        _expanderHeader.Text = Text;
                    }
                    break;

                case nameof(Sprite):
                    if (_expanderHeader != null)
                    {
                        _expanderHeader.Sprite = Sprite;
                    }
                    break;
            }
        }

        /// <summary>
        /// Called before the view and its children has been loaded.
        /// </summary>
        protected override void BeforeLoad()
        {
            base.BeforeLoad();

            // generate expander content and header
            if (ContentTemplates == null)
                return;

            foreach (var contentTemplate in ContentTemplates)
            {
                if (typeof(ExpanderContent).IsAssignableFrom(contentTemplate.TemplateType))
                {
                    var templateData = new ContentTemplateData();
                    _expanderContent = contentTemplate.Activator(templateData) as ExpanderContent;
                }
                else if (typeof(ExpanderHeader).IsAssignableFrom(contentTemplate.TemplateType))
                {
                    var templateData = new ContentTemplateData();
                    _expanderHeader = contentTemplate.Activator(templateData) as ExpanderHeader;
                }
            }

            if (_expanderHeader == null)
            {
                _expanderHeader = new DefaultExpanderHeader(this);
            }

            _expanderHeader.Alignment = HeaderAlignment;
            if (HeaderHeight != null)
            {
                _expanderHeader.Height = HeaderHeight;
            }
            _expanderHeader.ParentExpander = this;
            _expanderHeader.Text = Text;
            _expanderHeader.Sprite = Sprite;

            if (_expanderContent != null)
            {
                _expanderContent.Margin = ContentMargin;
            }
        }

        /// <summary>
        /// Called after the view is loaded.
        /// </summary>
        protected override void AfterLoad()
        {
            if (IgnoreObject)
                return;
            base.AfterLoad();

            IsDisabledChanged();
            IsExpandedChanged();
        }

        /// <summary>
        /// Called when a child changes its layout.
        /// </summary>
        protected override void ChildLayoutChanged()
        {
            base.ChildLayoutChanged();
            if (IgnoreObject)
                return;

            // the layout of the group needs to be updated
            LayoutRoot.RegisterChangeHandler(OnExpanderChildLayoutChanged);
        }

        /// <summary>
        /// Called when the layout of a child has been changed. 
        /// </summary>
        public void OnExpanderChildLayoutChanged()
        {
            if (UpdateLayout(false))
            {
                NotifyParentOfChildLayoutChanged();
            }
        }

        /// <summary>
        /// Called when the field IsExpanded is changed.
        /// </summary>
        public virtual void IsExpandedChanged()
        {
            if (IsDisabled)
                return;

            if (IsExpanded)
            {
                if (_expanderContent != null)
                {
                    _expanderContent.IsActive = true;
                    if (ToggleMode == SwitchMode.Load ||
                        ToggleMode == SwitchMode.LoadOnce)
                    {
                        _expanderContent.Load();
                    }
                }

                SetState("Expanded");
            }
            else
            {
                if (_expanderContent != null)
                {
                    _expanderContent.IsActive = false;
                    if (ToggleMode == SwitchMode.Load)
                    {
                        _expanderContent.Unload();
                    }
                }

                SetState(DefaultStateName);
            }
        }

        /// <summary>
        /// Updates based on expanded content size.
        /// </summary>
        public override bool UpdateLayout(bool notifyParent = true)
        {
            bool defaultDisableLayoutUpdate = DisableLayoutUpdate;
            DisableLayoutUpdate = true;

            // adjust width to content unless it has been explicitly set
            bool hasNewSize = false;
            if (Width == null)
            {
                float headerWidth = GetPixelWidth(_expanderHeader);
                float contentWidth = GetPixelWidth(_expanderContent);
                float totalWidth = Mathf.Max(headerWidth, contentWidth);
                ElementSize newWidth = totalWidth > 0 ? new ElementSize(totalWidth) : ElementSize.DefaultLayout;

                if (!newWidth.Equals(OverrideWidth))
                {
                    OverrideWidth = newWidth;
                    hasNewSize = true;
                }
            }

            // adjust height to content unless it has been explicitly set
            if (Height == null)
            {
                float headerHeight = GetPixelHeight(_expanderHeader);
                float contentHeight = GetPixelHeight(_expanderContent);
                float totalHeight = headerHeight + contentHeight;
                ElementSize newHeight = totalHeight > 0 ? new ElementSize(totalHeight) : 40;

                if (!newHeight.Equals(OverrideHeight))
                {
                    OverrideHeight = newHeight;
                    hasNewSize = true;
                }
            }

            DisableLayoutUpdate = defaultDisableLayoutUpdate;
            return base.UpdateLayout(notifyParent) || hasNewSize;
        }

        /// <summary>
        /// Called when IsDisabled field changes.
        /// </summary>
        public virtual void IsDisabledChanged()
        {
            if (IsDisabled)
            {
                SetState("Disabled");
            }
            else
            {
                SetState(IsExpanded ? "Expanded" : DefaultStateName);
            }
        }

        /// <summary>
        /// Sets the state of the view.
        /// </summary>
        public override void SetState(string state)
        {
            if (state.IEquals(_previousState))
                return;

            base.SetState(state);
            _expanderHeader?.SetState(state);
        }

        /// <summary>
        /// Called by designer to make the view presentable in the designer.
        /// </summary>
        public override void PrepareForDesigner()
        {
        }

        #endregion
    }
}
