using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Stocks.Server.Models.AlphaVantage
{
    public class TickerInfoDailyAdjusted
    {
        [JsonPropertyName("Time Series (Daily)")]
        public Dictionary<DateTime, TickerDataPointAdjusted> TimeSeries { get; set; }

        public static implicit operator Shared.Models.TickerTimeSeries(TickerInfoDailyAdjusted tickerInfoWeekly)
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
