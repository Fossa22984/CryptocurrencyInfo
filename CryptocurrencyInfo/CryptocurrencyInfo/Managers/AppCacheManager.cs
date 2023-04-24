using Models.ViewModels;

namespace CryptocurrencyInfo.Managers
{
    public class AppCacheManager
    {
        public CryptocurrencyModel SelectedCryptocurrency { get; set; }
        public MarketModel SelectedMarket { get; set; }
    }
}