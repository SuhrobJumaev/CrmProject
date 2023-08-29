namespace Crm.Enums;

public enum CommandsType : short
{
    CreateClient = 1,
    CreateOrder = 2,
    Exit = 3,
    ListCreatedClients = 4,
    ListCreatedOrders = 5,
    GetClientByNameAndLastName = 6,
    GetOrderByDescription = 7,
    GetOrderById = 8,
    UpdateClientById = 9,
    DeleteClient = 10,
    UpdateOrderById = 11,
    DeleteOrder = 12,
    UpdateOrderStatus = 13,
    TotalCountOrder = 14,
    TotalCountClient = 15,
    TotalCountOrderByState = 16,

}
