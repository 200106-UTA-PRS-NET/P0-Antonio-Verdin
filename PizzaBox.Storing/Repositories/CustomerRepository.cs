
using PizzaBox.Domain.Interfaces;
using PizzaBox.Models;

namespace PizzaBox.Storing.Repositories
{
   public class CustomerRepository : Repository<Customer>,ICustomer
    {
        public CustomerRepository(PizzaBoxContext context)
    : base(context)
        {
        }
        public PizzaBoxContext PizzaBoxContext
        {
            get { return Context as PizzaBoxContext; }
        }
    }
}
