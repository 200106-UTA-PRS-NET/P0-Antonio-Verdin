using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Client.Models;
using PizzaBox.Domain.PizzaLib;
namespace PizzaBox.Domain.DataAccess.Repository
{
    public class CrustRepository : IPizzaRepositoryRead<PizzaLib.Crust>
    {
        PizzaBoxContext db;
        public CrustRepository()
        {
            db = new PizzaBoxContext();
        }
        public CrustRepository(PizzaBoxContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void PizzaPrint()
        {
            var query2 = from e in db.Crust
                         select e.Price;
            foreach (decimal? Loc in query2)
            {
                Console.WriteLine(Loc);
            }

        }

        public IEnumerable<PizzaLib.Crust> PizzaReturn()
        {
            var query = from e in db.Crust
                        select CrustMapper.Map(e);
            return query;
        }
 
    }
}
