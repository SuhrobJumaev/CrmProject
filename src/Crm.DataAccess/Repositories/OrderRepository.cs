using Crm.DataAccess;

namespace Crm.DataAccess;

public sealed class OrderRepository : IOrderRepository
{
    private static readonly List<Order> _ordersList = new();
    private static int _id = 0;

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

    public int GetOrderTotalCount() => _ordersList.Count();
   
    public int GetOrderTotalCountByState(OrderState state)
    {
        List<Order> orders = _ordersList.Where(o => o.OrderState == state).ToList();

        return orders.Count(); 
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


    public Task<Order> CreateAsync(Order entity, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteAsync(int id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> UpdateOrderStateByIdAsync(int id, OrderState state, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<List<Order>> GetAllAsync(CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<Order>? GetAsync(int id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<long> GetOrderTotalCountAsync(CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> UpdateOrderByIdAsync(int id, string description, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<long> GetOrderTotalCountByStateAnsync(OrderState state, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<List<Order>> GetOrderByDescriptionAsync(string description, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    private int NextId()
    {
        return ++_id;
    }
}