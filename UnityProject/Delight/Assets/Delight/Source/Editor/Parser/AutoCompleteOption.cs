#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    /// <summary>
    /// Contains information about an auto-complete option.
    /// </summary>
    public class AutoCompleteOption : BindableObject
    {
        private string _text;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        private string _displayText;
        public string DisplayText
        {
            get { return !String.IsNullOrEmpty(_displayText) ? _displayText : _text; }
            set { SetProperty(ref _displayText, value); }
        }

        private bool _isMatch = true;
        public bool IsMatch
        {
            get { return _isMatch; }
            set { SetProperty(ref _isMatch, value); }
        }

        private bool _isMatchStart = true;
        public bool IsMatchStart
        {
            get { return _isMatchStart; }
            set { SetProperty(ref _isMatchStart, value); }
        }

        /// <summary>
        /// Matches option with word and updates display text.
        /// </summary>
        public bool MatchWithWord(string word)
        {
            if (String.IsNullOrEmpty(word))
            {
                DisplayText = _text;
                IsMatch = true;
                IsMatchStart = true;
                return true;
            }

            // updates display text based on word being typed
            if (_text.ToLower().StartsWith(word.ToLower()))
            {
                // show the auto-complete part in bold 
                DisplayText = String.Format("{0}<b><color=\"black\">{1}</color></b>", _text.Substring(0, word.Length), _text.Substring(word.Length));
                IsMatch = true;
                IsMatchStart = true;
                return true;
            }

            int matchIndex = _text.ToLower().IndexOf(word.ToLower());
            if (matchIndex >= 0)
            {
                string s1 = _text.Substring(0, matchIndex);
                string s2 = _text.Substring(matchIndex, word.Length);
                string s3 = _text.Substring(matchIndex + word.Length);

                IsMatch = true;
                IsMatchStart = false;
                DisplayText = String.Format("{0}<b><color=\"black\">{1}</color></b>{2}", s1, s2, s3);
                return true;
            }

            DisplayText = _text;
            IsMatch = false;
            IsMatchStart = false;
            return false;
        }
    }

    /// <summary>
    /// AutoCompleteOption collection.
    /// </summary>
    public class AutoCompleteOptionData : BindableCollection<AutoCompleteOption>
    {
    }
}
