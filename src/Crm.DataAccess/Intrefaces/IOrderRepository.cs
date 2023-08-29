namespace Crm.DataAccess;

public interface IOrderRepository : IBaseRepository<Order>
{
    List<Order> GetOrderByDescription(string description);
    bool UpdateOrderById(int id, string description);
    bool UpdateOrderStateById(int id, OrderState state);
    int GetOrderTotalCount();
    int GetOrderTotalCountByState(OrderState state);
}