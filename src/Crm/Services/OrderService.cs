namespace Crm.Serices;

using Crm.DataAccess;
using Crm.interfaces;

public class OrderService : IOrderService
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

    public Order UpdateOrderById(int id, string description)
    {
        Order order = _createdOrdersList.Find(c => c.Id == id);

        if(order == null)
        {
            return null;
        }

        order.Description = description;

        return order;
    }

    public bool DeleteOrder(int id)
    {
        Order order = _createdOrdersList.Find(c => c.Id == id);

        if(order == null)
        {
            return false;
        }

        var result = _createdOrdersList.Remove(order);

        return result;
    }

    private int NextId()
    {
        return ++_id;
    }
}
