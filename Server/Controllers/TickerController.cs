using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stocks.Server.Services;
using Stocks.Shared.Models;
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
        public async Task<ActionResult<TickerTimeSeries>> GetTickerDailyAdjustedAsync(string tickername)
        {
            var value = await _tickerService.GetTickerDailyAdjustedAsync(tickername);
            return value;
        }

        [HttpGet("{tickerName}/daily")]
        public async Task<ActionResult<TickerTimeSeries>> GetTickerDailyAsync(string tickername)
        {
            var value = await _tickerService.GetTickerDailyAsync(tickername);
            return value;
        }

        [HttpGet("{tickerName}/weekly/adjusted")]
        public async Task<ActionResult<TickerTimeSeries>> GetTickerWeeklyAdjustedAsync(string tickername)
        {
            var value = await _tickerService.GetTickerWeeklyAdjustedAsync(tickername);
            return value;
        }

        [HttpGet("{tickerName}/weekly")]
        public async Task<ActionResult<TickerTimeSeries>> GetTickerWeeklyAsync(string tickername)
        {
            var value = await _tickerService.GetTickerWeeklyAsync(tickername);
            return value;
        }

        [HttpGet("{tickerName}/monthly/adjusted")]
        public async Task<ActionResult<TickerTimeSeries>> GetTickerMonthlyAdjustedAsync(string tickername)
        {
            var value = await _tickerService.GetTickerMonthlyAdjustedAsync(tickername);
            return value;
        }

        [HttpGet("{tickerName}/monthly")]
        public async Task<ActionResult<TickerTimeSeries>> GetTickerMonthlyAsync(string tickername)
        {
            var value = await _tickerService.GetTickerMonthlyAsync(tickername);
            return value;
        }

        [HttpGet]
        public async Task<ActionResult<Ticker[]>> GetAllTickersAsync()
        {
            return await _databaseService.GetTickers();
        }
    }
}
