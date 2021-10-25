using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Stocks.Server.Models;
using Stocks.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Stocks.Server.Services
{
    public class SqlServerDatabaseService : IDatabaseService
    {
        private readonly MainDbContext _dbContext;

        public SqlServerDatabaseService(MainDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task AddToWatchlist(WatchTicker watch)
        {
            _dbContext.Watchlist.Add(watch);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddUser(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public Task<User> GetLoggedInUserAsync(User user)
        {
            return _dbContext.Users.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefaultAsync();
        }

        public Task<Ticker[]> GetTickers()
        {
            return Task.FromResult(_dbContext.Tickers.ToArray());
        }

        public Task<User> GetUserById(int userID)
        {
            return _dbContext.Users.Where(u => u.UserId == userID).FirstOrDefaultAsync();
        }

        public Task<Ticker[]> GetUserWatchlistAsync(int userId)
        {
            var tickers = _dbContext.Watchlist
                                    .Where(e => e.UserId == userId)
                                    .Select(e =>
                                        new Ticker
                                        {
                                            Name = e.TickerName
                                        });
            return Task.FromResult(tickers.ToArray()); 
        }

        public async Task RemoveFromWatchlist(WatchTicker watch)
        {
            var watch_obj = await _dbContext.Watchlist
                                            .Where(e => e.UserId == watch.UserId && e.TickerName == watch.TickerName)
                                            .FirstOrDefaultAsync();
            _dbContext.Watchlist.Attach(watch_obj);
            _dbContext.Watchlist.Remove(watch_obj);
            _dbContext.SaveChanges();
        }
    }
}
