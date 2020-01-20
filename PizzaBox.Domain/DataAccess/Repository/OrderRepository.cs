using PizzaBox.Client.Models;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.PizzaLib;
using PizzaBox.Domain.PizzaLib.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var query = db.Orders
                .Select(i => new { i.Customerid, i.Crust, i.Storeid, i.Ordercost,i.OrderNum })
                .ToArray();
            foreach (var item in query)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void OrderHistory(int customerid)
        {
            var query = db.Orders;
                if (db.Orders.Any(e => e.Customerid == customerid)) 
            {
                var results = db.Orders.Where(s => s.Customerid == customerid);

                foreach (var item in results)
                {
                    
                    Console.WriteLine($"Customer: {item.Customerid}\tOrder #: {item.OrderNum}\tCost: { item.Ordercost}");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No Order History");
            }
        }

        IEnumerable<Order> IPizzaRepositoryRead<Order>.PizzaReturn()
        {
                var query = from e in db.Orders
                            select OrderMapper.Map(e);
                return query;
            }
        }
    }
