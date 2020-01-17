using System;
using System.Collections.Generic;

namespace PizzaBox.Client.Models
{
    public partial class Pizzas
    {
        public int Topping { get; set; }
        public Guid? Orderid { get; set; }
        public int? Crust { get; set; }
        public int Id { get; set; }

        public virtual Crust CrustNavigation { get; set; }
        public virtual Orders Order { get; set; }
        public virtual Toppings ToppingNavigation { get; set; }
    }
}
