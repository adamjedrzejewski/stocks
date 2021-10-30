using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stocks.Server.Models;
using Stocks.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Server.Controllers
{
    // TODO: don't repeat yourself
    [Route("api/ticker")]
    [ApiController]
    public class TickerController : ControllerBase
    {
        private readonly IDatabaseService _databaseService;
        private readonly ITickerService _tickerService;

        public TickerController(IDatabaseService databaseService, ITickerService tickerService)
        {
            this._databaseService = databaseService;
            this._tickerService = tickerService;
        }

        [HttpGet("{tickerName}/daily/adjusted")]
        public async Task<ActionResult<Shared.Models.TickerTimeSeries>> GetTickerDailyAdjustedAsync(string tickername)
        {
            var value = await _tickerService.GetTickerDailyAdjustedAsync(tickername);
            if (value != null)
            {
                var series = value.TimeSeries.Select(e => new Models.DTO.TickerDataPoint
                {
                    Close = e.Close,
                    Open = e.Open,
                    Date = e.Date,
                    High = e.High,
                    Low = e.Low,
                    Volume = e.Volume,
                    TickerName = tickername,
                    SeriesName = TimeSeries.DAILY_ADJUSTED.SeriesStringName()
                }).ToArray();
                await _databaseService.UpdateTickerDataPoint(series);
                return value;
            }
            else
            {
                var series = await _databaseService.GetTickerTimeSeries(tickername, Models.TimeSeries.DAILY_ADJUSTED);
                var seriesList = series.Select(e => (Shared.Models.TickerDataPoint) e).ToList();
                return new Shared.Models.TickerTimeSeries()
                { 
                    TimeSeries = seriesList
                };
            }
        }

        [HttpGet("{tickerName}/daily")]
        public async Task<ActionResult<Shared.Models.TickerTimeSeries>> GetTickerDailyAsync(string tickername)
        {
            var value = await _tickerService.GetTickerDailyAsync(tickername);
            if (value != null)
            {
                var series = value.TimeSeries.Select(e => new Models.DTO.TickerDataPoint
                {
                    Close = e.Close,
                    Open = e.Open,
                    Date = e.Date,
                    High = e.High,
                    Low = e.Low,
                    Volume = e.Volume,
                    TickerName = tickername,
                    SeriesName = TimeSeries.DAILY.SeriesStringName()
                }).ToArray();
                await _databaseService.UpdateTickerDataPoint(series);
                return value;
            }
            else
            {
                var series = await _databaseService.GetTickerTimeSeries(tickername, Models.TimeSeries.DAILY);
                var seriesList = series.Select(e => (Shared.Models.TickerDataPoint)e).ToList();
                return new Shared.Models.TickerTimeSeries()
                {
                    TimeSeries = seriesList
                };
            }
        }

        [HttpGet("{tickerName}/weekly/adjusted")]
        public async Task<ActionResult<Shared.Models.TickerTimeSeries>> GetTickerWeeklyAdjustedAsync(string tickername)
        {
            var value = await _tickerService.GetTickerWeeklyAdjustedAsync(tickername);
            if (value != null)
            {
                var series = value.TimeSeries.Select(e => new Models.DTO.TickerDataPoint
                {
                    Close = e.Close,
                    Open = e.Open,
                    Date = e.Date,
                    High = e.High,
                    Low = e.Low,
                    Volume = e.Volume,
                    TickerName = tickername,
                    SeriesName = TimeSeries.WEEKLY_ADJUSTED.SeriesStringName()
                }).ToArray();
                await _databaseService.UpdateTickerDataPoint(series);
                return value;
            }
            else
            {
                var series = await _databaseService.GetTickerTimeSeries(tickername, Models.TimeSeries.WEEKLY_ADJUSTED);
                var seriesList = series.Select(e => (Shared.Models.TickerDataPoint)e).ToList();
                return new Shared.Models.TickerTimeSeries()
                {
                    TimeSeries = seriesList
                };
            }
        }

        [HttpGet("{tickerName}/weekly")]
        public async Task<ActionResult<Shared.Models.TickerTimeSeries>> GetTickerWeeklyAsync(string tickername)
        {
            var value = await _tickerService.GetTickerWeeklyAsync(tickername);
            if (value != null)
            {
                var series = value.TimeSeries.Select(e => new Models.DTO.TickerDataPoint
                {
                    Close = e.Close,
                    Open = e.Open,
                    Date = e.Date,
                    High = e.High,
                    Low = e.Low,
                    Volume = e.Volume,
                    TickerName = tickername,
                    SeriesName = TimeSeries.WEEKLY.SeriesStringName()
                }).ToArray();
                await _databaseService.UpdateTickerDataPoint(series);
                return value;
            }
            else
            {
                var series = await _databaseService.GetTickerTimeSeries(tickername, Models.TimeSeries.WEEKLY);
                var seriesList = series.Select(e => (Shared.Models.TickerDataPoint)e).ToList();
                return new Shared.Models.TickerTimeSeries()
                {
                    TimeSeries = seriesList
                };
            }
        }

        [HttpGet("{tickerName}/monthly/adjusted")]
        public async Task<ActionResult<Shared.Models.TickerTimeSeries>> GetTickerMonthlyAdjustedAsync(string tickername)
        {
            var value = await _tickerService.GetTickerMonthlyAdjustedAsync(tickername);
            if (value != null)
            {
                var series = value.TimeSeries.Select(e => new Models.DTO.TickerDataPoint
                {
                    Close = e.Close,
                    Open = e.Open,
                    Date = e.Date,
                    High = e.High,
                    Low = e.Low,
                    Volume = e.Volume,
                    TickerName = tickername,
                    SeriesName = TimeSeries.MONTHLY_ADJUSTED.SeriesStringName()
                }).ToArray();
                await _databaseService.UpdateTickerDataPoint(series);
                return value;
            }
            else
            {
                var series = await _databaseService.GetTickerTimeSeries(tickername, Models.TimeSeries.MONTHLY_ADJUSTED);
                var seriesList = series.Select(e => (Shared.Models.TickerDataPoint)e).ToList();
                return new Shared.Models.TickerTimeSeries()
                {
                    TimeSeries = seriesList
                };
            }
        }

        [HttpGet("{tickerName}/monthly")]
        public async Task<ActionResult<Shared.Models.TickerTimeSeries>> GetTickerMonthlyAsync(string tickername)
        {
            var value = await _tickerService.GetTickerMonthlyAsync(tickername);
            if (value != null)
            {
                var series = value.TimeSeries.Select(e => new Models.DTO.TickerDataPoint
                {
                    Close = e.Close,
                    Open = e.Open,
                    Date = e.Date,
                    High = e.High,
                    Low = e.Low,
                    Volume = e.Volume,
                    TickerName = tickername,
                    SeriesName = TimeSeries.MONTHLY.SeriesStringName()
                }).ToArray();
                await _databaseService.UpdateTickerDataPoint(series);
                return value;
            }
            else
            {
                var series = await _databaseService.GetTickerTimeSeries(tickername, Models.TimeSeries.MONTHLY);
                var seriesList = series.Select(e => (Shared.Models.TickerDataPoint)e).ToList();
                return new Shared.Models.TickerTimeSeries()
                {
                    TimeSeries = seriesList
                };
            }
        }

        [HttpGet]
        public async Task<ActionResult<Shared.Models.Ticker[]>> GetAllTickersAsync()
        {
            var tickers = await _databaseService.GetTickers();
            return tickers.Select(t => (Shared.Models.Ticker)t).ToArray();
        }
    }
}
