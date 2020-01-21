//testing namespaces
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Client.Models;
using PizzaBox.Domain.DataAccess.Repository;
using System;
using PizzaBox.Domain.View;
using PizzaBox.Domain.PizzaLib;

namespace PizzaBox
{
    class PizzaBox
    {

        static void Main(string[] args)
        {

            Login_Screen();


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
            OrderRepository orderRepository = new OrderRepository(db);
            TerminalView terminal = new TerminalView();
            terminal.Terminal_Welcome();
            int x=0;
            while (x == 0)
            {
               Console.WriteLine("Enter Your User number or (R)egister");
               string a = Console.ReadLine();
                if(a=="R"||a=="r")
                {
                    Customer newcustomer = new Customer();
                    Console.WriteLine("Register new user\nEnter your first name: ");
                    newcustomer.Fname = Console.ReadLine();
                    Console.WriteLine("\nEnter your Last name: ");
                    newcustomer.Lname = Console.ReadLine();
                    customerRepository.PizzaBoxAdd(newcustomer);
                    Console.WriteLine("Enter Your User number: ");
                    a = Console.ReadLine();
                }
                try
                {
                    Console.Clear(); 
                    x = Convert.ToInt16(a);
                    customerRepository.PrintUser(x);
                }
                catch
                {
                    Console.WriteLine("Error! Press Any Key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    x = 0;
                }

            }
            while (true)
            {
                Console.WriteLine($"Please Select Your Option:\n(O)rder\n(V)iew Order History\n(X)Logout");
                string option = Console.ReadLine();
                if (option == "x" || option == "X")
                {
                    Console.Clear();
                    Login_Screen();
                    
                }
                else if (option == "v" || option == "V")
                {
                    orderRepository.OrderHistory(x);

                }
                else if (option == "o"|| option == "O")
                {
                    Console.Clear();
                    Console.WriteLine($"Please Select Your Option\n(S)elect Pizza\n(C)reate your own");
                    option = Console.ReadLine();
                   
                    if (option == "S" || option == "s")
                    {
                        orderRepository.TestToppings(new Guid("647297d3-c1b5-41b5-9b9a-168a32141bd9"));
                        

                    }
                }
            }


        }

        
    }
}
