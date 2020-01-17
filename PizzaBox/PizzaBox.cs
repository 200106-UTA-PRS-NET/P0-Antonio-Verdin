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
using PizzaBox.Domain;
using PizzaBox.Domain.DataAcess.Repository;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox
{
    class PizzaBox
    {
        static void Main(string[] args)
        {
            
           // GetLocationlist(ConnectDB());
            StoreRepository a = new StoreRepository(ConnectDB());
            a.GetStores();
            ///Console.WriteLine(e.Count);
        }
           /*    static void GetLocationlist(PizzaBoxContext db)
             {
            var query = from e in db.Store
                        select e.Loc;
                 foreach(string topping in query)
                 {
                     Console.WriteLine(topping);
                 }
        }*/
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
