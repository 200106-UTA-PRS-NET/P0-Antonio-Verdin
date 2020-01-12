using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Interfaces
{
    interface IOrder
    {
        Dictionary<int, string> Return_Orders();
    }
}
