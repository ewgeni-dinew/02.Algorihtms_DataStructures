using System;
using System.Collections.Generic;
using System.Text;

namespace ProductInventory.Contacts
{
    internal interface IProduct
    {
        string Name { get; }
        string Description { get; }
        int Quantity { get; }
        decimal Price { get; }

        void AddStock(int amount);
        void RemoveStock(int amount);
        decimal GetProductValue();
    }
}
