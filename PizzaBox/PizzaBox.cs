//testing namespaces
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Client.Models;
using PizzaBox.Domain.DataAccess.Repository;
using System;
using PizzaBox.Domain.View;
using PizzaBox.Domain.DataAcess.Repository;

namespace PizzaBox
{
    class PizzaBox
    {

        static void Main(string[] args)
        {
           /* PizzaBoxContext db = ConnectDB();
            StoreRepository storeRepository = new StoreRepository(db);
            CrustRepository crustRepository = new CrustRepository(db);
            CustomerRepository customerRepository = new CustomerRepository(db);
            OrderRepository orderRepository = new OrderRepository(db);*/
            TerminalView terminal = new TerminalView();
            terminal.Terminal_Welcome();
            /* while (customernum == 0){
                 customernum = Login_Screen();
             }
             customerRepository.PrintUser(customernum);*/
            Login_Screen();
            Console.ReadKey();
            Console.Clear();

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
        static void Login_Screen()
        {
            PizzaBoxContext db = ConnectDB();
            CustomerRepository customerRepository = new CustomerRepository(db);

           // Console.WriteLine("Enter Your User number");
            // storeRepository.PizzaPrint();
            int x=0;
            while (x == 0)
            {
               Console.WriteLine("Enter Your User number");
               string a = Console.ReadLine();
                try
                {
                    x = Convert.ToInt16(a);
                    customerRepository.PrintUser(x);
                }
                catch
                {
                    Console.WriteLine("You did not input a valid number Try Again Press Any Key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    x = 0;
                }

            } 
        }

        
    }
}
