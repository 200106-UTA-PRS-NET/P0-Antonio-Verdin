using System;
using PizzaBox;
using PizzaBox.Domain.Models;

//testing namespaces
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace PizzaBox
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //DeSeralizaton Logic
            List<TempStore> stores = new List<TempStore>();
            string jsonString = File.ReadAllText("C:\\Users\\theki\\Documents\\Revature\\projects\\P0-Antonio-Verdin\\PizzaBox.Storing\\Repositories\\Stores.json");
            stores = JsonSerializer.Deserialize<List<TempStore>>(jsonString);

            List<TempStore> TempStores = new List<TempStore>();

            //Seralization Logic
            TempStore Store1 = new TempStore();
            TempStore Store2 = new TempStore();
            Store1.Name = "LAX";
            Store1.Id = 3;
            Store2.Name = "Boston";
            Store1.Id = 4;
            TempStores.Add(Store1);
            TempStores.Add(Store2);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsonString2 = "";
            jsonString2 = JsonSerializer.Serialize(TempStores, options);
            File.AppendAllText("C:\\Users\\theki\\Documents\\Revature\\projects\\P0-Antonio-Verdin\\PizzaBox.Storing\\Repositories\\Stores.json", jsonString2);


        }
    }
    class TempStore
    {
        public string Name { get; set;}
        public int Id { get; set; } 
        
    }

}
