namespace ProductInventory.Models
{
    using ProductInventory.Contacts;
    using System.Linq;
    using System.Collections.Generic;
    using System;

    class Inventory : IInventory
    {
        public ICollection<IProduct> Products { get; private set; }

        public Inventory()
        {
            this.Products = new List<IProduct>();
        }

        public void Add(IProduct product)
        {
            this.Products.Add(product);
        }

        public void Remove(string name)
        {
            var product = this.Products.FirstOrDefault(p => p.Name.Equals(name));

            if (product != null)
            {
                this.Products.Remove(product);
            }
            else
            {
                throw new ArgumentException("No such product exists in inventory!");
            }
        }

        public decimal GetTotalValue()
        {
            return this.Products.Select(p => p.GetProductValue()).Sum();
        }

        public IProduct GetProduct(string name)
        {
            var product = this.Products.FirstOrDefault(p => p.Name.Equals(name));

            if (product != null)
            {
                return product;
            }
            else
            {
                throw new ArgumentException("No such product exists in inventory!");
            }
        }
    }
}
