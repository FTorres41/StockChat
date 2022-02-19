using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace StockChat.SignalR.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string target, string message)
        {
            if (!string.IsNullOrEmpty(user))
                await Groups.AddToGroupAsync(Context.ConnectionId, user);

            if (!string.IsNullOrEmpty(target) && Clients.Group(target) != null)
                await Clients.Group(target).SendAsync("ReceiveMessage", user, message);
            else
                await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override Task OnConnectedAsync() => base.OnConnectedAsync();

        public override Task OnDisconnectedAsync(System.Exception exception) => base.OnDisconnectedAsync(exception);
    }
}