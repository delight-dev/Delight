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
    /// Renders a selection box around the parent view. Used by the designer to indicate selected views. 
    /// </summary>
    public partial class SelectionIndicator
    {
        #region Methods

        /// <summary>
        /// Called every frame.
        /// </summary>
        public override void Update()
        {
            base.Update();

            if (!IsLoaded)
                return;

            var targetTransform = SelectedViewInfo?.View?.RectTransform;
            if (targetTransform == null)
            {
                IsVisible = false;
                return;
            }

            // adjust size and position to tracked view
            RectTransform.SetParent(targetTransform.parent, false);
            RectTransform.anchorMin = targetTransform.anchorMin;
            RectTransform.anchorMax = targetTransform.anchorMax;
            RectTransform.anchoredPosition = targetTransform.anchoredPosition;
            RectTransform.sizeDelta = targetTransform.sizeDelta;
            IsVisible = true;
        }

        /// <summary>
        /// Called after view has been loaded.
        /// </summary>
        protected override void AfterLoad()
        {
            base.AfterLoad();
            GameObject.hideFlags = HideFlags.HideAndDontSave;
        }

        /// <summary>
        /// Called a dependency property changes value.
        /// </summary>
        public override void OnChanged(string property)
        {
            base.OnChanged(property);
            switch (property) 
            {
                case nameof(SelectedViewInfo):
                    OnSelectedViewInfoChanged();
                    break;
            }
        }

        /// <summary>
        /// Called when selected view info is changed.
        /// </summary>
        private void OnSelectedViewInfoChanged()
        {
        }

        /// <summary>
        /// Called by designer to make the view presentable in the designer.
        /// </summary>
        public override void PrepareForDesigner()
        {
            base.PrepareForDesigner();
            Width = 500;
            Height = 500;
        }

        #endregion
    }
}
