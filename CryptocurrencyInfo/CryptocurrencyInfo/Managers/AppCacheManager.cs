using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyInfo.Managers
{
    public class AppCacheManager
    {
        public CryptocurrencyModel SelectedCryptocurrency { get; set; }
        public MarketModel SelectedMarket { get; set; }
    }
}