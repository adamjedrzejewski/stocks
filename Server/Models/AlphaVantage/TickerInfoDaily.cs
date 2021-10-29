using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Stocks.Server.Models.AlphaVantage
{
    public class TickerInfoDaily : TickerInfo
    {
        [JsonPropertyName("Time Series (Daily)")]
        public Dictionary<DateTime, TickerDataPoint> TimeSeries { get; set; }

        public Shared.Models.TickerTimeSeries ToSharedTickerTimeSeries()
            => (Shared.Models.TickerTimeSeries) this;

        public static implicit operator Shared.Models.TickerTimeSeries(TickerInfoDaily tickerInfoWeekly)
            => new()
            {
                TimeSeries = tickerInfoWeekly.TimeSeries.Select(k =>
                    new Shared.Models.TickerDataPoint
                    {
                        Open = k.Value.Open,
                        Close = k.Value.Close,
                        High = k.Value.High,
                        Low = k.Value.Low,
                        Date = k.Key,
                        Volume = k.Value.Volume
                    }).ToList()
            };
    }
}
