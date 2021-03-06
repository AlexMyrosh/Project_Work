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

    public partial class RemoveManufacturePage : Page
    {
        GoodsContext db = new GoodsContext();
        public RemoveManufacturePage()
        {
            InitializeComponent();
            db.Manufactures.Load();
            List<string> ManufacturesList = new List<string>();

            foreach (var item in db.Manufactures.ToList())
            {
                ManufacturesList.Add(item.Name);
            }

            ManufacturesComboBox.ItemsSource = ManufacturesList;
        }

        private void Remove_Manufacture(object sender, RoutedEventArgs e)
        {
            string ManufactureName = (string)ManufacturesComboBox.SelectedItem;
            int ManufactureId = 0;
            foreach (var i in db.Manufactures)
            {
                if (i.Name == ManufactureName) ManufactureId = i.Id;
            }

            Manufacture manufacture = db.Manufactures.Find(ManufactureId);
            db.Remove(manufacture);
            db.SaveChanges();
            MessageBox.Show("Производитель успешно удален!");
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

        private void Remove_Supermarket_Menu(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RemoveSupermarketPage());
        }

        private void Add_Manufacture_Menu(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddManufacturePage());
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
