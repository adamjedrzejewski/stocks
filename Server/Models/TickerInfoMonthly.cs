using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Stocks.Shared.Models
{
    class TickerInfoMonthly
    {
        [JsonPropertyName("Monthly Time Series")]
        public Dictionary<DateTime, TickerDataPoint> TimeSeries { get; set; }

        public static implicit operator TickerInfo(TickerInfoMonthly tickerInfoWeekly)
            => new TickerInfo
            {
                TimeSeries = tickerInfoWeekly.TimeSeries
            };
    }
}
