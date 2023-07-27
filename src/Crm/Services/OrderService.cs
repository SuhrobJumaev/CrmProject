namespace Crm.Serices;
using Crm.Entities;

public class OrderService 
{
    public Order CreateOrder(
        int id, 
        string description, 
        decimal price, 
        DateTime orderDate, 
        DeliveryType deliveryType, 
        string deliveryAddress
    )
    {
        return new ()
        {
            Id = id,
            Description = description,
            Price = price,
            OrderDate = orderDate,
            DeliveryType = deliveryType,
            DeliveryAddress = deliveryAddress

        };
    }
}