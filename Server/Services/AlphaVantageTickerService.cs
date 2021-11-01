using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Stocks.Server.Models.AlphaVantage;
using Stocks.Server.Models;
using System.Linq;

namespace Stocks.Server.Services
{

#nullable enable
    /// <summary>
    /// Ticker serivce for Alpha Vantage
    /// </summary>
    public class AlphaVantageTickerService : ITickerService
    {
        private readonly IDatabaseService _databaseService;
        private readonly HttpClient _httpClient;
        private readonly String _apiKey;

        /// <summary>
        /// Construct new instance of AlphaVantageTickerService
        /// </summary>
        /// <param name="databaseService"></param>
        /// <param name="httpClient"></param>
        /// <param name="config"></param>
        public AlphaVantageTickerService(IDatabaseService databaseService, HttpClient httpClient, IConfiguration config)
        {
            this._databaseService = databaseService;
            this._httpClient = httpClient;
            this._apiKey = config["AlphaVantageServiceApiKey"];
        }

        /// <summary>
        /// Get ticker daily adjusted time series
        /// </summary>
        /// <param name="tickername"></param>
        /// <returns>Ticker daily adjusted time series</returns>
        public async Task<Shared.Models.TickerTimeSeries> GetTickerDailyAdjustedAsync(string tickername)
        {
            return await GetTickerTimeSeriesAsync<TickerInfoDailyAdjusted>(TimeSeries.DAILY_ADJUSTED, tickername);
        }

        /// <summary>
        /// Get daily ticker time series
        /// </summary>
        /// <param name="tickername"></param>
        /// <returns>Ticker daily time series</returns>
        public async Task<Shared.Models.TickerTimeSeries> GetTickerDailyAsync(string tickername)
        {
            return await GetTickerTimeSeriesAsync<TickerInfoDaily>(TimeSeries.DAILY, tickername);
        }

        /// <summary>
        /// Get ticker monthly adjusted time series
        /// </summary>
        /// <param name="tickername"></param>
        /// <returns>Ticker monthly adjusted time series</returns>
        public async Task<Shared.Models.TickerTimeSeries> GetTickerMonthlyAdjustedAsync(string tickername)
        {
            return await GetTickerTimeSeriesAsync<TickerInfoMonthlyAdjusted>(TimeSeries.MONTHLY_ADJUSTED, tickername);
        }

        /// <summary>
        /// Get ticker monthly time series
        /// </summary>
        /// <param name="tickername"></param>
        /// <returns>Ticker monthly time series</returns>
        public async Task<Shared.Models.TickerTimeSeries> GetTickerMonthlyAsync(string tickername)
        {
            return await GetTickerTimeSeriesAsync<TickerInfoMonthly>(TimeSeries.MONTHLY, tickername);
        }

        /// <summary>
        /// Get ticker weekly adjusted time series
        /// </summary>
        /// <param name="tickername"></param>
        /// <returns>Ticker weekly adjusted time series</returns>
        public async Task<Shared.Models.TickerTimeSeries> GetTickerWeeklyAdjustedAsync(string tickername)
        {
            return await GetTickerTimeSeriesAsync<TickerInfoWeeklyAdjusted>(TimeSeries.WEEKLY_ADJUSTED, tickername);
        }

        /// <summary>
        /// Get ticker weekly time series
        /// </summary>
        /// <param name="tickername"></param>
        /// <returns>Ticker weekly time series</returns>
        public async Task<Shared.Models.TickerTimeSeries> GetTickerWeeklyAsync(string tickername)
        {
            return await GetTickerTimeSeriesAsync<TickerInfoWeekly>(TimeSeries.WEEKLY, tickername);
        }

        private async Task<Shared.Models.TickerTimeSeries> GetTickerTimeSeriesAsync<T>(TimeSeries series, string tickername) where T : TickerInfo
        {
            var tickerSeries = await GetTickerTimeSeriesFromAPIAsync<T>(series, tickername);

            // if the api call fails use data stored in database instead
            if (tickerSeries != null)
            {
                // will be used in future, when api doesn't deliver
                await SaveSeriesToDatabaseAsync(tickerSeries, series, tickername);
                return tickerSeries;
            }
            else
            {
                return await GetSeriesFromDatabaseAsync(series, tickername);
            }
        }

        private async Task SaveSeriesToDatabaseAsync(Shared.Models.TickerTimeSeries tickerSeries, TimeSeries series, string tickername)
        {
            var dtoSeries = tickerSeries.TimeSeries.Select(e => new Models.DTO.TickerDataPoint
            {
                Close = e.Close,
                Open = e.Open,
                Date = e.Date,
                High = e.High,
                Low = e.Low,
                Volume = e.Volume,
                TickerName = tickername,
                SeriesName = series.SeriesStringName()
            }).ToArray();
            await _databaseService.UpdateTickerDataPointAsync(dtoSeries);
        }

        private async Task<Shared.Models.TickerTimeSeries> GetSeriesFromDatabaseAsync(TimeSeries series, string tickername)
        {
            var dtoSeries = await _databaseService.GetTickerTimeSeriesAsync(tickername, series);
            var seriesList = dtoSeries.Select(e => (Shared.Models.TickerDataPoint)e).ToList();
            return new Shared.Models.TickerTimeSeries()
            {
                TimeSeries = seriesList
            };
        }

        // try to get data from api
        private async Task<Shared.Models.TickerTimeSeries?> GetTickerTimeSeriesFromAPIAsync<T>(TimeSeries series, string tickername) where T : TickerInfo
        {
            try
            {
                string seriesName = series.SeriesStringName();
                string QUERY_URL = $"https://www.alphavantage.co/query?function={seriesName}&symbol={tickername}&apikey={_apiKey}";
                var tickerInfo = await _httpClient.GetFromJsonAsync<T>(QUERY_URL);
                return tickerInfo?.ToSharedTickerTimeSeries();
            }
            catch (Exception) // api may not answer with correct schema, limits per unit of time
            {
                return null;
            }
        }
    }
}
