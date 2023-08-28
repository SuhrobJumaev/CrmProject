namespace Crm.BusinessLogic;
using Crm.DataAccess;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public OrderDto? CreateOrder(OrderDto orderDto)
    {
        Order order = _orderRepository.Create(orderDto.OrderDtoToOrder());
        
        if(order is null)
            return null;

        return order.OrderToOrderDto();
    }

    public List<OrderDto>? GetOrderByDescription(string description)
    {
        List<Order> orders = _orderRepository.GetOrderByDescription(description);
        
        if(orders is null)
            return null;

        return  orders.OrderListToOrderDtoList();
    }

    public OrderDto? GetOrderById(int id)
    {
        Order order = _orderRepository.Get(id);
        
        if(order is null)
            return null;

        return order.OrderToOrderDto();
    }

    public List<OrderDto>? GetListCreatedOrders()
    {
        List<Order> orders = _orderRepository.GetAll();

        if(orders is null)
            return null;
        
        return orders.OrderListToOrderDtoList();
    }

    public bool UpdateOrderById(int id, string description)
    {
        return _orderRepository.UpdateOrderById(id, description);
    }

    public bool DeleteOrder(int id)
    {
        return _orderRepository.Delete(id);
    }
    
    public bool UpdateOrderStateById(int id, int state)
    {
        OrderState orderState = (OrderState)state;
        
        return _orderRepository.UpdateOrderStateById(id, orderState);
    }
}
