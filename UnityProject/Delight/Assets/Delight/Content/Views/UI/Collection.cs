#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
#endregion

namespace Delight
{
    /// <summary>
    /// Generic collection view.
    /// </summary>
    public partial class Collection
    {
        #region Methods

        /// <summary>
        /// Creates new item in collection.
        /// </summary>
        protected virtual View CreateItem(BindableObject item)
        {
            if (ContentTemplate == null)
                return null;

            var templateData = new ContentTemplateData { Item = item };
            var itemView = ContentTemplate.Activator(templateData);
            itemView.Load();

            return itemView;
        }

        #endregion
    }
}
