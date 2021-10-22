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

        public TickerController(IDatabaseService databaseService)
        {
            this._databaseService = databaseService;
        }

        [HttpGet("{tickerName}")]
        public async Task<IActionResult> GetTickerAsync(string tickername)
        {
            return Ok();
        }


        [HttpGet]
        public async Task<ActionResult<Ticker[]>> GetAllTickersAsync()
        {
            return await _databaseService.GetTickers();
        }
    }
}
