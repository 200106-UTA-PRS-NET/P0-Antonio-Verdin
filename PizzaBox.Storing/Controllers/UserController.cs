using PizzaBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaBox.Domain.Controller
{
    public class UserController
    {
        bool Authenticated = false;
        static int authenticatedid = 0;
        public UserController(PizzaBoxContext Pizzabox, int userid, string password)
        {

            using (var unitofWork = new PizzaBox.Storing.UnitofWork(Pizzabox))
            {
                var customer = unitofWork.Customer.SingleOrDefault(b => b.Id == userid);
                if (customer != null && customer.UserPassWord == password)
                {
                    Console.WriteLine("Authenticated Successfully");
                    Authenticated = true;
                    authenticatedid = userid;

                }
                else
                {
                    Console.WriteLine("Failed to Authenticate properly returning to menu");
                }

            }
        }
        public IEnumerable<Library.Store> RetrieveListStores(PizzaBoxContext Pizzabox)
        {
            using (var unitofWork = new PizzaBox.Storing.UnitofWork(Pizzabox))
            {

                var storelist = unitofWork.Store.GetAll();
                var storeaddress = unitofWork.Address.GetAll();
                var query = from store in storelist
                            join address in storeaddress on store.Address equals address.Id
                            select new Library.Store { StoreId = store.Id, Name = store.Name, City = address.City };
                return query;
            }
        }
        public IEnumerable<Library.Orders> GetOrdersbyUserId(PizzaBoxContext Pizzabox)
        {
            using (var unitofWork = new PizzaBox.Storing.UnitofWork(Pizzabox))
            {

                var orderlist = unitofWork.Order.GetAll().Where(e => e.CustomerId == authenticatedid).ToList();
                return orderlist.Select(e => new Library.Orders { Id = e.Id, orderdate=e.PlaceDate, TotalCost=e.TotalPrice,CustomerId=e.CustomerId,StoreId=e.StoreId});

            }

        }
        public IEnumerable<Library.Orders> GetOrdersbyStoreId(PizzaBoxContext Pizzabox, int id)
        {
            using (var unitofWork = new PizzaBox.Storing.UnitofWork(Pizzabox))
            {

                var pizza = unitofWork.Pizza.GetAll();
                var orderlist = unitofWork.Order.GetAll().Where(e => e.StoreId == id);





                return orderlist.Select(e => new Library.Orders { Id = e.Id});

            }

        }
        public IList<Library.Ingredients> ListToppings(PizzaBoxContext Pizzabox)
        {
            using(var unitofWork = new PizzaBox.Storing.UnitofWork(Pizzabox))
            {
                var toppinglist = unitofWork.Ingrediants.GetAll().ToList();
                return toppinglist.Select(e => new Library.Ingredients { Id = e.Id, Topping = e.Topping, Price = e.Price, Type=e.Type }).ToList();
                

            }
        }
        public void RegisterUser( PizzaBoxContext PizzaBox,Customer customer, Addressing addressing)
        {
            
           using(var unitofWork = new PizzaBox.Storing.UnitofWork(PizzaBox))
            {
                unitofWork.Address.Add(addressing);
                unitofWork.Customer.Add(customer);
                PizzaBox.SaveChanges();
            }
            
        }
        public void PlaceOrder(PizzaBoxContext PizzaBox, Library.Orders order)
        {
            Orders orders = new Orders()
            {
                StoreId = order.StoreId,
                PlaceDate = DateTime.Now,
                EmployeeId = 1,//for website and testing
                CustomerId = order.CustomerId,
                TotalPrice = order.TotalCost
            };
            using(var unitofWork = new PizzaBox.Storing.UnitofWork(PizzaBox))
            {
                unitofWork.Order.Add(orders);
                PizzaBox.SaveChanges();
            }

        }


    }
}

