using System;
using System.Collections.Generic;

namespace PizzaBox.Client.Models
{
    public partial class Crust
    {
        public Crust()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Crust1 { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
