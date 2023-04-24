using AutoMapper;
using BL.CoinCapApi.Services;
using BL.CoinCapApi.Services.Interfaces;
using BL.Services;
using BL.Services.Interfaces;
using CryptocurrencyInfo.Config;
using CryptocurrencyInfo.Managers;
using CryptocurrencyInfo.Managers.Interfaces;
using CryptocurrencyInfo.Pages;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace CryptocurrencyInfo
{
    public partial class App : Application
    {
        public static IServiceProviderManager ServiceProviderManager { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigrationService(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            ServiceProviderManager = serviceProvider.GetRequiredService<IServiceProviderManager>();

            serviceProvider.GetRequiredService<MainWindow>().Show();
        }
        private void ConfigrationService(IServiceCollection service)
        {
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
