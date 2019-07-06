#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class TabPanel
    {
        #region Fields

        private BindableObject _selectedItem;
        private BindableCollection _oldCollection;
        private Dictionary<BindableObject, Tab> _tabs = new Dictionary<BindableObject, Tab>();
        private Dictionary<BindableObject, TabHeader> _tabHeaders = new Dictionary<BindableObject, TabHeader>();

        #endregion

        #region Methods

        /// <summary>
        /// Called when a property has been changed. 
        /// </summary>
        public override void OnChanged(string property)
        {
            base.OnChanged(property);
            switch (property)
            {
                case nameof(SelectedTabIndex):
                    SelectedTabIndexChanged();
                    break;

                case nameof(Items):
                    ItemsChanged();
                    break;
            }
        }

        /// <summary>
        /// Called when selected tab index is changed.
        /// </summary>
        private void SelectedTabIndexChanged()
        {
            // toggle header
            if (TabHeaderGroup.LayoutChildren.Count > SelectedTabIndex)
            {
                if (SelectedTabIndex < 0)
                {
                    foreach (TabHeader tabHeader in TabHeaderGroup.LayoutChildren)
                    {
                        tabHeader.ToggleValue = false;
                    }
                }
                else
                {
                    (TabHeaderGroup.LayoutChildren[SelectedTabIndex] as TabHeader).ToggleValue = true;
                }
            }
        }

        /// <summary>
        /// Generates tab items from data in collection. 
        /// </summary>
        protected void CreateTabItems()
        {
            if (Items == null)
                return;

            foreach (var item in Items)
            {
                CreateTabItem(item);
            }

            SelectedTabIndexChanged();
        }

        /// <summary>
        /// Called after the view and its children has been loaded.
        /// </summary>
        protected override void AfterLoad()
        {
            base.AfterLoad();

            if (IsStaticProperty.IsUndefined(this) && ItemsProperty.IsUndefined(this))
            {
                // if items property isn't defined assume tab panel is meant to be static
                IsStatic = true;
            }

            if (IsStatic)
            {
                CreateStaticTabItems();
            }
            else
            {
                ItemsChanged();
            }
        }

        /// <summary>
        /// Called when the view has been unloaded.
        /// </summary>
        protected override void AfterUnload()
        {
            base.AfterUnload();
            if (Items != null)
            {
                // unsubscribe to change events in the old list
                Items.CollectionChanged -= OnCollectionChanged;
            }

            _tabs.Clear();
            _tabHeaders.Clear();
        }

        /// <summary>
        /// Called when the list of items has been changed.
        /// </summary>
        private void OnCollectionChanged(object sender, CollectionChangedEventArgs e)
        {
            if (!IsLoaded)
                return;

            // Debug.Log("Collection changed");
            bool updateLayout = false;
            if (e.ChangeAction == CollectionChangeAction.Batch)
            {
                var eventArgsBatch = (e as BatchedCollectionChangedEventArgs).CollectionChangedEventArgsBatch;
                foreach (var eventArgs in eventArgsBatch)
                {
                    updateLayout |= OnCollectionChanged(eventArgs);
                }
            }
            else
            {
                updateLayout = OnCollectionChanged(e);
            }

            if (updateLayout)
            {
                UpdateLayout();
            }
        }

        /// <summary>
        /// Handles collection changed events.
        /// </summary>
        private bool OnCollectionChanged(CollectionChangedEventArgs e)
        {
            bool updateLayout = false;
            switch (e.ChangeAction)
            {
                case CollectionChangeAction.Add:
                    CreateTabItem(e.Item);
                    break;

                case CollectionChangeAction.Remove:
                    DestroyItem(e.Item);
                    break;

                case CollectionChangeAction.Replace:
                    ReplaceItems();
                    break;

                case CollectionChangeAction.Clear:
                    ClearTabItems();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            return updateLayout;
        }

        /// <summary>
        /// Replaces presented items. 
        /// </summary>
        private void ReplaceItems()
        {
            // clear list items
            ClearTabItems();
            if (IsLoaded)
            {
                CreateTabItems();
            }
        }

        /// <summary>
        /// Destroys item in list.
        /// </summary>
        protected virtual void DestroyItem(BindableObject item)
        {
            if (_tabs.TryGetValue(item, out var tabItem))
            {
                tabItem.Unload();
                Content.LayoutChildren.Remove(tabItem);
                _tabs.Remove(item);
            }

            if (_tabHeaders.TryGetValue(item, out var tabHeaderItem))
            {
                tabHeaderItem.Unload();
                TabHeaderGroup.LayoutChildren.Remove(tabHeaderItem);
                _tabHeaders.Remove(item);
            }
        }

        /// <summary>
        /// Called when the list of items has been replaced.
        /// </summary>
        public virtual void ItemsChanged()
        {
            IsStatic = false;
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

            // clear list items
            ClearTabItems();

            if (IsLoaded)
            {
                CreateTabItems();
            }
        }

        /// <summary>
        /// Clears the list. 
        /// </summary>
        private void ClearTabItems()
        {
            // unload and clear existing children
            foreach (var tab in Content.LayoutChildren)
            {
                tab.Unload();
            }
            foreach (var tabHeader in TabHeaderGroup.LayoutChildren)
            {
                tabHeader.Unload();
            }

            Content.LayoutChildren.Clear();
            TabHeaderGroup.LayoutChildren.Clear();
            _tabs.Clear();
            _tabHeaders.Clear();
        }

        /// <summary>
        /// Called when a new item is to be generated.
        /// </summary>
        protected View CreateTabItem(BindableObject item)
        {
            var tabItem = CreateItem(item, typeof(Tab)) as Tab;
            if (tabItem == null)
            {
                // create empty tab
                tabItem = new Tab(this, Content);
            }

            if (!_tabs.ContainsKey(item))
            {
                _tabs.Add(item, tabItem);
            }

            var tabHeader = CreateTabHeader(tabItem, item);
            return tabItem;
        }

        /// <summary>
        /// Generates views from data in collection. 
        /// </summary>
        protected void CreateStaticTabItems()
        {
            if (ContentTemplates == null)
                return;

            foreach (var contentTemplate in ContentTemplates)
            {
                if (!typeof(Tab).IsAssignableFrom(contentTemplate.TemplateType))
                    continue;

                var templateData = new ContentTemplateData();
                var tab = contentTemplate.Activator(templateData) as Tab;

                var tabHeader = CreateTabHeader(tab);
            }

            SelectedTabIndexChanged();
        }

        /// <summary>
        /// Creates tab header for tab.
        /// </summary>
        protected View CreateTabHeader(Tab tab, BindableObject item = null)
        {
            var tabHeader = CreateItem(item, typeof(TabHeader), tab.TabHeaderId) as TabHeader;
            if (tabHeader == null)
            {
                // create default tab header
                tabHeader = new TabHeader(this, TabHeaderGroup);
            }

            if (item != null)
            {
                if (!_tabHeaders.ContainsKey(item))
                {
                    _tabHeaders.Add(item, tabHeader);
                }
            }

            tabHeader.ParentTabPanel = this;
            tabHeader.MoveTo(TabHeaderGroup);
            tabHeader.TabIndex = TabHeaderGroup.LayoutChildren.Count - 1;
            tabHeader.Load();

            // set default tab header text if undefined
            if (!Tab.TextProperty.IsUndefined(tab) && TabHeader.TextProperty.IsUndefined(tabHeader.Label))
            {
                tabHeader.Text = tab.Text;
            }

            if (TabHeaderWidth != null)
            {
                tabHeader.Width = TabHeaderWidth;
            }

            if (TabHeaderHeight != null)
            {
                tabHeader.Height = TabHeaderHeight;
            }

            return tabHeader;
        }

        #endregion
    }
}
