#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
#endregion

namespace Delight
{
    /// <summary>
    /// Generic collection view.
    /// </summary>
    public partial class CollectionView
    {
        #region Properties

        private BindableCollection<Player> _oldCollection;

        public readonly static DependencyProperty<BindableCollection<Player>> ItemsProperty = new DependencyProperty<BindableCollection<Player>>("Items");
        public BindableCollection<Player> Items
        {
            get { return ItemsProperty.GetValue(this); }
            set { ItemsProperty.SetValue(this, value); }
        }

        #endregion

        #region Constructor

        //public CollectionView(View parent = null, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
        //    base(parent, layoutParent, id, template ?? ListViewTemplates.Default, initializer)
        //{
        //}

        #endregion

        #region Methods

        /// <summary>
        /// Called when a property has been changed. 
        /// </summary>
        public override void OnPropertyChanged(object source, string property)
        {
            base.OnPropertyChanged(source, property);
            if (property == ItemsProperty.PropertyName)
            {
                ItemsChanged();
            }
        }

        /// <summary>
        /// Called when the list of items has been replaced.
        /// </summary>
        public virtual void ItemsChanged()
        {
            if (_oldCollection != null)
            {
                // unsubscribe from change events in the old list
                _oldCollection.CollectionChanged -= OnCollectionChanged;
            }
            _oldCollection = Items;

            // add new list
            if (Items != null)
            {
                // subscribe to change events in the new list
                Items.CollectionChanged += OnCollectionChanged;
            }

            // unload and clear existing children
            foreach (var child in _layoutChildren)
            {
                child.Unload();
            }
            _layoutChildren.Clear();

            if (IsLoaded)
            {
                GenerateItems();
            }
        }

        protected void GenerateItems()
        {
            // TODO the view template needs to be supplied somehow
            int i = 0;
            foreach (var item in Items)
            {
                // create new children 
                var label = new Label(this);
                if (item is Player)
                {
                    // bind label text to player name
                    var player = item as Player;
                    //_bindings.Add(new Binding2("Name", Label.TextProperty.PropertyName, () => player, () => label, () => label.Text = player.Name, () => player.Name = label.Text));
                    label.Load();
                    label.Offset = new ElementMargin(0, i * 35, 0, 0);
                    ++i;
                }
                else
                {
                    label.Load();
                }
            }

        }

        /// <summary>
        /// Called after the view and its children has been loaded.
        /// </summary>
        protected override void AfterLoad()
        {
            base.AfterLoad();
            GenerateItems();
        }

        /// <summary>
        /// Called when the list of items has been changed.
        /// </summary>
        private void OnCollectionChanged(object sender, CollectionChangedEventArgs e)
        {
            Debug.Log("Collection changed");

            if (e.ChangeAction == CollectionChangeAction.Add)
            {
                var label = new Label(this);
                var player = Items[e.Index] as Player;

                // bind label text to player name
                //_bindings.Add(new Binding("Name", Label.TextProperty.PropertyName, () => player, () => label, () => label.Text = player.Name, () => player.Name = label.Text));
                label.Load();
                label.Offset = new ElementMargin(0, e.Index * 35, 0, 0);
            }

            //// update list of items
            //if (e.ListChangeAction == ListChangeAction.Clear)
            //{
            //    UpdateItems();
            //}
            //else if (e.ListChangeAction == ListChangeAction.Add || e.ListChangeAction == ListChangeAction.DynamicAdd || e.ListChangeAction == ListChangeAction.DynamicAddSuppressLayoutChanged ||
            //    e.ListChangeAction == ListChangeAction.AddWithoutUpdatingUpdate)
            //{
            //    UpdateItems();
            //}
            //else if (e.ListChangeAction == ListChangeAction.Remove)
            //{
            //    UpdateItems();
            //}
            //else if (e.ListChangeAction == ListChangeAction.Replace)
            //{
            //    _updateVirtualization = true;
            //}
            //else if (e.ListChangeAction == ListChangeAction.ScrollTo)
            //{
            //    ScrollTo(e.StartIndex, e.Alignment);
            //}
            //else if (e.ListChangeAction == ListChangeAction.Modify)
            //{
            //    ItemsModified(e.StartIndex, e.EndIndex, e.FieldPath);
            //}
            //else if (e.ListChangeAction == ListChangeAction.Select)
            //{
            //    SelectItem(e.StartIndex);
            //}
            //else if (e.ListChangeAction == ListChangeAction.Move)
            //{
            //    _updateVirtualization = true;
            //}

            //if (ListChanged.HasEntries)
            //{
            //    ListChanged.Trigger(new ListChangedActionData { ListChangeAction = e.ListChangeAction, StartIndex = e.StartIndex, EndIndex = e.EndIndex, FieldPath = e.FieldPath });
            //}
        }

        #endregion
    }
}
