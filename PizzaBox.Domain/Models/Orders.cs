using System;
using System.Collections.Generic;

namespace PizzaBox.Client.Models
{
    public partial class Orders
    {
        public Orders()
        {
            Pizzas = new HashSet<Pizzas>();
        }

        public int OrderNum { get; set; }
        public int? Ordercount { get; set; }
        public Guid Orderuid { get; set; }
        public DateTime? Dateordered { get; set; }
        public int? Customerid { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual ICollection<Pizzas> Pizzas { get; set; }
    }
}
