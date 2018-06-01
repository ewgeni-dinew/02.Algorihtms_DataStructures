namespace ProductInventory.Models
{
    internal class Shirt : Product
    {
        public Shirt(string name, string description, int quantity, decimal price)
            : base(name, description, quantity, price)
        {

        }
    }
}
