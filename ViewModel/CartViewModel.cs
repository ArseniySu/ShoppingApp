using ShoppingApp.Helpers;
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

namespace ShoppingApp.ViewModel
{
    public class CartViewModel : INotifyPropertyChanged
    {
        private readonly Cart _cart;
        private readonly ProductRepository _productRepository;

        public CartViewModel(Cart cart, ProductRepository productRepository)
        {
            _cart = cart;
            _productRepository = productRepository;

            CartItems = new ObservableCollection<CartItem>(_cart.Items);
            RemoveFromCartCommand = new RelayCommand<CartItem>(RemoveFromCart);
        }

        public ObservableCollection<CartItem> CartItems { get; }

        public decimal TotalCost => _cart.TotalCost;

        public int ItemCount => _cart.ItemCount;

        public ICommand RemoveFromCartCommand { get; }

        private void RemoveFromCart(CartItem cartItem)
        {
            _cart.RemoveItem(cartItem);
            CartItems.Remove(cartItem);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
