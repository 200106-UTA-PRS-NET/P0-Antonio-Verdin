namespace PizzaBox.Domain.DataAccess
{ 
    class OrderMapper
    {
            public static PizzaLib.Order Map(Client.Models.Orders orders)
            {
            return new PizzaLib.Order()
            {
                OrderNum = orders.OrderNum,
                Ordercount = orders.Ordercount,
                Orderuid = orders.Orderuid,
                Dateordered = orders.Dateordered,
                Customerid = orders.Customerid,
                Storeid = orders.Storeid,
                Crust = orders.Crust,
                };
            }
            public static Client.Models.Orders Map(PizzaLib.Order order)
            {
                return new Client.Models.Orders
                {
                    OrderNum = order.OrderNum,
                    Ordercount = order.Ordercount,
                    Orderuid = order.Orderuid,
                    Dateordered = order.Dateordered,
                    Crust = order.Crust,
                    Customerid = order.Customerid,
                    Storeid = order.Storeid


                };

            }
        }
    }