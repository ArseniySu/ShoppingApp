using ShoppingApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly StoreViewModel _storeViewModel;
        private readonly CartViewModel _cartViewModel;

        private object _currentView;

        public MainViewModel(StoreViewModel storeViewModel, CartViewModel cartViewModel)
        {
            _storeViewModel = storeViewModel;
            _cartViewModel = cartViewModel;

            CurrentView = _storeViewModel;
        }

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public void ShowStoreView()
        {
            CurrentView = _storeViewModel;
        }

        public void ShowCartView()
        {
            CurrentView = _cartViewModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
