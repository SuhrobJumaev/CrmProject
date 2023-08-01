
using System.Text;
using Crm.Entities;
using Crm.Entities.Dtos;
using Crm.Serices;
using Crm.Validators;

var clientService = new ClientService();
var orderService = new OrderService();

Console.WriteLine("Добро пожаловать в наш маленький CRM!");
Console.WriteLine("Выберите команду, которую вы хотите выполнить!");
Console.WriteLine("Доступные команды: {1 - создать клинта}, {2 - создать заказ}, {3 - завершения программы}, {4 - список ранее созданных клиентов}");

int commandNumber;

while (!int.TryParse(Console.ReadLine(), out commandNumber))
{
    Console.WriteLine("Доступные команды: {1 - создать клинта}, {2 - создать заказ},{3 - завершения программы}, {4 - список ранее созданных клиентов}");
}

var command = (CommandsType)commandNumber;

while (command != CommandsType.Exit)
{

    switch (command)
    {
        case CommandsType.CreateClient:

            var client = CreateClient();

            if (client == null)
            {
                Console.WriteLine("Клиент не был создан. Неизвестная ошибка, попробуйте снова!");
                break;
            }

            Console.WriteLine(new StringBuilder().Append('-', 100));
            Console.WriteLine("Клиент успешно создан");
            Console.WriteLine("Имя клиента: " + client.FirstName);
            Console.WriteLine("Фамилия клиента: " + client.LastName);
            Console.WriteLine("Отчество клиента: " + client.MiddleName);
            Console.WriteLine("Возраст клиента: " + client.Age);
            Console.WriteLine("Серия и номер паспорта клиента: " + client.PassportNumber);
            Console.WriteLine("Пол: " + client.Gender);
            Console.WriteLine("Номер телефона: " + client.Phone);
            Console.WriteLine("Почта: " + client.Email);

            break;

        case CommandsType.CreateOrder:

            var order = CreateOrder();

            if (order == null)
            {
                Console.WriteLine("Заказ не был создан. Неизвестная ошибка, попробуйте снова!");
                break;
            }

            Console.WriteLine(new StringBuilder().Append('-', 100));
            Console.WriteLine("Заказ успешно создан");
            Console.WriteLine("Описания заказа: " + order.Description);
            Console.WriteLine("Цена: " + order.Price);
            Console.WriteLine("Тип доставки: " + order.DeliveryType);
            Console.WriteLine("Дата заказа: " + order.OrderDate?.ToString("yyyy-MM-dd"));
            Console.WriteLine("Адрес доставки: " + order.DeliveryAddress);
            break;

        case CommandsType.ListCreatedClients:

            clientService.GetListAllCreatedClients();
            break;

        default:
            Console.WriteLine("Неизвестная команда!");
            break;
    }

    Console.WriteLine(new StringBuilder().Append('-', 100));
    Console.WriteLine("Доступные команды: {1 - создать клинта}, {2 - создать заказ},{3 - завершения программы}, {4 - список ранее созданных клиентов}");

    while (!int.TryParse(Console.ReadLine(), out commandNumber))
    {
        Console.WriteLine("Доступные команды: {1 - создать клинта}, {2 - создать заказ},{3 - завершения программы}, {4 - список ранее созданных клиентов}");
    }

    command = (CommandsType)commandNumber;
}

Client CreateClient()
{
    Console.WriteLine("Введите имя клиента: ");
    var firstName = Console.ReadLine();

    while (!ClientValidator.IsValidFirstName(firstName))
    {
        Console.WriteLine("Введите имя клиента: ");
        firstName = Console.ReadLine();
    }

    Console.WriteLine("Введите фамилию клиента: ");
    var lastName = Console.ReadLine();

    while (!ClientValidator.IsValidLastName(lastName))
    {
        Console.WriteLine("Введите фамилию клиента: ");
        lastName = Console.ReadLine();
    }

    Console.WriteLine("Введите отчества клиента: {НЕОБЯЗАТЕЛЬНОЕ ПОЛЕ} ");
    var middleName = Console.ReadLine();

    short age;
    Console.WriteLine("Укажите возраст клиента: ");
    var ageString = Console.ReadLine();

    while (!ClientValidator.IsValidAge(ageString, out age))
    {
        Console.WriteLine("Укажите возраст клиента: ");
        ageString = Console.ReadLine();
    }

    Console.WriteLine("Укажите номер и серию паспорта клиента: ");
    var passportNumber = Console.ReadLine();

    while (!ClientValidator.IsValidPassportId(passportNumber))
    {
        Console.WriteLine("Укажите номер и серию паспорта клиента: ");
        passportNumber = Console.ReadLine();
    }

    short genderNumber;
    Console.WriteLine("Укажите пол клиента: {1 - М} {2 - Ж} ");
    var genderString = Console.ReadLine();

    while (!ClientValidator.IsValidGender(genderString, out genderNumber))
    {
        Console.WriteLine("Укажите пол клиента: {1 - М} {2 - Ж} ");
        genderString = Console.ReadLine();
    }

    Console.WriteLine("Введите номер телефона: {992900000000} ");

    var phone = Console.ReadLine();

    while (!ClientValidator.IsValidPhone(phone))
    {
        Console.WriteLine("Введите номер телефона: {992900000000} ");
        phone = Console.ReadLine();
    }

    Console.WriteLine("Введите email клиента: {name@mail.ru or name@gamil.com} ");

    var email = Console.ReadLine();

    while (!ClientValidator.IsValidEmail(email))
    {
        Console.WriteLine("Введите email клиента: {name@mail.ru or name@gamil.com} ");
        email = Console.ReadLine();
    }

    Console.WriteLine("Введите пароль клиента: ");

    var password = Console.ReadLine();

    while (!ClientValidator.IsValidPassword(password))
    {
        Console.WriteLine("Введите пароль клиента: ");
        password = Console.ReadLine();
    }

    var gender = (Gender)genderNumber;

    var clientDto = new ClientDto()
    {
        FirstName = firstName,
        LastName = lastName,
        MiddleName = middleName,
        Age = age,
        PassportNumber = passportNumber,
        Gender = gender,
        Phone = phone,
        Email = email,
        Password = password

    };

    var newClient = clientService.CreateClient(clientDto);

    return newClient;
}

Order CreateOrder()
{
    Console.WriteLine("Описания заказа: ");
    var description = Console.ReadLine();

    while (!OrderValidator.IsValidDescription(description))
    {
        Console.WriteLine("Описания заказа: ");
        description = Console.ReadLine();
    }

    decimal price;
    Console.WriteLine("Цена заказа: ");
    var priceString = Console.ReadLine();

    while (!OrderValidator.IsValidPrice(priceString, out price))
    {
        Console.WriteLine("Цена заказа: ");
        priceString = Console.ReadLine();
    }

    DateTime orderDate;
    Console.WriteLine("Укажите дату: {формат - гггг-ММ-дд} ");
    var dateString = Console.ReadLine();

    while (!OrderValidator.IsValidDate(dateString, out orderDate))
    {
        Console.WriteLine("Укажите дату: {формат - гггг-мм-дд} ");
        dateString = Console.ReadLine();
    }

    short deliverTypeNumber;
    Console.WriteLine("Тип доставки: {1 - Express} {2 - Standart} {3 - Free} ");
    var deliverTypeString = Console.ReadLine();

    while (!OrderValidator.IsValidDeliverType(deliverTypeString, out deliverTypeNumber))
    {
        Console.WriteLine("Тип доставки: {1 - Express} {2 - Standart} {3 - Free} ");
        deliverTypeString = Console.ReadLine();
    }

    var deliveryType = (DeliveryType)deliverTypeNumber;

    Console.WriteLine("Адрес доставки: ");
    var deliveryAddress = Console.ReadLine();

    while (!OrderValidator.IsValidDeliverAddress(deliveryAddress))
    {
        Console.WriteLine("Адрес доставки: ");
        deliveryAddress = Console.ReadLine();
    }

    var orderDto = new OrderDto()
    {
        Id = 1,
        Description = description,
        Price = price,
        OrderDate = orderDate,
        DeliveryType = deliveryType,
        DeliveryAddress = deliveryAddress,
    };

    var newOrder = orderService.CreateOrder(orderDto);

    return newOrder;
}
