namespace Crm.interfaces;

using Crm.Entities;
using Crm.Entities.Dtos;

public interface IOrderService
{
    Order CreateOrder(OrderDto orderDto);
    List<Order> GetOrderByDescription(string description);
    Order GetOrderById(int id);
    List<Order> GetListCreatedOrders();
}
