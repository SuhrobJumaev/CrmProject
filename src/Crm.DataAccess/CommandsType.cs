namespace Crm.DataAccess;

public enum CommandsType : short
{
    CreateClient = 1,
    CreateOrder = 2,
    Exit = 3,
    ListCreatedClients = 4,
    ListCreatedOrders = 5,
    GetClientByNameAndLastName = 6,
    GetOrderByDescription = 7,
    GetOrderById = 8
}
