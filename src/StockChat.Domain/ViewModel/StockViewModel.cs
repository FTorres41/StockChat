using System;

namespace StockChat.Domain.ViewModel
{
    public class StockViewModel
    {
        public class Response
        {
            public RequestedStockViewModel RequestedStock { get; set; }
            public ErrorViewModel Error { get; set; }

            public bool HasError() => Error != null;
        }
    }
}
