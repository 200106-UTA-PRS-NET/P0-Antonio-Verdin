using System;
using PizzaBox;
using PizzaBox.Domain.Models;

//testing namespaces
using System.IO;
using System.Text.Json;

namespace PizzaBox
{
    class Program
    {
        static void Main(string[] args)
        {


            string json = "";

            //Testing Code Below
            //Pizza pizza = new Pizza();
            //Pizza pizza2 = new Pizza();
            //pizza.showToppings();
            //using (StreamReader r = new StreamReader("C:\\Users\\theki\\Documents\\Revature\\projects\\P0-Antonio-Verdin\\PizzaBox.Storing\\Repositories\\Stores.json"))
            //using (StreamReader r = new StreamReader("..\\P0-Antonio-Verdin\\PizzaBox.Storing\\Repositories\\Stores.json"))
            {
              // json = r.ReadToEnd();
                
            }
            TempStore stores = new TempStore();
            string jsonString = File.ReadAllText("C:\\Users\\theki\\Documents\\Revature\\projects\\P0-Antonio-Verdin\\PizzaBox.Storing\\Repositories\\Stores.json");
            stores = JsonSerializer.Deserialize<TempStore>(jsonString);


            
        }
    }
    class TempStore
    {
        public string Name { get; set;}
        public int Id { get; set; } 
        
    }
}
