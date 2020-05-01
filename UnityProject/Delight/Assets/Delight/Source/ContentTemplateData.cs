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

        public int Index
        {
            get { return _zeroIndex + 1; }
            set { ZeroIndex = value - 1; }
        }

        private int _zeroIndex;
        public int ZeroIndex
        {
            get { return _zeroIndex; }
            set
            {
                SetProperty(ref _zeroIndex, value);
                OnPropertyChanged(nameof(Index));
            }
        }

        public static readonly ContentTemplateData Empty = new ContentTemplateData();
    }
}