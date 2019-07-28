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
#endregion

namespace Delight
{
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
        private Mesh _selectionMesh = new Mesh();
        private int _selectionOriginX;
        private int _selectionOriginY;
        private int _selectionTargetX;
        private int _selectionTargetY;
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
            if (property == nameof(XmlText))
            {
                ClearEditor();
                if (XmlText != null)
                {
                    _lines = new List<string>(XmlText.GetLines());
                }
                OnEditorChanged();
            }
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

            bool ctrlDown = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
            bool scrollEngaged = ctrlDown || Input.GetMouseButton(2);
            bool mouseButtonDown = false;
            bool shiftDown = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
            ScrollableRegion.ScrollEnabled = scrollEngaged;

            if (Input.GetMouseButtonDown(0))
            {
                if (!ContainsMouse(Input.mousePosition))
                {
                    // user has clicked outside the editor - deselect and deactivate caret
                    IsFocused = false;
                    _hasSelection = false;
                    Caret.IsActive = false;
                    _clickedInsideEditor = false;
                    GenerateCaretAndSelectionMeshes();
                }
                else
                {
                    IsFocused = true;
                    _clickedInsideEditor = true;
                    mouseButtonDown = true;
                    _mouseDownPosition = Input.mousePosition;

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

            if ((mouseButtonDown && shiftDown) || (Input.GetMouseButton(0) && _clickedInsideEditor && !scrollEngaged && !mouseButtonDown)) 
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

            if (inputString.Length <= 0)
                return;

            var shiftDown = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
            bool updateDesiredCaretX = true;
            for (int i = 0; i < inputString.Length; ++i)
            {
                char c = inputString[i];
                //Debug.Log((int)c);

                switch ((KeyCode)c)
                {
                    case KeyCode.Space:
                    case KeyCode.Less:
                        textChanged = true;
                        if (_hasSelection)
                        {
                            DeleteSelection();
                        }
                        _lines[_caretY] = _lines[_caretY].InsertOrAdd(_caretX, c.ToString());
                        ++_caretX;
                        break;

                    case KeyCode.KeypadEnter:
                    case KeyCode.Return:
                        textChanged = true;
                        if (_hasSelection)
                        {
                            DeleteSelection();
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
                                    _lines.InsertOrAdd(_caretY + 1, String.Format("{0}</{1}>", spacesStr, viewName));
                                    addIndentation = true;
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
                        textChanged = true;
                        if (_hasSelection)
                        {
                            DeleteSelection();
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
                        break;

                    case KeyCode.Tab:
                        textChanged = true;
                        if (_hasSelection)
                        {
                            DeleteSelection();
                        }
                        _lines[_caretY] = _lines[_caretY].InsertOrAdd(_caretX, new string(' ', SpacesPerTab));
                        _caretX += SpacesPerTab;
                        break;

                    case KeyCode.Delete:
                        textChanged = true;
                        if (_hasSelection)
                        {
                            DeleteSelection();
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
                        break;

                    case KeyCode.LeftArrow:
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
                            if (!_hasSelection)
                            {
                                // set origin of selection
                                _selectionOriginX = _caretX;
                                _selectionOriginY = _caretY;
                                _selectionTargetX = _selectionOriginX;
                                _selectionTargetY = _selectionOriginY;
                            }
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
                            if (!_hasSelection)
                            {
                                // set origin of selection
                                _selectionOriginX = _caretX;
                                _selectionOriginY = _caretY;
                                _selectionTargetX = _selectionOriginX;
                                _selectionTargetY = _selectionOriginY;
                            }
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
                        textChanged = true;
                        if (_hasSelection)
                        {
                            DeleteSelection();
                        }

                        // add ="" if caret isn't in a property value or comment
                        _lines[_caretY] = _lines[_caretY].InsertOrAdd(_caretX, c + "\"\"");
                        _caretX = _caretX + 2;
                        break;

                    case KeyCode.PageDown:
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

                    case KeyCode.PageUp:
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
                        textChanged = true;
                        if (_hasSelection)
                        {
                            DeleteSelection();
                        }

                        string str = c.ToString();
                        if (_caretElement == XmlSyntaxElement.Undefined)
                        {
                            str = "<" + str;
                        }
                        _lines[_caretY] = _lines[_caretY].InsertOrAdd(_caretX, str);
                        _caretX += str.Length;
                        break;
                }

                if (updateDesiredCaretX)
                {
                    // update desired caret unless up/down arrows have been pressed
                    _desiredCaretX = _caretX;
                }
            }
            
            ActivateCaret();
            OnEditorChanged();

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

            if (textChanged)
            {
                // trigger edit invent unless only arrow keys has been pressed
                Edit.Invoke(this, null);
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

            // key has been pressed in previous frame
            if (_trackKeyDown != KeyCode.None)
            {
                _trackKeyDown = KeyCode.None;
                _keyDownDelayTimeElapsed = 0;
                _keyDownRepeatTimeElapsed = 0;
            }

            // CTRL+V - paste
            if (Input.GetKeyDown(KeyCode.V))
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

            if (updateText)
            {
                OnEditorChanged();
            }
        }

        /// <summary>
        /// Called after the view has been loaded.
        /// </summary>
        protected override void AfterLoad()
        {
            base.AfterLoad();
            XmlTextLabel.GameObject.AddComponent<TMPro.Examples.TMP_TextInfoDebugTool>(); // TODO remove after debugging
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
                        xmlSyntaxElement = XmlSyntaxElement.PropertyName;
                        break;
                    case '\n':
                        addLine = true;
                        break;
                    case '\r':
                        lineChar = 0;
                        break;
                    default:
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
            //CaretElement.Text = _caretElement.ToString();
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

        #endregion
    }
}

#endif