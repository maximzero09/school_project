using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_project
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Customer(int id, string name, string email)
        {
            ID = id;
            Name = name;
            Email = email;
        }
    }
}
