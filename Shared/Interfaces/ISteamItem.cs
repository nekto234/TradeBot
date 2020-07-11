namespace Shared.Interfaces
{
    public interface ISteamItem : IItem
    {
        string GeneralId { get; set; }

        int CountBySellPrice { get; set; }

        int CountByOrderPrice { get; set; }
    }
}
