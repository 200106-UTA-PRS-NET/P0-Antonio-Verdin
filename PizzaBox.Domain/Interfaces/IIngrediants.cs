using PizzaBox.Models;
using System.Collections.Generic;

namespace PizzaBox.Domain.Interfaces
{
  public  interface IIngrediants: IRepository<Ingredients>
    {
        IEnumerable<Ingredients> GetToppingsforPizza(int id);

    }
}
