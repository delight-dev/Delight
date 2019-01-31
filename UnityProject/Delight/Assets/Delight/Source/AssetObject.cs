#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Base class for unity asset objects.
    /// </summary>
    public class AssetObject : BindableObject
    {
        public string AssetBundleId { get; set; }
        public AssetBundle AssetBundle
        {
            get { return Assets.AssetBundles[AssetBundleId]; }
            set { AssetBundleId = value?.Id; }
        }
    }

    /// <summary>
    /// Base class for unity asset objects.
    /// </summary>
    public class AssetObject<T> : AssetObject
        where T : UnityEngine.Object
    {
        #region Properties

        public T Object
        {
            get { return null; }
        }

        #endregion

        #region Methods
        #endregion
    }
}
