using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface ISteam<T>
    {
        Task<T> GetPriceById(string id, T model);

        Task<T> GetByName(string name, T model);

        Task<T> GetShortPriceInfoByName(string name, T model);

        Task GetSteamInventory(string steamId);
    }
}
