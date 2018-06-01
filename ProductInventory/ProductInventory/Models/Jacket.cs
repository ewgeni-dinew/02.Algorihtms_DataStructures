namespace ProductInventory.Models
{
    internal class Jacket : Product
    {
        public Jacket(string name, string description, int quantity, decimal price)
            : base(name, description, quantity, price)
        {
        }
    }
}
