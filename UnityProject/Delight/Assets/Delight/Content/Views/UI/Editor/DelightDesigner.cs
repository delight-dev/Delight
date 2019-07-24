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
#endregion

namespace Delight
{

    public partial class DelightDesigner
    {
        public UIView _displayedView;
        public TMP_Text _textComponent;
        public Color32 _propertyNameColor = new Color32(255, 72, 121, 255); // #ff4879
        public Color32 _propertyValueColor = new Color32(59, 155, 255, 255); // #3b9bff
        public Color32 _viewNameColor = new Color32(74, 80, 78, 255); // #4a504e
        public Color32 _commentColor = new Color32(0, 212, 0, 255); // #00d400
        public Color32 _undefinedColor = new Color32(0, 0, 0, 255);

        public override void OnChanged(string property)
        {
            base.OnChanged(property);
            if (property == nameof(XmlText))
            {
                if (_textComponent == null)
                    return;

                // TODO we want to track caret position, see what is being edited to do things like intellisense, autocomplete, etc.
                _textComponent.text = XmlText;
                _textComponent.ForceMeshUpdate();

                // syntax highlight the text
                SyntaxHighlightXml();
            }
        }

        /// <summary>
        /// Syntax highlights the text. 
        /// </summary>
        private void SyntaxHighlightXml()
        {
            string xmlText = XmlText;
            if (String.IsNullOrEmpty(xmlText))
                return;

            TMP_TextInfo textInfo = _textComponent.textInfo;
            Color32[] newVertexColors;
            Color32 characterColor = _textComponent.color;            
            var xmlSyntaxElement = XmlSyntaxElement.Undefined;

            int characterCount = textInfo.characterCount;
            for (int characterIndex = 0; characterIndex < characterCount; ++characterIndex)
            {                              
                int materialIndex = textInfo.characterInfo[characterIndex].materialReferenceIndex;
                newVertexColors = textInfo.meshInfo[materialIndex].colors32;
                int vertexIndex = textInfo.characterInfo[characterIndex].vertexIndex;

                switch (xmlText[characterIndex])
                {
                    case '"':
                        if (xmlSyntaxElement == XmlSyntaxElement.Comment)
                            break;
                        if (characterIndex > 0 && xmlText[characterIndex - 1] == '\\')
                            break;
                        xmlSyntaxElement = xmlSyntaxElement == XmlSyntaxElement.PropertyValue ? XmlSyntaxElement.EndPropertyValue : XmlSyntaxElement.PropertyValue;
                        break;
                    case '<':
                        if (xmlSyntaxElement == XmlSyntaxElement.Comment)
                            break;
                        if (characterIndex + 3 < characterCount)
                        {
                            if (xmlText[characterIndex+1] == '!' && xmlText[characterIndex + 2] == '-' && xmlText[characterIndex + 3] == '-')
                            {
                                xmlSyntaxElement = XmlSyntaxElement.Comment;
                                break;
                            }
                        }
                        if (xmlSyntaxElement == XmlSyntaxElement.PropertyValue)
                            break;
                        xmlSyntaxElement = XmlSyntaxElement.BeginViewName;
                        break;
                    case '/':
                        if (xmlSyntaxElement == XmlSyntaxElement.Comment)
                            break;
                        if (xmlSyntaxElement == XmlSyntaxElement.PropertyValue)
                            break;
                        if (characterIndex - 1 >= 0)
                        {
                            if (xmlText[characterIndex - 1] == '<')
                            {
                                xmlSyntaxElement = XmlSyntaxElement.BeginViewName;
                                break;
                            }
                        }

                        xmlSyntaxElement = XmlSyntaxElement.EndViewName;
                        break;
                    case '>':
                        if (xmlSyntaxElement == XmlSyntaxElement.Comment)
                        {
                            if (characterIndex - 4 >= 0)
                            {
                                if (xmlText[characterIndex - 1] == '-' && xmlText[characterIndex - 2] == '-' && !(xmlText[characterIndex - 3] == '!' && xmlText[characterIndex - 4] != '<'))
                                {
                                    xmlSyntaxElement = XmlSyntaxElement.EndComment;
                                    break;
                                }
                            }
                            break;
                        }
                        if (xmlSyntaxElement == XmlSyntaxElement.PropertyValue)
                            break;
                        xmlSyntaxElement = XmlSyntaxElement.EndView;
                        break;
                    case ' ':
                        if (xmlSyntaxElement == XmlSyntaxElement.PropertyValue || xmlSyntaxElement == XmlSyntaxElement.Comment)
                            break;
                        xmlSyntaxElement = XmlSyntaxElement.PropertyName;
                        break;
                    default:
                        break;
                }

                switch (xmlSyntaxElement)
                {
                    case XmlSyntaxElement.Undefined:
                        characterColor = _undefinedColor;
                        break;
                    case XmlSyntaxElement.BeginViewName:
                        characterColor = _propertyValueColor;
                        xmlSyntaxElement = XmlSyntaxElement.ViewName;
                        break;
                    case XmlSyntaxElement.ViewName:
                        characterColor = _viewNameColor;
                        break;
                    case XmlSyntaxElement.EndViewName:
                        characterColor = _propertyValueColor;
                        xmlSyntaxElement = XmlSyntaxElement.PropertyName;
                        break;
                    case XmlSyntaxElement.EndView:
                        characterColor = _propertyValueColor;
                        xmlSyntaxElement = XmlSyntaxElement.Undefined;
                        break;
                    case XmlSyntaxElement.PropertyValue:
                        characterColor = _propertyValueColor;
                        break;
                    case XmlSyntaxElement.EndPropertyValue:
                        characterColor = _propertyValueColor;
                        xmlSyntaxElement = XmlSyntaxElement.PropertyName;
                        break;
                    case XmlSyntaxElement.PropertyName:
                        characterColor = _propertyNameColor;
                        break;
                    case XmlSyntaxElement.Comment:
                        characterColor = _commentColor;
                        break;
                    case XmlSyntaxElement.EndComment:
                        characterColor = _commentColor;
                        xmlSyntaxElement = XmlSyntaxElement.Undefined;
                        break;
                }

                //characterColor = new Color32((byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), 255);

                if (textInfo.characterInfo[characterIndex].isVisible)
                {
                    newVertexColors[vertexIndex + 0] = characterColor;
                    newVertexColors[vertexIndex + 1] = characterColor;
                    newVertexColors[vertexIndex + 2] = characterColor;
                    newVertexColors[vertexIndex + 3] = characterColor;
                }
            }

            // update text meshes
            _textComponent.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
        }

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

                designerViews.Add(new DesignerView { Id = viewObject.Name, Name = viewObject.Name, ViewTypeName = viewObject.TypeName });
            }

            DesignerViews.AddRange(designerViews.OrderBy(x => x.Id));
        }

        protected override void AfterLoad()
        {
            base.AfterLoad();
            _textComponent = XmlTextLabel.TextMeshProUGUI;
            //_textComponent.UpdateGeometry
        }

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
    }
}
#endif