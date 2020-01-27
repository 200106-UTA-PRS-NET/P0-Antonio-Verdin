using PizzaBox.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Interfaces
{
    public interface IPizza : IRepository<Pizza>
    {
        IEnumerable<Pizza> GetPizzaforUser(int id);

    }
}
