using MassTransit;
using MassTransit.MultiBus;
using Microsoft.Extensions.DependencyInjection;

namespace StockChat.Broker
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureMassTransit(this IServiceCollection services)
        {
            services.AddMassTransit<IStockChatBus>(x =>
            {
                x.UsingInMemory((context, cfg) =>
                {
                    cfg.TransportConcurrencyLimit = 10;
                    cfg.ConfigureEndpoints(context);
                });
            });
            services.AddMassTransitHostedService();

            return services;
        }
    }
}
