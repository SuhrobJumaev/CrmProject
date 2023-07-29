namespace Crm.Serices;

using Crm.Entities;
using Crm.Entities.Dtos;

public class OrderService
{
    public Order CreateOrder(OrderDto orderDto)
    {
        return new()
        {
            Id = orderDto.Id,
            Description = orderDto.Description,
            Price = orderDto.Price,
            OrderDate = orderDto.OrderDate,
            DeliveryType = orderDto.DeliveryType,
            DeliveryAddress = orderDto.DeliveryAddress
        };

    }
}
