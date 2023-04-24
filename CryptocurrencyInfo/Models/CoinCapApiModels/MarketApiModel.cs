using Newtonsoft.Json;

namespace Models.CoinCapApiModels
{
    public class MarketsResponceApiModel
    {
        [JsonProperty("data")] public List<MarketApiModel> Markets { get; set; }
    }
    public class MarketApiModel
    {
        [JsonProperty("exchangeId")] public string ExchangeId { get; set; }
        [JsonProperty("baseId")] public string BaseId { get; set; }
        [JsonProperty("quoteId")] public string QuoteId { get; set; }
        [JsonProperty("baseSymbol")] public string BaseSymbol { get; set; }
        [JsonProperty("quoteSymbol")] public string QuoteSymbol { get; set; }
        [JsonProperty("volumeUsd24Hr")] public string VolumeUsd24Hr { get; set; }
        [JsonProperty("priceUsd")] public string PriceUsd { get; set; }
        [JsonProperty("volumePercent")] public string VolumePercent { get; set; }
    }
}
