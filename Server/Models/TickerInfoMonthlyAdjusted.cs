using Stocks.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Stocks.Server.Models
{
    public class TickerInfoMonthlyAdjusted
    {
        [JsonPropertyName("Monthly Adjusted Time Series")]
        public Dictionary<DateTime, TickerDataPoint> TimeSeries { get; set; }

        public static implicit operator TickerInfo(TickerInfoMonthlyAdjusted tickerInfoWeekly)
            => new TickerInfo
            {
                TimeSeries = tickerInfoWeekly.TimeSeries
            };
    }
}
