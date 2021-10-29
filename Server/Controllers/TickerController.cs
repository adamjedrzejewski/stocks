using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stocks.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Server.Controllers
{
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
                // TODO add to DB
                return value;
            }
            else
            {
                var series = await _databaseService.GetTickerTimeSeries(tickername);
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
                // TODO add to DB
                return value;
            }
            else
            {
                var series = await _databaseService.GetTickerTimeSeries(tickername);
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
            return value;
        }

        [HttpGet("{tickerName}/weekly")]
        public async Task<ActionResult<Shared.Models.TickerTimeSeries>> GetTickerWeeklyAsync(string tickername)
        {
            var value = await _tickerService.GetTickerWeeklyAsync(tickername);
            if (value != null)
            {
                // TODO add to DB
                return value;
            }
            else
            {
                var series = await _databaseService.GetTickerTimeSeries(tickername);
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
                // TODO add to DB
                return value;
            }
            else
            {
                var series = await _databaseService.GetTickerTimeSeries(tickername);
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
                // TODO add to DB
                return value;
            }
            else
            {
                var series = await _databaseService.GetTickerTimeSeries(tickername);
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
