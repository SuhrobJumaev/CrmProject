namespace Crm.BusinessLogic;

using Crm.DataAccess;

public interface IOrderService
{
    Order CreateOrder(OrderDto orderDto);
    List<Order> GetOrderByDescription(string description);
    Order GetOrderById(int id);
    List<Order> GetListCreatedOrders();
    bool UpdateOrderById(int id, string description);
    bool UpdateOrderStateById (int id, OrderState state);
    bool DeleteOrder(int id);
}
