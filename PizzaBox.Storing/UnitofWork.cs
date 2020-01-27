using PizzaBox.Models;
using PizzaBox.Storing.Repositories;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Storing
{
   public class UnitofWork: IUnitofWork
    {
        private readonly PizzaBoxContext _context;

        public UnitofWork(PizzaBoxContext context)
        {
            _context = context;
            Customer = new CustomerRepository(_context);
            Employee = new EmployeeRepository(_context);
            Pizza = new PizzaRepository(_context);
            Order = new OrderRepository(_context);
            Address = new AddressRepository(_context);
            Store = new StoreRepository(_context);
            Ingrediants = new IngredientsRepository(_context);
        }

        public IOrders Order { get; private set; }
        public IAddress Address { get; private set; }

        public IIngrediants Ingrediants { get; private set; }

        public IPizza Pizza { get; private set; }

        public IEmployee Employee { get; private set; }

        public ICustomer Customer { get; private set; }

        public IngrediantsPizza ingrediantsPizza { get; private set; }

        public IOrders Orders { get; private set; }

        public IStore Store { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
