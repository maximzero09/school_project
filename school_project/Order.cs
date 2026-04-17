using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_project
{
    public class Order
    {

        public int ID { get; set; }
        public string CustomerName { get; set; }
        public List<Product> Products { get; set; }
        public double TotalPrice { get; set; }

        public Order(int id, string customerName, List<Product> products)
        {
            ID = id;
            CustomerName = customerName;
            Products = products;
            TotalPrice = products.Sum(p => (double)p.Price * p.Quantity);
        }
    }
}
