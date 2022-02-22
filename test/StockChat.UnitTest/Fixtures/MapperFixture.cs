using AutoMapper;
using StockChat.Mappings.Profiles;

namespace StockChat.UnitTest.Fixtures
{
    public static class MapperFixture
    {
        public static IMapper GetMapper()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.AddProfile(new DomainToViewModelProfile());
                cfg.AddProfile(new ViewModelToDomainProfile());
                cfg.AddProfile(new ExternalServiceToDomainProfile());
            });

            return configuration.CreateMapper();
        }
    }
}
