
using System.Text;
using Crm.BusinessLogic;
using Crm.DataAccess;
using Crm.Validators;

IClientService clientService = new ClientService();
IOrderService orderService = new OrderService();

var strBuilder = new StringBuilder().Append('-', 100);

Console.WriteLine("Добро пожаловать в наш маленький CRM!");
Console.WriteLine("Выберите команду, которую вы хотите выполнить!");
Console.WriteLine(GetAvailableCommands());

int commandNumber;

while (!int.TryParse(Console.ReadLine(), out commandNumber))
{
    Console.WriteLine(GetAvailableCommands());
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
                AddNewEmptyLine();
                Console.WriteLine("Клиент не был создан. Неизвестная ошибка, попробуйте снова!");
                break;
            }

            Console.WriteLine(strBuilder);
            Console.WriteLine("Клиент успешно создан");

            AddNewEmptyLine();
            Console.WriteLine("ID клиента: " + client.Id);
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
                AddNewEmptyLine();
                Console.WriteLine("Заказ не был создан. Неизвестная ошибка, попробуйте снова!");
                break;
            }

            Console.WriteLine(new StringBuilder().Append('-', 100));
            Console.WriteLine("Заказ успешно создан");
            AddNewEmptyLine();

            Console.WriteLine("ID заказа: " + order.Id);
            Console.WriteLine("Описания заказа: " + order.Description);
            Console.WriteLine("Цена: " + order.Price);
            Console.WriteLine("Тип доставки: " + order.DeliveryType);
            Console.WriteLine("Дата заказа: " + order.OrderDate?.ToString("yyyy-MM-dd"));
            Console.WriteLine("Адрес доставки: " + order.DeliveryAddress);
            Console.WriteLine("Статус заказа: " + order.OrderState);
            break;

        case CommandsType.ListCreatedClients:

            var clients = clientService.GetListAllCreatedClients();

            if (clients == null)
            {
                AddNewEmptyLine();
                Console.WriteLine("Список клиентов не найден! Обратитесь за помощью к администратору!");
                break;
            }

            AddNewEmptyLine();
            Console.WriteLine("Count created clients is " + clients.Count());
            AddNewEmptyLine();

            if (clients.Count == 0)
            {
                break;
            }

            foreach (var item in clients)
            {
                AddNewEmptyLine();
                System.Console.WriteLine(strBuilder);

                Console.WriteLine("ID клиента: " + item.Id);
                Console.WriteLine("Имя клиента: " + item.FirstName);
                Console.WriteLine("Фамилия клиента: " + item.LastName);
                Console.WriteLine("Отчество клиента: " + item.MiddleName);
                Console.WriteLine("Возраст клиента: " + item.Age);
                Console.WriteLine("Серия и номер паспорта клиента: " + item.PassportNumber);
                Console.WriteLine("Пол: " + item.Gender);
                Console.WriteLine("Номер телефона: " + item.Phone);
                Console.WriteLine("Почта: " + item.Email);

                AddNewEmptyLine();
            }

            break;

        case CommandsType.ListCreatedOrders:
            var orders = orderService.GetListCreatedOrders();

            if (orders == null)
            {
                AddNewEmptyLine();
                Console.WriteLine("Список закзов не найден! Обратитесь за помощью к администратору!");
                break;
            }

            AddNewEmptyLine();
            System.Console.WriteLine("Count orders is " + orders.Count);
            AddNewEmptyLine();

            if (orders.Count == 0)
            {
                break;
            }

            foreach (var item in orders)
            {
                AddNewEmptyLine();
                System.Console.WriteLine(strBuilder);

                Console.WriteLine("ID заказа: " + item.Id);
                Console.WriteLine("Описания заказа: " + item.Description);
                Console.WriteLine("Цена: " + item.Price);
                Console.WriteLine("Тип доставки: " + item.DeliveryType);
                Console.WriteLine("Дата заказа: " + item.OrderDate?.ToString("yyyy-MM-dd"));
                Console.WriteLine("Адрес доставки: " + item.DeliveryAddress);
                Console.WriteLine("Статус заказа: " + item.OrderState);
                AddNewEmptyLine();
            }

            break;

        case CommandsType.GetClientByNameAndLastName:
            Console.WriteLine("Поиск пользователя по имени и фамилии: ");
            AddNewEmptyLine();

            Console.WriteLine("Введите имя клиента: ");
            var firstName = Console.ReadLine();

            while (!ClientValidator.IsValidFirstName(firstName))
            {
                AddNewEmptyLine();
                Console.WriteLine("Введите имя клиента: ");
                firstName = Console.ReadLine();
            }

            AddNewEmptyLine();
            Console.WriteLine("Введите фамилию клиента: ");
            var lastName = Console.ReadLine();

            while (!ClientValidator.IsValidLastName(lastName))
            {
                AddNewEmptyLine();
                Console.WriteLine("Введите фамилию клиента: ");
                lastName = Console.ReadLine();
            }

            var foundClients = clientService.GetClientByNameAndSurname(firstName, lastName);

            if (foundClients == null)
            {
                AddNewEmptyLine();
                Console.WriteLine("Вернулся пустой список! Обратитесь к адимистратору!");
                break;
            }

            AddNewEmptyLine();
            System.Console.WriteLine("Count found clients is " + foundClients.Count);
            AddNewEmptyLine();

            if (foundClients.Count == 0)
            {
                break;
            }

            foreach (var item in foundClients)
            {
                AddNewEmptyLine();
                System.Console.WriteLine(strBuilder);

                Console.WriteLine("ID клиента: " + item.Id);
                Console.WriteLine("Имя клиента: " + item.FirstName);
                Console.WriteLine("Фамилия клиента: " + item.LastName);
                Console.WriteLine("Отчество клиента: " + item.MiddleName);
                Console.WriteLine("Возраст клиента: " + item.Age);
                Console.WriteLine("Серия и номер паспорта клиента: " + item.PassportNumber);
                Console.WriteLine("Пол: " + item.Gender);
                Console.WriteLine("Номер телефона: " + item.Phone);
                Console.WriteLine("Почта: " + item.Email);

                AddNewEmptyLine();
            }

            break;

        case CommandsType.GetOrderByDescription:
            Console.WriteLine("Поиск заказа по описанию");
            AddNewEmptyLine();

            Console.WriteLine("Описания заказа: ");
            var description = Console.ReadLine();

            while (!OrderValidator.IsValidDescription(description))
            {
                AddNewEmptyLine();
                Console.WriteLine("Описания заказа: ");
                description = Console.ReadLine();
            }

            var foundOrders = orderService.GetOrderByDescription(description);

            if (foundOrders == null)
            {
                AddNewEmptyLine();
                Console.WriteLine("Вернулся пустой список! Обратитесь к адимистратору!");
                break;
            }

            AddNewEmptyLine();
            System.Console.WriteLine("Count found orders is " + foundOrders.Count);
            AddNewEmptyLine();

            if (foundOrders.Count == 0)
            {
                break;
            }

            foreach (var item in foundOrders)
            {
                AddNewEmptyLine();
                System.Console.WriteLine(strBuilder);

                Console.WriteLine("ID заказа: " + item.Id);
                Console.WriteLine("Описания заказа: " + item.Description);
                Console.WriteLine("Цена: " + item.Price);
                Console.WriteLine("Тип доставки: " + item.DeliveryType);
                Console.WriteLine("Дата заказа: " + item.OrderDate?.ToString("yyyy-MM-dd"));
                Console.WriteLine("Адрес доставки: " + item.DeliveryAddress);
                AddNewEmptyLine();

            }

            break;

        case CommandsType.GetOrderById:

            Console.WriteLine("Поиск заказа по ID");

            AddNewEmptyLine();
            Console.WriteLine("ID заказа: ");
            var idString = Console.ReadLine();

            int id;
            while (!OrderValidator.IsValidId(idString, out id))
            {
                AddNewEmptyLine();
                Console.WriteLine("Id заказа: ");
                idString = Console.ReadLine();
            }

            var foundOrder = orderService.GetOrderById(id);

            if (foundOrder == null)
            {
                AddNewEmptyLine();
                Console.WriteLine($"Заказ по данному ID - {id} не найден!");
                break;
            }

            Console.WriteLine(new StringBuilder().Append('-', 100));
            Console.WriteLine($"Заказ по ID - {id} найден!");
            AddNewEmptyLine();

            Console.WriteLine("ID заказа: " + foundOrder.Id);
            Console.WriteLine("Описания заказа: " + foundOrder.Description);
            Console.WriteLine("Цена: " + foundOrder.Price);
            Console.WriteLine("Тип доставки: " + foundOrder.DeliveryType);
            Console.WriteLine("Дата заказа: " + foundOrder.OrderDate?.ToString("yyyy-MM-dd"));
            Console.WriteLine("Адрес доставки: " + foundOrder.DeliveryAddress);

            break;

        case CommandsType.UpdateClientById:
            Console.WriteLine("Обновления пользователя по ID");

            AddNewEmptyLine();
            Console.WriteLine("ID клиента: ");
            var clientIdString = Console.ReadLine();

            int clientId;
            while (!ClientValidator.IsValidId(clientIdString, out clientId))
            {
                AddNewEmptyLine();
                Console.WriteLine("Id клиента: ");
                clientIdString = Console.ReadLine();
            }

            Console.WriteLine("Введите имя клиента: ");
            var clientFirstName = Console.ReadLine();

            while (!ClientValidator.IsValidFirstName(clientFirstName))
            {
                AddNewEmptyLine();
                Console.WriteLine("Введите имя клиента: ");
                clientFirstName = Console.ReadLine();
            }

            AddNewEmptyLine();
            Console.WriteLine("Введите фамилию клиента: ");
            var clientLastName = Console.ReadLine();

            while (!ClientValidator.IsValidLastName(clientLastName))
            {
                AddNewEmptyLine();
                Console.WriteLine("Введите фамилию клиента: ");
                clientLastName = Console.ReadLine();
            }

            bool isUpdatedClient = clientService.UpdateClientById(clientId, clientFirstName, clientLastName);

            if (!isUpdatedClient)
            {
                Console.WriteLine($"Клиент по ID {clientId} не был обновлен!");
                break;
            }

            Console.WriteLine($"Клиент успешно обновлен. ID клиента - {clientId}");
            break;

        case CommandsType.DeleteClient:
            Console.WriteLine("Удаления пользователя по ID");

            AddNewEmptyLine();
            Console.WriteLine("ID клиента: ");
            var clientIdForRemoveString = Console.ReadLine();

            int clientIdForRemove;
            while (!ClientValidator.IsValidId(clientIdForRemoveString, out clientIdForRemove))
            {
                AddNewEmptyLine();
                Console.WriteLine("Id клиента: ");
                clientIdForRemoveString = Console.ReadLine();
            }

            bool result = clientService.DeleteClient(clientIdForRemove);

            if (result == false)
            {
                Console.WriteLine($"Не получилось удалить клиента по ID {clientIdForRemove}!");
                break;
            }

            Console.WriteLine($"Клиент по ID {clientIdForRemove} успешно удален!");
            break;

        case CommandsType.UpdateOrderById:

            Console.WriteLine("Обновления заказа по ID");

            AddNewEmptyLine();
            Console.WriteLine("ID заказа: ");
            var idOrderString = Console.ReadLine();

            int orderId;
            while (!OrderValidator.IsValidId(idOrderString, out orderId))
            {
                AddNewEmptyLine();
                Console.WriteLine("Id заказа: ");
                idOrderString = Console.ReadLine();
            }

            Console.WriteLine("Описания заказа: ");
            var orderDescription = Console.ReadLine();

            while (!OrderValidator.IsValidDescription(orderDescription))
            {
                AddNewEmptyLine();
                Console.WriteLine("Описания заказа: ");
                orderDescription = Console.ReadLine();
            }

            bool isUpdatedOrder = orderService.UpdateOrderById(orderId, orderDescription);

            if (!isUpdatedOrder)
            {
                Console.WriteLine($"Не удалось обновить заказ по ID {orderId}");
                break;
            }

            Console.WriteLine($"Заказ был успешно обновлен! ID заказа - {orderId}");
            
            break;

        case CommandsType.DeleteOrder:
            Console.WriteLine("Удаления заказа по ID");

            AddNewEmptyLine();
            Console.WriteLine("ID заказа: ");
            var orderIdForRemoveString = Console.ReadLine();
            
            int orderIdForRemove;
            while (!OrderValidator.IsValidId(orderIdForRemoveString, out orderIdForRemove))
            {
                AddNewEmptyLine();
                Console.WriteLine("Id заказа: ");
                orderIdForRemoveString = Console.ReadLine();
            }

            var resultRemove = orderService.DeleteOrder(orderIdForRemove);

            if (resultRemove == false)
            {
                Console.WriteLine($"Не получилось удалить заказ по ID {orderIdForRemove}!");
                break;
            }

            Console.WriteLine($"Заказ по ID {orderIdForRemove} успешно удален!");
            break;

        case CommandsType.UpdateOrderStatus:

            Console.WriteLine("Обновления статуса заказа по ID");

            AddNewEmptyLine();
            Console.WriteLine("ID заказа: ");
            var idForUpdateStateString = Console.ReadLine();

            int idForUpdateState;
            while (!OrderValidator.IsValidId(idForUpdateStateString, out idForUpdateState))
            {
                AddNewEmptyLine();
                Console.WriteLine("Id заказа: ");
                idForUpdateStateString = Console.ReadLine();
            }

            AddNewEmptyLine();
            Console.WriteLine("Статус заказа: {1 - Pending} {2 - Approved} {3 - Cancelled} ");
            var orderStateString = Console.ReadLine();

            short orderStateNumber;
            while (!OrderValidator.IsValidOrderState(orderStateString, out orderStateNumber))
            {
                Console.WriteLine("Тип доставки: {1 - Pending} {2 - Approved} {3 - Cancelled} ");
                orderStateString = Console.ReadLine();
            }

            var orderState  = (OrderState)orderStateNumber;

            bool isUpdatedOrderState = orderService.UpdateOrderStateById(idForUpdateState,orderState);

            if (!isUpdatedOrderState)
            {
                Console.WriteLine($"Не удалось обновить статус заказ по ID {idForUpdateState}");
                break;
            }

            Console.WriteLine($"Статус заказ успешно обновлен! ID заказа - {idForUpdateState}");   

            break;
        default:
            Console.WriteLine("Неизвестная команда!");
            break;
    }

    AddNewEmptyLine();
    Console.WriteLine(strBuilder);
    Console.WriteLine(GetAvailableCommands());

    while (!int.TryParse(Console.ReadLine(), out commandNumber))
    {
        Console.WriteLine(GetAvailableCommands());
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

    Console.WriteLine("Укажите возраст клиента: ");
    var ageString = Console.ReadLine();

    short age;
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

    Console.WriteLine("Укажите пол клиента: {1 - М} {2 - Ж} ");
    var genderString = Console.ReadLine();

    short genderNumber;
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

    
    Console.WriteLine("Цена заказа: ");
    var priceString = Console.ReadLine();

    decimal price;
    while (!OrderValidator.IsValidPrice(priceString, out price))
    {
        Console.WriteLine("Цена заказа: ");
        priceString = Console.ReadLine();
    }

    Console.WriteLine("Укажите дату: {формат - гггг-ММ-дд} ");
    var dateString = Console.ReadLine();

    DateTime orderDate;
    while (!OrderValidator.IsValidDate(dateString, out orderDate))
    {
        Console.WriteLine("Укажите дату: {формат - гггг-мм-дд} ");
        dateString = Console.ReadLine();
    }

    Console.WriteLine("Тип доставки: {1 - Express} {2 - Standart} {3 - Free} ");
    var deliverTypeString = Console.ReadLine();

    short deliverTypeNumber;
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
        Description = description,
        Price = price,
        OrderDate = orderDate,
        DeliveryType = deliveryType,
        DeliveryAddress = deliveryAddress,
        OrderState = OrderState.Pending
    };

    var newOrder = orderService.CreateOrder(orderDto);

    return newOrder;
}

static string GetAvailableCommands()
{
    return @"Доступные команды:
    {1 - создать клинта}, 
    {2 - создать заказ},
    {3 - завершения программы}, 
    {4 - список ранее созданных клиентов}, 
    {5 - список ранее созданных заказов},
    {6 - поиск клиента по имени и фамилии},
    {7 - поиск заказа по описанию},
    {8 - поиск заказа по ID},
    {9 - обновить клиента по ID},
    {10 - удалить клиента},
    {11 - обновить заказ по ID},
    {12 - удалить заказ }'
    {13 - изменить статус заказа}";

}

static void AddNewEmptyLine()
{
    Console.WriteLine();
}
