using PizzaBox.Domain.Interfaces;
using PizzaBox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Repositories
{
    class IngredientsRepository : Repository<Ingredients>, IIngrediants

    {
     public IngredientsRepository(PizzaBoxContext context)
    : base(context)
        {
        }
        public PizzaBoxContext PizzaBoxContext
        {
            get { return Context as PizzaBoxContext; }
        }
        public IEnumerable<Ingredients> GetToppingsforPizza(int id)
        {
            throw new NotImplementedException();
        }
    }
}
