using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaBox.Domain.PizzaLib;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Client.Models;
using PizzaBox.Domain.DataAccess.Models;

namespace PizzaBox.Domain.DataAcess.Repository
{

    public class StoreRepository : IStoreRepository<PizzaLib.Store>
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

        public IEnumerable<PizzaLib.Store> GetStores( )
        {
            var query = from e in db.Store
                        select StoreMapper.Map(e);
            var query2 = from e in db.Store
                        select e.Loc;
            foreach (string Loc in query2)
            {
                Console.WriteLine(Loc);
            }

            return query;
        }
    }
}