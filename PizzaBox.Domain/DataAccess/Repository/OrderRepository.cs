using PizzaBox.Client.Models;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.PizzaLib;
using PizzaBox.Domain.PizzaLib.Abstracts;
using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.DataAccess.Repository
{
   public class OrderRepository : IPizzaRepositoryAdd<PizzaLib.Order>, IPizzaRepositoryDelete<PizzaLib.Order>, IPizzaRepositoryRead<PizzaLib.Order>
    {
        PizzaBoxContext db;
        public OrderRepository()
        {
            db = new PizzaBoxContext();
        }
        public OrderRepository(PizzaBoxContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public void PizzaBoxAdd(Order record)
        {
            throw new NotImplementedException();
        }

        public void PizzaPrint()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> PizzaReturn()
        {
            throw new NotImplementedException();
        }
    }
}
