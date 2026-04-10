using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, welcome to store managing program 1.0");

            int input = -1;

            while (input != 0)
            {
                Console.WriteLine("\nPlease select option:");
                Console.WriteLine("1 - Add product");
                Console.WriteLine("0 - Exit");

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
			    break;


                    case 0:
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }
}
