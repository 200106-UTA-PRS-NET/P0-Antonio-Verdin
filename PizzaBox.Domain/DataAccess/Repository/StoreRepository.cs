using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Client.Models;
using PizzaBox.Domain.DataAccess.Models;

namespace PizzaBox.Domain.DataAccess.Repository
{

    public class StoreRepository : IPizzaRepositoryRead<PizzaLib.Store>
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
        public void PizzaPrint()
        {
            var query2 = from e in db.Store
                         select e;
            foreach (var store in query2)
            {
                Console.WriteLine($"{store.Id}).\t{store.Loc}");
            }

        }
        public void PrintStores(int storenum)
            {
                if (db.Store.Any(e => e.Id == e.Id))
                {
                    var cus = db.Store.FirstOrDefault(e => e.Id == storenum);
                    Console.WriteLine($"Welcome to PizzaBox in {cus.Loc}");
                }
                else { }

            }

        }

            
}