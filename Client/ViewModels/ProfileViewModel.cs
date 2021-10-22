using Stocks.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Stocks.Client.ViewModels
{
    public class ProfileViewModel : IProfileViewModel
    {
        private readonly HttpClient _httpClient;

        public int UserID { get; set; }
        public string Username { get; set; }

        public ProfileViewModel(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task GetProfileAsync()
        {
            var uri = $"/api/user/profile/{UserID}";
            //var uri = "https://localhost:44392/api/user/profile/2";
            var result = await _httpClient.GetFromJsonAsync<User>(uri);
            Username = result.Username;
        }
    }
}
