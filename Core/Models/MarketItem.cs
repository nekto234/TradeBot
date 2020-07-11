using Shared.Interfaces;

namespace Core.Models
{
    public class MarketItem : Item, IMarketItem
    {
        public string GeneralId { get; set; }

        public string UniqueId { get; set; }
    }
}
