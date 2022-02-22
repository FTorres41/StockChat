namespace StockChat.Domain.ViewModel
{
    public class RequestedStockViewModel
    {
        public RequestedStockViewModel() { }

        public RequestedStockViewModel(string user, string stock, decimal value)
        {
            User = user;
            Stock = stock.ToUpper();
            Value = value;
        }

        public string User { get; set; }
        public string Stock { get; set; }
        public decimal Value { get; set; }
    }
}