using AutoMapper;
using StockChat.Domain.Entities;
using StockChat.Domain.Interfaces.ExternalServices;
using StooqApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockChat.ExternalServices.ExternalServices
{
    public class StooqExternalService : IStooqExternalService
    {
        private readonly IMapper _mapper;

        public StooqExternalService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IList<DailyStock>> Get(string stock)
        {
            try
            {
                var startTime = DateTime.Today.AddDays(-7);
                var endTime = DateTime.Today;
                var response = await Stooq.GetHistoricalAsync(symbol: stock, startTime: startTime, endTime: endTime);

                if (response != null)
                    return _mapper.Map<IList<DailyStock>>(response);

                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
