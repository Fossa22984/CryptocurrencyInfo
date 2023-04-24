using CryptocurrencyInfo.Managers;
using CryptocurrencyInfo.ViewModels;
using System.Windows.Controls;

namespace CryptocurrencyInfo.Pages
{
    public partial class MarketInfoPage : Page
    {
        private readonly AppCacheManager _appCacheManager;
        public MarketInfoPage(AppCacheManager appCacheManager)
        {
            _appCacheManager = appCacheManager;
            InitializeComponent();

            if (_appCacheManager.SelectedMarket != null)
                DataContext = new MarketInfoViewModel(_appCacheManager.SelectedMarket);
        }
    }
}