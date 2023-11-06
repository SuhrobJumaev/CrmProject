namespace Crm.BusinessLogic;

using Crm.DataAccess;

public static class OrderServiceFactory
{
    public static IOrderService CreateOrderService()
    {
        IOrderRepository orderRepository = new PosgreSqlOrderRepository();
        return new OrderService(orderRepository);
    }
}