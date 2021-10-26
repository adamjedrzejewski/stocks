using Microsoft.Extensions.Configuration;
using Stocks.Server.Models;
using Stocks.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Stocks.Server.Services
{
    // TODO: store backups in database
    public class AlphaVantageTickerService : ITickerService
    {
        private readonly HttpClient _httpClient;
        private readonly String _apiKey;

        public AlphaVantageTickerService(HttpClient httpClient, IConfiguration config)
        {
            this._httpClient = httpClient;
            this._apiKey = config["AlphaVantageServiceApiKey"];
        }

        public async Task<TickerTimeSeries> GetTickerDailyAdjustedAsync(string tickername)
        {
            return await GetTickerTimeSeries<TickerInfoDaily>("TIME_SERIES_DAILY_ADJUSTED", tickername);
        }

        public async Task<TickerTimeSeries> GetTickerDailyAsync(string tickername)
        {
            return await GetTickerTimeSeries<TickerInfoDaily>("TIME_SERIES_DAILY", tickername);
        }

        public async Task<TickerTimeSeries> GetTickerMonthlyAdjustedAsync(string tickername)
        {
            return await GetTickerTimeSeries<TickerInfoMonthlyAdjusted>("TIME_SERIES_MONTHLY_ADJUSTED", tickername);
        }

        public async Task<TickerTimeSeries> GetTickerMonthlyAsync(string tickername)
        {
            return await GetTickerTimeSeries<TickerInfoMonthly>("TIME_SERIES_MONTHLY", tickername);
        }

        public async Task<TickerTimeSeries> GetTickerWeeklyAdjustedAsync(string tickername)
        {
            return await GetTickerTimeSeries<TickerInfoWeeklyAdjusted>("TIME_SERIES_WEEKLY_ADJUSTED", tickername);
        }

        public async Task<TickerTimeSeries> GetTickerWeeklyAsync(string tickername)
        {
            return await GetTickerTimeSeries<TickerInfoWeekly>("TIME_SERIES_WEEKLY", tickername);
        }

        private async Task<T> GetTickerTimeSeries<T>(string series, string tickername)
        {
            string QUERY_URL = $"https://www.alphavantage.co/query?function={series}&symbol={tickername}&apikey={_apiKey}";
            var tickerInfo = await _httpClient.GetFromJsonAsync<T>(QUERY_URL);
            return tickerInfo;
        }
    }
}
