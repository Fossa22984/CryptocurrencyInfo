using Newtonsoft.Json;

namespace Models.CoinCapApiModels
{
    public class CandlesResponceApiModel
    {
        [JsonProperty("data")] public List<Candle> Candles { get; set; }
    }
    public class Candle
    {
        [JsonProperty("open")] public string Open { get; set; }
        [JsonProperty("high")] public string High { get; set; }
        [JsonProperty("low")] public string Low { get; set; }
        [JsonProperty("close")] public string Close { get; set; }
        [JsonProperty("volume")] public string Volume { get; set; }
        [JsonProperty("period")] public int Period { get; set; }
    }
}
