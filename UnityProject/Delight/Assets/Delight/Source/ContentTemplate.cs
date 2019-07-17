#region Using Statements
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Represent a content template. Contains an activator used to instantiate the template. Created in generated code-behind for certain views such as the List view if it has content, which is then used to create dynamic list items.
    /// </summary>
    public class ContentTemplate : BindableObject
    {
        #region Fields

        private Type _templateType;
        public Type TemplateType { get => _templateType; set => SetProperty(ref _templateType, value); }

        private Func<ContentTemplateData, View> _activator;
        public Func<ContentTemplateData, View> Activator { get => _activator; set => SetProperty(ref _activator, value); }

        #endregion

        #region Constructors

        public ContentTemplate(Func<ContentTemplateData, View> activator)
        {
            _activator = activator;
        }

        public ContentTemplate(Func<ContentTemplateData, View> activator, Type templateType, string id)
            : base(id)
        {
            _activator = activator;
            _templateType = templateType;
        }

        #endregion
    }
}
