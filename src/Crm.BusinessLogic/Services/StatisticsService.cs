using Crm.DataAccess;

namespace Crm.BusinessLogic;

public class StaticticsService : IStatisticsService
{
    private readonly IClientRepository _clientRepository;
    private readonly IOrderRepository _orderRepository;

    public StaticticsService(IClientRepository clientRepository, IOrderRepository orderRepository)
    {
        _clientRepository = clientRepository;
        _orderRepository = orderRepository;
    }

    public int GetClientsCount() => _clientRepository.GetClientTotalCount();
    
    public async ValueTask<long> GetOrderCountAsync() => await _orderRepository.GetOrderTotalCountAsync();

    public async ValueTask<long> GetOrderCountByStateAsync(int orderState) => await _orderRepository.GetOrderTotalCountByStateAnsync((OrderState)orderState);
}