namespace Delight
{
    /// <summary>
    /// Content template data. Contains information about data associated with an instantiated content template. 
    /// </summary>
    public class ContentTemplateData : BindableObject
    {
        private BindableObject _item;
        public BindableObject Item
        {
            get { return _item; }
            set { SetProperty(ref _item, value); }
        }

        private int _index;
        public int Index
        {
            get { return _index; }
            set { SetProperty(ref _index, value); }
        }

        private int _zeroIndex;
        public int ZeroIndex
        {
            get { return _zeroIndex; }
            set { SetProperty(ref _zeroIndex, value); }
        }

        public static readonly ContentTemplateData Empty = new ContentTemplateData();
    }
}