using System;
using System.Collections.Generic;

namespace PizzaBox.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaIngredients = new HashSet<PizzaIngredients>();
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public byte Amount { get; set; }

        public virtual Orders Order { get; set; }
        public virtual ICollection<PizzaIngredients> PizzaIngredients { get; set; }
    }
}
