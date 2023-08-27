namespace Crm.BusinessLogic;
using Crm.DataAccess;

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
            DeliveryAddress = orderDto.DeliveryAddress,
            OrderState = orderDto.OrderState
        };

        _createdOrdersList.Add(order);
        return order;
    }

    public List<Order> GetOrderByDescription(string description)
    {
        return _createdOrdersList.Where(c => c.Description == description).ToList();
    }

    public Order GetOrderById(int id)
    {
        return _createdOrdersList.FirstOrDefault(c => c.Id == id);
    }

    public List<Order> GetListCreatedOrders()
    {
        return _createdOrdersList;
    }

    public bool UpdateOrderById(int id, string description)
    {
        var order = _createdOrdersList.FirstOrDefault(c => c.Id == id);

        if(order is null)
        {
            return false;
        }

        order.Description = description;
        
        return true;
    }

    public bool DeleteOrder(int id)
    {
        Order order = _createdOrdersList.FirstOrDefault(c => c.Id == id);

        if(order is null)
        {
            return false;
        }

        return _createdOrdersList.Remove(order);
       
    }

    private int NextId()
    {
        return ++_id;
    }

    public bool UpdateOrderStateById(int id, OrderState state)
    {
        var order = _createdOrdersList.FirstOrDefault(o => o.Id == id);
        
        if(order is null)
        {
            return false;
        }

        order.OrderState = state;
       
        return true;
    }
}
