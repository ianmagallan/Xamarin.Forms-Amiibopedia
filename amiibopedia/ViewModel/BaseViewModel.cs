using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace amiibopedia.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool _isBusy;

        public bool IsBusy { 
            get => _isBusy; 
            set{
                _isBusy = value;
                NotifyPropertyChanged();
            }
        }
        public BaseViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
