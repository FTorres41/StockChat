using AutoMapper;
using StockChat.Domain.Entities;
using StooqApi;

namespace StockChat.Mappings.Profiles
{
    public class ExternalServiceToDomainProfile : Profile
    {
        public ExternalServiceToDomainProfile()
        {
            CreateMap<Candle, DailyStock>();
        }
    }
}
