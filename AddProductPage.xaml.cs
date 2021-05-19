using Microsoft.EntityFrameworkCore;
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
    
    public partial class AddProductPage : Page
    {
        GoodsContext db = new GoodsContext();
        public AddProductPage()
        {
            InitializeComponent();
            db.Manufactures.Load();
            List<string> ManufacturesList = new List<string>();

            foreach (var item in db.Manufactures.ToList())
            {
                ManufacturesList.Add(item.Name);
            }

            ManufactureComboBox.ItemsSource = ManufacturesList;

            db.Supermarkets.Load();
            List<string> SupermarketsList = new List<string>();

            foreach (var item in db.Supermarkets.ToList())
            {
                SupermarketsList.Add(item.Name);
            }
            SupermarketComboBox.ItemsSource = SupermarketsList;
        }

        private void Main_Menu(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuPage());
        }

        private void Add_Product(object sender, RoutedEventArgs e)
        {

            string name = Name.Text;
            if (!Int32.TryParse(Amount.Text, out int amount))
            {
                MessageBox.Show("Количество должно быть целочисленным!");
                return;
            }
            string measure = Measure.Text;
            if (!Double.TryParse(Price.Text, out double price))
            {
                MessageBox.Show("Цена должна быть числом с плавующей точкой!");
                return;
            }
            string dstu = DSTU.Text;


            string ManufactureName = (string)ManufactureComboBox.SelectedItem;
            string SupermarketName = (string)SupermarketComboBox.SelectedItem;


            int ManufactureId = 0;
            int SupermarketId = 0;
            foreach (var i in db.Manufactures)
            {
                if (i.Name == ManufactureName) ManufactureId = i.Id;
            }
            foreach (var i in db.Supermarkets)
            {
                if (i.Name == SupermarketName) SupermarketId = i.Id;
            }

            Manufacture manufacture = db.Manufactures.Find(ManufactureId);
            Supermarket supermarket = db.Supermarkets.Find(SupermarketId);

            Product newProduct = new Product(name, amount, measure, price, dstu, manufacture, supermarket);
            db.Products.Add(newProduct);
            db.SaveChanges();
            MessageBox.Show("Продукт успешно добавлен");
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
