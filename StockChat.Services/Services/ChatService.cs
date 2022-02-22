using Microsoft.AspNetCore.SignalR;
using StockChat.Domain.Entities;
using StockChat.Domain.Interfaces.Services;
using StockChat.SignalR.Hubs;
using System;
using System.Threading.Tasks;

namespace StockChat.Services.Services
{
    public class ChatService : IChatService
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatService(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task Send(ChatMessage message)
        {
            if (string.IsNullOrEmpty(message.User))
                throw new ArgumentNullException("User must not be null or empty");

            if (_hubContext.Clients.Group(message.User) != null)
                await _hubContext.Clients.Group(message.User).SendAsync("ReceiveMessage", message.User, message.Message);
        }
    }
}
