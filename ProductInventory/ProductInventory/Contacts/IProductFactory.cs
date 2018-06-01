using System;
using System.Collections.Generic;
using System.Text;

namespace ProductInventory.Contacts
{
    internal interface IProductFactory
    {
        IProduct CreateProduct(string type, string name, string description, int quantity, decimal price);
    }
}
