#region Using Statements
using System;
using System.Linq;
#endregion

namespace Delight
{
    /// <summary>
    /// Generic collection view. Used by views such as Lists and TabPanel that wants to display dynamic content through the Item property.
    /// </summary>
    public partial class Collection
    {
        #region Fields

        public BindableCollection<ContentTemplate> ContentTemplates = new BindableCollection<ContentTemplate>();

        #endregion

        #region Methods

        /// <summary>
        /// Creates new item in collection.
        /// </summary>
        protected virtual View CreateItem(BindableObject item, Type templateType = null, string templateId = null)
        {
            var template = GetContentTemplate(templateType, templateId);

            var activator = template?.Activator;
            if (activator == null)
                return null;

            var templateData = new ContentTemplateData { Item = item };            
            var itemView = activator(templateData);

            return itemView;
        }

        /// <summary>
        /// Gets content template of the specified type and id. 
        /// </summary>
        protected virtual ContentTemplate GetContentTemplate(Type templateType = null, string templateId = null)
        {
            if (ContentTemplates == null || ContentTemplates.Count <= 0)
                return null;

            // find activator that corresponds to the type specified           
            var templates = ContentTemplates.ToList();
            if (templateType != null)
            {
                templates = templates.Where(x => x.TemplateType == templateType).ToList();
            }
            if (templateId != null)
            {
                templates = templates.Where(x => x.Id == templateId).ToList();
            }

            return templates.FirstOrDefault();
        }

        #endregion
    }
}
