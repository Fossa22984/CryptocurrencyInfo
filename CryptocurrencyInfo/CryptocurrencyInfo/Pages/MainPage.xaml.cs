using CryptocurrencyInfo.Managers;
using CryptocurrencyInfo.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CryptocurrencyInfo.Pages
{
    public partial class MainPage : Page
    {
        private readonly AppCacheManager _appCacheManager;
        public MainPage(AppCacheManager appCacheManager)
        {
            _appCacheManager = appCacheManager;
            InitializeComponent();

            DataContext = new MainViewModel();
        }

        private void ListBox_Selected(object sender, RoutedEventArgs e)
        {
            if ((DataContext as MainViewModel).SelectedCryptocurrency == null) return;

            _appCacheManager.SelectedCryptocurrency = (DataContext as MainViewModel).SelectedCryptocurrency;
            var page = App.ServiceProviderManager.GetService<CryptocurrencyInfoPage>();
            NavigationService.Navigate(page);
        }
    }
}
