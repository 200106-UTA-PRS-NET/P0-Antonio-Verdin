using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Library
{
    public class Orders
    {
        public int Id { get; set; }
        public int? StoreId { get; set; }
        public int? CustomerId { get; set; }
        public int OrderId { get; set; }
        public byte Amount { get; set; }
        public DateTime? orderdate { get; set; }
        public Decimal? TotalCost { get; set; }
        public IList<Pizza> Pizzas{get; set;}
    }
}
