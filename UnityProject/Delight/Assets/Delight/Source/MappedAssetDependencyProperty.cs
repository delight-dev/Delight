#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
#endregion

namespace Delight
{   
    /// <summary>
    /// Dependency property that maps to a unity component asset. E.g. ImageComponent.sprite
    /// </summary>
    public class MappedAssetDependencyProperty<T, TComponent, TParent> : DependencyProperty<T>
        where TParent : DependencyObject
        where T : AssetObject
    {
        #region Fields

        public Func<TParent, TComponent> ComponentGetter;
        public Action<TComponent, T> Setter;

        #endregion

        #region Methods

        /// <summary>
        /// Called when asset has been changed. 
        /// </summary>
        public override void OnAssetChanged(DependencyObject key)
        {
            base.OnAssetChanged(key);

            var target = ComponentGetter((TParent)key);
            if (target == null)
                return;

            Setter(target, GetValue(key));
        }

        #endregion        

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public MappedAssetDependencyProperty(string propertyName, Func<TParent, TComponent> objectGetter, Action<TComponent, T> setter)
            : base(propertyName)
        {
            Setter = setter;
            ComponentGetter = objectGetter;
        }

        #endregion
    }
}
