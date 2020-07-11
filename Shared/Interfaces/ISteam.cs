using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface ISteam<T>
    {
        Task<T> GetPriceById(string id, T model);

        Task<T> GetByName(string name, T model);
    }
}
