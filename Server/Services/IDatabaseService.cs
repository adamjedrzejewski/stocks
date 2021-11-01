using Stocks.Server.Models;
using Stocks.Server.Models.DTO;
using System.Threading.Tasks;

namespace Stocks.Server.Services
{
    /// <summary>
    /// Interface for communitaction with database
    /// </summary>
    public interface IDatabaseService
    {
        /// <summary>
        /// Get logged in user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>logged in user</returns>
        public Task<User> GetLoggedInUserAsync(User user);
        
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>User with specified id</returns>
        public Task<User> GetUserByIdAsync(int userID);

        /// <summary>
        /// Check if user exists by username
        /// </summary>
        /// <param name="user"></param>
        /// <returns>True if user exists false otherwise</returns>
        public Task<bool> UsernameExistsAsync(User user);
        
        /// <summary>
        /// Check if user exists by id
        /// </summary>
        /// <param name="userid"></param>
        /// <returns>True if user exists false otherwise</returns>
        public Task<bool> UserExistsAsync(int userid);
        
        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task AddUserAsync(User user);
        
        /// <summary>
        /// Get all tickers in the database
        /// </summary>
        /// <returns>Array of tickers</returns>
        public Task<Ticker[]> GetTickersAsync();
        
        /// <summary>
        /// Get user's watchlist
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Array of tickers that are on user's watchlist</returns>
        public Task<Ticker[]> GetUserWatchlistAsync(int userId);
        
        /// <summary>
        /// Add entry to watchlist
        /// </summary>
        /// <param name="watch"></param>
        /// <returns></returns>
        public Task AddToWatchlistAsync(WatchTicker watch);
        
        /// <summary>
        /// Remove entry from watchlist
        /// </summary>
        /// <param name="watch"></param>
        /// <returns></returns>
        public Task RemoveFromWatchlistAsync(WatchTicker watch);
        
        /// <summary>
        /// Get datapoints for ticker of time series
        /// </summary>
        /// <param name="tickername"></param>
        /// <param name="name"></param>
        /// <returns>Array of datapoints for given ticker</returns>
        public Task<TickerDataPoint[]> GetTickerTimeSeriesAsync(string tickername, TimeSeries name);
        
        /// <summary>
        /// Passed as array, those entries that are not yet in the database are inserted
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public Task UpdateTickerDataPointAsync(TickerDataPoint[] points);
        
        /// <summary>
        /// Check if ticker exists
        /// </summary>
        /// <param name="tickername"></param>
        /// <returns>true if ticker exists false otherwise</returns>
        public Task<bool> TickerExistsAsync(string tickername);
    }
}
