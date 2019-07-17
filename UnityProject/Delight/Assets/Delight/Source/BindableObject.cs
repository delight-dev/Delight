#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Base class for bindable objects. Bindable objects notifies observers when their properties changes which allows for values to be propagated and bindings and UI to update as data changes. 
    /// </summary>
    public class BindableObject : INotifyPropertyChanged
    {
        #region Fields

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        private string _id;
        public string Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class. 
        /// </summary>
        public BindableObject()
        {
            _id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Initializes a new instance of the class. 
        /// </summary>
        public BindableObject(string id)
        {
            _id = String.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets property and notifies listeners if value has been changed.
        /// </summary>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Notifies listeners that a property has been changed.
        /// </summary>
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, propertyName);
        }

        #endregion
    }
}
