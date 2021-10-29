using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Server.Models.AlphaVantage
{
    public interface TickerInfo
    {
        public Shared.Models.TickerTimeSeries ToSharedTickerTimeSeries();
    }
}
