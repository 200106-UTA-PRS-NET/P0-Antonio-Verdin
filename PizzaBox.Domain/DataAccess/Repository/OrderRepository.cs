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

            IList<Orders> orderlist = new List<Orders>();
            var query = db.Orders;
                if (db.Orders.Any(e => e.Customerid == customerid)) 
            {
                var results = db.Orders.Where(s => s.Customerid == customerid);
                foreach (var item in results)
                {
                    orderlist.Add(item);

                }


            }
            else
            {
                Console.Clear();
                Console.WriteLine("No Order History");
            }
            foreach(var item in orderlist)
            {
                Console.WriteLine($"Order #: {item.OrderNum}\tItem#{item.Ordercount} \tCost: { item.Ordercost}");
                PrintToppings(item.Orderuid);

            }

                
        }
        public void PrintToppings(Guid ordernum)
        {
            decimal? cost = 0;
            
            var toppinglis = (from e in db.Toppings
                              join p in db.Pizzas
                              on e.Id equals p.Topping
                              join s in db.Orders
                              on p.Orderid equals s.Orderuid
                              join d in db.Crust
                              on s.Crust equals d.Id
                              where s.Orderuid == ordernum
                              select new
                              {
                                  id = p.Orderid,
                                  topping = e.Topping,
                                  price = e.Price,
                                  crust = d.Crust1

                              }).ToList();
            
            
            foreach (var topping in toppinglis)
            {

                Console.WriteLine($"{topping.topping}");
                cost += topping.price;
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
