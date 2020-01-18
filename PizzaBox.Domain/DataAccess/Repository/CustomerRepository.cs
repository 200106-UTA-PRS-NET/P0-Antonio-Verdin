using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Client.Models;
using PizzaBox.Domain.PizzaLib;
using PizzaBox.Domain.PizzaLib.Abstracts;

namespace PizzaBox.Domain.DataAccess.Repository
{
   public class CustomerRepository: IPizzaRepositoryRead<PizzaLib.Customer>, IPizzaRepositoryAdd<PizzaLib.Customer>
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

        public void PizzaBoxAdd(Customer record)
        {
            /*if (db.Customers.Any(e => e.Ssn == employee.Ssn) || employee.Ssn == null)
            {
                Console.WriteLine($"This employee with SSN {employee.Ssn} already exists and cannot be added");
                return;
            }*/
            //else
            db.Customers.Add(CustomerMapper.Map(record));// this will generate insert query
            db.SaveChanges();// this will execute the above generate insert query
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

        IEnumerable<Customer> IPizzaRepositoryRead<Customer>.PizzaReturn()
        {
            var query = from e in db.Customers
                        select CustomerMapper.Map(e);
            return query;
        }
    }

    }

