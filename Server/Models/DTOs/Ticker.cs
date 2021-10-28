using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Server.Models.DTO
{
    public class Ticker
    {
        public int TickerId { get; set; }
        public string Name { get; set; }

        public static implicit operator Shared.Models.Ticker(Ticker ticker)
            => new()
            {
                Name = ticker.Name,
                TickerId = ticker.TickerId
            };

        public static implicit operator Ticker(Shared.Models.Ticker ticker)
            => new()
            {
                Name = ticker.Name,
                TickerId = ticker.TickerId
            };

    }
}
