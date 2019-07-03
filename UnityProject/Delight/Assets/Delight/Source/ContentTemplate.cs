#region Using Statements
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Content template.
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
