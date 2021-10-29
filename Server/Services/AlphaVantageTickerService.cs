using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Stocks.Server.Models.AlphaVantage;

namespace Stocks.Server.Services
{

#nullable enable
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

        public async Task<Shared.Models.TickerTimeSeries?> GetTickerDailyAdjustedAsync(string tickername)
        {
            return await GetTickerTimeSeries<TickerInfoDailyAdjusted>("TIME_SERIES_DAILY_ADJUSTED", tickername);
        }

        public async Task<Shared.Models.TickerTimeSeries?> GetTickerDailyAsync(string tickername)
        {
            return await GetTickerTimeSeries<TickerInfoDaily>("TIME_SERIES_DAILY", tickername);
        }

        public async Task<Shared.Models.TickerTimeSeries?> GetTickerMonthlyAdjustedAsync(string tickername)
        {
            return await GetTickerTimeSeries<TickerInfoMonthlyAdjusted>("TIME_SERIES_MONTHLY_ADJUSTED", tickername);
        }

        public async Task<Shared.Models.TickerTimeSeries?> GetTickerMonthlyAsync(string tickername)
        {
            return await GetTickerTimeSeries<TickerInfoMonthly>("TIME_SERIES_MONTHLY", tickername);
        }

        public async Task<Shared.Models.TickerTimeSeries?> GetTickerWeeklyAdjustedAsync(string tickername)
        {
            return await GetTickerTimeSeries<TickerInfoWeeklyAdjusted>("TIME_SERIES_WEEKLY_ADJUSTED", tickername);
        }

        public async Task<Shared.Models.TickerTimeSeries?> GetTickerWeeklyAsync(string tickername)
        {
            return await GetTickerTimeSeries<TickerInfoWeekly>("TIME_SERIES_WEEKLY", tickername);
        }

        private async Task<Shared.Models.TickerTimeSeries?> GetTickerTimeSeries<T>(string series, string tickername) where T : TickerInfo
        {
            try
            {
                string QUERY_URL = $"https://www.alphavantage.co/query?function={series}&symbol={tickername}&apikey={_apiKey}";
                var tickerInfo = await _httpClient.GetFromJsonAsync<T>(QUERY_URL);
                return tickerInfo?.ToSharedTickerTimeSeries();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
