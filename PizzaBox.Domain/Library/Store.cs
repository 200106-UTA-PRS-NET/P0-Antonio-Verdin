using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Library
{
    public class Store:Addressing
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
    }
}
