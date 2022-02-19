using StockChat.Domain.Interfaces.Services;
using StockChat.Domain.ViewModel;
using System.Threading.Tasks;

namespace StockChat.Services.Services
{
    public class StockService : IStockService
    {
        public StockService()
        {

        }

        public Task<StockViewModel.Response> Get(string user, string stock)
        {
            throw new System.NotImplementedException();
        }
    }
}
