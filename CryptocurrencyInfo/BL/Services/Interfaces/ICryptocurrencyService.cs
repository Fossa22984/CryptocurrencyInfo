using Models.ViewModels;

namespace BL.Services.Interfaces
{
    public interface ICryptocurrencyService
    {
        Task<IEnumerable<CryptocurrencyModel>> GetCryptocurrencesAsync(int limit);
        Task<IEnumerable<CryptocurrencyModel>> GetCryptocurrencesAsync(int limit, string id);
        Task<IEnumerable<MarketModel>> GetMarketsAsync(string id);
        Task<MarketModel> GetMarketAsync(MarketModel market);
    }
}
