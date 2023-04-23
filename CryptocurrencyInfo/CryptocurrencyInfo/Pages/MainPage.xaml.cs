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
