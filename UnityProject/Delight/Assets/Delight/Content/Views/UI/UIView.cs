#region Using Statements
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class UIView
    {
        #region Methods

        /// <summary>
        /// Called before the view is loaded.
        /// </summary>
        protected override void BeforeLoad()
        {
            base.BeforeLoad();

            // add rect transform
            var rectTransform = GameObject.GetComponent<RectTransform>();
            if (rectTransform == null)
            {
                rectTransform = GameObject.AddComponent<RectTransform>();
            }
            RectTransform = rectTransform;

            // initialize root canvas
            if (LayoutRoot == null)
            {
                var parentUIView = this.FindParent<UIView>();
                if (parentUIView == null)
                {
                    // we are the root view
                    if (typeof(LayoutRoot).IsAssignableFrom(GetType()))
                    {
                        // we are the layout root
                        LayoutRoot = this as LayoutRoot;
                    }
                    else
                    {
                        // create new layout root
                        var layoutRoot = new LayoutRoot();
                        layoutRoot.Load();
                        LayoutRoot = layoutRoot;
                        LayoutParent = LayoutRoot;
                        GameObject.transform.SetParent(layoutRoot.GameObject.transform);
                    }
                }
                else
                {
                    // use the same layout root as parent UIView
                    LayoutRoot = parentUIView.LayoutRoot;
                }
            }
        }

        /// <summary>
        /// Called when a property has been changed. 
        /// </summary>
        public override void OnPropertyChanged(object source, string property)
        {
            base.OnPropertyChanged(source, property);
            switch (property)
            {
                case nameof(Width):
                case nameof(Height):
                case nameof(OverrideWidth):
                case nameof(OverrideHeight):
                    LayoutChanged();
                    break;

                case nameof(Offset):
                case nameof(OffsetFromParent):
                    OffsetChanged();
                    break;

                case nameof(Alpha):
                case nameof(RaycastBlockMode):
                case nameof(IsVisible):
                    VisibilityChanged();
                    break;
            }
        }

        /// <summary>
        /// Called after the view is loaded.
        /// </summary>
        protected override void AfterLoad()
        {
            base.AfterLoad();

            // update layout and visibility
            VisibilityChanged();
            UpdateLayout(false);
        }

        /// <summary>
        /// Called after the view is unloaded.
        /// </summary>
        protected override void AfterUnload()
        {
            base.AfterUnload();
        }

        /// <summary>
        /// Called when a property affecting the layout of the view has been changed.
        /// </summary>
        protected void LayoutChanged()
        {
            if (DisableLayoutUpdate)
                return;

            //Debug.Log(String.Format("{0}.LayoutChanged()", Name));            
            LayoutRoot.RegisterNeedLayoutUpdate(this);
        }

        /// <summary>
        /// Called when a property affecting the offset of the view has been changed.
        /// </summary>
        protected void OffsetChanged()
        {
            UpdateRectTransform();
        }

        /// <summary>
        /// Called when after the top-most load is called. Used to update parents.
        /// </summary>
        protected override void AfterInitiatedLoad()
        {            
            NotifyParentOfLayoutUpdate();
            base.AfterInitiatedLoad();
        }

        /// <summary>
        /// Called when after the top-most unload is called. Used to update parents.
        /// </summary>
        protected override void AfterInitiatedUnload()
        {
            NotifyParentOfLayoutUpdate();
            base.AfterInitiatedUnload();
        }

        /// <summary>
        /// Updates layout.
        /// </summary>
        public virtual void UpdateLayout(bool notifyParent = true)
        {
            //Debug.Log(String.Format("{0}.UpdateLayout()", Name));

            UpdateRectTransform();

            if (notifyParent)
            {
                NotifyParentOfLayoutUpdate();
            }
        }

        /// <summary>
        /// Notifies parent that the layout of a child has been updated.
        /// </summary>
        protected void NotifyParentOfLayoutUpdate()
        {
            // notify parent of layout update
            var uiViewParent = this.FindParent<UIView>();
            if (uiViewParent != null)
            {
                uiViewParent.ChildLayoutChanged();
            }
        }

        /// <summary>
        /// Called if a child has changed its layout. 
        /// </summary>
        protected virtual void ChildLayoutChanged()
        {
        }

        /// <summary>
        /// Updates rect transform. 
        /// </summary>
        private void UpdateRectTransform()
        {
            if (GameObject == null)
                return;

            // update rectTransform
            // horizontal alignment and positioning
            var width = OverrideWidth ?? (Width ?? ElementSize.DefaultLayout);
            var height = OverrideHeight ?? (Height ?? ElementSize.DefaultLayout);

            float xMin = 0f;
            float xMax = 0f;
            float offsetMinX = 0f;
            float offsetMaxX = 0f;

            if (Alignment.HasFlag(ElementAlignment.Left))
            {
                xMin = 0f;
                xMax = width.Percent;
                offsetMinX = 0f;
                offsetMaxX = width.Pixels;
            }
            else if (Alignment.HasFlag(ElementAlignment.Right))
            {
                xMin = 1f - width.Percent;
                xMax = 1f;
                offsetMinX = -width.Pixels;
                offsetMaxX = 0f;
            }
            else
            {
                xMin = 0.5f - width.Percent / 2f;
                xMax = 0.5f + width.Percent / 2f;
                offsetMinX = -width.Pixels / 2f;
                offsetMaxX = width.Pixels / 2f;
            }

            // vertical alignment
            float yMin = 0f;
            float yMax = 0f;
            float offsetMinY = 0f;
            float offsetMaxY = 0f;

            if (Alignment.HasFlag(ElementAlignment.Top))
            {
                yMin = 1f - height.Percent;
                yMax = 1f;
                offsetMinY = -height.Pixels;
                offsetMaxY = 0f;
            }
            else if (Alignment.HasFlag(ElementAlignment.Bottom))
            {
                yMin = 0f;
                yMax = height.Percent;
                offsetMinY = 0f;
                offsetMaxY = height.Pixels;
            }
            else
            {
                yMin = 0.5f - height.Percent / 2f;
                yMax = 0.5f + height.Percent / 2f;
                offsetMinY = -height.Pixels / 2f;
                offsetMaxY = height.Pixels / 2f;
            }

            var margin = Margin ?? ElementMargin.Default;
            RectTransform.anchorMin = new Vector2(xMin + margin.Left.Percent, yMin + margin.Bottom.Percent);
            RectTransform.anchorMax = new Vector2(xMax - margin.Right.Percent, yMax - margin.Top.Percent);

            // positioning and margins
            var offset = Offset ?? ElementMargin.Default;
            var offsetFromParent = OffsetFromParent ?? ElementMargin.Default;
            RectTransform.offsetMin = new Vector2(
                offsetMinX + margin.Left.Pixels + offset.Left.Pixels - offset.Right.Pixels + offsetFromParent.Left.Pixels - offsetFromParent.Right.Pixels,
                offsetMinY + margin.Bottom.Pixels - offset.Top.Pixels + offset.Bottom.Pixels - offsetFromParent.Top.Pixels + offsetFromParent.Bottom.Pixels);
            RectTransform.offsetMax = new Vector2(
                offsetMaxX - margin.Right.Pixels + offset.Left.Pixels - offset.Right.Pixels + offsetFromParent.Left.Pixels - offsetFromParent.Right.Pixels,
                offsetMaxY - margin.Top.Pixels - offset.Top.Pixels + offset.Bottom.Pixels - offsetFromParent.Top.Pixels + offsetFromParent.Bottom.Pixels);

            RectTransform.anchoredPosition = new Vector2(
                RectTransform.offsetMin.x / 2.0f + RectTransform.offsetMax.x / 2.0f,
                RectTransform.offsetMin.y / 2.0f + RectTransform.offsetMax.y / 2.0f);
        }
        
        /// <summary>
        /// Called when the visibility of the view has changed. 
        /// </summary>
        protected virtual void VisibilityChanged()
        {
            if (AlphaProperty.IsUndefined(this) && 
                IsVisibleProperty.IsUndefined(this) && 
                RaycastBlockModeProperty.IsUndefined(this))
                return;

            // to change alpha, visibility and raycast we need a canvas group attached
            if (CanvasGroup == null)
            {
                var canvasGroup = GameObject.GetComponent<CanvasGroup>();
                CanvasGroup = canvasGroup ?? GameObject.AddComponent<CanvasGroup>();
            }

            // set alpha value
            var alpha = AlphaProperty.IsUndefined(this) ? 1 : Alpha;
            CanvasGroup.alpha = IsVisible ? alpha : 0;

            // set raycast block mode
            if (RaycastBlockMode == RaycastBlockMode.Always)
            {
                CanvasGroup.blocksRaycasts = true;
            }
            else if (RaycastBlockMode == RaycastBlockMode.Never)
            {
                CanvasGroup.blocksRaycasts = false;
            }
            else
            {
                CanvasGroup.blocksRaycasts = (IsVisible && alpha > 0);
            }

            CanvasGroup.interactable = IsVisible && alpha > 0;
        }

        /// <summary>
        /// Sets size of view in pixels.
        /// </summary>
        public void SetSize(float width, float height)
        {
            Width.Pixels = width;
            Height.Pixels = height;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets actual width of view in pixels. Useful when Width may be specified as percentage and you want actual pixel width.
        /// </summary>
        public float ActualWidth
        {
            get
            {
                return Mathf.Abs(RectTransform.rect.width);
            }
        }

        /// <summary>
        /// Gets actual height of view in pixels. Useful when Height may be specified as percentage and you want actual pixel height.
        /// </summary>
        public float ActualHeight
        {
            get
            {
                return Mathf.Abs(RectTransform.rect.height);
            }
        }

        #endregion
    }
}
