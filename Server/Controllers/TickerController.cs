using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stocks.Server.Services;
using Stocks.Shared.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Server.Controllers
{
    /// <summary>
    /// Serves information about tickers
    /// </summary>
    [Route("api/ticker")]
    [ApiController]
    public class TickerController : ControllerBase
    {
        private readonly IDatabaseService _databaseService;
        private readonly ITickerService _tickerService;

        /// <summary>
        /// Constructs new instance of TickerController
        /// </summary>
        /// <param name="databaseService"></param>
        /// <param name="tickerService"></param>
        public TickerController(IDatabaseService databaseService, ITickerService tickerService)
        {
            _databaseService = databaseService;
            _tickerService = tickerService;
        }

        /// <summary>
        /// Get ticker daily adjusted time series
        /// </summary>
        /// <param name="tickername"></param>
        /// <returns>Daily time series for ticker</returns>
        /// <response code="200">Returns ticker time series</response>
        /// <response code="404">If ticker is not in the database</response>
        [HttpGet("{tickername}/daily/adjusted")]
        [ProducesResponseType(typeof(TickerTimeSeries), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TickerTimeSeries>> GetTickerDailyAdjustedAsync(string tickername)
        {
            var exists = await _databaseService.TickerExistsAsync(tickername);
            if (!exists)
            {
                return NotFound();
            }

            var result = await _tickerService.GetTickerDailyAdjustedAsync(tickername);
            return Ok(result);
        }

        /// <summary>
        /// Get ticker daily time series
        /// </summary>
        /// <param name="tickername"></param>
        /// <returns>Daily adjusted time series for ticker</returns>
        /// <response code="200">Returns ticker time series</response>
        /// <response code="404">If ticker is not in the database</response>
        [HttpGet("{tickername}/daily")]
        [ProducesResponseType(typeof(TickerTimeSeries), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TickerTimeSeries>> GetTickerDailyAsync(string tickername)
        {
            var exists = await _databaseService.TickerExistsAsync(tickername);
            if (!exists)
            {
                return NotFound();
            }

            var result = await _tickerService.GetTickerDailyAsync(tickername);
            return Ok(result);
        }

        /// <summary>
        /// Get ticker weekly adjusted time series
        /// </summary>
        /// <param name="tickername"></param>
        /// <returns>Weekly adjusted time series for ticker</returns>
        /// <response code="200">Returns ticker time series</response>
        /// <response code="404">If ticker is not in the database</response>
        [HttpGet("{tickername}/weekly/adjusted")]
        [ProducesResponseType(typeof(TickerTimeSeries), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TickerTimeSeries>> GetTickerWeeklyAdjustedAsync(string tickername)
        {
            var exists = await _databaseService.TickerExistsAsync(tickername);
            if (!exists)
            {
                return NotFound();
            }

            var result = await _tickerService.GetTickerWeeklyAdjustedAsync(tickername);
            return Ok(result);
        }

        /// <summary>
        /// Get ticker weekly time series
        /// </summary>
        /// <param name="tickername"></param>
        /// <returns>Weekly time series for ticker</returns>
        /// <response code="200">Returns ticker time series</response>
        /// <response code="404">If ticker is not in the database</response>
        [HttpGet("{tickername}/weekly")]
        [ProducesResponseType(typeof(TickerTimeSeries), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TickerTimeSeries>> GetTickerWeeklyAsync(string tickername)
        {
            var exists = await _databaseService.TickerExistsAsync(tickername);
            if (!exists)
            {
                return NotFound();
            }

            var result = await _tickerService.GetTickerWeeklyAsync(tickername);
            return Ok(result);
        }

        /// <summary>
        /// Get ticker monthly adjusted time series
        /// </summary>
        /// <param name="tickername"></param>
        /// <returns>Monthly adjusted time series for ticker</returns>
        /// <response code="200">Returns ticker time series</response>
        /// <response code="404">If ticker is not in the database</response>
        [HttpGet("{tickername}/monthly/adjusted")]
        [ProducesResponseType(typeof(TickerTimeSeries), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TickerTimeSeries>> GetTickerMonthlyAdjustedAsync(string tickername)
        {
            var exists = await _databaseService.TickerExistsAsync(tickername);
            if (!exists)
            {
                return NotFound();
            }

            var result = await _tickerService.GetTickerMonthlyAdjustedAsync(tickername);
            return Ok(result);
        }

        /// <summary>
        /// Get ticker monthly time series
        /// </summary>
        /// <param name="tickername"></param>
        /// <returns>Monthly time series for ticker</returns>
        /// <response code="200">Returns ticker time series</response>
        /// <response code="404">If ticker is not in the database</response>
        [HttpGet("{tickername}/monthly")]
        [ProducesResponseType(typeof(TickerTimeSeries), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TickerTimeSeries>> GetTickerMonthlyAsync(string tickername)
        {
            var exists = await _databaseService.TickerExistsAsync(tickername);
            if (!exists)
            {
                return NotFound();
            }

            var result = await _tickerService.GetTickerMonthlyAsync(tickername);
            return Ok(result);
        }

        /// <summary>
        /// Get ticker list
        /// </summary>
        /// <returns>A list of all available tickers</returns>
        /// <response code="200">Returns list of tickers</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Ticker[]>> GetAllTickersAsync()
        {
            var tickers = await _databaseService.GetTickersAsync();
            var result = tickers.Select(t => (Ticker) t).ToArray();
            return Ok(result);
        }
    }
}
