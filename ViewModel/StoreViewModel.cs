using ShoppingApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ShoppingApp.Helpers;


namespace ShoppingApp.ViewModel
{
    public class StoreViewModel : INotifyPropertyChanged
    {
        private readonly ProductRepository _productRepository;
        private Cart _cart;

        public StoreViewModel(ProductRepository productRepository, Cart cart)
        {
            _productRepository = productRepository;
            _cart = cart;
            Products = new ObservableCollection<Product>(_productRepository.GetAllProducts());
        }

        public ObservableCollection<Product> Products { get; }

        public ICommand AddToCartCommand { get; }

        public StoreViewModel()
        {
            AddToCartCommand = new RelayCommand<Product>(AddToCart);
        }

        private void AddToCart(Product product)
        {
            _cart.AddItem(product);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
