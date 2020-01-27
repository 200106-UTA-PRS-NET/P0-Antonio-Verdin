using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Library
{
   public class Ingredients
    {
        public int Id { get; set; }
        public string Topping { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string Type { get; set; }
    }
}
