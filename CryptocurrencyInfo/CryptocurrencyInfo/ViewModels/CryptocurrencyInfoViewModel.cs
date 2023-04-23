using BL.CoinCapApi.Services;
using Models.CoinCapApiModels;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyInfo.ViewModels
{
    public class CryptocurrencyInfoViewModel : BaseViewModel
    {
        private readonly CoinCapService _service;

        private MarketModel _selectedMarket;
        public MarketModel SelectedMarket
        {
            get => _selectedMarket;
            set
            {
                Set(ref _selectedMarket, value);
            }
        }

        private CryptocurrencyModel _selectedCryptocurrency;
        public CryptocurrencyModel SelectedCryptocurrency
        {
            get => _selectedCryptocurrency;
            set
            {
                Set(ref _selectedCryptocurrency, value);
            }
        }

        public CryptocurrencyInfoViewModel(CryptocurrencyModel c)
        {
            SelectedCryptocurrency = c;
            _service = App.ServiceProviderManager.GetService<CoinCapService>();
            GetMarkets();
        }

        public async void GetMarkets()
        {
            var markets = new ObservableCollection<Market>((await _service.GetMarketApiModelsAsync(SelectedCryptocurrency.Id)).Markets);
            SelectedCryptocurrency.Markets = Mapper(markets);
        }

        private ObservableCollection<MarketModel> Mapper(ObservableCollection<Market> markets)
        {
            var res = new ObservableCollection<MarketModel>();

            foreach (var item in markets)
            {
                res.Add(new MarketModel()
                {
                    ExchangeId = item.ExchangeId,
                    BaseId = item.BaseId,
                    QuoteId = item.QuoteId,
                    BaseSymbol = item.BaseSymbol,
                    QuoteSymbol = item.QuoteSymbol,
                    VolumeUsd24Hr = item.VolumeUsd24Hr,
                    PriceUsd = item.PriceUsd,
                    VolumePercent = item.VolumePercent,
                });
            }
            return res;
        }
    }
}