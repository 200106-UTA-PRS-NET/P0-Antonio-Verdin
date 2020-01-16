using System;
using PizzaBox;


//testing namespaces
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PizzaBox.Client.Models;

namespace PizzaBox
{
    class PizzaBox
    {
        static void Main(string[] args)
         {
            var configBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("C:\\Users\\theki\\Documents\\Revature\\projects\\P0-Antonio-Verdin\\PizzaBox\\appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = configBuilder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<PizzaBoxContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzaBox"));
            var options = optionsBuilder.Options;
            PizzaBoxContext db = new PizzaBoxContext(options);
            GetToppinglist(db);

        }
          static void GetToppinglist(PizzaBoxContext db)
        {
            var query = from e in db.Toppings
                        select e.Topping;
            foreach(string topping in query)
            {
                Console.WriteLine(topping);
            }
        }

    }
}
