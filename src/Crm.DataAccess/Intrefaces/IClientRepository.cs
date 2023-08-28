namespace Crm.DataAccess;

public interface IClientRepository : IBaseRepository<Client>
{
    List<Client> GetClientByNameAndSurname(string name, string surname);
    bool UpdateClientById(int id, string name, string surname);
}