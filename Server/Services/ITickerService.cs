using Stocks.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Server.Services
{
    /// <summary>
    /// Ticker service
    /// </summary>
    public interface ITickerService
    {
        /// <summary>
        /// Get ticker daily adjusted time series
        /// </summary>
        /// <param name="tickername"></param>
        /// <returns>Ticker daily adjusted time series</returns>
        public Task<TickerTimeSeries> GetTickerDailyAdjustedAsync(string tickername);

        /// <summary>
        /// Get daily ticker time series
        /// </summary>
        /// <param name="tickername"></param>
        /// <returns>Ticker daily time series</returns>
        public Task<TickerTimeSeries> GetTickerDailyAsync(string tickername);

        /// <summary>
        /// Get ticker weekly adjusted time series
        /// </summary>
        /// <param name="tickername"></param>
        /// <returns>Ticker weekly adjusted time series</returns>
        public Task<TickerTimeSeries> GetTickerWeeklyAdjustedAsync(string tickername);

        /// <summary>
        /// Get ticker weekly time series
        /// </summary>
        /// <param name="tickername"></param>
        /// <returns>Ticker weekly time series</returns>
        public Task<TickerTimeSeries> GetTickerWeeklyAsync(string tickername);

        /// <summary>
        /// Get ticker monthly adjusted time series
        /// </summary>
        /// <param name="tickername"></param>
        /// <returns>Ticker monthly adjusted time series</returns>
        public Task<TickerTimeSeries> GetTickerMonthlyAdjustedAsync(string tickername);

        /// <summary>
        /// Get ticker monthly time series
        /// </summary>
        /// <param name="tickername"></param>
        /// <returns>Ticker monthly time series</returns>
        public Task<TickerTimeSeries> GetTickerMonthlyAsync(string tickername);
    }
}
