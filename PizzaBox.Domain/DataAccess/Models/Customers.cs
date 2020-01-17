using System;
using System.Collections.Generic;

namespace PizzaBox.Client.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime? Lastorder { get; set; }
        public int Customerid { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
