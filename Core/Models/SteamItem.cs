using Shared.Interfaces;

namespace Core.Models
{
    public class SteamItem : Item, ISteamItem
    {
        public string GeneralId { get; set; }
        public int CountBySellPrice { get; set; }
        public int CountByOrderPrice { get; set; }
    }
}
