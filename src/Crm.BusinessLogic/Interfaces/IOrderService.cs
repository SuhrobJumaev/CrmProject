namespace Crm.BusinessLogic;

using Crm.DataAccess;

public interface IOrderService
{
    Task<OrderDto?> CreateOrderAsync(OrderDto orderDto, CancellationToken token = default);
    Task<IEnumerable<OrderDto>>? GetOrderByDescriptionAsync(string description, CancellationToken token = default);
    Task<OrderDto?> GetOrderByIdAsync(int id, CancellationToken token = default);
    Task<IEnumerable<OrderDto>>? GetListCreatedOrdersAsync(CancellationToken token = default);
    ValueTask<bool> UpdateOrderByIdAsync(int id, string description, CancellationToken token = default);
    ValueTask<bool> UpdateOrderStateByIdAsync (int id, int state, CancellationToken token = default);
    ValueTask<bool> DeleteOrderAsync(int id, CancellationToken token = default);
}
