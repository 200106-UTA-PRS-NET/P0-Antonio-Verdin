using System;
namespace PizzaBox.Domain.PizzaLib
{
    public class Customer
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime? Lastorder { get; set; }
        public int Customerid { get; set; }

    }
}
