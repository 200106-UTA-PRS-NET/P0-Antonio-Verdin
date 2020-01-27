using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Library
{
   public class Pizza
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public byte Amount { get; set; }
        public IList<Ingredients> Toppings {get; set;}
    }
}
