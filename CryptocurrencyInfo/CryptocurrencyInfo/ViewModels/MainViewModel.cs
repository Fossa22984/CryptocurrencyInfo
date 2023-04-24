using BL.CoinCapApi.Services;
using BL.Services.Interfaces;
using CryptocurrencyInfo.Command;
using Models.CoinCapApiModels;
using Models.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CryptocurrencyInfo.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ICryptocurrencyService _service;

        public delegate Task SelectedLimitCryptocurrencyDelegate(int limit);
        public event SelectedLimitCryptocurrencyDelegate SelectedLimitCryptocurrencyEvent;

        private List<int> _limitCryptocurrencies;
        public List<int> LimitCryptocurrencies
        {
            get => _limitCryptocurrencies;
            set => Set(ref _limitCryptocurrencies, value);
        }

        private string _searchBox;
        public string SearchBox
        {
            get => _searchBox;
            set => Set(ref _searchBox, value);
        }

        private int _selectedLimitCrypto;
        public int SelectedLimitCrypto
        {
            get => _selectedLimitCrypto;
            set
            {
                Set(ref _selectedLimitCrypto, value);
                SelectedLimitCryptocurrencyEvent?.Invoke(_selectedLimitCrypto);
            }
        }

        private ObservableCollection<CryptocurrencyModel> _cryptocurrencies;
        public ObservableCollection<CryptocurrencyModel> Cryptocurrencies
        {
            get => _cryptocurrencies;
            set => Set(ref _cryptocurrencies, value);
        }

        private CryptocurrencyModel _selectedCryptocurrency;
        public CryptocurrencyModel SelectedCryptocurrency
        {
            get => _selectedCryptocurrency;
            set => Set(ref _selectedCryptocurrency, value);
        }

        private RelayCommand _addCommand;
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
            LimitCryptocurrencies = new List<int> { 10, 25, 50, 100 };

            _service = App.ServiceProviderManager.GetService<ICryptocurrencyService>();
            SelectedLimitCryptocurrencyEvent += OnSelectedLimitCryptocurrency;
            OnSelectedLimitCryptocurrency(LimitCryptocurrencies.First());
        }

        public async Task OnSelectedLimitCryptocurrency(int limit)
        {
            Cryptocurrencies = new ObservableCollection<CryptocurrencyModel>(await _service.GetCryptocurrencesAsync(limit));
        }

        public async Task OnSearchCryptocurrency(int limit, string id)
        {
            Cryptocurrencies = new ObservableCollection<CryptocurrencyModel>(await _service.GetCryptocurrencesAsync(limit, id));
        }
    }
}