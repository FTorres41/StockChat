namespace StockChat.Domain.Messages.Commands
{
    public class GetRequestedStockCommand
    {
        public string User { get; set; }
        public string Stock { get; set; }
    }
}
