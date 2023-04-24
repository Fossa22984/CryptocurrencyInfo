namespace Models.ViewModels
{
    public class MarketModel : BaseModel
    {
        private string _exchangeId;
        private string _baseId;
        private string _quoteId;
        private string _baseSymbol;
        private string _quoteSymbol;
        private string _priceUsd;
        private string _volumeUsd24Hr;
        private string _volumePercent;
        private string _percentTotalVolume;
        private string _rank;
        private string _volumeUsd;
        private string _tradingPairs;
        private string _exchangeUrl;


        public string ExchangeId { get => _exchangeId; set => Set(ref _exchangeId, value); }

        public string BaseId
        {
            get => _baseId;
            set => Set(ref _baseId, value);
        }

        public string QuoteId
        {
            get => _quoteId;
            set => Set(ref _quoteId, value);
        }


        public string BaseSymbol
        {
            get => _baseSymbol;
            set => Set(ref _baseSymbol, value);
        }

        public string QuoteSymbol
        {
            get => _quoteSymbol;
            set => Set(ref _quoteSymbol, value);
        }

        public string VolumeUsd24Hr
        {
            get => _volumeUsd24Hr;
            set => Set(ref _volumeUsd24Hr, value);
        }

        public string PriceUsd
        {
            get => _priceUsd;
            set => Set(ref _priceUsd, value);
        }

        public string VolumePercent
        {
            get => _volumePercent;
            set => Set(ref _volumePercent, value);
        }

        public string Rank
        {
            get => _rank;
            set => Set(ref _rank, value);
        }

        public string PercentTotalVolume
        {
            get => _percentTotalVolume;
            set => Set(ref _percentTotalVolume, value);
        }

        public string VolumeUsd{ get => _volumeUsd; set => Set(ref _volumeUsd, value); }

        public string TradingPairs
        {
            get => _tradingPairs;
            set => Set(ref _tradingPairs, value);
        }

        public string ExchangeUrl
        {
            get => _exchangeUrl;
            set => Set(ref _exchangeUrl, value);
        }
    }
}
