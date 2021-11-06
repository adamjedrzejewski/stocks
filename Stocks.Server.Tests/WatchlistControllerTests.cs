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
    public class WatchlistControllerTests
    {
        [Fact]
        public async Task GetUserWatchList_Returns_User_Watchlist()
        {
            // Arrange
            int count = 10;
            int id = 12;
            var fakeTickers = A.CollectionOfDummy<Models.DTO.Ticker>(count).ToArray();
            var databaseService = A.Fake<IDatabaseService>();
            A.CallTo(() => databaseService.GetUserWatchlistAsync(A<int>._)).Returns(Task.FromResult(fakeTickers));
            var controller = new WatchlistController(databaseService);

            // Act
            var actionResult = await controller.GetUserWatchList(id);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as OkObjectResult;

            Assert.True(result.Value is Shared.Models.Ticker[]);
            var value = result.Value as Shared.Models.Ticker[];
            Assert.Equal(count, value.Length);
        }

        [Fact]
        public async Task AddToWatchList_BadRequest_On_Invalid_Input()
        {
            // Arrange
            var entry = A.Fake<Models.DTO.WatchTicker>();
            entry.TickerName = null;

            var databaseService = A.Fake<IDatabaseService>();
            var controller = new WatchlistController(databaseService);
            // Act
            var actionResult = await controller.AddToWatchList(entry);


            // Assert
            Assert.IsType<BadRequestResult>(actionResult);
        }

        [Fact]
        public async Task AddToWatchList_Created_On_Valid_Input()
        {
            // Arrange
            var entry = A.Fake<Models.DTO.WatchTicker>();
            entry.TickerName = "";

            var databaseService = A.Fake<IDatabaseService>();
            var controller = new WatchlistController(databaseService);
            // Act
            var actionResult = await controller.AddToWatchList(entry);

            A.CallTo(() => databaseService.AddToWatchlistAsync(A<Models.DTO.WatchTicker>._)).MustHaveHappened();

            // Assert
            Assert.IsType<StatusCodeResult>(actionResult);
            var result = actionResult as StatusCodeResult;
            Assert.Equal(201, result.StatusCode);
        }


        [Fact]
        public async Task RemoveFromWatchList_NoContent_On_Valid_Input()
        {
            // Arrange
            var entry = A.Fake<Models.DTO.WatchTicker>();
            entry.TickerName = "";

            var databaseService = A.Fake<IDatabaseService>();
            var controller = new WatchlistController(databaseService);
            // Act
            var actionResult = await controller.RemoveFromWatchList(entry);

            A.CallTo(() => databaseService.RemoveFromWatchlistAsync(A<Models.DTO.WatchTicker>._)).MustHaveHappened();

            // Assert
            Assert.IsType<NoContentResult>(actionResult);
        }

        [Fact]
        public async Task RemoveFromWatchList_BadRequest_On_InValid_Input()
        {
            // Arrange
            var entry = A.Fake<Models.DTO.WatchTicker>();
            entry.TickerName = null;

            var databaseService = A.Fake<IDatabaseService>();
            var controller = new WatchlistController(databaseService);
            // Act
            var actionResult = await controller.RemoveFromWatchList(entry);

            // Assert
            Assert.IsType<BadRequestResult>(actionResult);
        }
    }
}
