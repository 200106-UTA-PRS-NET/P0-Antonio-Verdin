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
            StoreRepository storeRepository = new StoreRepository(db);
            TerminalView terminal = new TerminalView();
            terminal.Terminal_Welcome();
            int customerid=0;
            int storeid = 0;
            Domain.PizzaLib.Crust usercrust = new Domain.PizzaLib.Crust();
            while (storeid == 0)
            {
                Console.WriteLine("Please select your Location");
                storeRepository.PizzaPrint();
                string a = Console.ReadLine();
                try
                {
                    Console.Clear();
                    storeid = Convert.ToInt16(a);
                    storeRepository.PrintStores(storeid);
                }
                catch
                {
                    Console.WriteLine("Invaild Error! Press Any Key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    storeid = 0;
                }
            }
            while (customerid == 0)
            {

                //Console.Clear();
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
                    customerid = Convert.ToInt16(a);
                    customerRepository.PrintUser(customerid);
                }
                catch
                {
                    Console.WriteLine("Error! Press Any Key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    customerid = 0;
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
                    orderRepository.OrderHistory(customerid);

                }
                else if (option == "o"|| option == "O")
                {
                    Console.Clear();
                    Console.WriteLine($"Please Select Your Option\n(S)elect Pizza\n(C)reate your own");
                    option = Console.ReadLine();
                   
                    if (option == "S" || option == "s")
                    {
                        Console.WriteLine("1. Large Pep Pizza\t 2. Medium Pep Pizza\t\t 3. Small Pep Pizza");
                        Console.WriteLine("4. Large Cheese Pizza\t 5. Medium Cheese Pizza\t\t 6. Small Cheese Pizza");
                        Console.WriteLine("7. Large Meat Pizza\t 8. Medium Meat Pizza\t\t 9. Small Meat Pizza");
                        Console.WriteLine("\t0. Veggie Gluten Friendly Pizza\t E(X)it");
                        Console.ReadKey();

                        ///TODO Create a switch statement with the default GUIDS

                        //orderRepository.TestToppings(new Guid("647297d3-c1b5-41b5-9b9a-168a32141bd9"));
                    }
                    else if(option=="C"||option == "c")
                    {
                        Console.Clear();
                        Console.WriteLine("Select Crust Type and Size");
                        CrustRepository crustrepository = new CrustRepository(db);
                        crustrepository.PizzaPrint();
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Select your Toppings From the List (E)nd Selction");
                        crustrepository.ToppingPrint();
                        Console.ReadLine();


                    }
                }
            }


        }

        
    }
}
