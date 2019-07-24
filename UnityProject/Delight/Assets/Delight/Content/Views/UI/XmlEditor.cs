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

        public static float CharLength = 10;
        public static float LineHeight = 20.98f;
        public static int SpacesPerTab = 2;
        public static float XmlTextMarginLeft = 20;
        public static float XmlTextMarginRight = 20;
        public static Color32 PropertyNameColor = new Color32(255, 72, 121, 255); // #ff4879
        public static Color32 PropertyValueColor = new Color32(59, 155, 255, 255); // #3b9bff
        public static Color32 ViewNameColor = new Color32(74, 80, 78, 255); // #4a504e
        public static Color32 CommentColor = new Color32(0, 212, 0, 255); // #00d400
        public static Color32 UndefinedColor = new Color32(255, 0, 0, 255);
        public static float KeyRepeatDelay = 0.30f;
        public static float KeyRepeatRate = 0.05f;

        private List<string> _lines = new List<string>();
        private int _caretX;
        private int _caretY;
        private int _desiredCaretX;
        private XmlSyntaxElement _caretElement = XmlSyntaxElement.Undefined;
        private KeyCode _trackKeyDown = KeyCode.None;
        private float _keyDownDelayTimeElapsed;
        private float _keyDownRepeatTimeElapsed;

        #endregion

        #region Methods

        public override void OnChanged(string property)
        {
            base.OnChanged(property);
            if (property == nameof(XmlText))
            {
                //OnXmlTextChanged();
            }
        }

        public override void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!ContainsMouse(Input.mousePosition))
                {
                    IsFocused = false;
                }
                else
                {
                    IsFocused = true;

                    // set text indicator
                }
            }

            if (Input.anyKey)
            {
                bool ctrlDown = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
                if (ctrlDown)
                {
                    // handle control commands
                    HandleControlInput();
                }
                else
                {
                    HandleKeyInput();
                }
            }
        }

        private void HandleKeyInput()
        {
            var inputString = Input.inputString;

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

            if (inputString.Length <= 0)
                return;

            bool updateDesiredCaretX = true;
            for (int i = 0; i < inputString.Length; ++i)
            {
                char c = inputString[i];
                Debug.Log((int)c);

                switch ((KeyCode)c)
                {
                    case KeyCode.Space:
                    case KeyCode.Less:
                        _lines[_caretY] = _lines[_caretY].InsertOrAdd(_caretX, c.ToString());
                        ++_caretX;
                        break;

                    case KeyCode.KeypadEnter:
                    case KeyCode.Return:
                        // TODO handle autocomplete logic and things like insertion of XML tags

                        // split the current line at caret position and add a new line with the new content
                        if (_caretX <= 0)
                        {
                            _lines.Insert(_caretY, string.Empty);
                        }
                        else if (_caretX >= _lines[_caretY].Length)
                        {
                            _lines.InsertOrAdd(_caretY + 1, string.Empty);
                        }
                        else
                        {
                            var rightStr = _lines[_caretY].Substring(_caretX);
                            var leftStr = _lines[_caretY].Substring(0, _caretX);
                            _lines[_caretY] = leftStr;
                            _lines.InsertOrAdd(_caretY + 1, rightStr);
                        }
                        ++_caretY;
                        _caretX = 0;
                        break;

                    case KeyCode.Backspace: // backspace
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
                        _lines[_caretY] = _lines[_caretY].InsertOrAdd(_caretX, new string(' ', SpacesPerTab));
                        _caretX += SpacesPerTab;
                        break;

                    case KeyCode.LeftArrow:
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
                        break;

                    case KeyCode.RightArrow:
                        if (_caretX < _lines[_caretY].Length)
                        {
                            ++_caretX;
                            break;
                        }
                        else if (_caretY < _lines.Count - 1)
                        {
                            // move to beginning of next line
                            _caretX = 0;
                            ++_caretY;
                        }
                        break;

                    case KeyCode.Delete:
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

                    case KeyCode.UpArrow:
                        updateDesiredCaretX = false;
                        if (_caretY > 0)
                        {
                            --_caretY;
                            _caretX = _desiredCaretX >= _lines[_caretY].Length ? _lines[_caretY].Length : _desiredCaretX;
                        }
                        break;

                    case KeyCode.DownArrow:
                        updateDesiredCaretX = false;
                        if (_caretY < _lines.Count - 1)
                        {
                            ++_caretY;
                            _caretX = _desiredCaretX >= _lines[_caretY].Length ? _lines[_caretY].Length : _desiredCaretX;
                        }
                        break;

                    case KeyCode.Home:
                        var nonSpaceIndex = _lines[_caretY].IndexOf(x => x != ' ');
                        if (nonSpaceIndex < 0)
                            nonSpaceIndex = 0;

                        _caretX = _caretX == nonSpaceIndex ? 0 : nonSpaceIndex;
                        break;

                    case KeyCode.End:
                        _caretX = _lines[_caretY].Length;
                        break;

                    case KeyCode.KeypadEquals:
                    case KeyCode.Equals:
                        // add ="" if caret isn't in a property value or comment
                        _lines[_caretY] = _lines[_caretY].InsertOrAdd(_caretX, c + "\"\"");
                        _caretX = _caretX + 2;
                        break;


                    // TODO implement shift + arrows/home/end for selection
                    // TODO implement scrolling to caret/line if it's outside viewport

                    default:
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

            OnXmlTextChanged();
        }

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

            if (Input.GetKeyDown(KeyCode.V))
            {
                var pasteText = GUIUtility.systemCopyBuffer;
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

            if (updateText)
            {
                OnXmlTextChanged();
            }
        }

        protected override void AfterLoad()
        {
            base.AfterLoad();
            XmlTextLabel.GameObject.AddComponent<TMPro.Examples.TMP_TextInfoDebugTool>();

            _caretX = 0;
            _caretY = 0;
            _lines.Clear();
            _lines.Add(string.Empty);
            XmlText = "";

            // TODO when parsing XML replace tabs with (2) spaces
            OnXmlTextChanged();
        }

        private void OnXmlTextChanged()
        {
            string xmlText = String.Join(Environment.NewLine, _lines);
            XmlTextLabel.TextMeshProUGUI.text = xmlText;

            XmlTextLabel.TextMeshProUGUI.ForceMeshUpdate();
            TMP_TextInfo textInfo = XmlTextLabel.TextMeshProUGUI.textInfo;
            var textBounds = XmlTextLabel.TextMeshProUGUI.textBounds;

            // set size and text of line numbers
            var maxLineNumberCharCount = _lines.Count().ToString().Length;
            LineNumbersLabel.Width = CharLength * maxLineNumberCharCount;
            LineNumbersLabel.Height = _lines.Count() * LineHeight;
            LineNumbersLabel.Text = String.Join(Environment.NewLine, Enumerable.Range(1, _lines.Count()).Select(x => x.ToString()));

            // set size and margins of XML edit and text region
            var maxLineLength = _lines.Max(x => x.Length);
            float labelWidth = maxLineLength * CharLength;
            float labelHeight = _lines.Count() * LineHeight;
            XmlEditRegion.Width = labelWidth + LineNumbersLabel.Width + XmlTextMarginLeft + XmlTextMarginRight;
            XmlEditRegion.Height = labelHeight;
            XmlTextRegion.Margin.Left = LineNumbersLabel.Width + CharLength;


            // position caret indicator
            if (Caret.OffsetFromParent == null)
                Caret.OffsetFromParent = new ElementMargin();
            Caret.OffsetFromParent.Left = CharLength * _caretX;
            Caret.OffsetFromParent.Top = LineHeight * _caretY;

            SyntaxHighlightXml();
        }

        /// <summary>
        /// Syntax highlights the text. 
        /// </summary>
        private void SyntaxHighlightXml()
        {
            _caretElement = XmlSyntaxElement.Undefined;
            string xmlText = XmlTextLabel.TextMeshProUGUI.text;
            if (String.IsNullOrEmpty(xmlText))
                return;

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

                if (textInfo.characterInfo[characterIndex].isVisible)
                {
                    newVertexColors[vertexIndex + 0] = characterColor;
                    newVertexColors[vertexIndex + 1] = characterColor;
                    newVertexColors[vertexIndex + 2] = characterColor;
                    newVertexColors[vertexIndex + 3] = characterColor;
                }
            }

            // update text meshes
            XmlTextLabel.TextMeshProUGUI.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);

            // TODO for debugging purposes show which element we are in
            CaretElement.Text = _caretElement.ToString();
        }

        #endregion
    }
}

#endif