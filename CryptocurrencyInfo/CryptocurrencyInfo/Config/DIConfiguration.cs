using BL.CoinCapApi.Services.Interfaces;
using BL.CoinCapApi.Services;
using BL.Services.Interfaces;
using BL.Services;
using CryptocurrencyInfo.Managers.Interfaces;
using CryptocurrencyInfo.Managers;
using CryptocurrencyInfo.Pages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models.SettingsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyInfo.Config
{
    public class DIConfiguration
    {
        public void RegisterAll(ref ServiceCollection service, IConfiguration configuration)
        {
            service.Configure<CoinCapApiOption>(configuration.GetSection("CoinCapApiOptions"));
            service.Configure<ApplicationOptions>(configuration.GetSection("ApplicationOptions"));

            service.AddTransient(typeof(MainWindow));
            service.AddTransient(typeof(MainPage));
            service.AddTransient(typeof(CryptocurrencyInfoPage));
            service.AddTransient(typeof(MarketInfoPage));
            service.AddSingleton(typeof(AppCacheManager));

            service.AddSingleton<IServiceProviderManager, ServiceProviderManager>();

            service.AddTransient<ICoinCapService, CoinCapService>();
            service.AddTransient<ICryptocurrencyService, CryptocurrencyService>();

            service.AddSingleton(AutoMapperProfile.GetMapper());
        }
    }
}
