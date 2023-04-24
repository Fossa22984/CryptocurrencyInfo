using CryptocurrencyInfo.Managers.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CryptocurrencyInfo.Managers
{
    public class ServiceProviderManager : IServiceProviderManager
    {
        private readonly IServiceProvider _serviceProvider;
        public ServiceProviderManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T GetService<T>() where T : notnull
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                return scope.ServiceProvider.GetRequiredService<T>();
            }
        }
    }
}
