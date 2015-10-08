using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml.Media.Imaging;

namespace ListViewSemanticZoomMVVMSample
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        #region Fields

        private StoreData _storeData;

        private readonly string[] _images = new[]
        {
            "image1.jpeg",  "image2.jpg",  "image3.png",  "image4.jpg",  "image5.png",
        };

        private List<ListWithKey<object>> _data;

        private readonly string[] _categories = new[]
        {
            //Categories will be ordered as strings by default
            "6","7","8","9","1","2","3","4","5","End"
        };

        #endregion

        #region Properties

        public List<ListWithKey<object>> Data
        {
            get { return _data;}
            private set
            {
                if (_data == value) return;
                _data = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Data"));
            }
        }

        #endregion

        #region Constructor

        public MainPageViewModel()
        {
            _storeData = new StoreData();
            FillCollection(_storeData.Collection, 1000);
            Data = _storeData.GetGroupsByCategory();
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, args);
        }

        #endregion

        #region Public Methods

        public void FillCollection(ObservableCollection<ICategorizable> collection,int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                var item = new ItemModel();
                item.Title =   $"Generated Neko   № {i}";
                int imageIndex = random.Next(0, _images.Length);

                //It is strongly recommended to reduce image quality before displaying 
                //it in list view in real project. Here images were left in initial 
                //state for list view performance testing
                
                item.Image = new BitmapImage(new Uri($"ms-appx:///Assets/{_images[imageIndex]}"));

                //Simply add random category to item. You may need to implement 
                //some logic for right category selection

                item.Category = _categories[random.Next(0, _categories.Length)];
                collection.Add(item);
            }
        }

        #endregion

    }
}
