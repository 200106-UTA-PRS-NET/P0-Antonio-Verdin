using System;
using System.Collections.Generic;

namespace PizzaBox.Models
{
    public partial class Ingredients
    {
        public Ingredients()
        {
            PizzaIngredients = new HashSet<PizzaIngredients>();
        }

        public int Id { get; set; }
        public string Topping { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string Type { get; set; }

        public virtual ICollection<PizzaIngredients> PizzaIngredients { get; set; }
    }
}
