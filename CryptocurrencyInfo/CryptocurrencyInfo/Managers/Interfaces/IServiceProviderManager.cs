namespace CryptocurrencyInfo.Managers.Interfaces
{
    public interface IServiceProviderManager
    {
        T GetService<T>() where T : notnull;
    }
}
