using Shared.Interfaces;
using System;

namespace Core.Models
{
    public class Item : IItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public DateTime UpdatedAt { get; set; }

        public double OrderPrice { get; set; }

        public int SaleCount { get; set; }
    }
}
