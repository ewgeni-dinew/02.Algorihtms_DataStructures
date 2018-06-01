namespace ProductInventory.Models
{
    using ProductInventory.Contacts;
    using System;
    using System.Text;

    internal abstract class Product : IProduct
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            private set
            {
                if (value < 0)
                {
                    quantity = 0;
                }
                else
                {
                    quantity = value;
                }
            }
        }

        protected Product(string name, string description, int quantity, decimal price)
        {
            if (price <= 0)
            {
                throw new ArgumentException("Product price cannot be null or negative");
            }
            if (quantity < 0)
            {
                throw new ArgumentException("Product quantity cannot be null or negative!");
            }
            this.Name = name;
            this.Description = description;
            this.Quantity = quantity;
            this.Price = price;
        }

        public void AddStock(int amount)
        {
            this.Quantity += amount;
        }

        public void RemoveStock(int amount)
        {
            this.Quantity -= amount;
        }

        public decimal GetProductValue()
        {
            return this.Quantity * this.Price;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Description: {this.Description}");
            sb.AppendLine($"Quantity: {this.Quantity}");
            sb.Append($"Price: {this.Price}");

            return sb.ToString();
        }
    }
}
