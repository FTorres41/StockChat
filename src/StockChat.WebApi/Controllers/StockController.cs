using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockChat.Domain.Interfaces.Services;
using StockChat.Domain.ViewModel;
using System.Net;
using System.Threading.Tasks;

namespace StockChat.WebApi.Controllers
{
    [ApiController]
    [Route("api/stock")]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        /// <summary>
        /// Retrieves selected stock's value
        /// </summary>
        /// <param name="user">User who requested the stock</param>
        /// <param name="stock">The stock that has to be searched</param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(StockViewModel.Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorViewModel), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get(string user, string stock)
        {
            var response = await _stockService.Get(user, stock);
            if (response.HasError())
                return BadRequest(response.Error);

            return Ok(response.RequestedStock);
        }
    }
}