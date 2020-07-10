using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SteamModule
{
    public class Steam<T> : IGeneral<T>
    {
        public async Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByName(string name)
        {
            //HttpUtility.UrlEncode(name, Encoding.UTF8);
            throw new NotImplementedException();
        }

        public async Task PostOrderOnMarket()
        {

        }
    }
}
