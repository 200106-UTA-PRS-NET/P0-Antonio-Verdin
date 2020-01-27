using System;
using System.Collections.Generic;

namespace PizzaBox.Models
{
    public partial class Orders
    {
        public Orders()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int Id { get; set; }
        public decimal? TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? PlaceDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? StoreId { get; set; }
        public int? EmployeeId { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
