using System.ComponentModel;
using Windows.UI.Xaml.Media;

namespace ListViewSemanticZoomMVVMSample
{
    public class ItemModel : INotifyPropertyChanged, ICategorizable
    {
        private string _title = string.Empty;

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title == value) return;
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        private string _category = string.Empty;

        public string Category
        {
            get { return _category; }
            set
            {
                if (_category == value) return;
                _category = value;
                OnPropertyChanged("Category");
            }
        }

        private ImageSource _image = null;

        public ImageSource Image
        {
            get { return _image; }
            set
            {
                if (_image == value) return;
                _image = value;
                OnPropertyChanged("Image");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
