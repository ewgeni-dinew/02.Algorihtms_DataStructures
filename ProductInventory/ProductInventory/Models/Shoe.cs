namespace ProductInventory.Models
{
    internal class Shoe : Product
    {
        public Shoe(string name, string description, int quantity, decimal price)
            : base(name, description, quantity, price)
        {
        }
    }
}
