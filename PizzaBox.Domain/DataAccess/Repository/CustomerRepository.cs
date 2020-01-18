using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Client.Models;
using PizzaBox.Domain.PizzaLib;

namespace PizzaBox.Domain.DataAccess.Repository
{
   public class CustomerRepository: IPizzaRepository<PizzaLib.Customer>
    {
           PizzaBoxContext db;
           public CustomerRepository()
           {
               db = new PizzaBoxContext();
           }
           public CustomerRepository(PizzaBoxContext db)
           {
               this.db = db ?? throw new ArgumentNullException(nameof(db));
           }

       public void PizzaPrint()
        {
            {
                var query = db.Customers
                    .Select(i => new { i.Customerid, i.Fname, i.Lname, i.Lastorder })
                    .ToArray();
                foreach(var item in query)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        IEnumerable<Customer> IPizzaRepository<Customer>.PizzaReturn()
        {
            var query = from e in db.Customers
                        select CustomerMapper.Map(e);
            return query;
        }
    }

    }

