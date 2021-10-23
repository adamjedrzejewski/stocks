using Stocks.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Stocks.Server.Services
{
    public class AlphaVantageTickerService : ITickerService
    {
        private readonly HttpClient _httpClient;

        public AlphaVantageTickerService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public Task<TickerInfo> GetTickerDailyAdjustedAsync(string tickername)
        {
            return GetTickerTimeSeries("TIME_SERIES_DAILY_ADJUSTED", tickername);
        }

        public Task<TickerInfo> GetTickerDailyAsync(string tickername)
        {
            return GetTickerTimeSeries("TIME_SERIES_DAILY", tickername);
        }

        public Task<TickerInfo> GetTickerMonthlyAdjustedAsync(string tickername)
        {
            return GetTickerTimeSeries("TIME_SERIES_MONTHLY_ADJUSTED", tickername);
        }

        public Task<TickerInfo> GetTickerMonthlyAsync(string tickername)
        {
            return GetTickerTimeSeries("TIME_SERIES_MONTHLY", tickername);
        }

        public Task<TickerInfo> GetTickerWeeklyAdjustedAsync(string tickername)
        {
            return GetTickerTimeSeries("TIME_SERIES_WEEKLY_ADJUSTED", tickername);
        }

        public Task<TickerInfo> GetTickerWeeklyAsync(string tickername)
        {
            return GetTickerTimeSeries("TIME_SERIES_WEEKLY", tickername);
        }

        private async Task<TickerInfo> GetTickerTimeSeries(string series, string tickername)
        {
            string QUERY_URL = $"https://www.alphavantage.co/query?function={series}&symbol=IBM&apikey=demo";
            var tickerInfo = await _httpClient.GetFromJsonAsync<TickerInfo>(QUERY_URL);
            return tickerInfo;
        }
    }
}
