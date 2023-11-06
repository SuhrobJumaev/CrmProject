using Crm.DataAccess;

namespace Crm.BusinessLogic;

public static class StatisticsServiceFactory
{
    public static IStatisticsService CreateStatisticsService()
    {
        IClientRepository clientRepository = new ClientRepository();
        IOrderRepository orderRepository = new PosgreSqlOrderRepository();
        return new StaticticsService(clientRepository, orderRepository);
    }
}