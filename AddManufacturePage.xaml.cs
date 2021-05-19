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

namespace Project_Work
{

    public partial class AddManufacturePage : Page
    {
        GoodsContext db = new GoodsContext();
        public AddManufacturePage()
        {
            InitializeComponent();
        }

        private void Add_Manufacture(object sender, RoutedEventArgs e)
        {
            string name = Name.Text;
            string country = Country.Text;
            string city = City.Text;
            string street = Street.Text;
            string house_number = House_Number.Text;

            Manufacture manufacture = new Manufacture(name, country, city, street, house_number);
            db.Manufactures.Add(manufacture);
            db.SaveChanges();
            MessageBox.Show("Производитель успешно добавлен");
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
