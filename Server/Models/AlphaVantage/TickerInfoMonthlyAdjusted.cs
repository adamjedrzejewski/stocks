using Stocks.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Stocks.Server.Models.AlphaVantage
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class TickerInfoMonthlyAdjusted : TickerInfo
    {
        [JsonPropertyName("Monthly Adjusted Time Series")]
        public Dictionary<DateTime, TickerDataPointAdjusted> TimeSeries { get; set; }

        public TickerTimeSeries ToSharedTickerTimeSeries()
            => this;

        public static implicit operator Shared.Models.TickerTimeSeries(TickerInfoMonthlyAdjusted tickerInfoWeekly)
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
