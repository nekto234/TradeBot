using System;

namespace Shared.Interfaces
{
    public interface IItem
    {
        int Id { get; set; }

        string Name { get; set; }

        double Price { get; set; }

        DateTime UpdatedAt { get; set; }

        double OrderPrice { get; set; }

        int SaleCount { get; set; }
    }
}
