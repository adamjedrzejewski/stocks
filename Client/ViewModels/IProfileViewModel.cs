using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Client.ViewModels
{
    public interface IProfileViewModel
    {
        public int UserID { get; set; }
        public string Username { get; set; }

        public Task GetProfileAsync();
    }
}
