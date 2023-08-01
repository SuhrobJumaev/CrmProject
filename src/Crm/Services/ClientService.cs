namespace Crm.Serices;

using System.Text;
using Crm.Entities;
using Crm.Entities.Dtos;

public sealed class ClientService
{
    private readonly List<Client> _createdClientsList = new();
    public Client CreateClient(ClientDto clientDto)
    {

        Client client = new()
        {
            FirstName = clientDto.FirstName,
            LastName = clientDto.LastName,
            MiddleName = clientDto.MiddleName,
            Age = clientDto.Age,
            PassportNumber = clientDto.PassportNumber,
            Gender = clientDto.Gender,
            Phone = clientDto.Phone,
            Email = clientDto.Email,
            Password = clientDto.Password
        };
        _createdClientsList.Add(client);
        return client;
    }

    public void GetListAllCreatedClients()
    {
        var strBuilder = new StringBuilder().Append('-', 100);

        Console.WriteLine("");
        System.Console.WriteLine("Count created clients is " + _createdClientsList.Count());
        Console.WriteLine("");

        if (_createdClientsList.Count == 0)
        {
            return;
        }

        foreach (var client in _createdClientsList)
        {
            Console.WriteLine("");
            System.Console.WriteLine(strBuilder);

            Console.WriteLine("Имя клиента: " + client.FirstName);
            Console.WriteLine("Фамилия клиента: " + client.LastName);
            Console.WriteLine("Отчество клиента: " + client.MiddleName);
            Console.WriteLine("Возраст клиента: " + client.Age);
            Console.WriteLine("Серия и номер паспорта клиента: " + client.PassportNumber);
            Console.WriteLine("Пол: " + client.Gender);
            Console.WriteLine("Номер телефона: " + client.Phone);
            Console.WriteLine("Почта: " + client.Email);

            Console.WriteLine("");
        }
    }
}
