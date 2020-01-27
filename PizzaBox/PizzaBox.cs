using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Controller;
using PizzaBox.Models;
using System;
using System.Collections.Generic;
using System.IO;



namespace PizzaBox
{
    class PizzaBox
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your user number or R to register");
            string userid = Console.ReadLine();
            Console.WriteLine( "Please enter you password");
            string pass = Console.ReadLine();
            int usernum = 0;
            try
            {
                if(userid == "r"|| userid== "R")
                {
                    Console.WriteLine("Please Enter your first name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Pleae Enter your last name");
                    string lname = Console.ReadLine();
                    Console.WriteLine("Pleae Enter a Password");
                    string password = Console.ReadLine();
                    Console.WriteLine("Please Enter your City");
                    string city = Console.ReadLine();
                    Console.WriteLine("Please Enter Your Street number or Aptnum");
                    string address = Console.ReadLine() ;

                }
               usernum = Int16.Parse(userid);
                
                
            }catch { } 
            UserController user = new UserController(ConnectDB(),usernum,pass);
                       
//ToDo logout if not authenticated
            IEnumerable<Domain.Library.Store> stores = user.RetrieveListStores(ConnectDB());
            Console.WriteLine("Please Select a Store from the List");
            foreach (var item in stores)
            {
                
                Console.WriteLine($"{item.StoreId}....\t{item.Name}\t {item.City}");
            }
            string temp = Console.ReadLine();
            IEnumerable<Domain.Library.Orders> pastorders = user.GetOrdersbyUserId(ConnectDB());

            
            if (pastorders != null)
            {
                Console.WriteLine("Here are your past orders");

                foreach (var item in pastorders)
                {
                    Console.WriteLine($"Order # { item.Id} on {item.orderdate} # {String.Format("{0:c}", item.TotalCost)} ");
                }
            }
//to do flow control here          
            Console.WriteLine("Would you like to (O)rder (Q)uit");
            Console.ReadKey();
            Console.Clear();
            Orders order = new Orders();
            Console.WriteLine("Would you like to Order a (C)ustom or (P)remade Pizza");
            string menu = Console.ReadLine();
            if (menu == "c" || menu == "C")
            {
                
                IList<Domain.Library.Ingredients> listoftoppings = user.ListToppings(ConnectDB());
                Console.WriteLine("First Please Choose your Crust");
                foreach (Domain.Library.Ingredients topping in listoftoppings)
                {
                    if (topping.Type == "Crust")
                    {
                        Console.WriteLine($"{topping.Topping} cost {String.Format("{0:c}", topping.Price)}");
                    }

                }
                Console.ReadLine();
                Console.WriteLine("Next Choose your Favorite Sauce");
                foreach (Domain.Library.Ingredients topping in listoftoppings)
                {
                    if (topping.Type == "Sauce")
                    {
                        Console.WriteLine($"{topping.Id}   {topping.Topping} cost {String.Format("{0:c}", topping.Price)}");
                    }

                }
                Console.WriteLine("Finally Choose up to 5 other Toppings");
                foreach (Domain.Library.Ingredients topping in listoftoppings)
                {
                    if (topping.Type == "Topping")
                    {
                        Console.WriteLine($"{topping.Id}   {topping.Topping} cost {String.Format("{0:c}", topping.Price)}");
                    }

                }
                
                Console.ReadKey();
            }
            else if(menu == "p" || menu == "P")
            {

            }
            else
            {

            }








        }
        static PizzaBoxContext ConnectDB()
        {
         var configBuilder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("C:\\Users\\theki\\Documents\\Revature\\projects\\P0-Antonio-Verdin\\PizzaBox\\appsettings.json", optional: true, reloadOnChange: true);
        IConfigurationRoot configuration = configBuilder.Build();

        var optionsBuilder = new DbContextOptionsBuilder<PizzaBoxContext>();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzaBox" ));
                  var options = optionsBuilder.Options;
        PizzaBoxContext db = new PizzaBoxContext(options);

         return db;
        }

}
}
