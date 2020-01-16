using System;
using System.Collections.Generic;

namespace PizzaBox.Client.Models
{
    public partial class Store
    {
        public Store()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Loc { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
