using BL.CoinCapApi.Services;
using BL.Services.Interfaces;
using Models.CoinCapApiModels;
using Models.ViewModels;
using System.Collections.ObjectModel;

namespace CryptocurrencyInfo.ViewModels
{
    public class CryptocurrencyInfoViewModel : BaseViewModel
    {
        private readonly ICryptocurrencyService _service;

        private MarketModel _selectedMarket;
        public MarketModel SelectedMarket
        {
            get => _selectedMarket;
            set => Set(ref _selectedMarket, value);
        }

        private CryptocurrencyModel _selectedCryptocurrency;
        public CryptocurrencyModel SelectedCryptocurrency
        {
            get => _selectedCryptocurrency;
            set => Set(ref _selectedCryptocurrency, value);
        }

        public CryptocurrencyInfoViewModel(CryptocurrencyModel c)
        {
            SelectedCryptocurrency = c;
            _service = App.ServiceProviderManager.GetService<ICryptocurrencyService>();
            GetMarkets();
        }

        public async void GetMarkets()
        {
            SelectedCryptocurrency.Markets = new ObservableCollection<MarketModel>(await _service.GetMarketsAsync(SelectedCryptocurrency.Id));
        }

        
    }
}