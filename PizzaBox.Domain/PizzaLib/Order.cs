using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.PizzaLib
{
   public class Order
    {
        public int OrderNum { get; set; }
        public int? Ordercount { get; set; }
        public Guid Orderuid { get; set; }
        public DateTime? Dateordered { get; set; }
        public int? Customerid { get; set; }
        public int? Storeid { get; set; }
        public decimal? Ordercost { get; set; }
        public int? Crust { get; set; }
        public Queue<string> toppings = new Queue<string>();
    }
}
