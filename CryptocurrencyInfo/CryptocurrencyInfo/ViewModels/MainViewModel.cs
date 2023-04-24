using BL.Services.Interfaces;
using CryptocurrencyInfo.Command;
using Microsoft.Extensions.Options;
using Models.SettingsModels;
using Models.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CryptocurrencyInfo.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        private readonly ApplicationOptions _applicationOptions;
        private readonly ICryptocurrencyService _service;

        public delegate Task SelectedLimitCryptocurrencyDelegate(int limit);
        public event SelectedLimitCryptocurrencyDelegate SelectedLimitCryptocurrencyEvent;

        private List<int> _limitCryptocurrencies;
        private string _searchBox;
        private ObservableCollection<CryptocurrencyModel> _cryptocurrencies;
        private CryptocurrencyModel _selectedCryptocurrency;
        private RelayCommand _addCommand;
        private int _selectedLimitCrypto;

        public List<int> LimitCryptocurrencies { get => _limitCryptocurrencies; set => Set(ref _limitCryptocurrencies, value); }
        public string SearchBox { get => _searchBox; set => Set(ref _searchBox, value); }
        public ObservableCollection<CryptocurrencyModel> Cryptocurrencies { get => _cryptocurrencies; set => Set(ref _cryptocurrencies, value); }
        public CryptocurrencyModel SelectedCryptocurrency { get => _selectedCryptocurrency; set => Set(ref _selectedCryptocurrency, value); }
        public int SelectedLimitCrypto
        {
            get => _selectedLimitCrypto;
            set
            {
                Set(ref _selectedLimitCrypto, value);
                SelectedLimitCryptocurrencyEvent?.Invoke(_selectedLimitCrypto);
            }
        }
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                  (_addCommand = new RelayCommand(obj =>
                  {
                      OnSearchCryptocurrency(_selectedLimitCrypto, SearchBox);
                  }));
            }
        }

        public MainViewModel()
        {
            _applicationOptions = App.ServiceProviderManager.GetService<IOptions<ApplicationOptions>>().Value;
            LimitCryptocurrencies = new List<int>(_applicationOptions.PaginationMenu);

            _service = App.ServiceProviderManager.GetService<ICryptocurrencyService>();
            SelectedLimitCryptocurrencyEvent += OnSelectedLimitCryptocurrency;
            OnSelectedLimitCryptocurrency(LimitCryptocurrencies.First());
        }

        public async Task OnSelectedLimitCryptocurrency(int limit)
        {
            try
            {
                Cryptocurrencies = new ObservableCollection<CryptocurrencyModel>(await _service.GetCryptocurrencesAsync(limit));
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public async Task OnSearchCryptocurrency(int limit, string id)
        {
            try
            {
                Cryptocurrencies = new ObservableCollection<CryptocurrencyModel>(await _service.GetCryptocurrencesAsync(limit, id));
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}