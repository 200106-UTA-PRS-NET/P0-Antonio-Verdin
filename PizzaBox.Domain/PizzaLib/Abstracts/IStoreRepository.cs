using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Abstracts
{
   public interface IStoreRepository<T>
    {
       public IEnumerable<T> GetStores();
    }
}
