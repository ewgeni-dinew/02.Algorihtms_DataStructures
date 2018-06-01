using System;
using System.Collections.Generic;
using System.Text;

namespace ProductInventory.Contacts
{
    interface IInventory
    {
        ICollection<IProduct> Products { get; }

        void Add(IProduct product);
        void Remove(string name);
        decimal GetTotalValue();
        IProduct GetProduct(string name);
    }
}
