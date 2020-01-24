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
            int crust = 0;
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
                else if (a == "iddqd" || a == "IDDQD")
                {
                    Console.WriteLine("Here is the order History: ");
                    orderRepository.StoreOrderHistory(storeid);
                    Console.ReadKey();
                    Console.Clear();
                    Login_Screen();
                }
                try
                {
                    Console.Clear(); 
                    customerid = Convert.ToInt16(a);
                    customerid = customerRepository.PrintUser(customerid);
                    if(customerid == 0)
                    {
                        Console.WriteLine("Here is you Order History");
                        orderRepository.OrderHistory(Convert.ToInt16(a));
                        Console.WriteLine("Press Any Key to return to return to the main menu");
                        Console.ReadKey();
                        Console.Clear();
                        Login_Screen();

                    }
                }
                catch
                {
                    Console.WriteLine(" Press Any Key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    customerid = 0;
                }

            }
            int newordernum = orderRepository.GetNextOrderNumber();
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
                    float Total = 5.0f;
                    int pizzacount = 1;
                        while (Total < 250.00 && pizzacount <= 100)
                        {
                        Console.Clear();
                        Console.WriteLine($"Your Total Cost is {String.Format("{0:c}",Total)}\n\nPlease Select Your Option\n(S)elect Pizza\nE(X)it\n(C)reate your own");
                        option = Console.ReadLine();
                   
                    if (option == "S" || option == "s")
                    {
                        Console.WriteLine("1. Large Pep Pizza\t 2. Medium Pep Pizza\t\t 3. Small Pep Pizza");
                        Console.WriteLine("4. Large Cheese Pizza\t 5. Medium Cheese Pizza\t\t 6. Small Cheese Pizza");
                        Console.WriteLine("7. Large 3Meat Pizza\t 8. Medium 3Meat Pizza\t\t 9. Small 3Meat Pizza");
                        Console.WriteLine("\t0. Veggie Gluten Friendly Pizza\t E(X)it");
                        
                            try
                            {
                                int[] x = new int[4];
                                Order order = new Order
                                {

                                    Dateordered = DateTime.Now,
                                    Storeid = storeid,
                                    Customerid = customerid,
                                    Ordercount = newordernum

                                };
                                int res = Convert.ToInt16(Console.ReadLine());
                                if(res<9 && res >= 0)
                                {
                                    switch (res)
                                    {
                                        case 1:
                                            order.Crust = 3;

                                            break;
                                        case 2:
                                            order.Crust = 2;
                                            break;
                                        case 3 :
                                            order.Crust = 1;
                                            break;
                                        case 4:
                                            order.Crust = 3;
                                            break;
                                        case 5:
                                            order.Crust = 2;
                                            break;
                                        case 6:
                                            order.Crust = 1;
                                            break;
                                        case 7:
                                            order.Crust = 3;
                                            break;
                                        case 8:
                                            order.Crust = 2;
                                            break;
                                        case 9:
                                            order.Crust = 1;
                                            break;
                                        case 0:
                                            order.Crust = 5;
                                            break;


                                    }

                                    Console.WriteLine("Type 'yes' to order and confirm this pizza or press enter to return to the menu");
                                    string temp = Console.ReadLine();
                                    if (temp == "yes" || temp == "Yes")
                                    {
                                        
                                        order.OrderNum = pizzacount;
                                        customerRepository.OrderPizza(customerid);
                                        orderRepository.PizzaBoxAddOrder(order, x);
                                        pizzacount++;
                                        Console.WriteLine("Here");
                                        Console.ReadLine();
                                    }

                                }
                            }
                            catch
                            {
                                Console.WriteLine("An error has occured going back to main menu");
                            }


                     
                    }
                    else if(option=="X"|| option == "x")
                        {
                            Console.WriteLine("Thank you for your buisness press any key to logout");
                            Console.ReadKey();
                            Console.Clear();
                            Login_Screen();
                        }
                    else if(option=="C"||option == "c")
                    {


                            Console.Clear();
                            Console.WriteLine($"Select Crust Type and Size\t\t\tYour Total Cost is{String.Format("{0:c}", Total)}");
                            CrustRepository crustrepository = new CrustRepository(db);
                            crustrepository.PizzaPrint();
                            try
                            {
                                crust = Convert.ToInt16(Console.ReadLine());
                                int i = 3;
                                int[] x = new int[5] { 1, 11, -1, -1, -1 };
                                int z = 2;
                                Console.WriteLine($"Pizza Sauce and Cheese have been added choose up to {i} toppings");

                                while (i > 0)
                                {
                                    {
                                        Console.WriteLine($"Select your Toppings From the List (E)nd You have {i} Toppings left to Choose");
                                        crustrepository.ToppingPrint();
                                        string s = Console.ReadLine();
                                        x[z]= Convert.ToInt16(s);
                                        if (s == "n" || s == "N")
                                        {
                                            i = 0;
                                        }

                                    }
                                    i--;
                                    z++;
                                }
                                
                                Order order = new Order
                                {

                                    Dateordered = DateTime.Now,
                                    Storeid = storeid,
                                    Crust = crust,
                                    Customerid = customerid,
                                    Ordercount = newordernum

                                };
                                Console.WriteLine("Type 'yes' to order and confirm this pizza or press enter to return to the menu");
                                string temp = Console.ReadLine();
                                if (temp == "yes" || temp == "Yes")
                                {

                                    
                                    order.OrderNum = pizzacount;
                                    customerRepository.OrderPizza(customerid);
                                    orderRepository.PizzaBoxAddOrder(order, x);
                                    pizzacount++;
                                }


                            }

                            catch
                            {
                                Console.WriteLine("Error in input");
                                Console.WriteLine("Press any key to continue");
                                Console.ReadLine();
                                Console.Clear();
                            }

                        }
                    }
                }
            }


        }

        
    }
}
