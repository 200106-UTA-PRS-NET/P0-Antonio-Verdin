using PizzaBox.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace PizzaBox.Domain.Controller
{
    class PizzaboxDeseralizerJson
    {
        PizzaboxDeseralizerJson() {
        //DeSeralizaton Logic
        List<JsonStore> stores = new List<JsonStore>();
        string jsonString = File.ReadAllText("C:\\Users\\theki\\Documents\\Revature\\projects\\P0-Antonio-Verdin\\PizzaBox.Storing\\Repositories\\Stores.json");
        stores = JsonSerializer.Deserialize<List<JsonStore>>(jsonString);
        List<JsonStore> TempStores = new List<JsonStore>();
        }
    }
}
