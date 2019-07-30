#region Using Statements
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Generic base class for data providers. Provides access to bindable objects of a certain type.
    /// </summary>
    public abstract class DataProvider<T> : BindableCollection<T>
        where T : BindableObject
    {
        #region Fields

        public PersistenceManager<T> PersistenceManager;

        #endregion

        #region Methods

        /// <summary>
        /// Loads persisted objects.
        /// </summary>
        public void Load(string segmentId = null)
        {
            var loadedObjects = PersistenceManager.Load(segmentId);
            AddRange(loadedObjects);
        }

        /// <summary>
        /// Saves objects to be persisted.
        /// </summary>
        public void Save(string segmentId = null)
        {
            PersistenceManager.Save(this);
        }

        #endregion
    }

    /// <summary>
    /// Persists objects between sessions. 
    /// </summary>
    public class PersistenceManager<T>
        where T : BindableObject
    {
        /// <summary>
        /// Loads persisted objects.
        /// </summary>
        public virtual IEnumerable<T> Load(string segmentId = null)
        {
            return null;
        }

        /// <summary>
        /// Saves objects to be persisted.
        /// </summary>
        public virtual void Save(IEnumerable<T> objects, string segmentId = null)
        {
        }
    }
}
