
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
    }
}
