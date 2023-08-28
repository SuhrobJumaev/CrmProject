namespace Crm.BusinessLogic;

using Crm.DataAccess;

public interface IOrderService
{
    OrderDto? CreateOrder(OrderDto orderDto);
    List<OrderDto>? GetOrderByDescription(string description);
    OrderDto? GetOrderById(int id);
    List<OrderDto>? GetListCreatedOrders();
    bool UpdateOrderById(int id, string description);
    bool UpdateOrderStateById (int id, int state);
    bool DeleteOrder(int id);
}
