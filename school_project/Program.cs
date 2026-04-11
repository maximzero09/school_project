using System;

namespace MyApp
{
    internal class Program
    {
	static void Main(string[] args)
	{
	    List<Order> orders = new List<Order>();
	    Console.WriteLine("Hello, welcome to store managing program 1.0");

	    int input = -1;

	    while (input != 0)
	    {
		Console.WriteLine("\nPlease select option:");
		Console.WriteLine("1 - Add product");
		Console.WriteLine("2 - view products");
		Console.WriteLine("3 - create new order");
		Console.WriteLine("4 - Add customers");
		Console.WriteLine("0 - Exit");
		Console.WriteLine("5 - look up product by name");
		input = int.Parse(Console.ReadLine());

		switch (input)
		{
		    case 1:
			Console.WriteLine("Please enter product name:");
			string pn = Console.ReadLine();
			Console.WriteLine("Please enter price");
			int price = int.Parse(Console.ReadLine());
			Console.WriteLine("Please enter quantity");
			int quantity = int.Parse(Console.ReadLine());
			int id = Random.Shared.Next(1000, 9999); // random product ID
			Product product = new Product(id, pn, price,quantity  );
			Console.WriteLine($"Product '{pn}' assigned ID: {id}");
			Store.products.Add(product);
			break;

		    case 0:
			Console.WriteLine("Exiting program...");
			break;
		    case 2:
			if(Store.products.Count == 0)
			{
			    Console.WriteLine("no products");

			}
			else
			{
			    foreach(var p in Store.products)
			    {
				Console.WriteLine($"ID: {p.ID}, Name: {p.Name}, Price: {p.Price}, Quantity: {p.Quantity}");
			    }
			}
			break;
		    case 3:
			Console.WriteLine("Enter client name:");
			string? clientName = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(clientName))
			{
			    Console.WriteLine("Invalid name.");
			    break;
			}

			List<Product> selectedProducts = new List<Product>();

			while (true)
			{
			    Console.WriteLine("Enter product ID to add (0 to finish):");

			    if (!int.TryParse(Console.ReadLine(), out int pid))
			    {
				Console.WriteLine("Invalid ID.");
				continue;
			    }

			    if (pid == 0)
				break;

			    Product? found = Store.products.FirstOrDefault(p => p.ID == pid);

			    if (found == null)
			    {
				Console.WriteLine("Product not found.");
			    }
			    else
			    {
				selectedProducts.Add(found);
				Console.WriteLine("Added.");
			    }
			}

			if (selectedProducts.Count == 0)
			{
			    Console.WriteLine("No products selected.");
			    break;
			}

			int orderId = Random.Shared.Next(1000, 9999);
			Order order = new Order(orderId, clientName, selectedProducts);

			orders.Add(order);

			Console.WriteLine($"Order {orderId} created. Total: {order.TotalPrice}");

			break;
		    case 4:
			Console.WriteLine("Please enter name ");
			string name = Console.ReadLine();
			Console.WriteLine("Please enter email ");
			string email = Console.ReadLine();
			int cid = Random.Shared.Next(1000, 9999); 
			Customer customer = new Customer(cid, name, email);
			break;	
		    case 5:
			Console.WriteLine("Please enter product name");
			string cinput = Console.ReadLine();
			var pfound = Store.products.FirstOrDefault(p => p.Name.Equals(cinput, StringComparison.OrdinalIgnoreCase));				if (pfound == null)	
			{
			    Console.WriteLine("Product not found");
			}
			else
			{
			    Console.WriteLine($"Product: \n {pfound.Name} \n Price:{pfound.Price} \n ID: {pfound.ID} \n  ");
			}
			break;
		    default:
			Console.WriteLine("Invalid option");
			break;
		}
	    }
	}
    }
}
