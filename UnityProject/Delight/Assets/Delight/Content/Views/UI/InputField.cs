#if !DELIGHT_MODULE_TEXTMESHPRO

// Internal view logic generated from "InputField.xml"
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
    /// Interactable input field enabling user to type single or multi-line text.
    /// </summary>
    public partial class InputField
    {
        #region Methods

        /// <summary>
        /// Called when a property has been changed. 
        /// </summary>
        public override void OnChanged(string property)
        {
            base.OnChanged(property);
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

            InputFieldComponent = GameObject.AddComponent<UnityEngine.UI.InputField>();
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
            InputFieldComponent.textComponent = InputText.TextComponent;
            InputFieldComponent.placeholder = InputFieldPlaceholder.ImageComponent;
            InputFieldComponent.transition = Selectable.Transition.None;
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
            InputFieldComponent.onEndEdit.RemoveAllListeners();
            InputFieldComponent.onEndEdit.AddListener(InputFieldEndEdit);

            InputFieldComponent.onValueChanged.RemoveAllListeners();
            InputFieldComponent.onValueChanged.AddListener(InputFieldValueChanged);
             
            // set initial text
            TextChanged();
        }

        /// <summary>
        /// Called when the input text is changed.
        /// </summary>
        public void TextChanged()
        {
            if (OnlyTriggerValueChangedFromUI)
            {
                InputFieldComponent.onValueChanged.RemoveAllListeners();
            }

            if (OnlyTriggerValueChangedFromUI)
            {
                InputFieldComponent.onValueChanged.AddListener(InputFieldValueChanged);
                UpdatePlaceholder();
            }
        }

        /// <summary>
        /// Called on input field end edit.
        /// </summary>
        public void InputFieldEndEdit(string value)
        {
            if (SetValueOnEndEdit)
            {
                TextChanged();

                // notify text property has been changed
                OnPropertyChanged("Text");
            }

            UpdatePlaceholder();
            EndEdit?.Invoke(this, null);
        }

        /// <summary>
        /// Called when input field value has been updated.
        /// </summary>
        public void InputFieldValueChanged(string value)
        {
            if (!SetValueOnEndEdit)
            {
                TextChanged();

                // notify text property has been changed
                OnPropertyChanged("Text");                
            }

            UpdatePlaceholder();
            ValueChanged?.Invoke(this, null);
        }

        /// <summary>
        /// Shows or hides placeholder based on text.
        /// </summary>
        private void UpdatePlaceholder()
        {
            if (String.IsNullOrEmpty(InputFieldComponent.text))
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
