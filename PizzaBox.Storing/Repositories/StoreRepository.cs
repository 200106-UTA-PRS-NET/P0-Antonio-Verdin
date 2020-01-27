using PizzaBox.Domain.Interfaces;
using PizzaBox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Repositories
{
    class StoreRepository:Repository<Store>, IStore
    {
        public StoreRepository(PizzaBoxContext context)
: base(context)
        {
        }
        public PizzaBoxContext PizzaBoxContext
        {
            get { return Context as PizzaBoxContext; }
        }
    }
}
