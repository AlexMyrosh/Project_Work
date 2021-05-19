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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace Project_Work
{

    public partial class RemoveProductPage : Page
    {
        GoodsContext db = new GoodsContext();
        public RemoveProductPage()
        {
            InitializeComponent();
            db.Products.Load();
            List<string> ProductsList = new List<string>();

            foreach (var item in db.Products.ToList())
            {
                ProductsList.Add(item.Name);
            }

            ProductsComboBox.ItemsSource = ProductsList;
        }

        private void Remove_Product(object sender, RoutedEventArgs e)
        {
            string ProductName = (string)ProductsComboBox.SelectedItem;
            int ProductId = 0;
            foreach (var i in db.Products)
            {
                if (i.Name == ProductName) ProductId = i.Id;
            }

            Manufacture product = db.Manufactures.Find(ProductId);
            db.Remove(product);
            db.SaveChanges();
            MessageBox.Show("Товар успешно удален!");
        }

        private void Main_Menu(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuPage());
        }


        private void Add_Product_Menu(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddProductPage());
        }

        private void Add_Supermarket_Menu(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddSupermarketPage());
        }

        private void Remove_Supermarket_Menu(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RemoveSupermarketPage());
        }

        private void Add_Manufacture_Menu(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddManufacturePage());
        }

        private void Remove_Manufacture_Menu(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RemoveManufacturePage());
        }

        private void Show_ProductsList_Menu(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ShowProductsListPage());
        }

        private void Show_SupermarketsList_Menu(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ShowSupermarketsListPage());
        }

        private void Show_ManufacturesList_Menu(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ShowManufacturesListPage());
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
