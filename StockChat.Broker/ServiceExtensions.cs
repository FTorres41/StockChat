using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace StockChat.Broker
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureMassTransit(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.UsingInMemory((context, cfg) =>
                {
                    cfg.TransportConcurrencyLimit = 100;
                    cfg.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}
