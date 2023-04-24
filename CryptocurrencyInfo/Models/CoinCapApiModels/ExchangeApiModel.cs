using Newtonsoft.Json;

namespace Models.CoinCapApiModels
{
    public class ExchangesResponceByIdApiModel
    {
        [JsonProperty("data")] public ExchangeApiModel Exchange { get; set; }
    }
    public class ExchangeApiModel
    {
        [JsonProperty("exchangeId")] public string Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("rank")] public string Rank { get; set; }
        [JsonProperty("percentTotalVolume")] public string PercentTotalVolume { get; set; }
        [JsonProperty("volumeUsd")] public string VolumeUsd { get; set; }
        [JsonProperty("tradingPairs")] public string TradingPairs { get; set; }
        [JsonProperty("exchangeUrl")] public string ExchangeUrl { get; set; }
    }
}
