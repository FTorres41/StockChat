using AutoMapper;
using StockChat.Domain.Enums;
using StockChat.Domain.Interfaces.ExternalServices;
using StockChat.Domain.Interfaces.Services;
using StockChat.Domain.ViewModel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StockChat.Services.Services
{
    public class StockService : IStockService
    {
        private readonly IStooqExternalService _stooqExternalService;
        private readonly IMapper _mapper;

        public StockService(IStooqExternalService stooqExternalService, IMapper mapper)
        {
            _stooqExternalService = stooqExternalService;
            _mapper = mapper;
        }

        public async Task<StockViewModel.Response> Get(string user, string stock)
        {
            try
            {
                var stocks = await _stooqExternalService.Get(stock);
                if (stocks.Any())
                {
                    var todayStock = stocks.OrderByDescending(s => s.DateTime).FirstOrDefault();
                    return _mapper.Map<StockViewModel.Response>((user, stock, todayStock.Close));
                }

                return _mapper.Map<StockViewModel.Response>(StockError.StockNotFound);
            }
            catch (Exception e)
            {
                return _mapper.Map<StockViewModel.Response>((StockError.ApiError, e));
            }
        }
    }
}
