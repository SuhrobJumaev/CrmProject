namespace Crm.BusinessLogic;
using Crm.DataAccess;

public class OrderService : IOrderService
{
    private readonly List<Order> _createdOrdersList = new();
    private int _id = 0;

    public OrderDto CreateOrder(OrderDto orderDto)
    {
        Order order = orderDto.OrderDtoToOrder();
        
        order.OrderState = OrderState.Pending;
        
        _createdOrdersList.Add(order);
        
        return order.OrderToOrderDto();
    }

    public List<OrderDto> GetOrderByDescription(string description)
    {
        return _createdOrdersList.Where(c => c.Description == description).ToList().OrderListToOrderDtoList();
    }

    public OrderDto GetOrderById(int id)
    {
        return _createdOrdersList.FirstOrDefault(c => c.Id == id).OrderToOrderDto();
    }

    public List<OrderDto> GetListCreatedOrders()
    {
        return _createdOrdersList.OrderListToOrderDtoList();
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
