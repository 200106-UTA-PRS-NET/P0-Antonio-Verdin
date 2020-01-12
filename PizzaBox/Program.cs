using System;
using PizzaBox;
using PizzaBox.Domain.Models;

namespace PizzaBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza = new Pizza();
            Pizza pizza2 = new Pizza();
            pizza.showToppings();

        }
    }
}
