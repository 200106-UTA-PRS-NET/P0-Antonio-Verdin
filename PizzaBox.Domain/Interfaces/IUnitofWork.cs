using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Interfaces
{
    public interface IUnitofWork:IDisposable
    {
        IAddress Address { get; }
        IIngrediants Ingrediants { get; }
        IPizza Pizza { get; }
        IEmployee Employee { get; }
        ICustomer Customer { get; }
        IngrediantsPizza ingrediantsPizza { get; }
        IOrders Orders { get; }
        IStore Store { get; }
        int Complete();
    }
}
