using PizzaBox.Domain.Interfaces;
using PizzaBox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Repositories
{
    class OrderRepository:Repository<Orders>, IOrders
    {
        public OrderRepository(PizzaBoxContext context)
: base(context)
        {
        }
        public PizzaBoxContext PizzaBoxContext
        {
            get { return Context as PizzaBoxContext; }
        }
    }
}

