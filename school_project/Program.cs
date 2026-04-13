using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_project
{
    internal class Program
    {

        private static readonly Random random = new Random();
        static void Main(string[] args)
        {

            Console.WriteLine("Hello, welcome to store managing program 1.0");

            int input = -1;

            while (input != 0)
            {
                Console.WriteLine("\nPlease select option:");
                Console.WriteLine("1 - Add product");
                Console.WriteLine("2 - view products");
                Console.WriteLine("3 - create new order");
                Console.WriteLine("4 - Add customers");
                Console.WriteLine("5 - look up product by name");
                Console.WriteLine("6 - view all clients");
                Console.WriteLine("7 - view total revenue");
                Console.WriteLine("8 - view order history");
                Console.WriteLine("0 - Exit");

                string rawInput = Console.ReadLine();
                if (!int.TryParse(rawInput, out input)) continue;

                switch (input)
                {
                    case 1:
                        Console.WriteLine("Please enter product name:");
                        string pn = Console.ReadLine();
                        Console.WriteLine("Please enter price");
                        int price = int.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter quantity");
                        int quantity = int.Parse(Console.ReadLine());

                        int id = random.Next(1000, 9999);
                        Product product = new Product(id, pn, price, quantity);
                        Console.WriteLine($"Product '{pn}' assigned ID: {id}");
                        Store.products.Add(product);
                        break;

                    case 0:
                        Console.WriteLine("Exiting program...");
                        break;

                    case 2:
                        if (Store.products.Count == 0)
                        {
                            Console.WriteLine("no products");
                        }
                        else
                        {
                            foreach (var p in Store.products)
                            {
                                Console.WriteLine($"ID: {p.ID}, Name: {p.Name}, Price: {p.Price}, Quantity: {p.Quantity}");
                            }
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter client name:");
                        string clientName = Console.ReadLine();

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

                            if (pid == 0) break;

                            Product found = Store.products.FirstOrDefault(p => p.ID == pid);

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


                        int orderId = random.Next(1000, 9999);
                        Order order = new Order(orderId, clientName, selectedProducts);


                        Store.orders.Add(order);

                        Console.WriteLine($"Order {orderId} created. Total: {order.TotalPrice}");
                        break;

                    case 4:
                        Console.WriteLine("Please enter name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Please enter email:");
                        string email = Console.ReadLine();
                        int cid = random.Next(1000, 9999);

                        Customer customer = new Customer(cid, name, email);
                        Store.customers.Add(customer);
                        Console.WriteLine($"Customer '{name}' added successfully with ID: {cid}");
                        break;

                    case 5:
                        Console.WriteLine("Please enter product name");
                        string cinput = Console.ReadLine();
                        var pfound = Store.products.FirstOrDefault(p => p.Name.Equals(cinput, StringComparison.OrdinalIgnoreCase));
                        if (pfound == null)
                        {
                            Console.WriteLine("Product not found");
                        }
                        else
                        {
                            Console.WriteLine($"Product: \n {pfound.Name} \n Price:{pfound.Price} \n ID: {pfound.ID} \n  ");
                        }
                        break;

                    case 6:
                        if (Store.customers.Count == 0)
                        {
                            Console.WriteLine("Client List is empty");
                        }
                        else
                        {
                            Console.WriteLine("\n--- list of clients ---");
                            foreach (var c in Store.customers)
                            {

                                Console.WriteLine($"ID: {c.ID}, name: {c.Name}, Email: {c.Email}");
                            }
                        }
                        break;

                    case 7:

                        double totalRevenue = Store.orders.Sum(o => o.TotalPrice);
                        Console.WriteLine($"Sum of every order in system: {totalRevenue} ");
                        break;

                    case 8:
                        Console.WriteLine("\n--- history of orders ---");
                        if (Store.orders.Count == 0) Console.WriteLine("No orders had been made.");
                        else foreach (var o in Store.orders)

                                Console.WriteLine($"order #{o.ID} | client: {o.CustomerName} | sum: {o.TotalPrice} ");
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }


        }
    }
}
