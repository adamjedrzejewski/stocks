using Stocks.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Server.Services
{
    public interface IDatabaseService
    {
        public Task<User> GetLoggedInUserAsync(User user);
        public Task<User> GetUserById(int userID);
        public Task AddUser(User user);
        public Task<Ticker[]> GetTickers();
        public Task<Ticker[]> GetUserWatchlistAsync(int userId);
    }
}
