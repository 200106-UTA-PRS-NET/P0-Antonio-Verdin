//testing namespaces
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Client.Models;
using PizzaBox.Domain.DataAccess.Repository;
using System;
using PizzaBox.Domain.View;

namespace PizzaBox
{
    class PizzaBox
    {

        static void Main(string[] args)
        {
            PizzaBoxContext db = ConnectDB();
            StoreRepository storeRepository = new StoreRepository(db);
            CrustRepository crustRepository = new CrustRepository(db);
            CustomerRepository customerRepository = new CustomerRepository(db);
            TerminalView terminal = new TerminalView();
            terminal.Terminal_Welcome();
            Console.WriteLine("Select your Store");
            storeRepository.PizzaPrint();
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
        static Domain.PizzaLib.Customer customer1()
        {
            return new Domain.PizzaLib.Customer()
            {
                Fname = "bob",
                Lname = "dobbie",
                Lastorder = DateTime.Now
            };

        }
    }
}
