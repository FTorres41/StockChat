using MassTransit;
using StockChat.Domain.Interfaces.Services;
using StockChat.Domain.Messages.Commands;
using System.Threading.Tasks;

namespace StockChat.Broker.Consumers
{
    public class GetRequestedStock : IConsumer<GetRequestedStockCommand>
    {
        private readonly IStockService _stockService;
        private readonly IChatService _chatService;

        public GetRequestedStock(IStockService stockService, IChatService chatService)
        {
            _stockService = stockService;
            _chatService = chatService;
        }

        public async Task Consume(ConsumeContext<GetRequestedStockCommand> context)
        {
            var message = context.Message;
            try
            {
                var response = await _stockService.Get(message.User, message.Stock);
                if (response != null)
                {
                    await _chatService.Send()
                }
            }
        }
    }
}
