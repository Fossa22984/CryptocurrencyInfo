using BL.CoinCapApi.Services;
using CryptocurrencyInfo.Command;
using Models.CoinCapApiModels;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyInfo.ViewModels
{
   public class MainViewModel : BaseViewModel
    {
        private readonly CoinCapService _service;

        public delegate Task SelectedLimitCryptocurrency(int limit);
        public event SelectedLimitCryptocurrency SelectedLimitCryptocurrencyEvent;

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

        private int _slectedLimitCryptocurrency;
        public int SlectedLimitCryptocurrency
        {
            get => _slectedLimitCryptocurrency;
            set
            {
                Set(ref _slectedLimitCryptocurrency, value);
                SelectedLimitCryptocurrencyEvent?.Invoke(_slectedLimitCryptocurrency);
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
            set
            {
                Set(ref _selectedCryptocurrency, value);
            }
        }

        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                  (_addCommand = new RelayCommand(obj =>
                  {
                      OnSearchCryptocurrency(_slectedLimitCryptocurrency, SearchBox);
                  }));
            }
        }

        public MainViewModel()
        {
            LimitCryptocurrencies = new List<int> { 10, 25, 50, 100 };

            _service = App.ServiceProviderManager.GetService<CoinCapService>();
            SelectedLimitCryptocurrencyEvent += OnSelectedLimitCryptocurrency;
            OnSelectedLimitCryptocurrency(LimitCryptocurrencies.First());
        }

        public async Task OnSelectedLimitCryptocurrency(int limit)
        {
            var res = new ObservableCollection<Cryptocurrency>((await _service.GetCryptocurrencesAsync(limit)).Cryptocurrencies);
            Cryptocurrencies = Mapper(res);
        }

        public async Task OnSearchCryptocurrency(int limit, string id)
        {
            var res = new ObservableCollection<Cryptocurrency>((await _service.GetCryptocurrencesAsync(limit, id)).Cryptocurrencies);
            Cryptocurrencies = Mapper(res); 
       }

        private ObservableCollection<CryptocurrencyModel> Mapper(ObservableCollection<Cryptocurrency> cryptocurrencies) {
           var res = new ObservableCollection<CryptocurrencyModel>();

            foreach (var item in cryptocurrencies)
            {
                res.Add(new CryptocurrencyModel()
                {
                    Id = item.Id,
                    Rank = item.Rank,
                    Symbol = item.Symbol,
                    Name = item.Name,
                    Supply = item.Supply,
                    MaxSupply = item.MaxSupply,
                    MarketCapUsd = item.MarketCapUsd,
                    VolumeUsd24Hr = item.VolumeUsd24Hr,
                    PriceUsd = item.PriceUsd,
                    ChangePercent24Hr = item.ChangePercent24Hr,
                    Vwap24Hr = item.Vwap24Hr
                });
            }
            return res;
        }
    }
}