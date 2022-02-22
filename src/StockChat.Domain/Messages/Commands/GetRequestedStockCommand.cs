namespace StockChat.Domain.Messages.Commands
{
    public class GetRequestedStockCommand
    {
        public GetRequestedStockCommand(string user, string stock)
        {
            User = user;
            Stock = stock;
        }

        public string User { get; set; }
        public string Stock { get; set; }
    }
}
