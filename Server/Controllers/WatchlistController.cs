using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stocks.Client.Pages;
using Stocks.Server.Services;
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
            return await _databaseService.GetUserWatchlistAsync(userId);
        }

        [HttpPost]
        public async Task<IActionResult> AddToWatchList()
        {
            return StatusCode(201);
        }

    }
}
