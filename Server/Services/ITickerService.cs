using Stocks.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Server.Services
{
    public interface ITickerService
    {
#nullable enable
        public Task<TickerTimeSeries> GetTickerDailyAdjustedAsync(string tickername);
        public Task<TickerTimeSeries> GetTickerDailyAsync(string tickername);

        public Task<TickerTimeSeries> GetTickerWeeklyAdjustedAsync(string tickername);
        public Task<TickerTimeSeries> GetTickerWeeklyAsync(string tickername);

        public Task<TickerTimeSeries> GetTickerMonthlyAdjustedAsync(string tickername);
        public Task<TickerTimeSeries> GetTickerMonthlyAsync(string tickername);
    }
}
