using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Server.Models.AlphaVantage
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public interface TickerInfo
    {
        public Shared.Models.TickerTimeSeries ToSharedTickerTimeSeries();
    }
}
