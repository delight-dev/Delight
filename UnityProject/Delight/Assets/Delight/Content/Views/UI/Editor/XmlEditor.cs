#if DELIGHT_MODULE_TEXTMESHPRO

#region Using Statements
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Text;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Delight.Editor.Parser;
using UnityEditor;
#endregion

namespace Delight
{
    /// <summary>
    /// Editor for changing view XML during runtime, part of the designer. 
    /// </summary>
    public partial class XmlEditor
    {
        #region Fields

        public static float CharWidth = 10;
        public static float LineHeight = 20.98f;
        public static int SpacesPerTab = 2;
        public static float XmlTextMarginLeft = 20;
        public static float XmlTextMarginRight = 20;
        public static Color32 PropertyNameColor = new Color32(255, 72, 121, 255); // #ff4879
        public static Color32 PropertyValueColor = new Color32(59, 155, 255, 255); // #3b9bff
        public static Color32 ViewNameColor = new Color32(74, 80, 78, 255); // #4a504e
        public static Color32 CommentColor = new Color32(0, 212, 0, 255); // #00d400
        public static Color32 UndefinedColor = new Color32(255, 0, 0, 255); // #ff0000
        public static Color32 SelectionColor = new Color32(224, 224, 224, 255); // #f4f4f4
        public static float KeyRepeatDelay = 0.30f;
        public static float KeyRepeatRate = 0.05f;
        public static float DoubleClickDelay = 0.5f;
        public static float CaretRepeatDelay = 0.5f;
        public static float CaretRepeatRate = 1.15f;
        public static float TooltipOffset = 0;
        public static float TooltipDelay = 0.30f;
        public static float MaxAutoCompleteBoxHeight = 150;
        public static Regex ViewNameStartRegex = new Regex(@"(?<=<)[A-Za-z0-9_]+(?=[\s>/])");
        public static Regex QuoteContentRegex = new Regex(@"""(\\""|[^""])*"""); // "(\\"|[^"])*"

        private List<string> _lines = new List<string>();
        private int _caretX;
        private int _caretY;
        private int _desiredCaretX;
        private int _previousClickCaretX;
        private int _previousClickCaretY;
        private XmlSyntaxElement _caretElement = XmlSyntaxElement.Undefined;
        private KeyCode _trackKeyDown = KeyCode.None;
        private float _caretDelayTimeElapsed;
        private float _caretRepeatTimeElapsed;
        private float _keyDownDelayTimeElapsed;
        private float _keyDownRepeatTimeElapsed;
        private float _mouseClickStart;
        private float _tooltipHoverTimeElapsed;
        private bool _tooltipDeactivatedUntilMouseMove;
        private Vector3 _previousMousePosition;
        private string _lastViewHover;
        private string _lastWordHover;
        private Mesh _selectionMesh = new Mesh();
        private int _selectionOriginX;
        private int _selectionOriginY;
        private int _selectionTargetX;
        private int _selectionTargetY;
        private int _autoCompleteWordOriginX;
        private int _autoCompleteWordTargetX;
        private List<AutoCompleteOption> _autoCompleteOptions = new List<AutoCompleteOption>();
        private XmlSyntaxElement _autoCompleteType = XmlSyntaxElement.Undefined;
        private string _lastWordAtCaret;
        private bool _autoCompleteActive;
        private bool _hasSelection;
        private CanvasRenderer _caretCanvasRenderer;
        private Vector3 _mouseDownPosition;
        private bool _clickedInsideEditor;

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
                case nameof(XmlText):
                    ClearEditor();
                    if (XmlText != null)
                    {
                        _lines = new List<string>(XmlText.GetLines());
                    }
                    OnEditorChanged();
                    break;
            }
        }

        /// <summary>
        /// Called after the view has been initialized.
        /// </summary>
        public override void AfterInitialize()
        {
            base.AfterInitialize();
            AutoCompleteOptions = new AutoCompleteOptionData();
        }

        /// <summary>
        /// Called every frame and handles keyboard and mouse input.
        /// </summary>
        public override void Update()
        {
            if (IsFocused)
            {
                // make caret blink
                _caretDelayTimeElapsed += Time.deltaTime;
                if (_caretDelayTimeElapsed > CaretRepeatDelay)
                {
                    _caretRepeatTimeElapsed += Time.deltaTime;
                    Caret.IsActive = _caretRepeatTimeElapsed % CaretRepeatRate > CaretRepeatRate / 2;
                }
            }
            else
            {
                // hide autocomplete box
                DeactivateAutoComplete();
            }

            // update XML editor left margin based on scroll position so the line numbers follow along with scrolling
            var scrollableContentOffset = ScrollableRegion.GetContentOffset();
            XmlEditLeftMargin.Offset.Left = -scrollableContentOffset.x;

            bool ctrlDown = (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && !Input.GetKey(KeyCode.AltGr);
            bool scrollEngaged = ctrlDown || Input.GetMouseButton(2);
            bool mouseButtonDown = false;
            bool shiftDown = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
            ScrollableRegion.ScrollEnabled = scrollEngaged;
            bool containsMouse = ContainsMouse(Input.mousePosition);

            // handle mouse clicks
            if (Input.GetMouseButtonDown(0))
            {
                if (!containsMouse)
                {
                    // user has clicked outside the editor - deselect and deactivate caret
                    IsFocused = false;
                    _hasSelection = false;
                    Caret.IsActive = false;
                    _clickedInsideEditor = false;
                    DeactivateAutoComplete();
                    GenerateCaretAndSelectionMeshes();
                }
                else
                {
                    IsFocused = true;
                    _clickedInsideEditor = true;
                    mouseButtonDown = true;
                    _mouseDownPosition = Input.mousePosition;
                    if (AutoCompleteBox.IsVisible)
                    {
                        if (!AutoCompleteBox.ContainsMouse(Input.mousePosition) || scrollEngaged || shiftDown)
                        {
                            // if clicked outside the autocomplete box, hide it
                            DeactivateAutoComplete();
                        }
                        else
                        {
                            // clicked inside box
                            return;
                        }
                    }

                    if (!scrollEngaged && !shiftDown)
                    {
                        // regular mouse click
                        _hasSelection = false;
                        GetMouseCaretPosition(out _caretX, out _caretY);
                        _desiredCaretX = _caretX;
                        _selectionOriginX = _caretX;
                        _selectionOriginY = _caretY;

                        // handle double-clicks
                        float timeStamp = Time.unscaledTime;
                        if (_mouseClickStart + DoubleClickDelay > timeStamp)
                        {
                            if (_previousClickCaretX == _caretX && _previousClickCaretY == _caretY)
                            {
                                // if double-click at the same spot, select the word at caret
                                SelectWordAtCaret();
                            }
                        }
                        else
                        {
                            _mouseClickStart = timeStamp;
                        }

                        _previousClickCaretX = _caretX;
                        _previousClickCaretY = _caretY;

                        ActivateCaret();
                        UpdateTextAndCaret(false);
                    }
                }
            }

            // handle mouse drags
            if (((mouseButtonDown && shiftDown) ||
                (Input.GetMouseButton(0) && _clickedInsideEditor && !scrollEngaged && !mouseButtonDown)) &&
                !AutoCompleteBox.IsVisible)
            {
                // if we've dragged beyond a certain threshold update selection (or if we shift+mouse click)
                Vector3 delta = _mouseDownPosition - Input.mousePosition;
                if (Mathf.Abs(delta.x) > 3 || Mathf.Abs(delta.y) > 3 || (mouseButtonDown && shiftDown))
                {
                    // handle dragging selection
                    GetMouseCaretPosition(out _selectionTargetX, out _selectionTargetY);
                    _hasSelection = _selectionTargetX != _selectionOriginX || _selectionTargetY != _selectionOriginY;
                    if (_hasSelection)
                    {
                        _caretX = _selectionTargetX;
                        _caretY = _selectionTargetY;

                        ActivateCaret();
                        UpdateTextAndCaret(false);
                    }
                }
            }

            if (_tooltipDeactivatedUntilMouseMove)
            {
                // see if mouse has moved beyond threshold
                Vector3 delta = _previousMousePosition - Input.mousePosition;
                if (Mathf.Abs(delta.x) > 3 || Mathf.Abs(delta.y) > 3)
                {
                    _tooltipDeactivatedUntilMouseMove = false;
                }                
            }

            // handle tooltip hovers
            if (containsMouse)
            {
                GetMouseCaretPosition(out var caretX, out var caretY);

                var viewAtCaret = GetViewAtCaret(caretY);
                var wordAtCaret = GetWordAtCaret(caretX, caretY, out var originX, out var targetX);

                if (viewAtCaret == _lastViewHover && wordAtCaret == _lastWordHover)
                {
                    _tooltipHoverTimeElapsed += Time.deltaTime;
                }
                else
                {
                    DeactivateTooltip();
                }

                _lastViewHover = viewAtCaret;
                _lastWordHover = wordAtCaret;

                if (_tooltipHoverTimeElapsed >= TooltipDelay)
                {
                    if (String.IsNullOrEmpty(viewAtCaret) || String.IsNullOrEmpty(wordAtCaret))
                    {
                        DeactivateTooltip();
                    }
                    else if (wordAtCaret == viewAtCaret)
                    {
                        // hovering over view
                        var comment = GetElementDoc(viewAtCaret);
                        if (!String.IsNullOrWhiteSpace(comment))
                        {
                            ActivateTooltip(comment);
                        }
                        else
                        {
                            DeactivateTooltip();
                        }
                    }
                    else
                    {
                        // hovering over a word inside view tag
                        // see if word has "=" to the right then it's a property name
                        var comment = GetElementDoc(viewAtCaret, wordAtCaret);
                        if (!String.IsNullOrWhiteSpace(comment))
                        {
                            ActivateTooltip(comment);
                        }
                        else
                        {
                            DeactivateTooltip();
                        }
                    }

                    if (TooltipBox.IsVisible)
                    {
                        // position tooltip box
                        if (TooltipBox.OffsetFromParent == null)
                            TooltipBox.OffsetFromParent = new ElementMargin();
                        TooltipBox.OffsetFromParent.Left = CharWidth * originX;
                        TooltipBox.OffsetFromParent.Bottom = LineHeight * (_lines.Count - (caretY - 2)) + TooltipOffset;
                    }
                }
            }
            else
            {
                DeactivateTooltip();
            }

            // handle keyboard input
            if (Input.anyKey && IsFocused)
            {
                if (ctrlDown)
                {
                    // handle control commands
                    HandleControlInput();
                }
                else
                {
                    // handle regular input
                    HandleKeyInput();
                }
            }

            _previousMousePosition = Input.mousePosition;
        }

        /// <summary>
        /// Activates tooltip.
        /// </summary>
        private void ActivateTooltip(string tooltipText)
        {
            if (_tooltipDeactivatedUntilMouseMove)
                return;

            TooltipLabel.Text = tooltipText;
            TooltipBox.IsVisible = true;
        }

        /// <summary>
        /// Deactivates the tooltip box.
        /// </summary>
        private void DeactivateTooltip(bool deactivateUntilMouseMove = false)
        {
            TooltipBox.IsVisible = false;
            _tooltipHoverTimeElapsed = 0;
            _lastViewHover = null;
            _lastWordHover = null;
            if (deactivateUntilMouseMove)
            {
                _tooltipDeactivatedUntilMouseMove = true;
            }
            _previousMousePosition = Input.mousePosition;
        }

        /// <summary>
        /// Gets XML text from editor.
        /// </summary>
        public string GetXmlText()
        {
            return XmlTextLabel.TextMeshProUGUI.text;
        }

        /// <summary>
        /// Selects the word at the current caret position.
        /// </summary>
        private void SelectWordAtCaret()
        {
            if (_lines[_caretY].Length <= 0)
                return;

            _selectionOriginX = _caretX - 1;
            _selectionTargetX = _caretX;
            _selectionOriginY = _caretY;
            _selectionTargetY = _caretY;

            if (_selectionOriginX < 0)
                _selectionOriginX = 0;

            // choose selection method
            Func<char, bool> selectChar = c => Char.IsLetterOrDigit(c); // select letters and digits by default
            char leftChar = _lines[_caretY][_selectionOriginX];
            char rightChar = _selectionTargetX < _lines[_caretY].Length ? _lines[_caretY][_selectionTargetX] : leftChar;

            if ((Char.IsWhiteSpace(leftChar) && Char.IsWhiteSpace(rightChar)) ||
                (Char.IsWhiteSpace(leftChar) && !Char.IsLetterOrDigit(rightChar)) ||
                (!Char.IsLetterOrDigit(leftChar) && Char.IsWhiteSpace(rightChar)))
            {
                // if surrounded by whitespace, select whitespace
                selectChar = c => Char.IsWhiteSpace(c);
            }
            else if (!Char.IsLetterOrDigit(leftChar) && !Char.IsLetterOrDigit(rightChar))
            {
                // if surrounded by special characters, select special characters
                selectChar = c => !Char.IsLetterOrDigit(c);
            }

            while (_selectionTargetX < _lines[_caretY].Length)
            {
                if (!selectChar(_lines[_caretY][_selectionTargetX]))
                {
                    break;
                }

                ++_selectionTargetX;
            }

            while (_selectionOriginX >= 0)
            {
                if (!selectChar(_lines[_caretY][_selectionOriginX]))
                {
                    _selectionOriginX = _selectionOriginX == _lines[_caretY].Length - 1 ? _selectionOriginX : _selectionOriginX + 1;
                    break;
                }

                --_selectionOriginX;
            }

            if (_selectionOriginX < 0)
                _selectionOriginX = 0;

            _hasSelection = _selectionTargetX != _selectionOriginX || _selectionTargetY != _selectionOriginY;
            if (_hasSelection)
            {
                _desiredCaretX = _selectionTargetX;
                _caretX = _selectionTargetX;
            }
        }

        /// <summary>
        /// Gets mouse caret position. 
        /// </summary>
        private void GetMouseCaretPosition(out int caretX, out int caretY)
        {
            // set text indicator
            UnityEngine.Canvas canvas = LayoutRoot.Canvas;
            Camera worldCamera = canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(XmlTextRegion.RectTransform, Input.mousePosition, worldCamera, out var localMousePosition);

            localMousePosition.x = localMousePosition.x + XmlTextRegion.ActualWidth / 2;
            localMousePosition.y = localMousePosition.y - XmlTextRegion.ActualHeight / 2;

            int lineIndex = Mathf.FloorToInt(Mathf.Abs(localMousePosition.y) / LineHeight);
            int charIndex = Mathf.RoundToInt(localMousePosition.x / CharWidth);
            if (charIndex < 0)
            {
                charIndex = 0;
            }
            if (lineIndex < 0)
            {
                lineIndex = 0;
            }

            caretY = lineIndex < _lines.Count ? lineIndex : _lines.Count - 1;
            caretX = charIndex < _lines[caretY].Length ? charIndex : _lines[caretY].Length;
        }

        /// <summary>
        /// Handles keyboard input. 
        /// </summary>
        private void HandleKeyInput()
        {
            var inputString = Input.inputString;
            bool textChanged = false;
            bool needReparse = false;

            // key has been pressed in previous frame
            if (_trackKeyDown != KeyCode.None)
            {
                if (Input.GetKey(_trackKeyDown))
                {
                    _keyDownDelayTimeElapsed += Time.deltaTime;
                    if (_keyDownDelayTimeElapsed > KeyRepeatDelay)
                    {
                        _keyDownRepeatTimeElapsed += Time.deltaTime;
                    }
                    if (_keyDownRepeatTimeElapsed > KeyRepeatRate)
                    {
                        _keyDownRepeatTimeElapsed = 0;
                        inputString = (char)_trackKeyDown + inputString;
                    }
                }
                else
                {
                    _trackKeyDown = KeyCode.None;
                    _keyDownDelayTimeElapsed = 0;
                    _keyDownRepeatTimeElapsed = 0;
                }
            }

            // check if a key has been pressed down, these are the keys that don't show up in Input.inputString
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Keypad4))
            {
                inputString = (char)KeyCode.LeftArrow + inputString;
                _trackKeyDown = KeyCode.LeftArrow;
                _keyDownDelayTimeElapsed = 0;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Keypad6))
            {
                inputString = (char)KeyCode.RightArrow + inputString;
                _trackKeyDown = KeyCode.RightArrow;
                _keyDownDelayTimeElapsed = 0;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Keypad8))
            {
                inputString = (char)KeyCode.UpArrow + inputString;
                _trackKeyDown = KeyCode.UpArrow;
                _keyDownDelayTimeElapsed = 0;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Keypad2))
            {
                inputString = (char)KeyCode.DownArrow + inputString;
                _trackKeyDown = KeyCode.DownArrow;
                _keyDownDelayTimeElapsed = 0;
            }
            else if (Input.GetKeyDown(KeyCode.Tab))
            {
                inputString = (char)KeyCode.Tab + inputString;
                _trackKeyDown = KeyCode.Tab;
                _keyDownDelayTimeElapsed = 0;
            }
            else if (Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.KeypadPeriod))
            {
                inputString = (char)KeyCode.Delete + inputString;
                _trackKeyDown = KeyCode.Delete;
                _keyDownDelayTimeElapsed = 0;
            }
            else if (Input.GetKeyDown(KeyCode.Home))
            {
                inputString = (char)KeyCode.Home + inputString;
                _trackKeyDown = KeyCode.Home;
                _keyDownDelayTimeElapsed = 0;
            }
            else if (Input.GetKeyDown(KeyCode.End))
            {
                inputString = (char)KeyCode.End + inputString;
                _trackKeyDown = KeyCode.End;
                _keyDownDelayTimeElapsed = 0;
            }
            else if (Input.GetKeyDown(KeyCode.PageDown))
            {
                inputString = (char)KeyCode.PageDown + inputString;
                _trackKeyDown = KeyCode.PageDown;
                _keyDownDelayTimeElapsed = 0;
            }
            else if (Input.GetKeyDown(KeyCode.PageUp))
            {
                inputString = (char)KeyCode.PageUp + inputString;
                _trackKeyDown = KeyCode.PageUp;
                _keyDownDelayTimeElapsed = 0;
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                inputString = (char)KeyCode.Escape + inputString;
            }

            if (inputString.Length <= 0)
                return;

            var shiftDown = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
            bool updateDesiredCaretX = true;
            bool activateAutoComplete = _autoCompleteActive;
            KeyCode lastKeyCode;

            for (int i = 0; i < inputString.Length; ++i)
            {
                char c = inputString[i];
                KeyCode keyCode = (KeyCode)c;
                lastKeyCode = keyCode;
                //Debug.Log((int)c);

                switch (keyCode)
                {
                    case KeyCode.Space:
                    case KeyCode.Less:
                        if (IsReadOnly)
                            break;

                        textChanged = true;
                        if (_hasSelection)
                        {
                            DeleteSelection();
                            needReparse = true;
                        }
                        _lines[_caretY] = _lines[_caretY].InsertOrAdd(_caretX, c.ToString());
                        ++_caretX;

                        DeactivateAutoComplete();
                        activateAutoComplete = true;

                        if (IsEditingPropertyValue())
                        {
                            needReparse = true;
                        }
                        break;

                    case KeyCode.KeypadEnter:
                    case KeyCode.Return:
                        if (IsReadOnly)
                            break;

                        textChanged = true;

                        // if autocomplete active, complete selected suggestion and break
                        if (AutoCompleteBox.IsVisible)
                        {
                            activateAutoComplete = FinishAutoComplete();
                            needReparse = true;
                            break;
                        }

                        if (_hasSelection)
                        {
                            DeleteSelection();
                            needReparse = true;
                        }

                        string viewName = string.Empty;
                        int indentLevel = 0;
                        bool hasGottenIndentLevel = false;
                        bool addIndentation = false;

                        if (_caretElement == XmlSyntaxElement.PropertyName || _caretElement == XmlSyntaxElement.ViewName)
                        {
                            if (_caretX >= _lines[_caretY].Length && _lines[_caretY].Length > 0)
                            {
                                var trimmedLine = _lines[_caretY].TrimEnd();
                                if (trimmedLine.EndsWith("."))
                                {
                                    // if we end view declaration with dot and press enter add "/>" to close it
                                    _lines[_caretY] = trimmedLine.Substring(0, trimmedLine.Length - 1).TrimEnd() + " />";
                                    _caretX = _lines[_caretY].Length;
                                    _caretElement = XmlSyntaxElement.Undefined;
                                    needReparse = true;
                                    break;
                                }
                                else if (trimmedLine.EndsWith(","))
                                {
                                    // if we end view declaration with comma and press enter add ">" to close it
                                    _lines[_caretY] = trimmedLine.Substring(0, trimmedLine.Length - 1).TrimEnd() + ">";
                                    _caretX = _lines[_caretY].Length;
                                    _caretElement = XmlSyntaxElement.Undefined;

                                    indentLevel = GetIndentLevelOfNextLine(out viewName);
                                    hasGottenIndentLevel = true;

                                    var spacesStr = new string(' ', indentLevel);
                                    _lines.InsertOrAdd(_caretY + 1, string.Format("{0}</{1}>", spacesStr, viewName));
                                    addIndentation = true;
                                    needReparse = true;
                                }
                            }
                        }

                        // split the current line at caret position and add a new line with the new content
                        if (!hasGottenIndentLevel)
                        {
                            indentLevel = GetIndentLevelOfNextLine(out viewName);
                        }

                        if (_caretX <= 0)
                        {
                            _lines.Insert(_caretY, string.Empty);
                        }
                        else if (_caretX >= _lines[_caretY].Length)
                        {
                            _lines.InsertOrAdd(_caretY + 1, string.Empty);
                            if (addIndentation)
                                indentLevel += SpacesPerTab;
                            _lines[_caretY + 1] += new string(' ', indentLevel);
                            _caretX = indentLevel;
                        }
                        else
                        {
                            var rightStr = _lines[_caretY].Substring(_caretX);
                            var leftStr = _lines[_caretY].Substring(0, _caretX);
                            _lines[_caretY] = leftStr;
                            _lines.InsertOrAdd(_caretY + 1, rightStr);
                            _lines[_caretY + 1] = new string(' ', indentLevel) + _lines[_caretY + 1];
                            _caretX = indentLevel;
                        }
                        ++_caretY;
                        break;

                    case KeyCode.Backspace: // backspace
                        if (IsReadOnly)
                            break;

                        textChanged = true;
                        if (_hasSelection)
                        {
                            DeleteSelection();
                            needReparse = true;
                            break; // do nothing else
                        }

                        --_caretX;
                        if (_caretX < 0)
                        {
                            // we're at the beggining of the line hitting backspace
                            --_caretY;
                            if (_caretY < 0)
                            {
                                // we're at the top-left in the input field, so do nothing
                                _caretY = 0;
                                _caretX = 0;
                            }
                            else
                            {
                                // append line to the line we've backspaced to
                                var newCaretX = _lines[_caretY].Length;
                                _lines[_caretY] += _lines[_caretY + 1];
                                _caretX = newCaretX;
                                _lines.RemoveAt(_caretY + 1);
                            }
                        }
                        else
                        {
                            _lines[_caretY] = _lines[_caretY].Remove(_caretX, 1);
                        }

                        if (IsEditingPropertyValue() || IsEditingViewNameThatExist())
                        {
                            needReparse = true;
                        }
                        break;

                    case KeyCode.Tab:
                        if (IsReadOnly)
                            break;

                        textChanged = true;
                        if (AutoCompleteBox.IsVisible)
                        {
                            activateAutoComplete = FinishAutoComplete();
                            needReparse = true;
                            break;
                        }

                        if (_hasSelection)
                        {
                            DeleteSelection();
                            needReparse = true;
                        }
                        _lines[_caretY] = _lines[_caretY].InsertOrAdd(_caretX, new string(' ', SpacesPerTab));
                        _caretX += SpacesPerTab;

                        if (IsEditingPropertyValue())
                        {
                            needReparse = true;
                        }
                        break;

                    case KeyCode.Delete:
                        if (IsReadOnly)
                            break;

                        textChanged = true;
                        if (_hasSelection)
                        {
                            DeleteSelection();
                            needReparse = true;
                            break; // do nothing else
                        }

                        if (_caretX < _lines[_caretY].Length)
                        {
                            _lines[_caretY] = _lines[_caretY].Remove(_caretX, 1);
                        }
                        else
                        {
                            // we're at the end of the line hitting delete, are there more lines below?
                            if (_caretY < _lines.Count - 1)
                            {
                                // yes. append below line to the current line
                                _lines[_caretY] += _lines[_caretY + 1];
                                _lines.RemoveAt(_caretY + 1);
                            }
                        }

                        if(IsEditingPropertyValue() || IsEditingViewNameThatExist())
                        {
                            needReparse = true;
                        }
                        break;

                    case KeyCode.LeftArrow:
                        // if we move over non-alphanumeric character deactivate auto-complete
                        int walkedOverCaret = _caretX - 1;
                        if (walkedOverCaret < _lines[_caretY].Length && walkedOverCaret >= 0)
                        {
                            char walkedOverChar = _lines[_caretY][walkedOverCaret];
                            if (!Char.IsLetterOrDigit(walkedOverChar))
                            {
                                activateAutoComplete = false;
                            }
                        }
                        else
                        {
                            activateAutoComplete = false;
                        }

                        // handle selection
                        if (shiftDown)
                        {
                            if (!_hasSelection)
                            {
                                // set origin of selection
                                _selectionOriginX = _caretX;
                                _selectionOriginY = _caretY;
                                _selectionTargetX = _selectionOriginX;
                                _selectionTargetY = _selectionOriginY;
                            }
                        }

                        --_caretX;
                        if (_caretX < 0)
                        {
                            --_caretY;
                            if (_caretY < 0)
                            {
                                // we're at the top-left in the input field, so do nothing
                                _caretY = 0;
                                _caretX = 0;
                            }
                            else
                            {
                                // move to end of previous line
                                _caretX = _lines[_caretY].Length;
                            }
                        }

                        // handle selection
                        if (shiftDown)
                        {
                            _selectionTargetX = _caretX;
                            _selectionTargetY = _caretY;
                            _hasSelection = _selectionTargetX != _selectionOriginX || _selectionTargetY != _selectionOriginY;
                        }
                        else
                        {
                            _hasSelection = false;
                        }
                        break;

                    case KeyCode.RightArrow:
                        // if we move over non-alphanumeric character deactivate auto-complete
                        int rightWalkedOverCaret = _caretX;
                        if (rightWalkedOverCaret < _lines[_caretY].Length && rightWalkedOverCaret >= 0)
                        {
                            char walkedOverChar = _lines[_caretY][rightWalkedOverCaret];
                            if (!Char.IsLetterOrDigit(walkedOverChar))
                            {
                                activateAutoComplete = false;
                            }
                        }
                        else
                        {
                            activateAutoComplete = false;
                        }

                        // handle selection
                        if (shiftDown)
                        {
                            if (!_hasSelection)
                            {
                                // set origin of selection
                                _selectionOriginX = _caretX;
                                _selectionOriginY = _caretY;
                                _selectionTargetX = _selectionOriginX;
                                _selectionTargetY = _selectionOriginY;
                            }
                        }

                        if (_caretX < _lines[_caretY].Length)
                        {
                            ++_caretX;
                        }
                        else if (_caretY < _lines.Count - 1)
                        {
                            // move to beginning of next line
                            _caretX = 0;
                            ++_caretY;
                        }

                        // handle selection
                        if (shiftDown)
                        {
                            _selectionTargetX = _caretX;
                            _selectionTargetY = _caretY;
                            _hasSelection = _selectionTargetX != _selectionOriginX || _selectionTargetY != _selectionOriginY;
                        }
                        else
                        {
                            _hasSelection = false;
                        }
                        break;

                    case KeyCode.UpArrow:
                        // handle selection
                        if (shiftDown)
                        {
                            activateAutoComplete = false;

                            if (!_hasSelection)
                            {
                                // set origin of selection
                                _selectionOriginX = _caretX;
                                _selectionOriginY = _caretY;
                                _selectionTargetX = _selectionOriginX;
                                _selectionTargetY = _selectionOriginY;
                            }
                        }
                        else if (AutoCompleteBox.IsVisible)
                        {
                            // if auto complete open, scroll in list and break
                            AutoCompleteOptionsList.SelectPrevious();
                            break;
                        }

                        updateDesiredCaretX = false;
                        if (_caretY > 0)
                        {
                            --_caretY;
                            _caretX = _desiredCaretX >= _lines[_caretY].Length ? _lines[_caretY].Length : _desiredCaretX;
                        }

                        // handle selection
                        if (shiftDown)
                        {
                            _selectionTargetX = _caretX;
                            _selectionTargetY = _caretY;
                            _hasSelection = _selectionTargetX != _selectionOriginX || _selectionTargetY != _selectionOriginY;
                        }
                        else
                        {
                            _hasSelection = false;
                        }
                        break;

                    case KeyCode.DownArrow:
                        // handle selection
                        if (shiftDown)
                        {
                            activateAutoComplete = false;

                            if (!_hasSelection)
                            {
                                // set origin of selection
                                _selectionOriginX = _caretX;
                                _selectionOriginY = _caretY;
                                _selectionTargetX = _selectionOriginX;
                                _selectionTargetY = _selectionOriginY;
                            }
                        }
                        else if (AutoCompleteBox.IsVisible)
                        {
                            // if auto complete open, scroll in list and break
                            AutoCompleteOptionsList.SelectNext();
                            break;
                        }

                        updateDesiredCaretX = false;
                        if (_caretY < _lines.Count - 1)
                        {
                            ++_caretY;
                            _caretX = _desiredCaretX >= _lines[_caretY].Length ? _lines[_caretY].Length : _desiredCaretX;
                        }

                        // handle selection
                        if (shiftDown)
                        {
                            _selectionTargetX = _caretX;
                            _selectionTargetY = _caretY;
                            _hasSelection = _selectionTargetX != _selectionOriginX || _selectionTargetY != _selectionOriginY;
                        }
                        else
                        {
                            _hasSelection = false;
                        }
                        break;

                    case KeyCode.Home:
                        // handle selection
                        if (shiftDown)
                        {
                            if (!_hasSelection)
                            {
                                // set origin of selection
                                _selectionOriginX = _caretX;
                                _selectionOriginY = _caretY;
                                _selectionTargetX = _selectionOriginX;
                                _selectionTargetY = _selectionOriginY;
                            }
                        }

                        var nonSpaceIndex = _lines[_caretY].IndexOf(x => x != ' ');
                        if (nonSpaceIndex < 0)
                            nonSpaceIndex = 0;

                        _caretX = _caretX == nonSpaceIndex ? 0 : nonSpaceIndex;

                        // handle selection
                        if (shiftDown)
                        {
                            _selectionTargetX = _caretX;
                            _selectionTargetY = _caretY;
                            _hasSelection = _selectionTargetX != _selectionOriginX || _selectionTargetY != _selectionOriginY;
                        }
                        else
                        {
                            _hasSelection = false;
                        }
                        break;

                    case KeyCode.End:
                        // handle selection
                        if (shiftDown)
                        {
                            if (!_hasSelection)
                            {
                                // set origin of selection
                                _selectionOriginX = _caretX;
                                _selectionOriginY = _caretY;
                                _selectionTargetX = _selectionOriginX;
                                _selectionTargetY = _selectionOriginY;
                            }
                        }

                        _caretX = _lines[_caretY].Length;

                        // handle selection
                        if (shiftDown)
                        {
                            _selectionTargetX = _caretX;
                            _selectionTargetY = _caretY;
                            _hasSelection = _selectionTargetX != _selectionOriginX || _selectionTargetY != _selectionOriginY;
                        }
                        else
                        {
                            _hasSelection = false;
                        }
                        break;

                    case KeyCode.KeypadEquals:
                    case KeyCode.Equals:
                        if (IsReadOnly)
                            break;

                        textChanged = true;
                        if (_hasSelection)
                        {
                            DeleteSelection();
                        }
                        // add ="" if caret isn't in a property value or comment
                        if (_caretElement != XmlSyntaxElement.PropertyValue && _caretElement != XmlSyntaxElement.EndPropertyValue &&
                            _caretElement != XmlSyntaxElement.BeginPropertyValue && _caretElement != XmlSyntaxElement.Comment && _caretElement != XmlSyntaxElement.EndComment)
                        {
                            _lines[_caretY] = _lines[_caretY].InsertOrAdd(_caretX, c + "\"\"");
                            _caretX = _caretX + 2;
                            DeactivateAutoComplete(); // re-trigger auto-complete
                            activateAutoComplete = true;
                        }
                        else
                        {
                            _lines[_caretY] = _lines[_caretY].InsertOrAdd(_caretX, c.ToString());
                            ++_caretX;
                        }
                        activateAutoComplete = true;
                        break;

                    case KeyCode.PageDown:
                        // handle selection
                        if (shiftDown)
                        {
                            activateAutoComplete = false;

                            if (!_hasSelection)
                            {
                                // set origin of selection
                                _selectionOriginX = _caretX;
                                _selectionOriginY = _caretY;
                                _selectionTargetX = _selectionOriginX;
                                _selectionTargetY = _selectionOriginY;
                            }
                        }
                        else if (AutoCompleteBox.IsVisible)
                        {
                            // if auto complete open, scroll in list and break
                            AutoCompleteOptionsList.ScrollPageDown(true);
                            break;
                        }

                        updateDesiredCaretX = false;
                        int jumpLines = Mathf.FloorToInt(ScrollableRegion.ViewportHeight / LineHeight);
                        _caretY += jumpLines;
                        if (_caretY > _lines.Count - 1)
                        {
                            _caretY = _lines.Count - 1;
                            _caretX = _desiredCaretX >= _lines[_caretY].Length ? _lines[_caretY].Length : _desiredCaretX;
                        }

                        // handle selection
                        if (shiftDown)
                        {
                            _selectionTargetX = _caretX;
                            _selectionTargetY = _caretY;
                            _hasSelection = _selectionTargetX != _selectionOriginX || _selectionTargetY != _selectionOriginY;
                        }
                        else
                        {
                            _hasSelection = false;
                        }
                        break;

                    case KeyCode.Escape:
                        activateAutoComplete = false;
                        break;

                    case KeyCode.PageUp:
                        // handle selection
                        if (shiftDown)
                        {
                            activateAutoComplete = false;

                            if (!_hasSelection)
                            {
                                // set origin of selection
                                _selectionOriginX = _caretX;
                                _selectionOriginY = _caretY;
                                _selectionTargetX = _selectionOriginX;
                                _selectionTargetY = _selectionOriginY;
                            }
                        }
                        else if (AutoCompleteBox.IsVisible)
                        {
                            // if auto complete open, scroll in list and break
                            AutoCompleteOptionsList.ScrollPageUp(true);
                            break;
                        }

                        updateDesiredCaretX = false;
                        int jumpLinesUp = Mathf.FloorToInt(ScrollableRegion.ViewportHeight / LineHeight);
                        _caretY -= jumpLinesUp;
                        if (_caretY < 0)
                        {
                            _caretY = 0;
                            _caretX = _desiredCaretX >= _lines[_caretY].Length ? _lines[_caretY].Length : _desiredCaretX;
                        }

                        // handle selection
                        if (shiftDown)
                        {
                            _selectionTargetX = _caretX;
                            _selectionTargetY = _caretY;
                            _hasSelection = _selectionTargetX != _selectionOriginX || _selectionTargetY != _selectionOriginY;
                        }
                        else
                        {
                            _hasSelection = false;
                        }
                        break;

                    default:
                        if (IsReadOnly)
                            break;

                        textChanged = true;
                        if (_hasSelection)
                        {
                            DeleteSelection();
                            needReparse = true;
                        }

                        string str = c.ToString();
                        if (_caretElement == XmlSyntaxElement.Undefined)
                        {
                            // if previous character isn't a "<" add it
                            int previousChar = _caretX - 1;
                            if (previousChar < 0 || previousChar >= _lines[_caretY].Length ||
                                _lines[_caretY][previousChar] != '<')
                            {
                                str = "<" + str;
                            }

                            activateAutoComplete = true;
                        }

                        if (activateAutoComplete && (c == ',' || c == '.'))
                        {
                            // terminate autocomplete when typing certain special characters to end the tag
                            activateAutoComplete = false;
                        }

                        _lines[_caretY] = _lines[_caretY].InsertOrAdd(_caretX, str);
                        _caretX += str.Length;

                        if (IsEditingPropertyValue() || IsEditingViewNameThatExist())
                        {
                            needReparse = true;
                        }

                        break;
                }

                if (updateDesiredCaretX)
                {
                    // update desired caret unless up/down arrows have been pressed
                    _desiredCaretX = _caretX;
                }
            }

            OnTextOrCaretChanged(textChanged, activateAutoComplete, needReparse);
        }

        /// <summary>
        /// Returns boolean indicating if caret position implies user is editing a property value.
        /// </summary>
        private bool IsEditingPropertyValue()
        {
            return _caretElement == XmlSyntaxElement.PropertyValue || _caretElement == XmlSyntaxElement.EndPropertyValue;
        }

        /// <summary>
        /// Returns boolean indicating if caret position implies user is editing a view name.
        /// </summary>
        private bool IsEditingViewName()
        {
            return _caretElement == XmlSyntaxElement.ViewName;
        }

        /// <summary>
        /// Returns boolean indicating if caret position implies user is editing a view name.
        /// </summary>
        private bool IsEditingViewNameThatExist()
        {
            if (!IsEditingViewName())
                return false;

            string wordAtCaret = GetWordAtCaret();
            return DesignerViews.Any(x => x.Name == wordAtCaret);
        }

        /// <summary>
        /// Called when text or caret has changed.
        /// </summary>
        private void OnTextOrCaretChanged(bool textChanged, bool activateAutoComplete, bool needReparse)
        {
            DeactivateTooltip(true);

            ActivateCaret();
            OnEditorChanged();

            // handle autocomplete
            if (activateAutoComplete)
            {
                ActivateAutoComplete();
            }
            else
            {
                DeactivateAutoComplete();
            }

            // check if caret is outside viewport and update scroll position
            float viewportWidth = ScrollableRegion.ViewportWidth;
            float viewportHeight = ScrollableRegion.ViewportHeight;
            var contentOffset = ScrollableRegion.GetContentOffset();
            contentOffset.x = Math.Abs(contentOffset.x);
            contentOffset.y = Math.Abs(contentOffset.y);
            float caretOffsetX = _caretX * CharWidth + XmlEditLeftMargin.Width;
            float caretOffsetY = _caretY * LineHeight;
            float scrollOffsetX = -1;
            float scrollOffsetY = -1;

            if ((caretOffsetX + CharWidth + ScrollableRegion.VerticalScrollbar.ActualWidth) > (contentOffset.x + viewportWidth))
            {
                scrollOffsetX = (caretOffsetX + CharWidth + ScrollableRegion.VerticalScrollbar.ActualWidth) - viewportWidth;
            }
            else if (caretOffsetX - XmlEditLeftMargin.Width < contentOffset.x)
            {
                scrollOffsetX = caretOffsetX - XmlEditLeftMargin.Width;
            }

            if ((caretOffsetY + LineHeight + ScrollableRegion.HorizontalScrollbar.ActualHeight) > (contentOffset.y + viewportHeight))
            {
                scrollOffsetY = (caretOffsetY + LineHeight + ScrollableRegion.HorizontalScrollbar.ActualHeight) - viewportHeight;
            }
            else if (caretOffsetY < contentOffset.y)
            {
                scrollOffsetY = caretOffsetY;
            }

            if (scrollOffsetX >= 0 || scrollOffsetY >= 0)
            {
                if (scrollOffsetX >= 0 && scrollOffsetY >= 0)
                    ScrollableRegion.SetAbsoluteScrollPosition(scrollOffsetX, scrollOffsetY);
                else if (scrollOffsetX >= 0)
                    ScrollableRegion.SetHorizontalAbsoluteScrollPosition(scrollOffsetX);
                else
                    ScrollableRegion.SetVerticalAbsoluteScrollPosition(scrollOffsetY);
            }

            if (textChanged && !IsReadOnly)
            {
                // trigger edit invent unless only arrow keys has been pressed
                Edit.Invoke(this, needReparse);
            }
        }

        /// <summary>
        /// Gets the selected text.
        /// </summary>
        private string GetSelection()
        {
            string selection = string.Empty;
            if (!_hasSelection)
                return selection;

            int startLine = Math.Min(_selectionOriginY, _selectionTargetY);
            int endLine = Math.Max(_selectionOriginY, _selectionTargetY);
            int startChar = startLine == endLine ? Math.Min(_selectionOriginX, _selectionTargetX) : _selectionOriginY > _selectionTargetY ? _selectionTargetX : _selectionOriginX;
            int endChar = startLine == endLine ? Math.Max(_selectionOriginX, _selectionTargetX) : _selectionOriginY > _selectionTargetY ? _selectionOriginX : _selectionTargetX;

            if (endLine == startLine)
            {
                return _lines[startLine].Substring(startChar, endChar - startChar);
            }
            else
            {
                var lines = new List<string>();
                lines.Add(_lines[startLine].Substring(startChar));
                int startRange = startLine + 1;
                if (endLine != startRange)
                {
                    int endRange = (endLine - startLine) - 1;
                    lines.AddRange(_lines.GetRange(startRange, endRange));
                }
                lines.Add(_lines[endLine].Substring(0, endChar));
                return String.Join(Environment.NewLine, lines);
            }
        }

        /// <summary>
        /// Removes the selected text.
        /// </summary>
        private void DeleteSelection()
        {
            _hasSelection = false;
            int startLine = Math.Min(_selectionOriginY, _selectionTargetY);
            int endLine = Math.Max(_selectionOriginY, _selectionTargetY);
            int startChar = startLine == endLine ? Math.Min(_selectionOriginX, _selectionTargetX) : _selectionOriginY > _selectionTargetY ? _selectionTargetX : _selectionOriginX;
            int endChar = startLine == endLine ? Math.Max(_selectionOriginX, _selectionTargetX) : _selectionOriginY > _selectionTargetY ? _selectionOriginX : _selectionTargetX;

            if (endLine == startLine)
            {
                _lines[startLine] = _lines[startLine].Substring(0, startChar) + _lines[startLine].Substring(endChar);
            }
            else
            {
                _lines[startLine] = _lines[startLine].Substring(0, startChar) + _lines[endLine].Substring(endChar);
                _lines.RemoveRange(startLine + 1, endLine - startLine);
            }

            _caretX = startChar;
            _caretY = startLine;
        }

        /// <summary>
        /// Gets indendation level and viewname of the next line.
        /// </summary>
        private int GetIndentLevelOfNextLine(out string viewName)
        {
            viewName = string.Empty;
            bool getPropertyIdentation = false;

            if (_caretElement == XmlSyntaxElement.PropertyName)
            {
                getPropertyIdentation = true;
            }

            int caretY = _caretY;
            while (caretY >= 0)
            {
                var line = _lines[caretY];
                var trimmedLine = line.TrimStart();
                if (trimmedLine.StartsWith("<") && !trimmedLine.StartsWith("<!"))
                {
                    int leadingSpaces = _lines[caretY].TakeWhile(Char.IsWhiteSpace).Count();
                    if (leadingSpaces + 1 < _lines[caretY].Length)
                    {
                        viewName = new string(_lines[caretY].Substring(leadingSpaces + 1).TakeWhile(Char.IsLetterOrDigit).ToArray());
                    }

                    if (getPropertyIdentation)
                    {
                        return leadingSpaces + viewName.Length + 2;
                    }
                    else
                    {
                        return leadingSpaces;
                    }
                }
                --caretY;
            }
            return 0;
        }

        /// <summary>
        /// Handles input when CTRL key is pressed.
        /// </summary>
        private void HandleControlInput()
        {
            var inputString = Input.inputString;
            bool updateText = false;
            bool needReparse = false;

            // key has been pressed in previous frame
            if (_trackKeyDown != KeyCode.None)
            {
                _trackKeyDown = KeyCode.None;
                _keyDownDelayTimeElapsed = 0;
                _keyDownRepeatTimeElapsed = 0;
            }

            // CTRL+C - copy
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (_hasSelection)
                {
                    GUIUtility.systemCopyBuffer = GetSelection();
                }
            }

            // CTRL+X - cut
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (_hasSelection)
                {
                    GUIUtility.systemCopyBuffer = GetSelection();

                    if (!IsReadOnly)
                    {
                        DeleteSelection();
                        updateText = true;
                        needReparse = true;
                    }
                }
            }

            // CTRL+V - paste
            if (Input.GetKeyDown(KeyCode.V) && !IsReadOnly)
            {
                var pasteText = GUIUtility.systemCopyBuffer;
                if (String.IsNullOrEmpty(pasteText))
                    return;

                if (_hasSelection)
                {
                    DeleteSelection();
                }

                var pasteLines = pasteText.GetLines().ToList();
                if (pasteLines.Count == 1)
                {
                    if (pasteLines[0].Length > 0)
                    {
                        _lines[_caretY] = _lines[_caretY].InsertOrAdd(_caretX, pasteLines[0]);
                        _caretX += pasteLines[0].Length;
                    }
                }
                else
                {
                    var rightStr = string.Empty;
                    var leftStr = string.Empty;

                    if (_caretX <= 0)
                    {
                        rightStr = _lines[_caretY];
                    }
                    else if (_caretX >= _lines[_caretY].Length)
                    {
                        leftStr = _lines[_caretY];
                    }
                    else
                    {
                        rightStr = _lines[_caretY].Substring(_caretX);
                        leftStr = _lines[_caretY].Substring(0, _caretX);
                    }

                    if (pasteLines[0].Length == 1)
                    {
                        _lines[_caretY] = leftStr + pasteLines[0] + rightStr;
                        _caretX += pasteLines[0].Length;
                    }
                    else
                    {
                        _lines[_caretY] = leftStr + pasteLines[0];
                        int lastIndex = pasteLines.Count - 1;
                        for (int j = 1; j < lastIndex; ++j)
                        {
                            _lines.InsertOrAdd(_caretY + j, pasteLines[j]);
                        }

                        _lines.InsertOrAdd(_caretY + lastIndex, pasteLines[lastIndex] + rightStr);
                        _caretX = pasteLines[lastIndex].Length;
                        _caretY += lastIndex;
                    }
                }

                updateText = true;
                needReparse = true;
            }

            // CTRL+A - select all
            else if (Input.GetKeyDown(KeyCode.A))
            {
                _selectionOriginX = 0;
                _selectionOriginY = 0;
                _selectionTargetY = _lines.Count() - 1;
                _selectionTargetX = _lines[_selectionTargetY].Length;
                _hasSelection = _selectionTargetX != _selectionOriginX || _selectionTargetY != _selectionOriginY;

                if (_hasSelection)
                {
                    _caretX = _selectionTargetX;
                    _caretY = _selectionTargetY;
                    UpdateTextAndCaret(false);
                }
            }

            // CTRL+Space - trigger intellisense/autocomplete
            else if (Input.GetKeyDown(KeyCode.Space) && !IsReadOnly)
            {
                ActivateAutoComplete();
            }

            if (updateText)
            {
                OnEditorChanged();
                Edit.Invoke(this, needReparse);
            }
        }

        /// <summary>
        /// Called after the view has been loaded.
        /// </summary>
        protected override void AfterLoad()
        {
            base.AfterLoad();
            //XmlTextLabel.GameObject.AddComponent<TMPro.Examples.TMP_TextInfoDebugTool>(); // TODO remove after debugging
            _caretCanvasRenderer = Caret.GameObject.GetComponent<CanvasRenderer>();

            ClearEditor();
        }

        /// <summary>
        /// Clears all input and resets editor to default state.
        /// </summary>
        public void ClearEditor()
        {
            _caretX = 0;
            _caretY = 0;
            _desiredCaretX = 0;
            _lines.Clear();
            _lines.Add(string.Empty);
            _hasSelection = false;
            ScrollableRegion.SetScrollPosition(0, 0);

            OnEditorChanged();
        }

        /// <summary>
        /// Called when the XML text, selection or caret has changed. 
        /// </summary>
        private void OnEditorChanged()
        {
            string xmlText = String.Join(Environment.NewLine, _lines);
            XmlTextLabel.TextMeshProUGUI.text = xmlText;

            XmlTextLabel.TextMeshProUGUI.ForceMeshUpdate();
            TMP_TextInfo textInfo = XmlTextLabel.TextMeshProUGUI.textInfo;
            var textBounds = XmlTextLabel.TextMeshProUGUI.textBounds;

            // set size and text of line numbers
            var maxLineNumberCharCount = _lines.Count().ToString().Length;
            var lineNumbersWidth = CharWidth * maxLineNumberCharCount;
            var lineNumbersHeight = _lines.Count() * LineHeight;

            LineNumbersLabel.Width = lineNumbersWidth;
            LineNumbersLabel.Height = lineNumbersHeight;
            LineNumbersLabel.Text = String.Join(Environment.NewLine, Enumerable.Range(1, _lines.Count()).Select(x => x.ToString()));

            float leftMarginSpacing = CharWidth;
            XmlEditLeftMargin.Width = lineNumbersWidth + leftMarginSpacing;
            XmlEditLeftMargin.Height = lineNumbersHeight;
            XmlEditLeftMargin.Margin.Right = leftMarginSpacing;

            // set size and margins of XML edit and text region
            var maxLineLength = _lines.Max(x => x.Length);
            float textWidth = maxLineLength * CharWidth;
            float textHeight = _lines.Count() * LineHeight;
            XmlEditRegion.Width = textWidth + XmlEditLeftMargin.Width + XmlTextMarginLeft + XmlTextMarginRight + ScrollableRegion.VerticalScrollbar.ActualWidth;
            XmlEditRegion.Height = textHeight + ScrollableRegion.HorizontalScrollbar.ActualHeight + LineHeight;
            XmlTextRegion.Margin.Left = XmlEditLeftMargin.Width;

            // update text, syntax highlighting, selection and caret position
            UpdateTextAndCaret();
        }

        /// <summary>
        /// Updates text, syntax highlighting, selection and caret.
        /// </summary>
        private void UpdateTextAndCaret(bool syntaxHighlight = true)
        {
            if (Caret.OffsetFromParent == null)
                Caret.OffsetFromParent = new ElementMargin();
            Caret.OffsetFromParent.Left = CharWidth * _caretX;
            Caret.OffsetFromParent.Top = LineHeight * _caretY;

            // position intellisense box
            if (AutoCompleteBox.OffsetFromParent == null)
                AutoCompleteBox.OffsetFromParent = new ElementMargin();
            AutoCompleteBox.OffsetFromParent.Left = CharWidth * _caretX;
            AutoCompleteBox.OffsetFromParent.Top = LineHeight * (_caretY + 1);

            _caretElement = XmlSyntaxElement.Undefined;
            string xmlText = XmlTextLabel.TextMeshProUGUI.text;
            if (String.IsNullOrEmpty(xmlText))
            {
                GenerateCaretAndSelectionMeshes();
                return;
            }

            TMP_TextInfo textInfo = XmlTextLabel.TextMeshProUGUI.textInfo;
            Color32[] newVertexColors;
            Color32 characterColor = XmlTextLabel.TextMeshProUGUI.color;
            var xmlSyntaxElement = XmlSyntaxElement.Undefined;

            int line = 0;
            int lineChar = 0;
            int characterCount = textInfo.characterCount;
            int caretX = _caretX;
            bool caretLastInLine = false;
            bool addLine = false;
            if (_lines[_caretY].Length == _caretX)
            {
                --caretX;
                caretLastInLine = true;
            }

            // go through characters, syntax highlight and track current caret element
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
                        xmlSyntaxElement = xmlSyntaxElement == XmlSyntaxElement.BeginPropertyValue || xmlSyntaxElement == XmlSyntaxElement.PropertyValue ? XmlSyntaxElement.EndPropertyValue : XmlSyntaxElement.BeginPropertyValue;
                        break;
                    case '<':
                        if (xmlSyntaxElement == XmlSyntaxElement.Comment)
                            break;
                        if (characterIndex + 3 < characterCount)
                        {
                            if (xmlText[characterIndex + 1] == '!' && xmlText[characterIndex + 2] == '-' && xmlText[characterIndex + 3] == '-')
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
                        if (xmlSyntaxElement == XmlSyntaxElement.PropertyValue || xmlSyntaxElement == XmlSyntaxElement.Comment || xmlSyntaxElement == XmlSyntaxElement.Undefined)
                            break;

                        // if previous is part of a view name we don't want this to be a property name
                        if (characterIndex - 1 >= 0)
                        {
                            char previousChar = xmlText[characterIndex - 1];
                            if (previousChar == '<' || Char.IsLetterOrDigit(previousChar))
                            {
                                xmlSyntaxElement = XmlSyntaxElement.ViewName;
                                break;
                            }
                        }

                        xmlSyntaxElement = XmlSyntaxElement.PropertyName;
                        break;
                    case '\n':
                        addLine = true;
                        break;
                    case '\r':
                        lineChar = 0;
                        break;
                    default:
                        if (xmlSyntaxElement == XmlSyntaxElement.ViewName)
                        {
                            if (characterIndex - 1 >= 0)
                            {
                                char previousChar = xmlText[characterIndex - 1];
                                if (previousChar == ' ')
                                {
                                    xmlSyntaxElement = XmlSyntaxElement.PropertyName;
                                    break;
                                }
                            }
                        }

                        break;
                }

                if (!caretLastInLine && line == _caretY && lineChar == caretX)
                {
                    _caretElement = xmlSyntaxElement;
                }

                switch (xmlSyntaxElement)
                {
                    case XmlSyntaxElement.Undefined:
                        characterColor = UndefinedColor;
                        break;
                    case XmlSyntaxElement.BeginViewName:
                        characterColor = PropertyValueColor;
                        xmlSyntaxElement = XmlSyntaxElement.ViewName;
                        break;
                    case XmlSyntaxElement.ViewName:
                        characterColor = ViewNameColor;
                        break;
                    case XmlSyntaxElement.EndViewName:
                        characterColor = PropertyValueColor;
                        xmlSyntaxElement = XmlSyntaxElement.PropertyName;
                        break;
                    case XmlSyntaxElement.EndView:
                        characterColor = PropertyValueColor;
                        xmlSyntaxElement = XmlSyntaxElement.Undefined;
                        break;
                    case XmlSyntaxElement.BeginPropertyValue:
                        characterColor = PropertyValueColor;
                        xmlSyntaxElement = XmlSyntaxElement.PropertyValue;
                        break;
                    case XmlSyntaxElement.PropertyValue:
                        characterColor = PropertyValueColor;
                        break;
                    case XmlSyntaxElement.EndPropertyValue:
                        characterColor = PropertyValueColor;
                        xmlSyntaxElement = XmlSyntaxElement.PropertyName;
                        break;
                    case XmlSyntaxElement.PropertyName:
                        characterColor = PropertyNameColor;
                        break;
                    case XmlSyntaxElement.Comment:
                        characterColor = CommentColor;
                        break;
                    case XmlSyntaxElement.EndComment:
                        characterColor = CommentColor;
                        xmlSyntaxElement = XmlSyntaxElement.Undefined;
                        break;
                }

                if (caretLastInLine && line == _caretY && lineChar == caretX)
                {
                    _caretElement = xmlSyntaxElement;
                }

                ++lineChar;
                if (addLine)
                {
                    ++line;
                    lineChar = 0;
                    addLine = false;
                }

                if (textInfo.characterInfo[characterIndex].isVisible && syntaxHighlight)
                {
                    newVertexColors[vertexIndex + 0] = characterColor;
                    newVertexColors[vertexIndex + 1] = characterColor;
                    newVertexColors[vertexIndex + 2] = characterColor;
                    newVertexColors[vertexIndex + 3] = characterColor;
                }
            }

            // update text meshes
            if (syntaxHighlight)
            {
                XmlTextLabel.TextMeshProUGUI.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
            }

            // generate caret and selection meshes
            GenerateCaretAndSelectionMeshes();

            // TODO for debugging purposes show which element we are in
            DebugTextLabel.Text = _caretElement.ToString();
        }

        /// <summary>
        /// Generates caret and selection meshes.
        /// </summary>
        private void GenerateCaretAndSelectionMeshes()
        {
            _selectionMesh = new Mesh();
            using (var vertexHelper = new VertexHelper())
            {
                if (_hasSelection)
                {
                    UIVertex vertex = UIVertex.simpleVert;
                    vertex.uv0 = Vector2.zero;
                    vertex.color = SelectionColor;

                    var startX = -TextSelection.ActualWidth / 2;
                    var startY = TextSelection.ActualHeight / 2;

                    int startLine = Math.Min(_selectionOriginY, _selectionTargetY);
                    int endLine = Math.Max(_selectionOriginY, _selectionTargetY);
                    int startChar = startLine == endLine ? Math.Min(_selectionOriginX, _selectionTargetX) : _selectionOriginY > _selectionTargetY ? _selectionTargetX : _selectionOriginX;
                    int endChar = startLine == endLine ? Math.Max(_selectionOriginX, _selectionTargetX) : _selectionOriginY > _selectionTargetY ? _selectionOriginX : _selectionTargetX;

                    // draw selection quads for each line that the selection covers
                    for (int line = startLine; line <= endLine; ++line)
                    {
                        int startCharCount = line == startLine ? startChar : 0;
                        int endCharCount = (line == endLine ? endChar : _lines[line].Length + 1) - startCharCount;

                        // generate vertices for selection
                        Vector2 startPosition = new Vector2(startX + startCharCount * CharWidth, startY - line * LineHeight);
                        Vector2 endPosition = new Vector2(startPosition.x + endCharCount * CharWidth, startPosition.y - LineHeight);

                        // check if vertices are outside viewport and clamp position to viewport
                        float viewportWidth = ScrollableRegion.ViewportWidth;
                        float viewportHeight = ScrollableRegion.ViewportHeight;
                        var contentOffset = ScrollableRegion.GetContentOffset();
                        contentOffset.x = Math.Abs(contentOffset.x);
                        contentOffset.y = Math.Abs(contentOffset.y);

                        var startIndex = vertexHelper.currentVertCount;
                        vertex.position = new Vector3(startPosition.x, endPosition.y, 0.0f);
                        vertexHelper.AddVert(vertex);

                        vertex.position = new Vector3(endPosition.x, endPosition.y, 0.0f);
                        vertexHelper.AddVert(vertex);

                        vertex.position = new Vector3(endPosition.x, startPosition.y, 0.0f);
                        vertexHelper.AddVert(vertex);

                        vertex.position = new Vector3(startPosition.x, startPosition.y, 0.0f);
                        vertexHelper.AddVert(vertex);

                        vertexHelper.AddTriangle(startIndex, startIndex + 1, startIndex + 2);
                        vertexHelper.AddTriangle(startIndex + 2, startIndex + 3, startIndex + 0);
                    }
                }

                vertexHelper.FillMesh(_selectionMesh);
            }

            TextSelection.CanvasRendererComponent.SetMesh(_selectionMesh);
        }

        /// <summary>
        /// Makes caret visible and resets caret repeat delay. Used when caret is moved to make sure it's visible.
        /// </summary>
        public void ActivateCaret()
        {
            _caretDelayTimeElapsed = 0;
            _caretRepeatTimeElapsed = 0;
            Caret.IsActive = true;
        }

        /// <summary>
        /// Activates autocomplete box and content based on caret position. 
        /// </summary>
        private void ActivateAutoComplete()
        {
            string wordAtCaret = GetWordAtCaret(out _autoCompleteWordOriginX, out _autoCompleteWordTargetX);
            DebugTextLabel.Text = String.Format("{0}: {1}", _caretElement.ToString(), wordAtCaret);
            bool updateOptions = _lastWordAtCaret != wordAtCaret;
            _lastWordAtCaret = wordAtCaret;

            if (!_autoCompleteActive)
            {
                // auto-complete activated, populate list
                _autoCompleteOptions.Clear();
                switch (_caretElement)
                {
                    case XmlSyntaxElement.ViewName:
                    case XmlSyntaxElement.BeginViewName:
                        foreach (var view in DesignerViews)
                        {
                            _autoCompleteOptions.Add(new AutoCompleteOption { Text = view.Name });
                        }
                        break;

                    case XmlSyntaxElement.EndView:
                    case XmlSyntaxElement.EndViewName:
                    case XmlSyntaxElement.PropertyName:
                        {
                            // get property names from current view
                            var viewNameAtCaret = GetViewAtCaret();
                            var viewAtCaret = DesignerViews.FirstOrDefault(x => x.Name == viewNameAtCaret);
                            if (viewAtCaret == null)
                                break;

                            var properties = CodeGenerator.GetPropertyDeclarations(viewAtCaret.ViewObject, true, true, true).OrderBy(x => x.Declaration.PropertyName);
                            foreach (var property in properties)
                            {
                                if (property.Declaration.DeclarationType == PropertyDeclarationType.Template ||
                                    property.Declaration.DeclarationType == PropertyDeclarationType.UnityComponent ||
                                    (property.Declaration.DeclarationType == PropertyDeclarationType.View && !property.IsMapped))
                                    continue; // ignore properties not set from XML

                                _autoCompleteOptions.Add(new AutoCompleteOption { Text = property.Declaration.PropertyName });
                            }

                            // add attribute properties
                            _autoCompleteOptions.Add(new AutoCompleteOption { Text = "Id" });
                            _autoCompleteOptions.Add(new AutoCompleteOption { Text = "Style" });
                            _autoCompleteOptions.Add(new AutoCompleteOption { Text = "StateAnimations" });
                        }
                        break;

                    case XmlSyntaxElement.PropertyValue:
                    case XmlSyntaxElement.EndPropertyValue:
                        {
                            var viewNameAtCaret = GetViewAtCaret();
                            var viewAtCaret = DesignerViews.FirstOrDefault(x => x.Name == viewNameAtCaret);
                            if (viewAtCaret == null)
                                break;

                            var propertyNameAtCaret = GetPropertyAtCaret();
                            if (propertyNameAtCaret == "Style")
                            {
                                // populate with styles that can be applied to current view
                                var contentObjectModel = ContentObjectModel.GetInstance();
                                var styleNames = contentObjectModel.GetStyleNames(viewNameAtCaret);
                                foreach (var style in styleNames)
                                {
                                    _autoCompleteOptions.Add(new AutoCompleteOption { Text = style });
                                }
                                break;
                            }
                            
                            if (propertyNameAtCaret == "StateAnimations")
                            {
                                // populate with state animations
                                var contentObjectModel = ContentObjectModel.GetInstance();
                                var stateAnimationsNames = contentObjectModel.GetStateAnimationsNames(viewNameAtCaret);
                                foreach (var stateAnimationsName in stateAnimationsNames)
                                {
                                    _autoCompleteOptions.Add(new AutoCompleteOption { Text = stateAnimationsName });
                                }
                                break;
                            }

                            var property = CodeGenerator.GetPropertyDeclarations(viewAtCaret.ViewObject, true, true, true).FirstOrDefault(x => x.Declaration.PropertyName == propertyNameAtCaret);
                            if (property == null)
                                break;

                            if (property.IsAssetReference)
                            {
                                // populate depending on asset type
                                var contentObjectModel = ContentObjectModel.GetInstance();
                                var assetObjects = contentObjectModel.AssetBundleObjects.SelectMany(x => x.AssetObjects).Where(x => x.Type == property.AssetType).OrderBy(x => x.Name).ToList();
                                foreach (var assetObject in assetObjects)
                                {
                                    _autoCompleteOptions.Add(new AutoCompleteOption { Text = assetObject.Name, IsAsset = true, AssetObject = assetObject });
                                }
                            }
                            else if (property.Declaration.DeclarationType == PropertyDeclarationType.Default)
                            {
                                // see if type is an enum
                                var type = MasterConfig.GetType(property.Declaration.PropertyTypeName);
                                if (type != null && type.IsEnum)
                                {
                                    var names = Enum.GetNames(type);
                                    foreach (var name in names.OrderBy(x => x))
                                    {
                                        _autoCompleteOptions.Add(new AutoCompleteOption { Text = name });
                                    }
                                }
                            }
                        }
                        break;

                    default:
                        break;
                }

                AutoCompleteOptions.Replace(_autoCompleteOptions);
                if (AutoCompleteOptions.Any())
                {
                    AutoCompleteOptions.SelectAndScrollTo(0, ElementAlignment.Center);
                    updateOptions = true;
                }
                else
                {
                    DeactivateAutoComplete();
                    return;
                }
            }
            else
            {
                // in some cases if caret element type changes we want to deactivate autocomplete
                bool deactivateAutoComplete = false;
                switch (_caretElement)
                {
                    case XmlSyntaxElement.ViewName:
                    case XmlSyntaxElement.BeginViewName:
                        deactivateAutoComplete = _autoCompleteType != XmlSyntaxElement.ViewName &&
                            _autoCompleteType != XmlSyntaxElement.BeginViewName;
                        break;

                    case XmlSyntaxElement.EndViewName:
                    case XmlSyntaxElement.PropertyName:
                        deactivateAutoComplete = _autoCompleteType != XmlSyntaxElement.EndViewName &&
                            _autoCompleteType != XmlSyntaxElement.PropertyName;
                        break;

                    case XmlSyntaxElement.PropertyValue:
                    case XmlSyntaxElement.EndPropertyValue:
                        deactivateAutoComplete = _autoCompleteType != XmlSyntaxElement.PropertyValue &&
                            _autoCompleteType != XmlSyntaxElement.EndPropertyValue;
                        break;
                    default:
                        deactivateAutoComplete = _caretElement != _autoCompleteType;
                        break;
                }

                if (deactivateAutoComplete)
                {
                    DeactivateAutoComplete();
                    return;
                }
            }

            _autoCompleteActive = true;
            _autoCompleteType = _caretElement;

            if (!updateOptions)
                return;

            int longestOption = 0;
            var matchedStartOptions = new List<AutoCompleteOption>();
            var matchedAnyOptions = new List<AutoCompleteOption>();
            var matchedOptions = new List<AutoCompleteOption>();

            foreach (var option in _autoCompleteOptions)
            {
                if (option.MatchWithWord(wordAtCaret))
                {
                    if (option.IsMatchStart)
                    {
                        matchedStartOptions.Add(option);
                    }
                    else
                    {
                        matchedAnyOptions.Add(option);
                    }

                    int optionLength = option.Text.Length;
                    longestOption = optionLength > longestOption ? optionLength : longestOption;
                }
            }

            matchedOptions.AddRange(matchedStartOptions);
            matchedOptions.AddRange(matchedAnyOptions);
            bool hasAnyMatch = matchedOptions.Any();

            // arrange size of auto-complete box based on number of matches and the longest match in list            
            AutoCompleteBox.IsVisible = hasAnyMatch;
            if (hasAnyMatch)
            {
                int matchCount = matchedOptions.Count();
                AutoCompleteBox.Width = longestOption * CharWidth + 40;
                float height = matchCount * LineHeight;
                if (height > MaxAutoCompleteBoxHeight)
                {
                    height = MaxAutoCompleteBoxHeight;
                }

                AutoCompleteBox.Height = height;
                AutoCompleteOptionsList.Height = height;

                AutoCompleteOptions.Replace(matchedOptions);
                AutoCompleteOptions.SelectAndScrollTo(matchedOptions.First());
            }
        }

        /// <summary>
        /// Gets the view at the current caret position.
        /// </summary>
        public string GetViewAtCaret()
        {
            return GetViewAtCaret(_caretY);
        }

        /// <summary>
        /// Gets the view at the specified caret position.
        /// </summary>
        private string GetViewAtCaret(int caretY)
        {
            for (int lineIndex = caretY; lineIndex >= 0; --lineIndex)
            {
                string line = _lines[lineIndex];

                // remove everything in the line within quotes "" so we don't match elements within strings
                line = QuoteContentRegex.Replace(line, String.Empty);
                var match = ViewNameStartRegex.Match(line);
                if (match.Success)
                {
                    return match.Value;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets the property name at the current caret position.
        /// </summary>
        private string GetPropertyAtCaret()
        {
            return GetPropertyAtCaret(_caretX, _caretY);
        }

        /// <summary>
        /// Gets the property name at the specified caret position.
        /// </summary>
        private string GetPropertyAtCaret(int caretX, int caretY)
        {
            string line = _lines[caretY].Substring(0, caretX);
            int equalIndex = line.LastIndexOf('=');
            if (equalIndex < 0)
            {
                return string.Empty;
            }

            line = line.Substring(0, equalIndex);
            string lastWord = line.Split(' ', '-').LastOrDefault();
            if (String.IsNullOrEmpty(lastWord))
            {
                return string.Empty;
            }

            return lastWord;
        }

        /// <summary>
        /// Gets the word at the current caret position.
        /// </summary>
        private string GetWordAtCaret()
        {
            return GetWordAtCaret(_caretX, _caretY, out _, out _);
        }

        /// <summary>
        /// Gets the word at the current caret position.
        /// </summary>
        private string GetWordAtCaret(out int originX, out int targetX)
        {
            return GetWordAtCaret(_caretX, _caretY, out originX, out targetX);
        }

        /// <summary>
        /// Gets the word at the specified caret position.
        /// </summary>
        private string GetWordAtCaret(int caretX, int caretY, out int originX, out int targetX)
        {
            if (_lines[caretY].Length <= 0)
            {
                originX = caretX;
                targetX = caretX;
                return string.Empty;
            }

            originX = caretX - 1;
            targetX = caretX;

            if (originX < 0)
                originX = 0;

            // get characters to the left and right of caret that are digits or letters
            Func<char, bool> selectChar = c => Char.IsLetterOrDigit(c); // select letters and digits by default
            while (targetX < _lines[caretY].Length)
            {
                if (!selectChar(_lines[caretY][targetX]))
                {
                    break;
                }

                ++targetX;
            }

            while (originX >= 0)
            {
                if (!selectChar(_lines[caretY][originX]))
                {
                    originX = originX == _lines[caretY].Length - 1 ? originX : originX + 1;
                    break;
                }

                --originX;
            }

            if (originX < 0)
                originX = 0;

            int length = targetX - originX;
            bool wordAtCaret = length == 1 ? selectChar(_lines[caretY][originX]) : length > 0;
            if (wordAtCaret)
            {
                return _lines[caretY].Substring(originX, length);
            }
            else
            {
                originX = targetX;
                return string.Empty;
            }
        }

        /// <summary>
        /// Hides autocomplete box.
        /// </summary>
        private void DeactivateAutoComplete()
        {
            _autoCompleteActive = false;
            _autoCompleteType = XmlSyntaxElement.Undefined;
            AutoCompleteBox.IsVisible = false;
        }

        /// <summary>
        /// Called when option is selected in the autocomplete box.
        /// </summary>
        public void AutoCompleteOptionSelected(AutoCompleteOption option)
        {
            FinishAutoComplete();
            OnTextOrCaretChanged(true, false, true);
        }

        /// <summary>
        /// Auto-completes the current text. 
        /// </summary>
        private bool FinishAutoComplete()
        {
            if (IsReadOnly)
                return false;

            var option = SelectedAutoCompleteOption;
            var autoCompleteType = _autoCompleteType;
            DeactivateAutoComplete();

            if (autoCompleteType == XmlSyntaxElement.PropertyName || autoCompleteType == XmlSyntaxElement.EndViewName)
            {
                // when completing property name add ="" to the end and activate auto-complete for property values
                _lines[_caretY] = _lines[_caretY].Substring(0, _autoCompleteWordOriginX) + option.Text + "=\"\"" + _lines[_caretY].Substring(_autoCompleteWordTargetX);
                _caretX = _autoCompleteWordOriginX + option.Text.Length + 2;
                _autoCompleteType = XmlSyntaxElement.PropertyValue;
                _caretElement = XmlSyntaxElement.PropertyValue;
                ActivateAutoComplete();
                return true;
            }
            else
            {
                _lines[_caretY] = _lines[_caretY].Substring(0, _autoCompleteWordOriginX) + option.Text + _lines[_caretY].Substring(_autoCompleteWordTargetX);
                _caretX = _autoCompleteWordOriginX + option.Text.Length;
                return false;
            }
        }

        /// <summary>
        /// Selects auto-complete item template based on option type.
        /// </summary>
        public string AutoCompleteOptionSelector(AutoCompleteOption option)
        {
            return option.IsAsset ? "AssetOptionItem" : "DefaultOptionItem";
        }

        /// <summary>
        /// Gets property documentation for specified element.
        /// </summary>
        private string GetElementDoc(string viewName, string propertyName = null)
        {
            var config = MasterConfig.GetInstance();
            var docObject = config.DocObjects.FirstOrDefault(x => x.Name == viewName);
            if (docObject == null)
            {
                if (propertyName == null)
                {
                    return string.Empty;
                }
                else
                {
                    var basedOnView = DesignerViews.FirstOrDefault(x => x.Name == viewName)?.ViewObject?.BasedOn;
                    return basedOnView != null ? GetElementDoc(basedOnView.Name, propertyName) : null;
                }
            }

            if (propertyName == null)
                return docObject.Comment;

            var docProperty = docObject.Properties.FirstOrDefault(x => x.Name == propertyName);
            if (docProperty == null)
            {
                // check if property resides in parent view
                var basedOnView = DesignerViews.FirstOrDefault(x => x.Name == viewName)?.ViewObject?.BasedOn;
                if (basedOnView == null)
                    return string.Empty;

                return GetElementDoc(basedOnView.Name, propertyName);
            }

            return docProperty.Comment;
        }

        #endregion
    }
}

#endif