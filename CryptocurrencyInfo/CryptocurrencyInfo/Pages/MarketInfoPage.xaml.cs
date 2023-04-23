using CryptocurrencyInfo.Managers;
using CryptocurrencyInfo.ViewModels;
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