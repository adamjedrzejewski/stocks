using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Stocks.Server.Models
{
    public class TickerDataPointAdjusted
    {
        [JsonPropertyName("1. open")]
        public float Open { get; set; }

        [JsonPropertyName("2. high")]
        public float High { get; set; }

        [JsonPropertyName("3. low")]
        public float Low { get; set; }

        [JsonPropertyName("4. close")]
        public float Close { get; set; }

        [JsonPropertyName("5. adjusted close")]
        public float AdjustedClose { get; set; }

        [JsonPropertyName("6. volume")]
        public long Volume { get; set; }

        [JsonPropertyName("7. dividend amount")]
        public float DividendAmount { get; set; }

        [JsonPropertyName("8. split coefficient")]
        public float SplitCoefficient { get; set; }
    }
}
