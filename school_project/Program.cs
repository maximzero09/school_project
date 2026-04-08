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
			 int id = Random.Shared.Next(1000, 9999); // random product ID

		        Console.WriteLine($"Product '{pn}' assigned ID: {id}");
			    break;

			Console.WriteLine("Please enter ");
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
