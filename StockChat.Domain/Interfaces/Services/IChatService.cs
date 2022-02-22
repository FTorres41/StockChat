using StockChat.Domain.Entities;
using System.Threading.Tasks;

namespace StockChat.Domain.Interfaces.Services
{
    public interface IChatService
    {
        Task Send(ChatMessage message);
    }
}
