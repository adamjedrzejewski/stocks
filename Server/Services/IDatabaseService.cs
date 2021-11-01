﻿using Stocks.Server.Models;
using System.Threading.Tasks;

namespace Stocks.Server.Services
{
    public interface IDatabaseService
    {
        public Task<Models.DTO.User> GetLoggedInUserAsync(Models.DTO.User user);
        public Task<Models.DTO.User> GetUserById(int userID);
        public Task<bool> UsernameExistsAsync(Models.DTO.User user);
        public Task AddUser(Models.DTO.User user);
        public Task<Models.DTO.Ticker[]> GetTickers();
        public Task<Models.DTO.Ticker[]> GetUserWatchlistAsync(int userId);
        public Task AddToWatchlist(Models.DTO.WatchTicker watch);
        public Task RemoveFromWatchlist(Models.DTO.WatchTicker watch);

        public Task<Models.DTO.TickerDataPoint[]> GetTickerTimeSeries(string tickername, TimeSeries name);
        public Task UpdateTickerDataPoint(Models.DTO.TickerDataPoint[] points);
        public Task<bool> TickerExistsAsync(string tickername);
    }
}
