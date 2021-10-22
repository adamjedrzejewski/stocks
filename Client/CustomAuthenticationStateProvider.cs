using Microsoft.AspNetCore.Components.Authorization;
using Stocks.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Stocks.Client
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;

        public CustomAuthenticationStateProvider(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            User currentUser = await _httpClient.GetFromJsonAsync<User>("api/user/current");
            if (currentUser != null && currentUser.Username != null)
            {
                var claimUsername = new Claim(ClaimTypes.Name, currentUser.Username);
                var claimIdentifier = new Claim(ClaimTypes.NameIdentifier, currentUser.UserId.ToString());
                var claimsIdentity = new ClaimsIdentity(new[] { claimUsername, claimIdentifier }, "serverAuth");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                return new AuthenticationState(claimsPrincipal);
            }
            else
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
        }
    }
}
