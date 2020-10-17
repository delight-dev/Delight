#region Using Statements
using System;
#endregion

namespace Delight.Editor.Parser
{
    /// <summary>
    /// Contains information about a template item variable. 
    /// </summary>
    public class TemplateItemInfo
    {
        public string Name;
        public string VariableName;
        public PropertyBinding ItemIdDeclaration;
        public Type ItemType;
        public string ItemTypeName;
        public bool IsBindableCollection;

        private ContentTemplateData _contentTemplateData;
        public ContentTemplateData ContentTemplateData
        { 
            get
            {
                return _contentTemplateData;
            }
            set
            {
                _contentTemplateData = value;
            }
        }
    }
}
