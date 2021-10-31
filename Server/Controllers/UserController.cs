 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stocks.Shared.Models;
using Stocks.Server.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace Stocks.Server.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDatabaseService _databaseService;

        public UserController(IDatabaseService databaseService)
        {
            this._databaseService = databaseService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<Shared.Models.User>> LoginUserAsync(Shared.Models.User user)
        {
            var loggedInUser = await _databaseService.GetLoggedInUserAsync(user);
            if (loggedInUser != null)
            {
                var claimUsername = new Claim(ClaimTypes.Name, loggedInUser.Username);
                var claimIdentifier = new Claim(ClaimTypes.NameIdentifier, loggedInUser.UserId.ToString());
                var claimsIdentity = new ClaimsIdentity(new[] { claimUsername, claimIdentifier }, "serverAuth");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                
            }

            return (Shared.Models.User) loggedInUser;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(Shared.Models.User user)
        {
            if (await _databaseService.UsernameExistsAsync(user))
            {
                return StatusCode(409);
            }

            await _databaseService.AddUser(user);
            return Ok();
        }

        [HttpGet("current")]
        public async Task<ActionResult<Shared.Models.User>> GetCurrentUserAsync()
        {
            var user = new User();
            if (User.Identity.IsAuthenticated)
            {
                user.Username = User.FindFirstValue(ClaimTypes.Name);
                user.UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            return user;
        }

        [HttpGet("logout")]
        public async Task<IActionResult> LogoutUserAsync()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }

        [HttpGet("profile/{userId}")]
        public async Task<ActionResult<Shared.Models.User>> GetProfileAsync(int userId)
        {
            var result =  await _databaseService.GetUserById(userId);
            return (Shared.Models.User) result;
        }
    }
}
