using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Stocks.Shared.Models
{
    class TickerInfoDaily
    {
        [JsonPropertyName("Time Series (Daily)")]
        public Dictionary<DateTime, Server.Models.TickerDataPoint> TimeSeries { get; set; }

        public static implicit operator TickerTimeSeries(TickerInfoDaily tickerInfoWeekly)
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
