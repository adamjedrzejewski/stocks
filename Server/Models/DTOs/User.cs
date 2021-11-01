using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Server.Models.DTO
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual HashSet<WatchTicker> Watchlist { get; set; } = new HashSet<WatchTicker>();

        public static implicit operator Shared.Models.User(User user)
            => new Shared.Models.User
            {
                UserId = user.UserId,
                Username = user.Username,
                Password = user.Password
            };

        public static implicit operator User(Shared.Models.User user)
            => new User
            {
                UserId = user.UserId,
                Username = user.Username,
                Password = user.Password
            };
    }
}
