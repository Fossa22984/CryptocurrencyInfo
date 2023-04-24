using BL.Services.Interfaces;
using Models.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace CryptocurrencyInfo.ViewModels
{
    public class CryptocurrencyInfoViewModel : BaseViewModel
    {
        private readonly ICryptocurrencyService _service;

        private MarketModel _selectedMarket;
        private CryptocurrencyModel _selectedCryptocurrency;

        public MarketModel SelectedMarket { get => _selectedMarket; set => Set(ref _selectedMarket, value); }
        public CryptocurrencyModel SelectedCryptocurrency { get => _selectedCryptocurrency; set => Set(ref _selectedCryptocurrency, value); }

        public CryptocurrencyInfoViewModel(CryptocurrencyModel c)
        {
            SelectedCryptocurrency = c;
            _service = App.ServiceProviderManager.GetService<ICryptocurrencyService>();
            GetMarkets();
        }

        public async void GetMarkets()
        {
            try
            {
                SelectedCryptocurrency.Markets = new ObservableCollection<MarketModel>(await _service.GetMarketsAsync(SelectedCryptocurrency.Id));
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}