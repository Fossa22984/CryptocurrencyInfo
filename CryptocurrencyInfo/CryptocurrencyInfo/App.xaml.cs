using BL.CoinCapApi.Services;
using BL.CoinCapApi.Services.Interfaces;
using BL.Services;
using BL.Services.Interfaces;
using CryptocurrencyInfo.Config;
using CryptocurrencyInfo.Managers;
using CryptocurrencyInfo.Managers.Interfaces;
using CryptocurrencyInfo.Pages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models.SettingsModels;
using System.Windows;

namespace CryptocurrencyInfo
{
    public partial class App : Application
    {
        public static IServiceProviderManager ServiceProviderManager { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var serviceCollection = new ServiceCollection();
            var diConfiguration = new DIConfiguration();
            diConfiguration.RegisterAll(ref serviceCollection, config);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            ServiceProviderManager = serviceProvider.GetRequiredService<IServiceProviderManager>();

            serviceProvider.GetRequiredService<MainWindow>().Show();
        }
    }
}
