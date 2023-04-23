using BL.CoinCapApi.Services.Interfaces;
using Models.CoinCapApiModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace BL.CoinCapApi.Services
{
    public class CoinCapService : ICoinCapService
    {
        private readonly HttpClient _client;

        public CoinCapService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://api.coincap.io/v2/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<AssetsResponceApiModel> GetCryptocurrencesAsync(int limit)
        {
            var response = await _client.GetAsync($"assets?limit={limit}");
            if (!response.IsSuccessStatusCode)
                throw new Exception();

            try
            {
                var res = await response.Content.ReadAsStringAsync();
                var cryptocurrences = JsonConvert.DeserializeObject<AssetsResponceApiModel>(res);
                return cryptocurrences;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<AssetsResponceApiModel> GetCryptocurrencesAsync(int limit, string search)
        {
            var response = await _client.GetAsync($"assets?limit={limit}&search={search}");
            if (!response.IsSuccessStatusCode)
                throw new Exception();

            try
            {
                var res = await response.Content.ReadAsStringAsync();
                var cryptocurrences = JsonConvert.DeserializeObject<AssetsResponceApiModel>(res);
                return cryptocurrences;
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public async Task<CandlesResponceApiModel> GetCandlesAsync(string exchange, string interval, string baseId, string quoteId)
        {
            var response = await _client.GetAsync($"candles?exchange={exchange}&interval={interval}&baseId={baseId}&quoteId={quoteId}");

            if (!response.IsSuccessStatusCode)
                throw new Exception();

            try
            {
                var res = await response.Content.ReadAsStringAsync();
                var candles = JsonConvert.DeserializeObject<CandlesResponceApiModel>(res);
                return candles;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MarketsResponceApiModel> GetMarketApiModelsAsync(string idCryptocurrency)
        {
            var response = await _client.GetAsync($"assets/{idCryptocurrency}/markets?limit=50");

            if (!response.IsSuccessStatusCode)
                throw new Exception();
            try
            {
                var res = await response.Content.ReadAsStringAsync();
                var markets = JsonConvert.DeserializeObject<MarketsResponceApiModel>(res);
                return markets;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ExchangesResponceByIdApiModel> GetExchangeApiModelsAsync(string idExchange)
        {
            var response = await _client.GetAsync($"exchanges/{idExchange}");

            if (!response.IsSuccessStatusCode)
                throw new Exception();

            try
            {
                var res = await response.Content.ReadAsStringAsync();
                var exchange = JsonConvert.DeserializeObject<ExchangesResponceByIdApiModel>(res);
                return exchange;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}