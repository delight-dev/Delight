#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class Image
    {
        #region Properties

        public readonly static MappedAssetDependencyProperty<SpriteAsset, UnityEngine.UI.Image, Image> SpriteProperty = 
            new MappedAssetDependencyProperty<SpriteAsset, UnityEngine.UI.Image, Image>("Sprite",
            x => x.Image, (x, y) => x.sprite = y.Object);
        public SpriteAsset Sprite
        {
            get { return SpriteProperty.GetValue(this); }
            set { SpriteProperty.SetValue(this, value); }
        }

        private SpriteAsset SpriteAsset; 
        public readonly static DependencyProperty<string> SpriteIdProperty = new DependencyProperty<string>("SpriteId");
        public string SpriteId
        {
            get { return SpriteIdProperty.GetValue(this); }
            set { SpriteIdProperty.SetValue(this, value); }
        }
        
        #endregion

        protected override void AfterLoad()
        {
            base.AfterLoad();

            // this is perhaps a situation where an observable is desired, a sprite asset observable that can be subscribed to
        }
    }

    /// <summary>
    /// Dependency property that maps to another property or field.
    /// </summary>
    public class MappedAssetDependencyProperty<T, TObject, TParent> : DependencyProperty
        where TParent : DependencyObject
        where T : AssetObject
    {
        #region Fields

        public Dictionary<DependencyObject, T> Values; // TODO here we want a weak keyed dictionary
        public Dictionary<Template, T> Defaults;
        public Func<TParent, TObject> ObjectGetter;
        public Action<TObject, T> Setter;

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the mapped dependency property.
        /// </summary>
        public override void Initialize(DependencyObject key)
        {
            base.Initialize(key);
            if (Values.ContainsKey(key))
            {
                return;
            }

            
        }

        /// <summary>
        /// Gets mapped dependency property value for specified instance.
        /// </summary>
        public T GetValue(DependencyObject key)
        {
            T currentValue;
            if (Values.TryGetValue(key, out currentValue))
            {
                return currentValue;
            }
            else
            {
                return GetDefault(key.Template);
            }
        }

        /// <summary>
        /// Sets dependency property value for specified instance.
        /// </summary>
        public void SetValue(DependencyObject key, T value, bool notifyObservers = true)
        {
            // get old value
            T oldValue;
            T currentValue;
            if (Values.TryGetValue(key, out currentValue))
            {
                oldValue = currentValue;
            }
            else
            {
                oldValue = GetDefault(key.Template);
            }

            // has value changed?
            if (oldValue != null ? oldValue.Equals(value) : value == null)
            {
                return; // no.
            }

            // attach change handlers
            if (oldValue != null)
            {
                oldValue.PropertyChanged -= AssetChanged;
            }

            if (value != null)
            {
                value.PropertyChanged += AssetChanged;
            }

            // set value
            if (currentValue != null)
            {
                Values[key] = value;
            }
            else
            {
                Values.Add(key, value);
            }

            // trigger property-changed event
            key.OnPropertyChanged(PropertyName);

            //var target = ObjectGetter((TParent)key);
            //if (target == null)
            //    return;

            //// has value changed?
            //T oldValue = Getter(target);
            //if (oldValue != null ? oldValue.Equals(value) : value == null)
            //{
            //    return; // no.
            //}

            //Setter(target, value);

            //// trigger property-changed event
            //key.OnPropertyChanged(PropertyName);
        }

        private void AssetChanged(object source, string propertyName)
        {
            // here we have a problem because we don't have access to the dependency object, only the resource
            // and we have no link between the two. 

            var asset = source as AssetObject;
        }

        /// <summary>
        /// Clears run-time values for the specified instance.
        /// </summary>
        public override void ClearRuntimeValues(DependencyObject key)
        {
            base.ClearRuntimeValues(key);
            Values.Remove(key);
        }

        /// <summary>
        /// Checks if dependency property value is undefined (no run-time or default value set). Mainly used check if values of non-nullable types has been set.
        /// </summary>
        public bool IsUndefined(DependencyObject key)
        {
            if (Values.ContainsKey(key))
                return false;

            var template = key.Template;
            while (true)
            {
                if (Defaults.ContainsKey(template))
                {
                    return false;
                }

                template = template.BasedOn;
                if (template == ViewTemplates.Default)
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Gets default value from type.
        /// </summary>
        public T GetDefault(Template template)
        {
            while (true)
            {
                T defaultValue;
                if (Defaults.TryGetValue(template, out defaultValue))
                {
                    return defaultValue;
                }

                template = template.BasedOn;
                if (template == ViewTemplates.Default)
                {
                    return default(T);
                }
            }
        }

        /// <summary>
        /// Sets default value for type.
        /// </summary>
        public void SetDefault(Template template, T defaultValue)
        {
            Defaults[template] = defaultValue;
        }

        #endregion        

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public MappedAssetDependencyProperty(string propertyName, Func<TParent, TObject> objectGetter, Action<TObject, T> setter)
        {
            Defaults = new Dictionary<Template, T>();
            Setter = setter;
            ObjectGetter = objectGetter;
            PropertyName = propertyName;
        }

        #endregion
    }
}
