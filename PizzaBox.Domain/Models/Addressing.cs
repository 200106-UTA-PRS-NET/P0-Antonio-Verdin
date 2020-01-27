using System;
using System.Collections.Generic;

namespace PizzaBox.Models
{
    public partial class Addressing
    {
        public Addressing()
        {
            Customer = new HashSet<Customer>();
            Store = new HashSet<Store>();
        }

        public int Id { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Store> Store { get; set; }
    }
}
