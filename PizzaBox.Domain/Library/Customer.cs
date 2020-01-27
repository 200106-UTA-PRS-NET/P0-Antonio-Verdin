namespace PizzaBox.Domain.Library
{
    public class Customer:Addressing
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserPassWord { get; set; }

    }
    
}
