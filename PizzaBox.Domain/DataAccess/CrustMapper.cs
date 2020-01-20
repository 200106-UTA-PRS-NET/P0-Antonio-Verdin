using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.DataAccess
{
    class CrustMapper
    {
        public static PizzaLib.Crust Map(Client.Models.Crust crust)
        {
            return new PizzaLib.Crust()
            {
                Id = crust.Id,
                name = crust.Crust1,
                price = crust.Price
            };
        }
    }
}
