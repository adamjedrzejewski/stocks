using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Stocks.Server.Models.AlphaVantage
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class Ticker
    {

        [JsonPropertyName("Time Series")]
        public Dictionary<DateTime, TickerDataPoint> TimeSeries { get; set; }

    }
}
