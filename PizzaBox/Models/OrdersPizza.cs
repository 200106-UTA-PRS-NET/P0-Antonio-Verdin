using System;
using System.Collections.Generic;

namespace PizzaBox.Client.Models
{
    public partial class OrdersPizza
    {
        public int? PizzaId { get; set; }
        public int? OrderId { get; set; }
        public int Id { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
