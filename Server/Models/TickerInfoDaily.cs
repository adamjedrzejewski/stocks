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
        public Dictionary<DateTime, TickerDataPoint> TimeSeries { get; set; }

        public static implicit operator TickerInfo(TickerInfoDaily tickerInfoWeekly)
            => new TickerInfo
            {
                TimeSeries = tickerInfoWeekly.TimeSeries
            };
    }
}
