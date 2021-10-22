using Stocks.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Stocks.Client.ViewModels
{
    public class LoginViewModel : ILoginViewModel
    {
        private readonly HttpClient _httpClient;

        public string Username { get; set; }
        public string Password { get; set; }

        public LoginViewModel()
        {

        }

        public LoginViewModel(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task LoginUserAsync()
        {
            await _httpClient.PostAsJsonAsync<User>("api/user/login", this);
        }

        public static implicit operator LoginViewModel(User user)
            => new LoginViewModel
            {
                Username = user.Username,
                Password = user.Password
            };

        public static implicit operator User(LoginViewModel loginViewModel)
            => new User
            {
                Username = loginViewModel.Username,
                Password = loginViewModel.Password
            };
    }
}
