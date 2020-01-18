namespace PizzaBox.Domain.DataAccess.Models
{
    class StoreMapper
    {
        public static PizzaLib.Store Map(Client.Models.Store store)
        {
            return new PizzaLib.Store()
            {
                Id = store.Id,
                name = store.Loc
            };
        }
    }
}
