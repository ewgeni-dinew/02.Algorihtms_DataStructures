namespace ProductInventory.Models
{
    internal class Pants : Product
    {
        public Pants(string name, string description, int quantity, decimal price)
            : base(name, description, quantity, price)
        {
        }
    }
}
