namespace Crm.BusinessLogic;
using Crm.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

public class OrderService : IOrderService
{
   
    private IOrderRepository _posgreSqlOrderRepository;

    public OrderService(IOrderRepository posgreSqlOrderRepository)
    {
        _posgreSqlOrderRepository = posgreSqlOrderRepository;
    }

    public async Task<OrderDto?> CreateOrderAsync(OrderDto orderDto, CancellationToken token = default)
    {
        Order order = await _posgreSqlOrderRepository.CreateAsync(orderDto.OrderDtoToOrder(), token);

        if (order is null)
            return null;

        return order.OrderToOrderDto();
    }

    public async Task<IEnumerable<OrderDto>>? GetOrderByDescriptionAsync(string description, CancellationToken token = default)
    {
        List<Order> orders = await _posgreSqlOrderRepository.GetOrderByDescriptionAsync(description, token);
        
        if(orders.Count() <= 0)
            return null;

        return  orders.OrderListToOrderDtoList();
    }

    public async Task<OrderDto?> GetOrderByIdAsync(int id, CancellationToken token = default)
    {

        Order order = await _posgreSqlOrderRepository.GetAsync(id, token);
        
        if(order is null)
            return null;

        return order.OrderToOrderDto();
    }

    public async Task<IEnumerable<OrderDto>>? GetListCreatedOrdersAsync(CancellationToken token = default)
    {
        List<Order> orders = await _posgreSqlOrderRepository.GetAllAsync(token);

        if (orders.Count() <= 0)
            return null;

        return orders.OrderListToOrderDtoList();
    }

    public async ValueTask<bool> UpdateOrderByIdAsync(int id, string description, CancellationToken token = default)
    {
        return await _posgreSqlOrderRepository.UpdateOrderByIdAsync(id, description, token);
    }

    public async ValueTask<bool> DeleteOrderAsync(int id, CancellationToken token = default)
    {
        return await _posgreSqlOrderRepository.DeleteAsync(id, token);
    }
    
    public async ValueTask<bool> UpdateOrderStateByIdAsync(int id, int state, CancellationToken token = default)
    {
        OrderState orderState = (OrderState)state;
        
        return await _posgreSqlOrderRepository.UpdateOrderStateByIdAsync(id, orderState, token);
    }
}
