﻿namespace Crm.interfaces;


using Crm.DataAccess;

public interface IClientService
{
    Client CreateClient(ClientDto clientDto);
    List<Client> GetListAllCreatedClients();
    List<Client> GetClientByNameAndSurname(string firstName, string lastName);
    Client UpdateClientById(int id,string firstName, string lastName);
    bool DeleteClient(int id);
}
