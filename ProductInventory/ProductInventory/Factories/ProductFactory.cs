namespace ProductInventory.Factories
{
    using ProductInventory.Contacts;
    using System;
    using System.Linq;
    using System.Reflection;

    internal class ProductFactory : IProductFactory
    {
        public IProduct CreateProduct(string type, string name,string description, int quantity, decimal price)
        {
            var productType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Single(t => t.Name.ToLower().Equals(type.ToLower()));

            return (IProduct)Activator.CreateInstance(productType,name,description,quantity,price);
        }
    }
}
