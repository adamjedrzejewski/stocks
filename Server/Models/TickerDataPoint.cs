using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Stocks.Server.Models
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
