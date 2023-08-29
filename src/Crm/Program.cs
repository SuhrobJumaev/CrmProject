using System.Text;
using Crm.BusinessLogic;
using Crm.Enums;
using Crm.Helpers;
using Crm.Validators;

IClientService clientService = ClientServiceFactory.CreateClientService();
IOrderService orderService = OrderServiceFactory.CreateOrderService();
IStatisticsService statisticsService = StatisticsServiceFactory.CreateStatisticsService();

var strBuilder = new StringBuilder().Append('-', 100);

Console.WriteLine("Добро пожаловать в наш маленький CRM!");
Console.WriteLine("Выберите команду, которую вы хотите выполнить!");
Console.WriteLine(FunctionsHelper.GetAvailableCommands());

int commandNumber;

while (!int.TryParse(Console.ReadLine(), out commandNumber))
{
    Console.WriteLine(FunctionsHelper.GetAvailableCommands());
}

var command = (CommandsType)commandNumber;

while (command != CommandsType.Exit)
{
    switch (command)
    {
        case CommandsType.CreateClient:

            ClientDto? client = CreateClient();

            if (client == null)
            {
                FunctionsHelper.AddNewEmptyLine();
                Console.WriteLine("Клиент не был создан. Неизвестная ошибка, попробуйте снова!");
                break;
            }

            Console.WriteLine(strBuilder);
            Console.WriteLine("Клиент успешно создан");

            FunctionsHelper.AddNewEmptyLine();
            Console.WriteLine("ID клиента: " + client.Value.Id);
            Console.WriteLine("Имя клиента: " + client.Value.FirstName);
            Console.WriteLine("Фамилия клиента: " + client.Value.LastName);
            Console.WriteLine("Отчество клиента: " + client.Value.MiddleName);
            Console.WriteLine("Возраст клиента: " + client.Value.Age);
            Console.WriteLine("Серия и номер паспорта клиента: " + client.Value.PassportNumber);
            Console.WriteLine("Пол: " + client.Value.Gender);
            Console.WriteLine("Номер телефона: " + client.Value.Phone);
            Console.WriteLine("Почта: " + client.Value.Email);

            break;

        case CommandsType.CreateOrder:

            OrderDto? order = CreateOrder();

            if (order == null)
            {
                FunctionsHelper.AddNewEmptyLine();
                Console.WriteLine("Заказ не был создан. Неизвестная ошибка, попробуйте снова!");
                break;
            }

            Console.WriteLine(new StringBuilder().Append('-', 100));
            Console.WriteLine("Заказ успешно создан");
            FunctionsHelper.AddNewEmptyLine();

            Console.WriteLine("ID заказа: " + order.Value.Id);
            Console.WriteLine("Описания заказа: " + order.Value.Description);
            Console.WriteLine("Цена: " + order.Value.Price);
            Console.WriteLine("Тип доставки: " + FunctionsHelper.GetStringDeliveryType(order.Value.DeliveryType));
            Console.WriteLine("Дата заказа: " + order.Value.OrderDate?.ToString("yyyy-MM-dd"));
            Console.WriteLine("Адрес доставки: " + order.Value.DeliveryAddress);
            Console.WriteLine("Статус заказа: " + FunctionsHelper.GetStringOrderState(order.Value.OrderState));
            break;

        case CommandsType.ListCreatedClients:

            var clients = clientService.GetListAllCreatedClients();

            if (clients == null)
            {
                FunctionsHelper.AddNewEmptyLine();
                Console.WriteLine("Список клиентов не найден! Обратитесь за помощью к администратору!");
                break;
            }

            FunctionsHelper.AddNewEmptyLine();

            if (clients is null)
            {
                break;
            }

            foreach (var item in clients)
            {
                FunctionsHelper.AddNewEmptyLine();
                System.Console.WriteLine(strBuilder);

                Console.WriteLine("ID клиента: " + item.Id);
                Console.WriteLine("Имя клиента: " + item.FirstName);
                Console.WriteLine("Фамилия клиента: " + item.LastName);
                Console.WriteLine("Отчество клиента: " + item.MiddleName);
                Console.WriteLine("Возраст клиента: " + item.Age);
                Console.WriteLine("Серия и номер паспорта клиента: " + item.PassportNumber);
                Console.WriteLine("Пол: " + FunctionsHelper.GetStringClientGender(item.Gender));
                Console.WriteLine("Номер телефона: " + item.Phone);
                Console.WriteLine("Почта: " + item.Email);

                FunctionsHelper.AddNewEmptyLine();
            }

            break;

        case CommandsType.ListCreatedOrders:
            var orders = orderService.GetListCreatedOrders();

            if (orders == null)
            {
                FunctionsHelper.AddNewEmptyLine();
                Console.WriteLine("Список закзов не найден! Обратитесь за помощью к администратору!");
                break;
            }

            FunctionsHelper.AddNewEmptyLine();

            if (orders is null)
            {
                break;
            }

            foreach (var item in orders)
            {
                FunctionsHelper.AddNewEmptyLine();
                System.Console.WriteLine(strBuilder);

                Console.WriteLine("ID заказа: " + item.Id);
                Console.WriteLine("Описания заказа: " + item.Description);
                Console.WriteLine("Цена: " + item.Price);
                Console.WriteLine("Тип доставки: " + FunctionsHelper.GetStringDeliveryType(item.DeliveryType));
                Console.WriteLine("Дата заказа: " + item.OrderDate?.ToString("yyyy-MM-dd"));
                Console.WriteLine("Адрес доставки: " + item.DeliveryAddress);
                Console.WriteLine("Статус заказа: " + FunctionsHelper.GetStringOrderState(item.OrderState));
                FunctionsHelper.AddNewEmptyLine();
            }

            break;

        case CommandsType.GetClientByNameAndLastName:
            Console.WriteLine("Поиск пользователя по имени и фамилии: ");
            FunctionsHelper.AddNewEmptyLine();

            Console.WriteLine("Введите имя клиента: ");
            var firstName = Console.ReadLine();

            while (!ClientValidator.IsValidFirstName(firstName))
            {
                FunctionsHelper.AddNewEmptyLine();
                Console.WriteLine("Введите имя клиента: ");
                firstName = Console.ReadLine();
            }

            FunctionsHelper.AddNewEmptyLine();
            Console.WriteLine("Введите фамилию клиента: ");
            var lastName = Console.ReadLine();

            while (!ClientValidator.IsValidLastName(lastName))
            {
                FunctionsHelper.AddNewEmptyLine();
                Console.WriteLine("Введите фамилию клиента: ");
                lastName = Console.ReadLine();
            }

            var foundClients = clientService.GetClientByNameAndSurname(firstName, lastName);

            if (foundClients == null)
            {
                FunctionsHelper.AddNewEmptyLine();
                Console.WriteLine("Вернулся пустой список! Обратитесь к адимистратору!");
                break;
            }

            FunctionsHelper.AddNewEmptyLine();

            if (foundClients is null)
            {
                break;
            }

            foreach (var item in foundClients)
            {
                FunctionsHelper.AddNewEmptyLine();
                System.Console.WriteLine(strBuilder);

                Console.WriteLine("ID клиента: " + item.Id);
                Console.WriteLine("Имя клиента: " + item.FirstName);
                Console.WriteLine("Фамилия клиента: " + item.LastName);
                Console.WriteLine("Отчество клиента: " + item.MiddleName);
                Console.WriteLine("Возраст клиента: " + item.Age);
                Console.WriteLine("Серия и номер паспорта клиента: " + item.PassportNumber);
                Console.WriteLine("Пол: " + FunctionsHelper.GetStringClientGender(item.Gender));
                Console.WriteLine("Номер телефона: " + item.Phone);
                Console.WriteLine("Почта: " + item.Email);

                FunctionsHelper.AddNewEmptyLine();
            }

            break;

        case CommandsType.GetOrderByDescription:
            Console.WriteLine("Поиск заказа по описанию");
            FunctionsHelper.AddNewEmptyLine();

            Console.WriteLine("Описания заказа: ");
            var description = Console.ReadLine();

            while (!OrderValidator.IsValidDescription(description))
            {
                FunctionsHelper.AddNewEmptyLine();
                Console.WriteLine("Описания заказа: ");
                description = Console.ReadLine();
            }

            var foundOrders = orderService.GetOrderByDescription(description);

            if (foundOrders == null)
            {
                FunctionsHelper.AddNewEmptyLine();
                Console.WriteLine("Вернулся пустой список! Обратитесь к адимистратору!");
                break;
            }

            FunctionsHelper.AddNewEmptyLine();

            if (foundOrders is null)
            {
                break;
            }

            foreach (var item in foundOrders)
            {
                FunctionsHelper.AddNewEmptyLine();
                System.Console.WriteLine(strBuilder);

                Console.WriteLine("ID заказа: " + item.Id);
                Console.WriteLine("Описания заказа: " + item.Description);
                Console.WriteLine("Цена: " + item.Price);
                Console.WriteLine("Тип доставки: " + FunctionsHelper.GetStringDeliveryType(item.DeliveryType));
                Console.WriteLine("Дата заказа: " + item.OrderDate?.ToString("yyyy-MM-dd"));
                Console.WriteLine("Адрес доставки: " + item.DeliveryAddress);
                Console.WriteLine("Статус заказа: " + FunctionsHelper.GetStringOrderState(item.OrderState));
                FunctionsHelper.AddNewEmptyLine();
            }

            break;

        case CommandsType.GetOrderById:

            Console.WriteLine("Поиск заказа по ID");

            FunctionsHelper.AddNewEmptyLine();
            Console.WriteLine("ID заказа: ");
            var idString = Console.ReadLine();

            int id;
            while (!OrderValidator.IsValidId(idString, out id))
            {
                FunctionsHelper.AddNewEmptyLine();
                Console.WriteLine("Id заказа: ");
                idString = Console.ReadLine();
            }

            var foundOrder = orderService.GetOrderById(id);

            if (foundOrder == null)
            {
                FunctionsHelper.AddNewEmptyLine();
                Console.WriteLine($"Заказ по данному ID - {id} не найден!");
                break;
            }

            Console.WriteLine(new StringBuilder().Append('-', 100));
            Console.WriteLine($"Заказ по ID - {id} найден!");
            FunctionsHelper.AddNewEmptyLine();

            Console.WriteLine("ID заказа: " + foundOrder.Value.Id);
            Console.WriteLine("Описания заказа: " + foundOrder.Value.Description);
            Console.WriteLine("Цена: " + foundOrder.Value.Price);
            Console.WriteLine("Тип доставки: " + FunctionsHelper.GetStringDeliveryType(foundOrder.Value.DeliveryType));
            Console.WriteLine("Дата заказа: " + foundOrder.Value.OrderDate?.ToString("yyyy-MM-dd"));
            Console.WriteLine("Адрес доставки: " + foundOrder.Value.DeliveryAddress);
            Console.WriteLine("Статус заказа: " + FunctionsHelper.GetStringOrderState(foundOrder.Value.OrderState));

            break;

        case CommandsType.UpdateClientById:
            Console.WriteLine("Обновления пользователя по ID");

            FunctionsHelper.AddNewEmptyLine();
            Console.WriteLine("ID клиента: ");
            var clientIdString = Console.ReadLine();

            int clientId;
            while (!ClientValidator.IsValidId(clientIdString, out clientId))
            {
                FunctionsHelper.AddNewEmptyLine();
                Console.WriteLine("Id клиента: ");
                clientIdString = Console.ReadLine();
            }

            Console.WriteLine("Введите имя клиента: ");
            var clientFirstName = Console.ReadLine();

            while (!ClientValidator.IsValidFirstName(clientFirstName))
            {
                FunctionsHelper.AddNewEmptyLine();
                Console.WriteLine("Введите имя клиента: ");
                clientFirstName = Console.ReadLine();
            }

            FunctionsHelper.AddNewEmptyLine();
            Console.WriteLine("Введите фамилию клиента: ");
            var clientLastName = Console.ReadLine();

            while (!ClientValidator.IsValidLastName(clientLastName))
            {
                FunctionsHelper.AddNewEmptyLine();
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

            FunctionsHelper.AddNewEmptyLine();
            Console.WriteLine("ID клиента: ");
            var clientIdForRemoveString = Console.ReadLine();

            int clientIdForRemove;
            while (!ClientValidator.IsValidId(clientIdForRemoveString, out clientIdForRemove))
            {
                FunctionsHelper.AddNewEmptyLine();
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

            FunctionsHelper.AddNewEmptyLine();
            Console.WriteLine("ID заказа: ");
            var idOrderString = Console.ReadLine();

            int orderId;
            while (!OrderValidator.IsValidId(idOrderString, out orderId))
            {
                FunctionsHelper.AddNewEmptyLine();
                Console.WriteLine("Id заказа: ");
                idOrderString = Console.ReadLine();
            }

            Console.WriteLine("Описания заказа: ");
            var orderDescription = Console.ReadLine();

            while (!OrderValidator.IsValidDescription(orderDescription))
            {
                FunctionsHelper.AddNewEmptyLine();
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

            FunctionsHelper.AddNewEmptyLine();
            Console.WriteLine("ID заказа: ");
            var orderIdForRemoveString = Console.ReadLine();

            int orderIdForRemove;
            while (!OrderValidator.IsValidId(orderIdForRemoveString, out orderIdForRemove))
            {
                FunctionsHelper.AddNewEmptyLine();
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

            FunctionsHelper.AddNewEmptyLine();
            Console.WriteLine("ID заказа: ");
            var idForUpdateStateString = Console.ReadLine();

            int idForUpdateState;
            while (!OrderValidator.IsValidId(idForUpdateStateString, out idForUpdateState))
            {
                FunctionsHelper.AddNewEmptyLine();
                Console.WriteLine("Id заказа: ");
                idForUpdateStateString = Console.ReadLine();
            }

            FunctionsHelper.AddNewEmptyLine();
            Console.WriteLine("Статус заказа: {1 - Pending} {2 - Approved} {3 - Cancelled} ");
            var orderStateString = Console.ReadLine();

            short orderStateNumber;
            while (!OrderValidator.IsValidOrderState(orderStateString, out orderStateNumber))
            {
                Console.WriteLine("Тип доставки: {1 - Pending} {2 - Approved} {3 - Cancelled} ");
                orderStateString = Console.ReadLine();
            }

            bool isUpdatedOrderState = orderService.UpdateOrderStateById(idForUpdateState, orderStateNumber);

            if (!isUpdatedOrderState)
            {
                Console.WriteLine($"Не удалось обновить статус заказ по ID {idForUpdateState}");
                break;
            }

            Console.WriteLine($"Статус заказ успешно обновлен! ID заказа - {idForUpdateState}");

            break;

        case CommandsType.TotalCountOrder:

            int totalCountOrders = statisticsService.GetOrderCount();

            FunctionsHelper.AddNewEmptyLine();

            Console.WriteLine("Общее количество созданных заказов: " + totalCountOrders);

            break;

        case CommandsType.TotalCountClient:

            int totalCountClient = statisticsService.GetClientsCount();

            FunctionsHelper.AddNewEmptyLine();

            Console.WriteLine("Общее количество созданных клиентов: " + totalCountClient);

            break;

        case CommandsType.TotalCountOrderByState:

            FunctionsHelper.AddNewEmptyLine();

            Console.WriteLine("Статус заказа: {1 - Pending} {2 - Approved} {3 - Cancelled} ");
            var orderStateStringForStatistics = Console.ReadLine();

            short orderStateNumberForStatistics;
            while (!OrderValidator.IsValidOrderState(orderStateStringForStatistics, out orderStateNumberForStatistics))
            {
                Console.WriteLine("Тип доставки: {1 - Pending} {2 - Approved} {3 - Cancelled} ");
                orderStateStringForStatistics = Console.ReadLine();
            }

            int totalCountOrderByState = statisticsService.GetOrderCountByState(orderStateNumberForStatistics);

            FunctionsHelper.AddNewEmptyLine();

            Console.WriteLine($"Общее количество заказов: {totalCountOrderByState} со статусом: {FunctionsHelper.GetStringOrderState(orderStateNumberForStatistics)}");

            break;
        default:
            Console.WriteLine("Неизвестная команда!");
            break;
    }

    FunctionsHelper.AddNewEmptyLine();
    Console.WriteLine(strBuilder);
    Console.WriteLine(FunctionsHelper.GetAvailableCommands());

    while (!int.TryParse(Console.ReadLine(), out commandNumber))
    {
        Console.WriteLine(FunctionsHelper.GetAvailableCommands());
    }

    command = (CommandsType)commandNumber;
}

ClientDto? CreateClient()
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

    var clientDto = new ClientDto()
    {
        FirstName = firstName,
        LastName = lastName,
        MiddleName = middleName,
        Age = age,
        PassportNumber = passportNumber,
        Gender = genderNumber,
        Phone = phone,
        Email = email,
        Password = password
    };

    ClientDto? newClient = clientService.CreateClient(clientDto);
    return newClient;
}

OrderDto? CreateOrder()
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
        DeliveryType = deliverTypeNumber,
        DeliveryAddress = deliveryAddress,
    };

    var newOrder = orderService.CreateOrder(orderDto);

    return newOrder;
}

