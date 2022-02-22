using AutoMapper;
using MassTransit;
using StockChat.Domain.Entities;
using StockChat.Domain.Interfaces.Services;
using StockChat.Domain.Messages.Commands;
using System.Threading.Tasks;

namespace StockChat.Broker.Consumers
{
    public class GetRequestedStock : IConsumer<GetRequestedStockCommand>
    {
        private readonly IStockService _stockService;
        private readonly IChatService _chatService;
        private readonly IMapper _mapper;

        public GetRequestedStock(IStockService stockService, IChatService chatService, IMapper mapper)
        {
            _stockService = stockService;
            _chatService = chatService;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<GetRequestedStockCommand> context)
        {
            var message = context.Message;
            var response = await _stockService.Get(message.User, message.Stock);
            if (response != null)
            {
                await _chatService.Send(_mapper.Map<ChatMessage>(response));
            }
        }
    }
}
