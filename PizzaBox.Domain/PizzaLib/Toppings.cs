using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.PizzaLib
{
    class Toppings
    {
        public int Id { get; set; }
        public string Topping { get; set; }
        public decimal? Price { get; set; }
    }
}
