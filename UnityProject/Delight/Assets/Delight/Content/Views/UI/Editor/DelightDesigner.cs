#if DELIGHT_MODULE_TEXTMESHPRO
#region Using Statements
using Delight.Editor.Parser;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.IO;
#endregion

namespace Delight
{
    /// <summary>
    /// Delight designer.
    /// </summary>
    public partial class DelightDesigner
    {
        #region Fields

        public UIView _displayedView;
        public DesignerView _currentEditedView;

        #endregion

        #region Methods

        /// <summary>
        /// Called after the view has been initialized.
        /// </summary>
        public override void AfterInitialize()
        {
            base.AfterInitialize();

            // initialize designer views
            DesignerViews = new DesignerViewData();

            // load designer view data from the object model
            var contentObjectModel = ContentObjectModel.GetInstance();
            var designerViews = new List<DesignerView>();
            foreach (var viewObject in contentObjectModel.ViewObjects.Where(x => !x.HideInDesigner))
            {
                // ignore views that aren't scene object views
                if (!IsUIView(viewObject))
                    continue;

                designerViews.Add(new DesignerView { Id = viewObject.Name, Name = viewObject.Name, ViewTypeName = viewObject.TypeName, ViewObject = viewObject });
            }

            DesignerViews.AddRange(designerViews.OrderBy(x => x.Id));
        }

        /// <summary>
        /// Called when the user edits the current view.
        /// </summary>
        public void OnEdit()
        {
            if (_currentEditedView != null)
            {
                _currentEditedView.IsDirty = true;
            }
        }

        /// <summary>
        /// Called after the view has been loaded.
        /// </summary>
        protected override void AfterLoad()
        {
            base.AfterLoad();
        }

        /// <summary>
        /// Returns boolean indicating if view-object is a UIView.
        /// </summary>
        private bool IsUIView(ViewObject viewObject)
        {
            if (viewObject == null || String.IsNullOrEmpty(viewObject.Name) || viewObject.Name == "View")
                return false;
            if (viewObject.Name == "UIView")
                return true;
            return IsUIView(viewObject.BasedOn);
        }

        /// <summary>
        /// Called when a view gets selected in the view list.
        /// </summary>
        public async void ViewSelected(DesignerView designerView)
        {
            if (_displayedView != null)
            {
                _displayedView.Destroy();
            }

            // add "Designer" prefix to see if there is a dedicated designer wrapper for the view
            _displayedView = Assets.CreateView(designerView.ViewTypeName, this, ViewContentRegion) as UIView;

            var sw2 = System.Diagnostics.Stopwatch.StartNew();

            await _displayedView?.LoadAsync();
            _displayedView?.PrepareForDesigner();

            // center on view
            ScrollableContentRegion.SetScrollPosition(0.5f, 0.5f);
            SetScale(Vector3.one);

            // load XML into the editor
            _currentEditedView = designerView;
            XmlEditor.XmlText = File.ReadAllText(designerView.ViewObject.FilePath);

            sw2.Stop();
            Debug.Log(String.Format("Loading view {0}: {1}", designerView.ViewTypeName, sw2.ElapsedMilliseconds));
        }

        /// <summary>
        /// Called when the content is scrolled using mouse wheel or track pad.
        /// </summary>
        public void OnScroll(DependencyObject sender, object eventArgs)
        {
            if (_displayedView == null)
                return;

            PointerEventData pointerData = eventArgs as PointerEventData;
            bool zoomIn = pointerData.scrollDelta.x > 0 || pointerData.scrollDelta.y > 0;
            var zoomFactor = 0.10f;
            zoomFactor = zoomIn ? 1 + zoomFactor : 1 - zoomFactor;

            var scale = ContentRegionCanvas.Scale;
            scale.x *= zoomFactor;
            scale.y *= zoomFactor;

            SetScale(scale);
        }

        /// <summary>
        /// Scales view content. 
        /// </summary>
        public void SetScale(Vector3 scale)
        {
            if (_displayedView == null)
            {
                ContentRegionCanvas.Scale = Vector3.one;
                return;
            }

            ContentRegionCanvas.Scale = scale;

            // adjust size of view region based on size of view and viewport
            var viewportWidth = ScrollableContentRegion.ActualWidth;
            var viewportHeight = ScrollableContentRegion.ActualHeight;

            var width = _displayedView.OverrideWidth ?? _displayedView.Width ?? ElementSize.FromPercents(1);
            var height = _displayedView.OverrideHeight ?? _displayedView.Height ?? ElementSize.FromPercents(1);

            float adjustedWidth = viewportWidth * Mathf.Max(scale.x, 1.0f);
            float adjustedHeight = viewportHeight * Mathf.Max(scale.y, 1.0f);

            if (width.Unit != ElementSizeUnit.Percents)
            {
                float viewWidth = width.Pixels * Mathf.Max(scale.x, 1.0f);
                adjustedWidth = Mathf.Max(viewWidth, adjustedWidth);
            }

            if (height.Unit != ElementSizeUnit.Percents)
            {
                float viewHeight = height.Pixels * Mathf.Max(scale.y, 1.0f);
                adjustedHeight = Mathf.Max(viewHeight, adjustedHeight);
            }

            // adjust content regions to size
            ContentRegionCanvas.SetSize(adjustedWidth * 2, adjustedHeight * 2);
            ViewContentRegion.SetSize(adjustedWidth, adjustedHeight);
        }

        #endregion
    }
}
#endif