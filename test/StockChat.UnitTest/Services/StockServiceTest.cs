using AutoMapper;
using FizzWare.NBuilder;
using Moq;
using StockChat.Domain.Entities;
using StockChat.Domain.Enums;
using StockChat.Domain.Interfaces.ExternalServices;
using StockChat.Services.Services;
using StockChat.UnitTest.Fixtures;
using System.Collections.Generic;
using Xunit;
using EnumHelper = StockChat.Domain.Enums.EnumHelper;

namespace StockChat.UnitTest.Services
{
    public class StockServiceTest
    {
        private readonly Mock<IStooqExternalService> _mockExternalService;
        private readonly IMapper _mapper;

        public StockServiceTest()
        {
            _mockExternalService = new();
            _mapper = MapperFixture.GetMapper();
        }

        [Theory(DisplayName = "Should return valid stock")]
        [Trait("Service", "Stock")]
        [InlineData("user", "stock", 1)]
        [InlineData("Request", "APPL.US", 2)]
        public void StockService_ValidData_ShouldReturnStock(string user, string stock, int quantity)
        {
            //Arrange
            var externalServiceResponse = Builder<DailyStock>.CreateListOfSize(quantity).TheFirst(1).With(d => d.DateTime = System.DateTime.Today).Build();
            _mockExternalService.Setup(x => x.Get(stock)).ReturnsAsync(externalServiceResponse);
            var service = new StockService(_mockExternalService.Object, _mapper);

            //Act
            var result = service.Get(user, stock).Result;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(user, result.RequestedStock.User);
            Assert.True(result.RequestedStock.Value != 0);
        }

        [Theory(DisplayName = "Should return StockNotFound error")]
        [Trait("Service", "Stock")]
        [InlineData("user", "stock")]
        [InlineData("Request", "APPL.US")]
        public void StockService_InvalidData_ShouldReturnStockNotFound(string user, string stock)
        {
            //Arrange
            var externalServiceResponse = Builder<List<DailyStock>>.CreateNew().Build();
            _mockExternalService.Setup(x => x.Get(stock)).ReturnsAsync(externalServiceResponse);
            var service = new StockService(_mockExternalService.Object, _mapper);

            //Act
            var result = service.Get(user, stock).Result;

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Error);
            Assert.Equal(StockError.StockNotFound.ToString(), result.Error.Code);
            Assert.Equal(EnumHelper.GetDescription(StockError.StockNotFound), result.Error.Message);
        }

        [Theory(DisplayName = "Should return ApiError error")]
        [Trait("Service", "Stock")]
        [InlineData("user", null)]
        [InlineData("Request", "")]
        public void StockService_InvalidData_ShouldReturnApiError(string user, string stock)
        {
            //Arrange
            var errorMessage = "Invalid stock value";
            _mockExternalService.Setup(x => x.Get(stock)).ThrowsAsync(new System.Exception(errorMessage));
            var service = new StockService(_mockExternalService.Object, _mapper);

            //Act
            var result = service.Get(user, stock).Result;

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Error);
            Assert.Equal(StockError.ApiError.ToString(), result.Error.Code);
            Assert.Equal(string.Format(EnumHelper.GetDescription(StockError.ApiError), errorMessage), result.Error.Message);
        }
    }
}
