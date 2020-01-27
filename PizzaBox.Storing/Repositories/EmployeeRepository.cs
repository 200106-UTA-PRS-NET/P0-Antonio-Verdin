using PizzaBox.Domain.Interfaces;
using PizzaBox.Models;
namespace PizzaBox.Storing.Repositories
{
    class EmployeeRepository: Repository<Employee>,IEmployee
    {
        public EmployeeRepository(PizzaBoxContext context)
            : base(context)
        {
        }
        public PizzaBoxContext PizzaBoxContext
        {
            get { return Context as PizzaBoxContext; }
        }
    }
}
