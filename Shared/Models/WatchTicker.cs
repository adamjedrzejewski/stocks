using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Shared.Models
{
    public class WatchTicker
    {
        public int WatchId { get; set; }
        public string TickerName { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
