using BL.CoinCapApi.Services.Interfaces;
using Microsoft.Extensions.Options;
using Models.CoinCapApiModels;
using Models.SettingsModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace BL.CoinCapApi.Services
{
    public class CoinCapService : ICoinCapService
    {
        private readonly HttpClient _client;
        private readonly CoinCapApiOption _coinCupOptions;

        public CoinCapService(IOptions<CoinCapApiOption> coinCupOptions)
        {
            _coinCupOptions = coinCupOptions.Value;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_coinCupOptions.Url);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<AssetsResponceApiModel> GetCryptocurrencesAsync(int limit)
        {
            var response = await _client.GetAsync($"assets?limit={limit}");
            if (!response.IsSuccessStatusCode)
                throw new Exception("Cannot get cryptocurrences!");

            try
            {
                var res = await response.Content.ReadAsStringAsync();
                var cryptocurrences = JsonConvert.DeserializeObject<AssetsResponceApiModel>(res);
                return cryptocurrences;
            }
            catch (Exception)
            {
                throw new Exception("Cannot get cryptocurrences!");
            }
        }

        public async Task<AssetsResponceApiModel> GetCryptocurrencesAsync(int limit, string search)
        {
            var response = await _client.GetAsync($"assets?limit={limit}&search={search}");
            if (!response.IsSuccessStatusCode)
                throw new Exception("Cannot get cryptocurrences!");

            try
            {
                var res = await response.Content.ReadAsStringAsync();
                var cryptocurrences = JsonConvert.DeserializeObject<AssetsResponceApiModel>(res);
                return cryptocurrences;
            }
            catch (Exception)
            {
                throw new Exception("Cannot get cryptocurrences!");
            }

        }

        public async Task<CandlesResponceApiModel> GetCandlesAsync(string exchange, string interval, string baseId, string quoteId)
        {
            var response = await _client.GetAsync($"candles?exchange={exchange}&interval={interval}&baseId={baseId}&quoteId={quoteId}");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Cannot get candles!");

            try
            {
                var res = await response.Content.ReadAsStringAsync();
                var candles = JsonConvert.DeserializeObject<CandlesResponceApiModel>(res);
                return candles;
            }
            catch (Exception)
            {
                throw new Exception("Cannot get candles!");
            }
        }

        public async Task<MarketsResponceApiModel> GetMarketApiModelsAsync(string idCryptocurrency)
        {
            var response = await _client.GetAsync($"assets/{idCryptocurrency}/markets?limit=50");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Cannot get markets!");
            try
            {
                var res = await response.Content.ReadAsStringAsync();
                var markets = JsonConvert.DeserializeObject<MarketsResponceApiModel>(res);
                return markets;
            }
            catch (Exception)
            {
                throw new Exception("Cannot get markets!");
            }
        }

        public async Task<ExchangesResponceByIdApiModel> GetExchangeApiModelsAsync(string idExchange)
        {
            var response = await _client.GetAsync($"exchanges/{idExchange}");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Cannot get market info!");

            try
            {
                var res = await response.Content.ReadAsStringAsync();
                var exchange = JsonConvert.DeserializeObject<ExchangesResponceByIdApiModel>(res);
                return exchange;
            }
            catch (Exception)
            {
                throw new Exception("Cannot get market info!");
            }
        }
    }
}