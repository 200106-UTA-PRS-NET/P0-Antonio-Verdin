using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
     public class Pizza: Interfaces.IPizza
    {

        Dictionary<string, double> Toppings = new Dictionary<string, double>();
        string crust = "";
        string size = "";
        public Pizza()
        {
            addTopping("Red Sauce", 5.00f);
            addTopping("Cheese", 5.00f);
            Console.WriteLine(Toppings.Count);
        }
        double Interfaces.IPizza.Cost()
        {
            double cost = 0;
            foreach (KeyValuePair<string, double> item in Toppings)
            { cost += item.Value; }
            return cost;
        }
        void addTopping(string a, double cost)
        {
            if (Toppings.Count <= 5)
            {
                Toppings.Add(a, cost);
            }
            else
            {
                Console.WriteLine("Our Pizza Cook Faster and Taste Better with 5 or less toppings");
            }
        }
        void removeTopping(string a)
        {
            Toppings.Remove(a)
;        }
        public void showToppings()
        {
            foreach(KeyValuePair<string,double> topping in Toppings)
            {
                Console.WriteLine(topping.Key);

            }
        }

    }
}
