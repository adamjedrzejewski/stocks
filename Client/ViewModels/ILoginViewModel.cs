using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Client.ViewModels
{
    public interface ILoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Task LoginUserAsync();
    }
}
