using System;
using System.Collections.Generic;

namespace PizzaBox.Client.Models
{
    public partial class Toppings
    {
        public Toppings()
        {
            PizzaTopping1Navigation = new HashSet<Pizza>();
            PizzaTopping2Navigation = new HashSet<Pizza>();
            PizzaTopping3Navigation = new HashSet<Pizza>();
            PizzaTopping4Navigation = new HashSet<Pizza>();
            PizzaTopping5Navigation = new HashSet<Pizza>();
        }

        public int Id { get; set; }
        public string Topping { get; set; }

        public virtual ICollection<Pizza> PizzaTopping1Navigation { get; set; }
        public virtual ICollection<Pizza> PizzaTopping2Navigation { get; set; }
        public virtual ICollection<Pizza> PizzaTopping3Navigation { get; set; }
        public virtual ICollection<Pizza> PizzaTopping4Navigation { get; set; }
        public virtual ICollection<Pizza> PizzaTopping5Navigation { get; set; }
    }
}
