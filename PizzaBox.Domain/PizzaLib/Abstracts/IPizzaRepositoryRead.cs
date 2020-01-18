
using System.Collections.Generic;
namespace PizzaBox.Domain.Abstracts
{
   public interface IPizzaRepositoryRead<T>
    {
       public IEnumerable<T> PizzaReturn();
       public void PizzaPrint();
    }
}
