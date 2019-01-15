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
    public class DependencyObject //: BindableObject
    {
        #region Fields
        
        private string _id;
        protected Template _template;
        protected static Dictionary<Template, List<DependencyProperty>> DependencyProperties = new Dictionary<Template, List<DependencyProperty>>();

        public delegate void PropertyChangedEventHandler(DependencyObject source, DependencyProperty property);
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets dependency object ID.
        /// </summary>
        public string Id
        {
            get
            {
                return _id;
            }
        }

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
        /// Triggers a property changed event. 
        /// </summary>
        public void NotifyPropertyChanged(DependencyObject source, DependencyProperty propertyChanged)
        {
            PropertyChanged(source, propertyChanged);
        }

        /// <summary>
        /// Called when a property has been changed. 
        /// </summary>
        public virtual void OnPropertyChanged(DependencyObject source, DependencyProperty property)
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
            _id = id ?? Guid.NewGuid().ToString();
            _template = template;
            PropertyChanged += OnPropertyChanged;
        }

        #endregion
    }
}
