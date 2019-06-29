#if DELIGHT_MODULE_TEXTMESHPRO

#region Using Statements
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    /// <summary>
    /// Input field view.
    /// </summary>
    public partial class InputField
    {
        #region Methods

        /// <summary>
        /// Called when a property has been changed. 
        /// </summary>
        public override void OnPropertyChanged(object source, string property)
        {
            if (IgnoreObject)
                return;

            base.OnPropertyChanged(source, property);
            switch (property)
            {
                case nameof(Text):
                    TextChanged();
                    break;
            }
        }

        /// <summary>
        /// Called before the view is loaded.
        /// </summary>
        protected override void BeforeLoad()
        {
            if (IgnoreObject)
                return;
            base.BeforeLoad();

            TMP_InputFieldComponent = GameObject.AddComponent<TMPro.TMP_InputField>();
        }

        /// <summary>
        /// Called just after the children are loaded, but before dependency properties are loaded.
        /// </summary>
        protected override void AfterChildrenLoaded()
        {
            if (IgnoreObject)
                return;
            base.AfterChildrenLoaded();

            // set default values
            //TMP_InputFieldComponent.textComponent = InputText.TextMeshProUGUI; // TODO fix
            TMP_InputFieldComponent.textViewport = TextArea.RectTransform;
            TMP_InputFieldComponent.placeholder = InputFieldPlaceholder.ImageComponent;
            TMP_InputFieldComponent.transition = Selectable.Transition.None;
        }

        /// <summary>
        /// Called after the view is loaded.
        /// </summary>
        protected override void AfterLoad()
        {
            if (IgnoreObject)
                return;
            base.AfterLoad();
            
            // hook up input field event system triggers
            TMP_InputFieldComponent.onEndEdit.RemoveAllListeners();
            TMP_InputFieldComponent.onEndEdit.AddListener(TMProInputFieldEndEdit);

            TMP_InputFieldComponent.onValueChanged.RemoveAllListeners();
            TMP_InputFieldComponent.onValueChanged.AddListener(TMProInputFieldValueChanged);

            // set initial text
            TextChanged();

            // workaround for textmeshpro issue where caret was not being spawned
            typeof(TMP_InputField).GetMethod("OnEnable", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(TMP_InputFieldComponent, null);
        }

        /// <summary>
        /// Called when the input text is changed.
        /// </summary>
        public void TextChanged()
        {
            if (OnlyTriggerValueChangedFromUI)
            {
                TMP_InputFieldComponent.onValueChanged.RemoveAllListeners();
            }

            TMP_InputFieldComponent.text = Text ?? String.Empty;
            
            if (OnlyTriggerValueChangedFromUI)
            {
                TMP_InputFieldComponent.onValueChanged.AddListener(TMProInputFieldValueChanged);
                TMProUpdatePlaceholder();
            }
        }

        /// <summary>
        /// Called on input field end edit.
        /// </summary>
        public void TMProInputFieldEndEdit(string value)
        {
            if (SetValueOnEndEdit)
            {
                TextChanged();
            }

            TMProUpdatePlaceholder();
            EndEdit?.Invoke(this, null);
        }

        /// <summary>
        /// Called when input field value has been updated.
        /// </summary>
        public void TMProInputFieldValueChanged(string value)
        {
            if (!SetValueOnEndEdit)
            {
                TextChanged();
            }

            TMProUpdatePlaceholder();
            ValueChanged?.Invoke(this, null);
        }

        /// <summary>
        /// Shows or hides placeholder based on text.
        /// </summary>
        private void TMProUpdatePlaceholder()
        {
            if (String.IsNullOrEmpty(TMP_InputFieldComponent.text))
            {
                InputFieldPlaceholder.IsActive = true;
            }
            else
            {
                InputFieldPlaceholder.IsActive = false;
            }
        }

        #endregion
    }
}

#endif
