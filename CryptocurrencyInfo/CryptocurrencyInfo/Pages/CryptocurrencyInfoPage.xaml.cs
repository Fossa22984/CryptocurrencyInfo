using CryptocurrencyInfo.Managers;
using CryptocurrencyInfo.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace CryptocurrencyInfo.Pages
{
    public partial class CryptocurrencyInfoPage : Page
    {
        private readonly AppCacheManager _appCacheManager;
        public CryptocurrencyInfoPage(AppCacheManager appCacheManager)
        {
            _appCacheManager = appCacheManager;
            InitializeComponent();

            if (_appCacheManager.SelectedCryptocurrency != null)
                DataContext = new CryptocurrencyInfoViewModel(_appCacheManager.SelectedCryptocurrency);
        }

        private void ListBox_Selected(object sender, RoutedEventArgs e)
        {
            _appCacheManager.SelectedMarket = (DataContext as CryptocurrencyInfoViewModel).SelectedMarket;

            var page = App.ServiceProviderManager.GetService<MarketInfoPage>();
            this.NavigationService.Navigate(page);
        }
    }
}
