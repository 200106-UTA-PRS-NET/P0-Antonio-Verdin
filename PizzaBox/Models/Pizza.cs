using System;
using System.Collections.Generic;

namespace PizzaBox.Client.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            Orders = new HashSet<Orders>();
            OrdersPizza = new HashSet<OrdersPizza>();
        }

        public int Id { get; set; }
        public int? Topping1 { get; set; }
        public int? Topping2 { get; set; }
        public int? Topping3 { get; set; }
        public int? Topping4 { get; set; }
        public int? Topping5 { get; set; }
        public byte[] Isdefault { get; set; }

        public virtual Toppings Topping1Navigation { get; set; }
        public virtual Toppings Topping2Navigation { get; set; }
        public virtual Toppings Topping3Navigation { get; set; }
        public virtual Toppings Topping4Navigation { get; set; }
        public virtual Toppings Topping5Navigation { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<OrdersPizza> OrdersPizza { get; set; }
    }
}
