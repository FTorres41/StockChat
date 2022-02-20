using StockChat.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockChat.Domain.Interfaces.ExternalServices
{
    public interface IStooqExternalService
    {
        Task<IList<DailyStock>> Get(string stock);
    }
}
