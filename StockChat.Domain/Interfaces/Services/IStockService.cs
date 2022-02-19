using StockChat.Domain.ViewModel;
using System.Threading.Tasks;

namespace StockChat.Domain.Interfaces.Services
{
    public interface IStockService
    {
        Task<StockViewModel.Response> Get(string user, string stock);
    }
}
