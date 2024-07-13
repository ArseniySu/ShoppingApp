using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Model
{
    public class Cart
    {
        private readonly List<CartItem> _items = new List<CartItem>();

        public ObservableCollection<CartItem> Items { get; } = new ObservableCollection<CartItem>();

        public decimal TotalCost
        {
            get => _items.Sum(item => item.Product.Price * item.Quantity);
        }

        public int ItemCount
        {
            get => _items.Count;
        }

        public void AddItem(Product product)
        {
            var existingItem = _items.FirstOrDefault(item => item.Product.Id == product.Id);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                _items.Add(new CartItem { Product = product, Quantity = 1 });
                Items.Add(new CartItem { Product = product, Quantity = 1 }); // Добавление в ObservableCollection для обновления UI
            }
        }

        public void RemoveItem(CartItem cartItem)
        {
            _items.Remove(cartItem);
            Items.Remove(cartItem); // Удаление из ObservableCollection для обновления UI
        }

        public void Clear()
        {
            _items.Clear();
            Items.Clear(); // Очистка ObservableCollection для обновления UI
        }
    }
}
