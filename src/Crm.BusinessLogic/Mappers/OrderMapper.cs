namespace Crm.BusinessLogic;

using Crm.DataAccess;

public static class OrderMapper 
{    
    public static Order OrderDtoToOrder(this OrderDto orderDto)
    {
        return new () 
        {
            Id = orderDto.Id,
            Description = orderDto.Description,
            Price = orderDto.Price,
            OrderDate = orderDto.OrderDate,
            DeliveryType = (DeliveryType)orderDto.DeliveryType,
            DeliveryAddress = orderDto.DeliveryAddress,
        };
    }  
    public static OrderDto OrderToOrderDto(this Order order)
    {
        return new () 
        {
            Id = order.Id,
            Description = order.Description,
            Price = order.Price,
            OrderDate = order.OrderDate,
            DeliveryType = (int)order.DeliveryType,
            DeliveryAddress = order.DeliveryAddress,
            OrderState = (int)order.OrderState,
        };
    }   
    public static List<OrderDto> OrderListToOrderDtoList(this List<Order> orders)
    {
        List<OrderDto> ordersDto = new();

        ordersDto = orders.Select(c => new OrderDto
        {
            Id = c.Id,
            Description = c.Description,
            Price = c.Price,
            OrderDate = c.OrderDate,
            DeliveryType = (int)c.DeliveryType,
            DeliveryAddress = c.DeliveryAddress,
            OrderState = (int)c.OrderState,
        }).ToList();
        
        return ordersDto;
    }
    public static List<Order> OrderDtoListToOrderList(this List<OrderDto> ordersDto)
    {
        List<Order> orders = new();

        orders = ordersDto.Select(c => new Order
        {
            Id = c.Id,
            Description = c.Description,
            Price = c.Price,
            OrderDate = c.OrderDate,
            DeliveryType = (DeliveryType)c.DeliveryType,
            DeliveryAddress = c.DeliveryAddress,
            OrderState = (OrderState)c.OrderState,
        }).ToList();
        
        return orders;
    }

}