namespace ProductInventory.Models
{
    internal class Sock : Product
    {
        public Sock(string name, string description, int quantity, decimal price)
            : base(name, description, quantity, price)
        {
        }
    }
}
