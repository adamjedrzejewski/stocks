using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Stocks.Server.Models
{
    public class Ticker
    {

        [JsonPropertyName("Time Series")]
        public Dictionary<DateTime, TickerDataPoint> TimeSeries { get; set; }

    }
}
