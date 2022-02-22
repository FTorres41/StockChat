using FizzWare.NBuilder;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StockChat.Domain.Interfaces.Services;
using StockChat.Domain.ViewModel;
using StockChat.WebApi.Controllers;
using Xunit;

namespace StockChat.UnitTest.WebApi.Controllers
{
    public class StockControllerTest
    {
        private readonly Mock<IStockService> _mockService;

        public StockControllerTest()
        {
            _mockService = new();
        }

        [Theory(DisplayName = "Should return OkResult(200)")]
        [Trait("Controller", "Stock")]
        [InlineData("user", "stock")]
        [InlineData("Request", "APPL.US")]
        public void StockController_ValidData_ShouldReturn200(string user, string stock)
        {
            //Arrange
            var requestedStock = Builder<RequestedStockViewModel>.CreateNew().With(s => s.User = user).With(s => s.Stock = stock).Build();
            var response = Builder<StockViewModel.Response>.CreateNew().With(r => r.RequestedStock = requestedStock).Build();
            _mockService.Setup(x => x.Get(user, stock)).ReturnsAsync(response);
            var controller = new StockController(_mockService.Object);

            //Act
            var result = controller.Get(user, stock).Result;

            //Assert
            Assert.NotNull(result);
            var okResult = Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.Equal(200, (int)okResult.StatusCode);
        }

        [Theory(DisplayName = "Should return BadRequest(400)")]
        [Trait("Controller", "Stock")]
        [InlineData("user", "stock")]
        [InlineData("Request", "APPL.US")]
        public void StockController_InvalidData_ShouldReturn400(string user, string stock)
        {
            //Arrange
            var errorViewModel = Builder<ErrorViewModel>.CreateNew().Build();
            var response = Builder<StockViewModel.Response>.CreateNew().With(r => r.Error = errorViewModel).Build();
            _mockService.Setup(x => x.Get(user, stock)).ReturnsAsync(response);
            var controller = new StockController(_mockService.Object);

            //Act
            var result = controller.Get(user, stock).Result;

            //Assert
            Assert.NotNull(result);
            var badRequestResult = Assert.IsAssignableFrom<BadRequestObjectResult>(result);
            Assert.Equal(400, (int)badRequestResult.StatusCode);
        }
    }
}
