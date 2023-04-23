namespace Models.ViewModels
{
    public class MarketModel : BaseModel
    {
        private string _exchangeId;
        public string ExchangeId
        {
            get => _exchangeId;
            set => Set(ref _exchangeId, value);
        }

        private string _baseId;
        public string BaseId
        {
            get => _baseId;
            set => Set(ref _baseId, value);
        }

        private string _quoteId;
        public string QuoteId
        {
            get => _quoteId;
            set => Set(ref _quoteId, value);
        }


        private string _baseSymbol;
        public string BaseSymbol
        {
            get => _baseSymbol;
            set => Set(ref _baseSymbol, value);
        }

        private string _quoteSymbol;
        public string QuoteSymbol
        {
            get => _quoteSymbol;
            set => Set(ref _quoteSymbol, value);
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

        private string _volumePercent;
        public string VolumePercent
        {
            get => _volumePercent;
            set => Set(ref _volumePercent, value);
        }

        private string _rank;
        public string Rank
        {
            get => _rank;
            set => Set(ref _rank, value);
        }

        private string _percentTotalVolume;
        public string PercentTotalVolume
        {
            get => _percentTotalVolume;
            set => Set(ref _percentTotalVolume, value);
        }

        private string _volumeUsd;
        public string VolumeUsd
        {
            get => _volumeUsd;
            set => Set(ref _volumeUsd, value);
        }

        private string _tradingPairs;
        public string TradingPairs
        {
            get => _tradingPairs;
            set => Set(ref _tradingPairs, value);
        }

        private string _exchangeUrl;
        public string ExchangeUrl
        {
            get => _exchangeUrl;
            set => Set(ref _exchangeUrl, value);
        }
    }
}
