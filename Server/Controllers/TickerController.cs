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


        [HttpGet]
        public async Task<ActionResult<Ticker[]>> GetAllTickersAsync()
        {
            return await _databaseService.GetTickers();
        }
    }
}
