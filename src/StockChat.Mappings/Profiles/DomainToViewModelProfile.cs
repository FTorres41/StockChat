using AutoMapper;
using StockChat.Domain.Enums;
using StockChat.Domain.ViewModel;
using System;

namespace StockChat.Mappings.Profiles
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<(string, string, decimal), StockViewModel.Response>()
                .ForMember(destination => destination.RequestedStock, source => source.MapFrom(src => new RequestedStockViewModel(src.Item1, src.Item2, src.Item3)));

            CreateMap<StockError, StockViewModel.Response>()
                .ForMember(destination => destination.Error, source => source.MapFrom(src => new ErrorViewModel(src.ToString(), EnumHelper.GetDescription(src))));

            CreateMap<(StockError, Exception), StockViewModel.Response>()
                .ForMember(destination => destination.Error, source => source.MapFrom(src => new ErrorViewModel(src.Item1.ToString(), GetErrorMessage(src))));
        }

        private static string GetErrorMessage((StockError, Exception) src) =>  string.Format(EnumHelper.GetDescription(src.Item1), src.Item2.Message);
    }
}
