using CryptocurrencyInfo.Pages;
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
        }
    }
}