using System;
using System.Collections.Generic;

namespace PizzaBox.Client.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrdersPizza = new HashSet<OrdersPizza>();
        }

        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? OrderTime { get; set; }
        public int? StoreId { get; set; }

        public virtual Pizza Customer { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<OrdersPizza> OrdersPizza { get; set; }
    }
}
