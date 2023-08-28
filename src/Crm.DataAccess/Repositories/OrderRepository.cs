using Crm.DataAccess;

namespace Crm.DataAccess;

public class OrderRepository : IOrderRepository
{
    private readonly List<Order> _ordersList = new();
    private int _id = 0;

    public Order Create(Order entity)
    {
        entity.OrderState = OrderState.Pending;
        entity.Id = NextId();

        _ordersList.Add(entity);

        return entity;
    }

    public bool Delete(int id)
    {
        Order order = _ordersList.FirstOrDefault(c => c.Id == id);

        if(order is null)
        {
            return false;
        }

        return _ordersList.Remove(order);
    }

    public Order? Get(int id)
    {
        return _ordersList.FirstOrDefault(o => o.Id == id);
    }

    public List<Order> GetAll()
    {
        return _ordersList;
    }

    public List<Order> GetOrderByDescription(string description)
    {
        return _ordersList.Where(o => o.Description == description).ToList();
    }

    public bool UpdateOrderById(int id, string description)
    {
        var order = _ordersList.FirstOrDefault(c => c.Id == id);

        if(order is null)
        {
            return false;
        }

        order.Description = description;
        
        return true;
    }

    public bool UpdateOrderStateById(int id, OrderState state)
    {
        var order = _ordersList.FirstOrDefault(o => o.Id == id);
        
        if(order is null)
        {
            return false;
        }

        order.OrderState = state;
       
        return true;
    }
    private int NextId()
    {
        return ++_id;
    }
}