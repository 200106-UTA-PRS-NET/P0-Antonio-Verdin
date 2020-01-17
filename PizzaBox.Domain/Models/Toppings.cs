using System;
using System.Collections.Generic;

namespace PizzaBox.Client.Models
{
    public partial class Toppings
    {
        public Toppings()
        {
            Pizzas = new HashSet<Pizzas>();
        }

        public int Id { get; set; }
        public string Topping { get; set; }

        public virtual ICollection<Pizzas> Pizzas { get; set; }
    }
}
