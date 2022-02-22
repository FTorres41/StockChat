using AutoMapper;
using StockChat.Domain.Entities;
using StooqApi;

namespace StockChat.Mappings.Profiles
{
    public class ExternalServiceToEntitiesProfile : Profile
    {
        public ExternalServiceToEntitiesProfile()
        {
            CreateMap<Candle, DailyStock>();
        }
    }
}
