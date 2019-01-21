#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Base class for dependency objects.
    /// </summary>
    public class DependencyObject : BindableObject
    {
        #region Fields
        
        protected Template _template;
        protected static Dictionary<Template, List<DependencyProperty>> DependencyProperties = new Dictionary<Template, List<DependencyProperty>>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets dependency object data template.
        /// </summary>
        public Template Template
        {
            get
            {
                return _template;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when a property has been changed. 
        /// </summary>
        public virtual void OnPropertyChanged(object source, string property)
        {
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public DependencyObject() : this(null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public DependencyObject(string id = null, Template template = null)
        {            
            Id = id ?? Guid.NewGuid().ToString();
            _template = template;
            PropertyChanged += OnPropertyChanged;
        }

        #endregion
    }
}
