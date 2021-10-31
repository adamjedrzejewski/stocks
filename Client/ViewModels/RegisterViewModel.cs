using Stocks.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Stocks.Client.ViewModels
{
    public class RegisterViewModel : IRegisterViewModel
    {
        private readonly HttpClient _httpClient;

        public string Username { get; set; }
        public string Password { get; set; }

        public RegisterViewModel(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public RegisterViewModel()
        { 
        }

        public async Task<bool> RegisterUserAsync()
        {
            var response = await _httpClient.PostAsJsonAsync<User>("api/user/register", this);
            return response.IsSuccessStatusCode;
        }

        public static implicit operator RegisterViewModel(User user)
            => new()
            {
                Username = user.Username,
                Password = user.Password
            };

        public static implicit operator User(RegisterViewModel registerViewModel)
            => new()
            {
                Username = registerViewModel.Username,
                Password = registerViewModel.Password
            };
    }
}
