using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface IGeneral<T>
    {
        Task<T> GetById(int id);

        Task<T> GetByName(string name);  
    }
}
