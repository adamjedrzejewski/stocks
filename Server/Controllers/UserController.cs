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
    /// <summary>
    /// Serves information about user
    /// </summary>
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDatabaseService _databaseService;

        /// <summary>
        /// Constructs new instance of UserController
        /// </summary>
        /// <param name="databaseService"></param>
        public UserController(IDatabaseService databaseService)
        {
            this._databaseService = databaseService;
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <response code="200">User has been logged in</response>
        [HttpPost("login")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        public async Task<ActionResult<User>> LoginUserAsync(User user)
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

            return (User) loggedInUser;
        }

        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <response code="200">User has been registered</response>
        /// <response code="409">If user with such username already exist</response>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> RegisterUser(User user)
        {
            if (await _databaseService.UsernameExistsAsync(user))
            {
                return StatusCode(409);
            }

            await _databaseService.AddUser(user);
            return Ok();
        }

        /// <summary>
        /// Get current user
        /// </summary>
        /// <returns>Current user</returns>
        /// <response code="200">Current user</response>
        [HttpGet("current")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        public Task<ActionResult<User>> GetCurrentUserAsync()
        {
            var user = new User();
            if (User.Identity.IsAuthenticated)
            {
                user.Username = User.FindFirstValue(ClaimTypes.Name);
                user.UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            return Task.FromResult(new ActionResult<User>(user));
        }

        /// <summary>
        /// Log out user
        /// </summary>
        /// <returns></returns>
        ///<response code="200">User has been logged out</response>
        [HttpGet("logout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> LogoutUserAsync()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>User associated with this id</returns>
        /// <response code="200">Returns user</response>
        /// <response code="404">If no user with such id exist</response>
        [HttpGet("profile/{userId}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> GetUserByIdAsync(int userId)
        {
            var exists = await _databaseService.UserExistsAsync(userId);
            if (!exists)
            {
                return NotFound();
            }

            var user =  await _databaseService.GetUserById(userId);
            return (User) user;
        }
    }
}
