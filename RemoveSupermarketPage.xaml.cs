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

    public partial class RemoveSupermarketPage : Page
    {
        GoodsContext db = new GoodsContext();
        public RemoveSupermarketPage()
        {
            InitializeComponent();
            db.Supermarkets.Load();
            List<string> SupermarketsList = new List<string>();

            foreach (var item in db.Supermarkets.ToList())
            {
                SupermarketsList.Add(item.Name);
            }

            SupermarketsComboBox.ItemsSource = SupermarketsList;
        }

        private void Remove_Supermarket(object sender, RoutedEventArgs e)
        {
            string SupermarketName = (string)SupermarketsComboBox.SelectedItem;
            int SupermarketId = 0;
            foreach (var i in db.Supermarkets)
            {
                if (i.Name == SupermarketName) SupermarketId = i.Id;
            }

            Supermarket supermarket = db.Supermarkets.Find(SupermarketId);
            db.Remove(supermarket);
            db.SaveChanges();
            MessageBox.Show("Реализатор успешно удален!");
        }

        private void Main_Menu(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuPage());
        }


        private void Add_Product_Menu(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddProductPage());
        }

        private void Remove_Product_Menu(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RemoveProductPage());
        }

        private void Add_Supermarket_Menu(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddSupermarketPage());
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
