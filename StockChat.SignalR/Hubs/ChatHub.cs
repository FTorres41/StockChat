using Microsoft.AspNetCore.SignalR;
using StockChat.Broker;
using StockChat.Domain.Messages.Commands;
using System.Threading.Tasks;

namespace StockChat.SignalR.Hubs
{
    public class ChatHub : Hub
    {
        private const string BotTarget = "BOT";
        private readonly IStockChatBus _bus;

        public ChatHub(IStockChatBus bus)
        {
            _bus = bus;
        }

        public async Task SendMessage(string user, string target, string message)
        {
            if (!string.IsNullOrEmpty(user))
                await Groups.AddToGroupAsync(Context.ConnectionId, user);

            if (target.ToUpper() == BotTarget)
            {
                await _bus.Publish(new GetRequestedStockCommand(user, message));
                return;
            }
            
            if (!string.IsNullOrEmpty(target) && Clients.Group(target) != null)
                await Clients.Group(target).SendAsync("ReceiveMessage", user, message);
            else
                await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override Task OnConnectedAsync() => base.OnConnectedAsync();

        public override Task OnDisconnectedAsync(System.Exception exception) => base.OnDisconnectedAsync(exception);
    }
}