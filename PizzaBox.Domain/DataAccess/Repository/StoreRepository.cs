using System;
using System.Collections.Generic;
using System.Linq;

using PizzaBox.Domain.Abstracts;
using PizzaBox.Client.Models;
using PizzaBox.Domain.DataAccess.Models;

namespace PizzaBox.Domain.DataAcess.Repository
{

    public class StoreRepository : IPizzaRepository<PizzaLib.Store>
    {
        PizzaBoxContext db;
        public StoreRepository()
        {
            db = new PizzaBoxContext();
        }
        public StoreRepository(PizzaBoxContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IEnumerable<PizzaLib.Store> PizzaReturn()
        {
            var query = from e in db.Store
                        select StoreMapper.Map(e);
            return query;
        }
        public void PizzaPrint() { 
            var query2 = from e in db.Store
                        select e.Loc;
            foreach (string Loc in query2)
            {
                Console.WriteLine(Loc);
            }

            
        }
    }
}