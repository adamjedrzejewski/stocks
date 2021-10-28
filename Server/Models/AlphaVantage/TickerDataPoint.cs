using System.Text.Json.Serialization;

namespace Stocks.Server.Models.AlphaVantage
{
    public class TickerDataPoint
    {
        [JsonPropertyName("1. open")]
        public float Open { get; set; }

        [JsonPropertyName("2. high")]
        public float High { get; set; }

        [JsonPropertyName("3. low")]
        public float Low { get; set; }

        [JsonPropertyName("4. close")]
        public float Close { get; set; }

        [JsonPropertyName("5. volume")]
        public decimal Volume { get; set; }
    }
}
