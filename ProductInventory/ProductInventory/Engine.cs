namespace ProductInventory
{
    using System;
    using System.Reflection;
    using ProductInventory.Contacts;
    using ProductInventory.Factories;
    using ProductInventory.Models;

    internal class Engine
    {
        private IProductFactory productFactory;
        private IInventory inventory;

        public Engine()
        {
            this.productFactory = new ProductFactory();
            this.inventory = new Inventory();
        }

        internal void Run()
        {
            while (true)
            {
                Console.WriteLine("Input command: ");
                var command = Console.ReadLine();

                if (command.ToLower().Equals("end"))
                {
                    Console.WriteLine("Program terminated.");
                    break;
                }

                try
                {
                    switch (command.ToLower().Trim())
                    {
                        case "add product":
                            CreateProduct();
                            break;
                        case "remove product":
                            RemoveProduct();
                            break;
                        case "add stock":
                            AddStockToProduct();
                            break;
                        case "remove stock":
                            RemoveStockFromProduct();
                            break;
                        case "product value":
                            GetProductValue();
                            break;
                        case "inventory value":
                            GetInventoryValue();
                            break;
                        case "product info":
                            GetProductInfo();
                            break;
                        default:
                            break;
                    }
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Invalid input product type!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input format!");
                }
                catch (TargetInvocationException ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (MissingMemberException)
                {
                    Console.WriteLine("Cannot instanciate member of given type!");
                }
                finally
                {
                    Console.WriteLine();
                }
            }
        }

        private void CreateProduct()
        {
            Console.Write("Input product type: ");
            var type = Console.ReadLine();

            Console.Write("Input product name: ");
            var name = Console.ReadLine();

            Console.Write("Input product description: ");
            var description = Console.ReadLine();

            Console.Write("Input product quantity: ");
            var quantity = int.Parse(Console.ReadLine());

            Console.Write("Input product price: ");
            var price = decimal.Parse(Console.ReadLine());

            var product = this.productFactory.CreateProduct(type, name, description, quantity, price);
            this.inventory.Add(product);
        }

        private void RemoveProduct()
        {
            Console.Write("Input product name: ");
            var name = Console.ReadLine();

            this.inventory.Remove(name);
        }

        private void AddStockToProduct()
        {
            Console.WriteLine("Input product name: ");
            var name = Console.ReadLine();

            Console.Write("Input amount: ");
            var amount = int.Parse(Console.ReadLine());

            var product = this.inventory.GetProduct(name);

            product.AddStock(amount);
        }

        private void RemoveStockFromProduct()
        {
            Console.WriteLine("Input product name: ");
            var name = Console.ReadLine();

            Console.WriteLine("Input amount: ");
            var amount = int.Parse(Console.ReadLine());

            var product = this.inventory.GetProduct(name);

            product.RemoveStock(amount);
        }

        private void GetProductValue()
        {
            Console.WriteLine("Input product name: ");
            var name = Console.ReadLine();

            var product = this.inventory.GetProduct(name);

            Console.WriteLine(product.GetProductValue());
        }

        private void GetInventoryValue()
        {
            Console.WriteLine(this.inventory.GetTotalValue());
        }

        private void GetProductInfo()
        {
            Console.WriteLine("Input product name: ");
            var name = Console.ReadLine();

            var product = this.inventory.GetProduct(name);

            Console.WriteLine(product.ToString());
        }
    }
}
