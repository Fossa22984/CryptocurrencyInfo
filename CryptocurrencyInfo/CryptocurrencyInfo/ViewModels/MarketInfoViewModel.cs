using BL.CoinCapApi.Services;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyInfo.ViewModels
{
    public class MarketInfoViewModel : BaseViewModel
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

        public MarketInfoViewModel(MarketModel m)
        {
            SelectedMarket = m;
            _service = App.ServiceProviderManager.GetService<CoinCapService>();
            Task.Run(async () => await GetMarket());
        }

        public async Task GetMarket()
        {
            var market = (await _service.GetExchangeApiModelsAsync(SelectedMarket.ExchangeId)).Exchange;
            SelectedMarket.Rank = market.Rank;
            SelectedMarket.PercentTotalVolume = market.PercentTotalVolume;
            SelectedMarket.VolumeUsd = market.VolumeUsd;
            SelectedMarket.TradingPairs = market.TradingPairs;
            SelectedMarket.ExchangeUrl = market.ExchangeUrl;
        }
    }
}
