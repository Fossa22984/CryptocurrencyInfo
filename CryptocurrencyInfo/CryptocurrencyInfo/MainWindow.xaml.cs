using CryptocurrencyInfo.Pages;
using CryptocurrencyInfo.ViewModels;
using System.Windows;

namespace CryptocurrencyInfo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var page = App.ServiceProviderManager.GetService<MainPage>();
            Frame.Navigate(page);

            DataContext = new ApplicationViewModel();
        }
    }
}