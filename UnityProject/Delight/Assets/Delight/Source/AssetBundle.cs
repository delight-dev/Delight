#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
#endregion

namespace Delight
{
    public class AssetBundle : BindableObject
    {
        public StorageMode StorageMode { get; set; }
    }

    public partial class AssetBundles : BindableCollection<AssetBundle>
    {
        public readonly AssetBundle Bundle1;
        public readonly AssetBundle Bundle2;

        public AssetBundles()
        {
            Bundle1 = new AssetBundle { Id = "Bundle1", StorageMode = StorageMode.Server };
            Bundle2 = new AssetBundle { Id = "Bundle2", StorageMode = StorageMode.Server };

            Add(Bundle1);
            Add(Bundle2);
        }
    }

    public static partial class Assets
    {
        public static AssetBundles AssetBundles = new AssetBundles();
    }
}
