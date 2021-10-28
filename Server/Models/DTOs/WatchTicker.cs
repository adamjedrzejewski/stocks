using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Server.Models.DTO
{
    public class WatchTicker
    {
        public int WatchId { get; set; }
        public string TickerName { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public static implicit operator Shared.Models.WatchTicker(WatchTicker watch)
            => new()
            { 
                TickerName = watch.TickerName,
                UserId = watch.UserId,
                WatchId = watch.WatchId
            };

        public static implicit operator WatchTicker(Shared.Models.WatchTicker watch)
            => new()
            {
                TickerName = watch.TickerName,
                UserId = watch.UserId,
                WatchId = watch.WatchId
            };
    }
}
