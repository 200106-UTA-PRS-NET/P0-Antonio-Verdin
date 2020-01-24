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
            db.Customers.Add(CustomerMapper.Map(record));// this will generate insert query
            db.SaveChanges();// this will execute the above generate insert query
            var cus = db.Customers.FirstOrDefault(e => e.Fname == record.Fname && e.Lname==record.Lname);
            Console.WriteLine($"Your id number is {cus.Customerid}");
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
        public void OrderPizza(int customerid)
        {
            var cus = db.Customers.FirstOrDefault(e => e.Customerid == customerid);
            cus.Lastorder = DateTime.Now;
            db.SaveChanges();

        }
        public int PrintUser(int customerid)
        {
            if (db.Customers.Any(e => e.Customerid == e.Customerid))
            {
                var cus = db.Customers.FirstOrDefault(e => e.Customerid == customerid);

                if (cus.Lastorder == null || cus.Lastorder < DateTime.Now.AddHours(-24))
                {
                    //v  cus.Lastorder = DateTime.Now;
                    Console.WriteLine($"Welcome {cus.Fname} {cus.Lname} the last time you here was \n{cus.Lastorder}");
                    return (cus.Customerid);
                }

                else
                {
                    Console.WriteLine("You have to wait a full 24 hours to Order more delicious pizza!");


                }
            }
            return 0;
            
        }
        IEnumerable<Customer> IPizzaRepositoryRead<Customer>.PizzaReturn()
        {
            var query = from e in db.Customers
                        select CustomerMapper.Map(e);
            return query;
        }
    }

    }

