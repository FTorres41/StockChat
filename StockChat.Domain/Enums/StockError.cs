using System.ComponentModel;

namespace StockChat.Domain.Enums
{
    public enum StockError
    {
        [Description("Stock has not been found or isn't available for the specified datetime range")]
        StockNotFound = 0,

        [Description("An error has occurred when Stooq was reached: {0}")]
        ApiError = 1,
    }
}
