using BL.Services.Interfaces;
using Models.ViewModels;
using System.Threading.Tasks;
using System.Windows;

namespace CryptocurrencyInfo.ViewModels
{
    public class MarketInfoViewModel : BaseViewModel
    {
        private readonly ICryptocurrencyService _service;

        private MarketModel _selectedMarket;
        public MarketModel SelectedMarket { get => _selectedMarket; set => Set(ref _selectedMarket, value); }

        public MarketInfoViewModel(MarketModel m)
        {
            SelectedMarket = m;
            _service = App.ServiceProviderManager.GetService<ICryptocurrencyService>();
            Task.Run(async () => await GetMarket());
        }

        public async Task GetMarket()
        {
            try
            {
                SelectedMarket = await _service.GetMarketAsync(SelectedMarket);
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
