using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Stocks.Shared.Models
{
    public class TickerTimeSeries
    {

        public List<TickerDataPoint> TimeSeries { get; set; }

    }
}
