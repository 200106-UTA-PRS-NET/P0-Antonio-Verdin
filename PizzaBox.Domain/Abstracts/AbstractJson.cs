using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace PizzaBox.Domain.Abstracts
{
    abstract class PizzaBoxSeralizer
    {
        void PizzaBoxSeralizeJson<T>(List<T> ts, string file)
        {
            string filename = "C:\\Users\\theki\\Documents\\Revature\\projects\\P0-Antonio-Verdin\\PizzaBox.Storing\\Repositories\\" + file;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsonString2 = JsonSerializer.Serialize(ts, options);
            File.AppendAllText(filename, jsonString2);
        }

        List<T> PizzaboxDeseralizerJson<T>(string file)
        {
            //DeSeralizaton Logic
            List<T> returnlist = new List<T>();
            string jsonString = File.ReadAllText("C:\\Users\\theki\\Documents\\Revature\\projects\\P0-Antonio-Verdin\\PizzaBox.Storing\\Repositories\\"+file);
            returnlist = JsonSerializer.Deserialize<List<T>>(jsonString);
            return returnlist;
        }
    }
}
