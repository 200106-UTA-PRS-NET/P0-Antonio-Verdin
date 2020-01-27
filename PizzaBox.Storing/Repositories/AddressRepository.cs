using PizzaBox.Domain.Interfaces;
using PizzaBox.Models;

namespace PizzaBox.Storing.Repositories
{
    public class AddressRepository : Repository<Addressing>, IAddress
    {
        public AddressRepository(PizzaBoxContext context)
    : base(context)
        {
        }
        public PizzaBoxContext PizzaBoxContext
        {
            get { return Context as PizzaBoxContext; }
        }
    }
}