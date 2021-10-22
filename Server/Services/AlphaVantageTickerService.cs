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

        public async Task<TickerInfo> GetTickerDailyAdjustedAsync(string tickername)
        {
            string QUERY_URL = "https://www.alphavantage.co/query?function=TIME_SERIES_DAILY_ADJUSTED&symbol=IBM&apikey=demo";
            var tickerInfo = await _httpClient.GetFromJsonAsync<TickerInfo>(QUERY_URL);
            return tickerInfo;
        }
    }
}
