using Microsoft.Extensions.DependencyInjection;

namespace StockChat.ExternalServices
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddExternalServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
