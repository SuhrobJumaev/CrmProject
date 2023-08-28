namespace Crm.BusinessLogic;

using Crm.DataAccess;

public static class ClientServiceFactory 
{
    public static IClientService CreateClientService()
    {
        IClientRepository clientRepository = new ClientRepository();
        return new ClientService(clientRepository);
    }
}