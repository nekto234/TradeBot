using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Interfaces
{
    public interface IMarketItem : IItem
    {
        string GeneralId { get; set; }

        string UniqueId { get; set; }
    }
}
