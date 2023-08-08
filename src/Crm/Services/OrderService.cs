namespace Crm.Serices;

using Crm.Entities;
using Crm.Entities.Dtos;

public class OrderService
{
    private readonly List<Order> _createdOrdersList = new();
    private int _id = 0;

    public Order CreateOrder(OrderDto orderDto)
    {
        Order order = new()
        {
            Id = NextId(),
            Description = orderDto.Description,
            Price = orderDto.Price,
            OrderDate = orderDto.OrderDate,
            DeliveryType = orderDto.DeliveryType,
            DeliveryAddress = orderDto.DeliveryAddress
        };

        _createdOrdersList.Add(order);
        return order;
    }

    public List<Order> GetOrderByDescription(string description)
    {
        return _createdOrdersList.FindAll(c => c.Description == description).ToList();
    }

    public Order GetOrderById(int id)
    {
        return _createdOrdersList.Find(c => c.Id == id);
    }

    public List<Order> GetListCreatedOrders()
    {
        return _createdOrdersList;
    }

    private int NextId()
    {
        return ++_id;
    }
}
