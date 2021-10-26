using Stocks.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Stocks.Server.Models
{
    public class TickerInfoWeeklyAdjusted
    {
        [JsonPropertyName("Weekly Adjusted Time Series")]
        public Dictionary<DateTime, Server.Models.TickerDataPointAdjusted> TimeSeries { get; set; }

        public static implicit operator TickerTimeSeries(TickerInfoWeeklyAdjusted tickerInfoWeekly)
            => new Shared.Models.TickerTimeSeries
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
