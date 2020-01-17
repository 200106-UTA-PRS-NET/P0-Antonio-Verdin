using System;
using System.Collections.Generic;

namespace PizzaBox.Client.Models
{
    public partial class Crust
    {
        public Crust()
        {
            Pizzas = new HashSet<Pizzas>();
        }

        public int Id { get; set; }
        public string Crust1 { get; set; }

        public virtual ICollection<Pizzas> Pizzas { get; set; }
    }
}
