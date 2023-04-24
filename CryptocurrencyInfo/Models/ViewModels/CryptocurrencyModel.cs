using System.Collections.ObjectModel;

namespace Models.ViewModels
{
    public class CryptocurrencyModel : BaseModel
    {
        private string _id;
        private string _rank;
        private string _symbol;
        private string _name;
        private string _supply;
        private string _maxSupply;
        private string _marketCapUsd;
        private string _volumeUsd24Hr;
        private string _priceUsd;
        private string _changePercent24Hr;
        private string _vwap24Hr;
        private ObservableCollection<MarketModel> _markets;

        public string Rank { get => _rank; set => Set(ref _rank, value); }
        public string Id { get => _id; set => Set(ref _id, value); }
        public string Symbol { get => _symbol; set => Set(ref _symbol, value); }
        public string Name { get => _name; set => Set(ref _name, value); }
        public string Supply { get => _supply; set => Set(ref _supply, value); }
        public string MaxSupply { get => _maxSupply; set => Set(ref _maxSupply, value); }
        public string MarketCapUsd { get => _marketCapUsd; set => Set(ref _marketCapUsd, value); }
        public string VolumeUsd24Hr { get => _volumeUsd24Hr; set => Set(ref _volumeUsd24Hr, value); }
        public string PriceUsd { get => _priceUsd; set => Set(ref _priceUsd, value); }
        public string ChangePercent24Hr { get => _changePercent24Hr; set => Set(ref _changePercent24Hr, value); }
        public string Vwap24Hr { get => _vwap24Hr; set => Set(ref _vwap24Hr, value); }
        public ObservableCollection<MarketModel> Markets { get => _markets; set => Set(ref _markets, value); }

        public CryptocurrencyModel()
        {
            Markets = new ObservableCollection<MarketModel>();
        }
    }
}