namespace Crm.BusinessLogic;

public interface IStatisticsService
{
    public int GetClientsCount();
    public ValueTask<long> GetOrderCountAsync();
    public ValueTask<long> GetOrderCountByStateAsync(int orderState);  
}