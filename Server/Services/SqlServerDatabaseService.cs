using Microsoft.EntityFrameworkCore;
using Stocks.Server.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Server.Services
{
    /// <summary>
    /// Database service for Microsoft SQL Server
    /// </summary>
    public class SqlServerDatabaseService : IDatabaseService
    {
        private readonly MainDbContext _dbContext;

        /// <summary>
        /// Construct new instance of SqlServerDatabaseService
        /// </summary>
        /// <param name="dbContext"></param>
        public SqlServerDatabaseService(MainDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// Add entry to watchlist
        /// </summary>
        /// <param name="watch"></param>
        /// <returns></returns>
        public async Task AddToWatchlistAsync(Models.DTO.WatchTicker watch)
        {
            if (!_dbContext.Watchlist.Any(w => w.TickerName == watch.TickerName && w.UserId == watch.UserId))
            {
                _dbContext.Watchlist.Add(watch);
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task AddUserAsync(Models.DTO.User user)
        {
            user.Password = PasswordUtility.Encrypt(user.Password);
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Get logged in user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>logged in user</returns>
        public Task<Models.DTO.User> GetLoggedInUserAsync(Models.DTO.User user)
        {
            // TODO: password salting
            user.Password = PasswordUtility.Encrypt(user.Password);
            return _dbContext.Users.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get all tickers in the database
        /// </summary>
        /// <returns>Array of tickers</returns>
        public Task<Models.DTO.Ticker[]> GetTickersAsync()
        {
            return Task.FromResult(_dbContext.Tickers.ToArray());
        }

        /// <summary>
        /// Get datapoints for ticker of time series
        /// </summary>
        /// <param name="tickername"></param>
        /// <param name="series"></param>
        /// <returns>Array of datapoints for given ticker</returns>
        public async Task<Models.DTO.TickerDataPoint[]> GetTickerTimeSeriesAsync(string tickername, TimeSeries series)
        {
            string seriesName = series.SeriesStringName();
            return await _dbContext.TickerDataPoints
                                   .Where(t => t.TickerName == tickername && t.SeriesName == seriesName)
                                   .ToArrayAsync();
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>User with specified id</returns>
        public Task<Models.DTO.User> GetUserByIdAsync(int userID)
        {
            return _dbContext.Users.Where(u => u.UserId == userID).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get user's watchlist
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Array of tickers that are on user's watchlist</returns>
        public Task<Models.DTO.Ticker[]> GetUserWatchlistAsync(int userId)
        {
            var tickers = _dbContext.Watchlist
                                    .Where(e => e.UserId == userId)
                                    .Select(e =>
                                        new Models.DTO.Ticker
                                        {
                                            Name = e.TickerName
                                        });
            return Task.FromResult(tickers.ToArray()); 
        }

        /// <summary>
        /// Remove entry from watchlist
        /// </summary>
        /// <param name="watch"></param>
        /// <returns></returns>
        public async Task RemoveFromWatchlistAsync(Models.DTO.WatchTicker watch)
        {
            var watch_obj = await _dbContext.Watchlist
                                            .Where(e => e.UserId == watch.UserId && e.TickerName == watch.TickerName)
                                            .FirstOrDefaultAsync();
            _dbContext.Watchlist.Attach(watch_obj);
            _dbContext.Watchlist.Remove(watch_obj);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Check if ticker exists
        /// </summary>
        /// <param name="tickername"></param>
        /// <returns>true if ticker exists false otherwise</returns>
        public Task<bool> TickerExistsAsync(string tickername)
        {
            return _dbContext.Tickers.AnyAsync(t => t.Name == tickername);
        }

        /// <summary>
        /// Passed as array, those entries that are not yet in the database are inserted
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public async Task UpdateTickerDataPointAsync(Models.DTO.TickerDataPoint[] points)
        {
            foreach (var point in points)
            {
                if (!_dbContext.TickerDataPoints.Any(e => e.Date == point.Date && e.TickerName == point.TickerName && e.SeriesName == point.SeriesName))
                {
                    _dbContext.TickerDataPoints.Attach(point);
                }
            }
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Check if user exists by id
        /// </summary>
        /// <param name="userid"></param>
        /// <returns>True if user exists false otherwise</returns>
        public Task<bool> UserExistsAsync(int userid)
        {
            return _dbContext.Users.AnyAsync(u => u.UserId == userid);
        }

        /// <summary>
        /// Check if user exists by username
        /// </summary>
        /// <param name="user"></param>
        /// <returns>True if user exists false otherwise</returns>
        public async Task<bool> UsernameExistsAsync(Models.DTO.User user)
        {
            return await _dbContext.Users.AnyAsync(u => u.Username == user.Username);
        }
    }
}
