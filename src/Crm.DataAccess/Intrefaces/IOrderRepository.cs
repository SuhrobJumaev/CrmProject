namespace Crm.DataAccess;

public interface IOrderRepository : IBaseRepository<Order>
{
    List<Order> GetOrderByDescription(string description);
    bool UpdateOrderById(int id, string description);
    bool UpdateOrderStateById(int id, OrderState state);
    int GetOrderTotalCount();
    int GetOrderTotalCountByState(OrderState state);

    Task<List<Order>> GetOrderByDescriptionAsync(string description, CancellationToken token = default);
    ValueTask<bool> UpdateOrderByIdAsync(int id, string description, CancellationToken token = default);
    ValueTask<bool> UpdateOrderStateByIdAsync(int id, OrderState state, CancellationToken token = default);
    ValueTask<long> GetOrderTotalCountAsync(CancellationToken token = default);
    ValueTask<long> GetOrderTotalCountByStateAnsync(OrderState state, CancellationToken token = default);
}