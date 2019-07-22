// add module "TextMeshPro" to Config.txt to enable TextMeshPro integration
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
    /// Interactable input field view enabling user to type single or multi-line text. Based on TextMeshPro input field component. 
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
            TMP_InputFieldComponent.textComponent = InputText.TextMeshProUGUI;
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

            // fix textmeshpro issue with word wrapping being reset for some reason
            if (!EnableWordWrappingProperty.IsUndefined(InputText))
            {
                EnableWordWrappingProperty.Load(InputText);
            }

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

                // notify text property has been changed
                OnPropertyChanged("Text");  
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

                // notify text property has been changed
                OnPropertyChanged("Text");  
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