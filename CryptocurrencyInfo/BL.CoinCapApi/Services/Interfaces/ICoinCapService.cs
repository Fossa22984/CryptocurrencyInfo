using Models.CoinCapApiModels;

namespace BL.CoinCapApi.Services.Interfaces
{
    public interface ICoinCapService
    {
        Task<AssetsResponceApiModel> GetCryptocurrencesAsync(int limit);
        Task<AssetsResponceApiModel> GetCryptocurrencesAsync(int limit, string search);
        Task<CandlesResponceApiModel> GetCandlesAsync(string exchange, string interval, string baseId, string quoteId);
        Task<MarketsResponceApiModel> GetMarketApiModelsAsync(string idCryptocurrency);
        Task<ExchangesResponceByIdApiModel> GetExchangeApiModelsAsync(string idExchange);

    }
}
