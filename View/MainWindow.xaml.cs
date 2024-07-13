using ShoppingApp.Helpers;
using ShoppingApp.Model;
using ShoppingApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ShoppingApp.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StoreViewModel storeViewModel;
        private CartViewModel cartViewModel;
        public MainWindow()
        {
            InitializeComponent();
            DataContext.GetType().GetProperty("ShowStoreViewCommand").SetValue(DataContext, new RelayCommand<Product>(ShowStoreView));
            DataContext.GetType().GetProperty("ShowCartViewCommand").SetValue(DataContext, new RelayCommand<CartItem>(ShowCartView));

            DataContext = new MainViewModel(storeViewModel, cartViewModel);
        }

        private void ShowStoreView(Product product)  
        {
            ((MainViewModel)DataContext).ShowStoreView();
        }

        private void ShowCartView(CartItem cartItem) 
        {
            ((MainViewModel)DataContext).ShowCartView();
        }
    }
}
