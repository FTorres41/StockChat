using MassTransit;
using StockChat.Domain.Messages.Commands;
using System.Threading.Tasks;

namespace StockChat.Broker.Consumers
{
    public class GetRequestedStock : IConsumer<GetRequestedStockCommand>
    {
        public Task Consume(ConsumeContext<GetRequestedStockCommand> context)
        {
            throw new System.NotImplementedException();
        }
    }
}
