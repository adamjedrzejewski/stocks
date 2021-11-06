using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Stocks.Server.Controllers;
using Stocks.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Stocks.Server.Tests
{
    public class UserControllerTests
    {
        [Fact]
        public async Task LoginUserAsync_BadRequest_On_Invalid_Input()
        {
            // Arrange
            Models.DTO.User user = A.Fake<Models.DTO.User>();
            var databaseService = A.Fake<IDatabaseService>();

            A.CallTo(() => databaseService.GetLoggedInUserAsync(A<Models.DTO.User>._))
                                          .Returns(Task.FromResult<Models.DTO.User>(null));
            var controller = new UserController(databaseService);

            // Act
            var actionResult = await controller.LoginUserAsync(user);

            // Assert
            Assert.IsType<BadRequestResult>(actionResult.Result);
        }

        [Fact]
        public async Task LoginUserAsync_BadRequest_On_NonExistent_User()
        {
            // Arrange
            Models.DTO.User user = A.Fake<Models.DTO.User>();
            var databaseService = A.Fake<IDatabaseService>();

            A.CallTo(() => databaseService.GetLoggedInUserAsync(A<Models.DTO.User>._))
                                          .Returns(Task.FromResult<Models.DTO.User>(null));
            var controller = new UserController(databaseService);

            // Act
            var actionResult = await controller.LoginUserAsync(user);

            // Assert
            Assert.IsType<BadRequestResult>(actionResult.Result);
        }

        // Can't really test it right now because UserController.LoginUserAsync uses it's HttpContext which is not available
        // [Fact]
        public async Task LoginUserAsync_Ok_On_Valid_User()
        {
            // Arrange
            Models.DTO.User user = A.Fake<Models.DTO.User>();

            var databaseService = A.Fake<IDatabaseService>();
            user.Username = "asd";
            user.Password = "asdfsa";

            A.CallTo(() => databaseService.GetLoggedInUserAsync(A<Models.DTO.User>._)).Returns(Task.FromResult(user));
            var controller = new UserController(databaseService);

            // Act
            var actionResult = await controller.LoginUserAsync(user);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }

        [Fact]
        public async Task RegisterUser_BadRequest_On_Invalid_Input()
        {
            // Arrange
            Models.DTO.User user = A.Fake<Models.DTO.User>();
            user.Username = null;
            user.Password = null;

            var databaseService = A.Fake<IDatabaseService>();
            A.CallTo(() => databaseService.UsernameExistsAsync(A<Models.DTO.User>._)).Returns(Task.FromResult(false));
            var controller = new UserController(databaseService);

            // Act
            var actionResult = await controller.RegisterUserAsync(user);

            // Assert
            Assert.IsType<BadRequestResult>(actionResult);
        }

        [Fact]
        public async Task RegisterUser_ConflictResult_On_Already_Taken_Username()
        {
            // Arrange
            Models.DTO.User user = A.Fake<Models.DTO.User>();
            user.Username = "";
            user.Password = "";

            var databaseService = A.Fake<IDatabaseService>();
            A.CallTo(() => databaseService.UsernameExistsAsync(A<Models.DTO.User>._)).Returns(Task.FromResult(true));
            var controller = new UserController(databaseService);

            // Act
            var actionResult = await controller.RegisterUserAsync(user);

            // Assert
            Assert.IsType<ConflictResult>(actionResult);
        }


        [Fact]
        public async Task RegisterUser_Created()
        {
            // Arrange
            Models.DTO.User user = A.Fake<Models.DTO.User>();
            user.Username = "";
            user.Password = "";

            var databaseService = A.Fake<IDatabaseService>();
            A.CallTo(() => databaseService.UsernameExistsAsync(A<Models.DTO.User>._)).Returns(Task.FromResult(false));
            A.CallTo(() => databaseService.AddUserAsync(A<Models.DTO.User>._)).Returns(Task.CompletedTask);
            var controller = new UserController(databaseService);

            // Act
            var actionResult = await controller.RegisterUserAsync(user);

            // Assert
            Assert.IsType<StatusCodeResult>(actionResult);
            var statusCode = actionResult as StatusCodeResult;
            Assert.Equal(201, statusCode.StatusCode);
        }
    }
}
