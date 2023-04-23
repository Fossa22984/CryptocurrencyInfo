using System.Collections.ObjectModel;

namespace Models.ViewModels
{
    public class CryptocurrencyModel : BaseModel
    {
        private string _id;
        public string Id
        {
            get => _id;
            set => Set(ref _id, value);
        }


        private string _rank;
        public string Rank
        {
            get => _rank;
            set => Set(ref _rank, value);
        }

        private string _symbol;
        public string Symbol
        {
            get => _symbol;
            set => Set(ref _symbol, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        private string _supply;
        public string Supply
        {
            get => _supply;
            set => Set(ref _supply, value);
        }

        private string _maxSupply;
        public string MaxSupply
        {
            get => _maxSupply;
            set => Set(ref _maxSupply, value);
        }

        private string _marketCapUsd;
        public string MarketCapUsd
        {
            get => _marketCapUsd;
            set => Set(ref _marketCapUsd, value);
        }

        private string _volumeUsd24Hr;
        public string VolumeUsd24Hr
        {
            get => _volumeUsd24Hr;
            set => Set(ref _volumeUsd24Hr, value);
        }

        private string _priceUsd;
        public string PriceUsd
        {
            get => _priceUsd;
            set => Set(ref _priceUsd, value);
        }

        private string _changePercent24Hr;
        public string ChangePercent24Hr
        {
            get => _changePercent24Hr;
            set => Set(ref _changePercent24Hr, value);
        }

        private string _vwap24Hr;
        public string Vwap24Hr
        {
            get => _vwap24Hr;
            set => Set(ref _vwap24Hr, value);
        }

        private ObservableCollection<MarketModel> _markets;
        public ObservableCollection<MarketModel> Markets
        {
            get => _markets;
            set => Set(ref _markets, value);
        }

        //public ObservableCollection<Candle> Candles { get; set; }
        public CryptocurrencyModel()
        {
            //Candles = new ObservableCollection<Candle>();
            Markets = new ObservableCollection<MarketModel>();
        }
    }
}