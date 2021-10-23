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
        public async Task<ActionResult<TickerInfo>> GetTickerDailyAdjustedAsync(string tickername)
        {
            return await _tickerService.GetTickerDailyAdjustedAsync(tickername);
        }

        [HttpGet("{tickerName}/daily")]
        public async Task<ActionResult<TickerInfo>> GetTickerDailyAsync(string tickername)
        {
            return await _tickerService.GetTickerDailyAsync(tickername);
        }

        [HttpGet("{tickerName}/weekly/adjusted")]
        public async Task<ActionResult<TickerInfo>> GetTickerWeeklyAdjustedAsync(string tickername)
        {
            return await _tickerService.GetTickerWeeklyAdjustedAsync(tickername);
        }

        [HttpGet("{tickerName}/weekly")]
        public async Task<ActionResult<TickerInfo>> GetTickerWeeklyAsync(string tickername)
        {
            return await _tickerService.GetTickerWeeklyAsync(tickername);
        }

        [HttpGet("{tickerName}/montly/adjusted")]
        public async Task<ActionResult<TickerInfo>> GetTickerMonthlyAdjustedAsync(string tickername)
        {
            return await _tickerService.GetTickerMonthlyAdjustedAsync(tickername);
        }

        [HttpGet("{tickerName}/montly")]
        public async Task<ActionResult<TickerInfo>> GetTickerMonthlyAsync(string tickername)
        {
            return await _tickerService.GetTickerMonthlyAsync(tickername);
        }

        [HttpGet]
        public async Task<ActionResult<Ticker[]>> GetAllTickersAsync()
        {
            return await _databaseService.GetTickers();
        }
    }
}
