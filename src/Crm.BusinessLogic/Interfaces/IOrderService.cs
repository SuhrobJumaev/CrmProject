namespace Crm.BusinessLogic;

using Crm.DataAccess;

public interface IOrderService
{
    OrderDto? CreateOrder(OrderDto orderDto);
    IEnumerable<OrderDto>? GetOrderByDescription(string description);
    OrderDto? GetOrderById(int id);
    IEnumerable<OrderDto>? GetListCreatedOrders();
    bool UpdateOrderById(int id, string description);
    bool UpdateOrderStateById (int id, int state);
    bool DeleteOrder(int id);
}
