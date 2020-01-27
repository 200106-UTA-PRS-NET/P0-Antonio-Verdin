using PizzaBox.Domain.Interfaces;
using PizzaBox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Repositories
{
    class PizzaRepository : Repository<Pizza>,IPizza
    {
        public PizzaRepository(PizzaBoxContext context)
: base(context)
        {
        }
        public PizzaBoxContext PizzaBoxContext
        {
            get { return Context as PizzaBoxContext; }
        }

        public IEnumerable<Pizza> GetPizzaforUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
