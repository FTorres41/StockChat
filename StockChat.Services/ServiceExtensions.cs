using Microsoft.Extensions.DependencyInjection;
using StockChat.Domain.Interfaces.Services;
using StockChat.Services.Services;

namespace StockChat.Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IStockService, StockService>();

            return services;
        }
    }
}
