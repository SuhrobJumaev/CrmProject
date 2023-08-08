namespace Crm.interfaces;

using Crm.DataAccess;

public interface IOrderService
{
    Order CreateOrder(OrderDto orderDto);
    List<Order> GetOrderByDescription(string description);
    Order GetOrderById(int id);
    List<Order> GetListCreatedOrders();
}
