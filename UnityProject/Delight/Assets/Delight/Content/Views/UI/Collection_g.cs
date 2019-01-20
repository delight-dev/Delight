// Internal view logic generated from "Collection.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class CollectionView : UIImageView
    {
        #region Constructors

        public CollectionView(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? CollectionViewTemplates.Default, initializer)
        {
        }

        public CollectionView() : this(null)
        {
        }

        static CollectionView()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(CollectionViewTemplates.Default, dependencyProperties);
        }

        #endregion

        #region Properties

        #endregion
    }

    #region Data Templates

    public static class CollectionViewTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return CollectionView;
            }
        }

        private static Template _collectionView;
        public static Template CollectionView
        {
            get
            {
#if UNITY_EDITOR
                if (_collectionView == null || _collectionView.CurrentVersion != Template.Version)
#else
                if (_collectionView == null)
#endif
                {
                    _collectionView = new Template(UIImageViewTemplates.UIImageView);
                }
                return _collectionView;
            }
        }

        #endregion
    }

    #endregion
}
