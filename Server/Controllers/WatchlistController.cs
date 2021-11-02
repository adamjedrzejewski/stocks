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
    /// <summary>
    /// 
    /// </summary>
    [Route("api/watchlist")]
    [ApiController]
    public class WatchlistController : ControllerBase
    {
        private readonly IDatabaseService _databaseService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseService"></param>
        public WatchlistController(IDatabaseService databaseService)
        {
            this._databaseService = databaseService;
        }

        /// <summary>
        /// Returns watchlist for given user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List of tickers that are on users watchlist</returns>
        /// <response code="200">Returns the list</response>
        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Shared.Models.Ticker[]>> GetUserWatchList(int userId)
        {
            var tickers = await _databaseService.GetUserWatchlistAsync(userId);
            var tickersArray = tickers.Select(t => (Shared.Models.Ticker) t).ToArray();
            return tickersArray;
        }

        /// <summary>
        /// Add entry to user's watchlist
        /// </summary>
        /// <param name="watch"></param>
        /// <returns></returns>
        /// <response code="201">Watchlist has been updated</response>
        /// <response code="400">If posted watchlist schema is invalid</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddToWatchList([FromBody] WatchTicker watch)
        {
            if (watch.TickerName == null)
            {
                return BadRequest();
            }

            await _databaseService.AddToWatchlistAsync(watch);
            return StatusCode(201);
        }

        /// <summary>
        /// Remove entry from user's watchlist
        /// </summary>
        /// <param name="watch"></param>
        /// <returns></returns>
        /// <response code="204">Watchlist has been updated</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RemoveFromWatchList([FromBody] WatchTicker watch)
        {
            await _databaseService.RemoveFromWatchlistAsync(watch);
            return NoContent();
        }

    }
}
