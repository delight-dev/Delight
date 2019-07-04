#region Using Statements
using System;
using System.Linq;
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
        protected virtual View CreateItem(BindableObject item, Type templateType = null, string templateId = null)
        {
            if (ContentTemplates == null || ContentTemplates.Count <= 0)
                return null;

            // find activator that corresponds to the type specified                       
            var activator = templateType == null ? ContentTemplates[0].Activator : 
                ContentTemplates.FirstOrDefault(x => (x.TemplateType == templateType) && (templateId == null || templateId == x.Id))?.Activator;
            if (activator == null)
                return null;

            var templateData = new ContentTemplateData { Item = item };            
            var itemView = activator(templateData);

            return itemView;
        }

        #endregion
    }
}
