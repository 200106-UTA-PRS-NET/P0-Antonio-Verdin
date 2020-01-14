using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
    class Order
    {
        double cost = 0.0f;
        public long OrderId { get; set; }
        public ArrayList OrderList { get; set; }


    }
}
