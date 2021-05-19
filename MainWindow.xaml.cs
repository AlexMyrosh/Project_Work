using System.Windows;

namespace Project_Work
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new MainMenuPage();
            
        }
    }
}
