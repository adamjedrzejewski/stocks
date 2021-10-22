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
    }
}
