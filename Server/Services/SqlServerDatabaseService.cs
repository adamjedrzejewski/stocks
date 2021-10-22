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
    }
}
