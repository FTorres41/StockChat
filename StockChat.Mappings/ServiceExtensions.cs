using Microsoft.Extensions.DependencyInjection;
using StockChat.Mappings.Profiles;

namespace StockChat.Mappings
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => {
                cfg.AddProfile(new ExternalServiceToEntitiesProfile());
            });

            return services;
        }
    }
}
