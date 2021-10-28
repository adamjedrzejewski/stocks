using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Stocks.Server.Models.AlphaVantage
{
    public class Ticker
    {

        [JsonPropertyName("Time Series")]
        public Dictionary<DateTime, TickerDataPoint> TimeSeries { get; set; }

    }
}
