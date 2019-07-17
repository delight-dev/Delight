#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Base class for dependency objects. Dependency objects contains the information about the object that dependency properties need.
    /// </summary>
    public class DependencyObject : BindableObject
    {
        #region Fields

        public static string DefaultStateName = String.Empty;
        public static string AnyStateName = "Any";

        protected Template _template;
        protected static Dictionary<Template, List<DependencyProperty>> DependencyProperties = new Dictionary<Template, List<DependencyProperty>>();
        protected static Dictionary<Template, List<DependencyProperty>> StateChangingProperties = new Dictionary<Template, List<DependencyProperty>>();
        protected string _state;
        protected string _previousState;

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

        /// <summary>
        /// Gets dependency object state.
        /// </summary>
        public string State
        {
            get
            {
                return _state;
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
