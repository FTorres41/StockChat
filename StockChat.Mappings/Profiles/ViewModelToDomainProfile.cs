using AutoMapper;
using StockChat.Domain.Entities;
using StockChat.Domain.ViewModel;

namespace StockChat.Mappings.Profiles
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<StockViewModel.Response, ChatMessage>()
                .ForMember(destination => destination.User, origin => origin.MapFrom(src => src.RequestedStock.User))
                .ForMember(destination => destination.Message, origin => origin.MapFrom(src => $"{src.RequestedStock.Stock.ToUpper()} quote is ${src.RequestedStock.Value} per share"));
        }
    }
}
