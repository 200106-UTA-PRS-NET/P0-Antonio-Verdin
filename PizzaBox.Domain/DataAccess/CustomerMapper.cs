
namespace PizzaBox.Domain.DataAccess.Repository
{
    class CustomerMapper
    {
        public static PizzaLib.Customer Map(Client.Models.Customers customers)
        {
            return new PizzaLib.Customer()
            {
                Customerid = customers.Customerid,
                Fname = customers.Fname,
                Lname = customers.Lname,
                Lastorder = customers.Lastorder,

            };
        }
        public static Client.Models.Customers Map(PizzaLib.Customer customer)
        {
            return new Client.Models.Customers
            {
                Customerid = customer.Customerid,
                Fname = customer.Fname,
                Lname = customer.Lname,
                Lastorder = customer.Lastorder
            };

        }
    }
}
