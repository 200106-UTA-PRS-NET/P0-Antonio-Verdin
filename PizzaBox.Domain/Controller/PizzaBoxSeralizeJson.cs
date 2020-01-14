using PizzaBox.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace PizzaBox.Domain.Controller
{
    class PizzaBoxSeralizeJson
    {
        PizzaBoxSeralizeJson()
        {
            List<JsonStore> stores = new List<JsonStore>();
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsonString2 = "";
            jsonString2 = JsonSerializer.Serialize(stores, options);
            File.AppendAllText("C:\\Users\\theki\\Documents\\Revature\\projects\\P0-Antonio-Verdin\\PizzaBox.Storing\\Repositories\\Stores.json", jsonString2);
        }
    }
}
