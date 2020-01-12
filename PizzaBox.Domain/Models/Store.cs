using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
    class Store: Interfaces.IOrder
    {
        string Name;
        Dictionary<int, string> PastOrders = new Dictionary<int, string>();
        public Store (string StoreName)
        {
            this.Name = StoreName;
        }
        Dictionary<int,string> Interfaces.IOrder.Return_Orders()
        {
            return this.PastOrders;
        }
        
    }
}
