using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stocks.Client.Pages;
using Stocks.Server.Services;
using Stocks.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Server.Controllers
{
    [Route("api/watchlist")]
    [ApiController]
    public class WatchlistController : ControllerBase
    {
        private readonly IDatabaseService _databaseService;

        public WatchlistController(IDatabaseService databaseService)
        {
            this._databaseService = databaseService;
        }

        [HttpGet("{userID}")]
        public async Task<ActionResult<Shared.Models.Ticker[]>> GetUserWatchList(int userId)
        {
            var tickers = await _databaseService.GetUserWatchlistAsync(userId);
            var tickersArray = tickers.Select(t => (Shared.Models.Ticker) t).ToArray();
            return tickersArray;
        }

        [HttpPost]
        public async Task<IActionResult> AddToWatchList([FromBody] WatchTicker watch)
        {
            await _databaseService.AddToWatchlist(watch);
            return StatusCode(201);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFromWatchList([FromBody] WatchTicker watch)
        {
            await _databaseService.RemoveFromWatchlist(watch);
            return StatusCode(200);
        }

    }
}
