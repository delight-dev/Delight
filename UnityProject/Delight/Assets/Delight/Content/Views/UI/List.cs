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
    /// Generic list view.
    /// </summary>
    public class List<TViewModel, TView> : UIImageView
        where TView : View, new()
    {
        #region Properties

        private ObservableList<TViewModel> _presentedItems;

        public readonly static DependencyProperty<ObservableList<TViewModel>> ItemsProperty = new DependencyProperty<ObservableList<TViewModel>>();
        public ObservableList<TViewModel> Items
        {
            get { return ItemsProperty.GetValue(this); }
            set { ItemsProperty.SetValue(this, value); }
        }

        #endregion

        #region Constructor

        public List(View parent = null, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? ListTemplates.Default, initializer)
        {
        }

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
            if (!IsLoaded)
                return;

            if (_presentedItems != null)
            {
                // unsubscribe from change events in the old list
                _presentedItems.ListChanged -= OnListChanged;
            }
            _presentedItems = Items;

            // add new list
            if (_presentedItems != null)
            {
                // subscribe to change events in the new list
                _presentedItems.ListChanged += OnListChanged;
            }

            // unload and clear existing children
            foreach (var child in _layoutChildren)
            {
                child.Unload();
            }
            _layoutChildren.Clear();

            int i = 0;
            foreach (var item in _presentedItems)
            {
                // create new children 
                var itemView = new TView();
                itemView.Parent = this;
                itemView.LayoutParent = this;
                LayoutChildren.Add(itemView);

                // TODO temp debug logic remove
                if (itemView is Label && item is Student)
                {
                    var student = item as Student;
                    var label = itemView as Label;
                    Debug.Log("Student name = " + student.Name);                    
                    label.Load();
                    label.Color = Color.black;
                    label.Offset = new ElementMargin(0, i * 35, 0, 0);
                    label.Text = student.Name;
                    ++i;
                    continue;
                }
                
                // -----

                itemView.Load();                
            }
        }

        /// <summary>
        /// Called after the view and its children has been loaded.
        /// </summary>
        protected override void AfterLoad()
        {
            base.AfterLoad();

            // TODO remove debug log
            Debug.Log(String.Format("List.AfterLoad() called, itemCount = {0}", Items?.Count));
            ItemsChanged();
        }

        /// <summary>
        /// Called when the list of items has been changed.
        /// </summary>
        private void OnListChanged(object sender, ListChangedEventArgs e)
        {
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
