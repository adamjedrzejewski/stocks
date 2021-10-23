using Stocks.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Server.Services
{
    public interface ITickerService
    {
        public Task<TickerInfo> GetTickerDailyAdjustedAsync(string tickername);
        public Task<TickerInfo> GetTickerDailyAsync(string tickername);

        public Task<TickerInfo> GetTickerWeeklyAdjustedAsync(string tickername);
        public Task<TickerInfo> GetTickerWeeklyAsync(string tickername);

        public Task<TickerInfo> GetTickerMonthlyAdjustedAsync(string tickername);
        public Task<TickerInfo> GetTickerMonthlyAsync(string tickername);
    }
}
