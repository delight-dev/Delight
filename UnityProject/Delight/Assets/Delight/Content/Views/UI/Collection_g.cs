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
    public partial class Collection : UIImageView
    {
        #region Constructors

        public Collection(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? CollectionTemplates.Default, initializer)
        {
            this.AfterInitializeInternal();
        }

        public Collection() : this(null)
        {
        }

        static Collection()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(CollectionTemplates.Default, dependencyProperties);

            dependencyProperties.Add(ItemsProperty);
            dependencyProperties.Add(TemplateSelectorProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<Delight.BindableCollection> ItemsProperty = new DependencyProperty<Delight.BindableCollection>("Items");
        public Delight.BindableCollection Items
        {
            get { return ItemsProperty.GetValue(this); }
            set { ItemsProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ViewMethod> TemplateSelectorProperty = new DependencyProperty<ViewMethod>("TemplateSelector", () => new ViewMethod());
        public ViewMethod TemplateSelector
        {
            get { return TemplateSelectorProperty.GetValue(this); }
            set { TemplateSelectorProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class CollectionTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return Collection;
            }
        }

        private static Template _collection;
        public static Template Collection
        {
            get
            {
#if UNITY_EDITOR
                if (_collection == null || _collection.CurrentVersion != Template.Version)
#else
                if (_collection == null)
#endif
                {
                    _collection = new Template(UIImageViewTemplates.UIImageView);
#if UNITY_EDITOR
                    _collection.Name = "Collection";
#endif
                }
                return _collection;
            }
        }

        #endregion
    }

    #endregion
}
