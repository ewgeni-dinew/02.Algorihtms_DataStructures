namespace ProductInventory.Models
{
    internal class Coat : Product
    {
        public Coat(string name, string description, int quantity, decimal price)
            : base(name, description, quantity, price)
        {
        }
    }
}
