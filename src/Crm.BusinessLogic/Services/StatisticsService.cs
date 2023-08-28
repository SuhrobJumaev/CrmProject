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
    
    public int GetOrderCount() => _orderRepository.GetOrderTotalCount();

    public int GetOrderCountByState(int orderState) =>  _orderRepository.GetOrderTotalCountByState((OrderState)orderState);
}