using AutoMapper;
using BL.CoinCapApi.Services.Interfaces;
using BL.Services.Interfaces;
using Models.CoinCapApiModels;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class CryptocurrencyService : ICryptocurrencyService
    {
        private readonly ICoinCapService _coinCapService;
        private readonly IMapper _mapper;
        public CryptocurrencyService(ICoinCapService coinCapService, IMapper mapper)
        {
            _coinCapService = coinCapService;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CryptocurrencyModel>> GetCryptocurrencesAsync(int limit)
        {
            var result = await _coinCapService.GetCryptocurrencesAsync(limit);
            return _mapper.Map<List<CryptocurrencyApiModel>, List<CryptocurrencyModel>>(result.Cryptocurrencies);
        }

        public async Task<IEnumerable<CryptocurrencyModel>> GetCryptocurrencesAsync(int limit, string id)
        {
            var result = await _coinCapService.GetCryptocurrencesAsync(limit, id);

            return _mapper.Map<List<CryptocurrencyApiModel>, List<CryptocurrencyModel>>(result.Cryptocurrencies);
        }

        public async Task<IEnumerable<MarketModel>> GetMarketsAsync(string id)
        {
            var result = await _coinCapService.GetMarketApiModelsAsync(id);
            return _mapper.Map<List<MarketApiModel>, List<MarketModel>>(result.Markets);
        }

        public async Task<MarketModel> GetMarketAsync(MarketModel market)
        {
            var result = (await _coinCapService.GetExchangeApiModelsAsync(market.ExchangeId)).Exchange;
            market.Rank = result.Rank;
            market.PercentTotalVolume = result.PercentTotalVolume;
            market.VolumeUsd = result.VolumeUsd;
            market.TradingPairs = result.TradingPairs;
            market.ExchangeUrl = result.ExchangeUrl;
            return market;
        }
    }
}
