using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Stocks.Server.Controllers;
using Stocks.Server.Services;
using Stocks.Shared.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Stocks.Server.Tests
{
    public class TickerControllerTests
    {
        [Fact]
        public async Task GetTickerDailyAdjustedAsync_Returns_A_Time_Series_For_Valid_TickerName()
        {
            // Arrange
            string tickername = "AAPL";
            var fakeTickerTimeSeries = A.Fake<TickerTimeSeries>();
            var databaseService = A.Fake<IDatabaseService>();
            var tickerService = A.Fake<ITickerService>();

            A.CallTo(() => databaseService.TickerExistsAsync(A<string>._)).Returns(Task.FromResult(true));
            A.CallTo(() => tickerService.GetTickerDailyAdjustedAsync(A<string>._)).Returns(Task.FromResult(fakeTickerTimeSeries));
            var controller = new TickerController(databaseService, tickerService);

            // Act
            var actionResult = await controller.GetTickerDailyAdjustedAsync(tickername);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as OkObjectResult;
            Assert.True(result.Value is TickerTimeSeries);
        }

        [Fact]
        public async Task GetTickerDailyAdjustedAsync_Returns_NotFound_For_InValid_TickerName()
        {
            // Arrange
            string tickername = "AAPL";
            var fakeTickerTimeSeries = A.Fake<TickerTimeSeries>();
            var databaseService = A.Fake<IDatabaseService>();
            var tickerService = A.Fake<ITickerService>();

            A.CallTo(() => databaseService.TickerExistsAsync(A<string>._)).Returns(Task.FromResult(false));
            A.CallTo(() => tickerService.GetTickerDailyAdjustedAsync(A<string>._)).Returns(Task.FromResult(fakeTickerTimeSeries));
            var controller = new TickerController(databaseService, tickerService);

            // Act
            var actionResult = await controller.GetTickerDailyAdjustedAsync(tickername);

            // Assert
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }

        [Fact]
        public async Task GetTickerDailyAsync_Returns_A_Time_Series_For_Valid_TickerName()
        {
            // Arrange
            string tickername = "AAPL";
            var fakeTickerTimeSeries = A.Fake<TickerTimeSeries>();
            var databaseService = A.Fake<IDatabaseService>();
            var tickerService = A.Fake<ITickerService>();

            A.CallTo(() => databaseService.TickerExistsAsync(A<string>._)).Returns(Task.FromResult(true));
            A.CallTo(() => tickerService.GetTickerDailyAsync(A<string>._)).Returns(Task.FromResult(fakeTickerTimeSeries));
            var controller = new TickerController(databaseService, tickerService);

            // Act
            var actionResult = await controller.GetTickerDailyAsync(tickername);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as OkObjectResult;
            Assert.True(result.Value is TickerTimeSeries);
        }

        [Fact]
        public async Task GetTickerDailyAsync_Returns_NotFound_For_InValid_TickerName()
        {
            // Arrange
            string tickername = "AAPL";
            var fakeTickerTimeSeries = A.Fake<TickerTimeSeries>();
            var databaseService = A.Fake<IDatabaseService>();
            var tickerService = A.Fake<ITickerService>();

            A.CallTo(() => databaseService.TickerExistsAsync(A<string>._)).Returns(Task.FromResult(false));
            A.CallTo(() => tickerService.GetTickerDailyAsync(A<string>._)).Returns(Task.FromResult(fakeTickerTimeSeries));
            var controller = new TickerController(databaseService, tickerService);

            // Act
            var actionResult = await controller.GetTickerDailyAsync(tickername);

            // Assert
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }

        [Fact]
        public async Task GetTickerWeeklyAdjustedAsync_Returns_A_Time_Series_For_Valid_TickerName()
        {
            // Arrange
            string tickername = "AAPL";
            var fakeTickerTimeSeries = A.Fake<TickerTimeSeries>();
            var databaseService = A.Fake<IDatabaseService>();
            var tickerService = A.Fake<ITickerService>();

            A.CallTo(() => databaseService.TickerExistsAsync(A<string>._)).Returns(Task.FromResult(true));
            A.CallTo(() => tickerService.GetTickerWeeklyAdjustedAsync(A<string>._)).Returns(Task.FromResult(fakeTickerTimeSeries));
            var controller = new TickerController(databaseService, tickerService);

            // Act
            var actionResult = await controller.GetTickerWeeklyAdjustedAsync(tickername);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as OkObjectResult;
            Assert.True(result.Value is TickerTimeSeries);
        }

        [Fact]
        public async Task GetTickerWeeklyAdjustedAsync_Returns_NotFound_For_InValid_TickerName()
        {
            // Arrange
            string tickername = "AAPL";
            var fakeTickerTimeSeries = A.Fake<TickerTimeSeries>();
            var databaseService = A.Fake<IDatabaseService>();
            var tickerService = A.Fake<ITickerService>();

            A.CallTo(() => databaseService.TickerExistsAsync(A<string>._)).Returns(Task.FromResult(false));
            A.CallTo(() => tickerService.GetTickerWeeklyAdjustedAsync(A<string>._)).Returns(Task.FromResult(fakeTickerTimeSeries));
            var controller = new TickerController(databaseService, tickerService);

            // Act
            var actionResult = await controller.GetTickerWeeklyAdjustedAsync(tickername);

            // Assert
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }

        [Fact]
        public async Task GetTickerWeeklyAsync_Returns_A_Time_Series_For_Valid_TickerName()
        {
            // Arrange
            string tickername = "AAPL";
            var fakeTickerTimeSeries = A.Fake<TickerTimeSeries>();
            var databaseService = A.Fake<IDatabaseService>();
            var tickerService = A.Fake<ITickerService>();

            A.CallTo(() => databaseService.TickerExistsAsync(A<string>._)).Returns(Task.FromResult(true));
            A.CallTo(() => tickerService.GetTickerWeeklyAsync(A<string>._)).Returns(Task.FromResult(fakeTickerTimeSeries));
            var controller = new TickerController(databaseService, tickerService);

            // Act
            var actionResult = await controller.GetTickerWeeklyAsync(tickername);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as OkObjectResult;
            Assert.True(result.Value is TickerTimeSeries);
        }

        [Fact]
        public async Task GetTickerWeeklyAsync_Returns_NotFound_For_InValid_TickerName()
        {
            // Arrange
            string tickername = "AAPL";
            var fakeTickerTimeSeries = A.Fake<TickerTimeSeries>();
            var databaseService = A.Fake<IDatabaseService>();
            var tickerService = A.Fake<ITickerService>();

            A.CallTo(() => databaseService.TickerExistsAsync(A<string>._)).Returns(Task.FromResult(false));
            A.CallTo(() => tickerService.GetTickerWeeklyAsync(A<string>._)).Returns(Task.FromResult(fakeTickerTimeSeries));
            var controller = new TickerController(databaseService, tickerService);

            // Act
            var actionResult = await controller.GetTickerWeeklyAsync(tickername);

            // Assert
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }

        [Fact]
        public async Task GetTickerMonthlyAdjustedAsync_Returns_A_Time_Series_For_Valid_TickerName()
        {
            // Arrange
            string tickername = "AAPL";
            var fakeTickerTimeSeries = A.Fake<TickerTimeSeries>();
            var databaseService = A.Fake<IDatabaseService>();
            var tickerService = A.Fake<ITickerService>();

            A.CallTo(() => databaseService.TickerExistsAsync(A<string>._)).Returns(Task.FromResult(true));
            A.CallTo(() => tickerService.GetTickerMonthlyAdjustedAsync(A<string>._)).Returns(Task.FromResult(fakeTickerTimeSeries));
            var controller = new TickerController(databaseService, tickerService);

            // Act
            var actionResult = await controller.GetTickerMonthlyAdjustedAsync(tickername);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as OkObjectResult;
            Assert.True(result.Value is TickerTimeSeries);
        }

        [Fact]
        public async Task GetTickerMonthlyAdjustedAsync_Returns_NotFound_For_InValid_TickerName()
        {
            // Arrange
            string tickername = "AAPL";
            var fakeTickerTimeSeries = A.Fake<TickerTimeSeries>();
            var databaseService = A.Fake<IDatabaseService>();
            var tickerService = A.Fake<ITickerService>();

            A.CallTo(() => databaseService.TickerExistsAsync(A<string>._)).Returns(Task.FromResult(false));
            A.CallTo(() => tickerService.GetTickerMonthlyAdjustedAsync(A<string>._)).Returns(Task.FromResult(fakeTickerTimeSeries));
            var controller = new TickerController(databaseService, tickerService);

            // Act
            var actionResult = await controller.GetTickerMonthlyAdjustedAsync(tickername);

            // Assert
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }

        [Fact]
        public async Task GetTickerMonthlyAsync_Returns_A_Time_Series_For_Valid_TickerName()
        {
            // Arrange
            string tickername = "AAPL";
            var fakeTickerTimeSeries = A.Fake<TickerTimeSeries>();
            var databaseService = A.Fake<IDatabaseService>();
            var tickerService = A.Fake<ITickerService>();

            A.CallTo(() => databaseService.TickerExistsAsync(A<string>._)).Returns(Task.FromResult(true));
            A.CallTo(() => tickerService.GetTickerMonthlyAsync(A<string>._)).Returns(Task.FromResult(fakeTickerTimeSeries));
            var controller = new TickerController(databaseService, tickerService);

            // Act
            var actionResult = await controller.GetTickerMonthlyAsync(tickername);

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as OkObjectResult;
            Assert.True(result.Value is TickerTimeSeries);
        }

        [Fact]
        public async Task GetTickerMonthlyAsync_Returns_NotFound_For_InValid_TickerName()
        {
            // Arrange
            string tickername = "AAPL";
            var fakeTickerTimeSeries = A.Fake<TickerTimeSeries>();
            var databaseService = A.Fake<IDatabaseService>();
            var tickerService = A.Fake<ITickerService>();

            A.CallTo(() => databaseService.TickerExistsAsync(A<string>._)).Returns(Task.FromResult(false));
            A.CallTo(() => tickerService.GetTickerMonthlyAsync(A<string>._)).Returns(Task.FromResult(fakeTickerTimeSeries));
            var controller = new TickerController(databaseService, tickerService);

            // Act
            var actionResult = await controller.GetTickerMonthlyAsync(tickername);

            // Assert
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }

        [Fact]
        public async Task GetAllTickersAsync_Returns_A_Correct_List_Of_Tickers()
        {
            // Arrange
            int count = 10;
            var fakeTickers = A.CollectionOfDummy<Server.Models.DTO.Ticker>(count).ToArray();
            var databaseService = A.Fake<IDatabaseService>();
            var tickerService = A.Fake<ITickerService>();
            A.CallTo(() => databaseService.GetTickersAsync()).Returns(Task.FromResult(fakeTickers));
            var controller = new TickerController(databaseService, tickerService);

            // Act
            var actionResult = await controller.GetAllTickersAsync();

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            var result = actionResult.Result as OkObjectResult;

            Assert.True(result.Value is Ticker[]);
            var value = result.Value as Ticker[];
            Assert.Equal(count, value.Length);
        }
    }
}
