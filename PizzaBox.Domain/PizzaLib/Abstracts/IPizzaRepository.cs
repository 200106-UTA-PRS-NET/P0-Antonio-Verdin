using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Abstracts
{
   public interface IPizzaRepository<T>
    {
       public IEnumerable<T> PizzaReturn();
       public void PizzaPrint();
    }
}
