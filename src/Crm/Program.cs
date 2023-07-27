using Crm.Serices;
using Crm.Entities;
using Crm.Validators;
using System.Text;

ClientService clientService = new ClientService();
OrderService orderService = new OrderService();


Console.WriteLine("Добро пожаловать в наш маленький CRM!");
Console.WriteLine("Выберите команду, которую вы хотите выполнить!");
Console.WriteLine("Доступные команды: {1 - создать клинта}, {2 - создать заказ}, {3 - завершения программы}");

int commandNumber;

while(!int.TryParse(Console.ReadLine(), out commandNumber))
{
    Console.WriteLine("Доступные команды: {1 - создать клинта}, {2 - создать заказ},{3 - завершения программы}");
}

CommandsType command = (CommandsType)commandNumber;

while (command != CommandsType.Exit)
{

    switch (command)
    {
        case CommandsType.CreateClient:
          
            Client client = CreateClient();
            
            if (client == null)
            {
                Console.WriteLine("Клиент не был создан. Неизвестная ошибка, попробуйте снова!");
                break;
            }
                
            Console.WriteLine(new StringBuilder().Append('-', 100));
            Console.WriteLine("Клиент успешно создан");
            Console.WriteLine("Имя клиента: "+ client.FirstName);
            Console.WriteLine("Фамилия клиента: "+ client.LastName);
            Console.WriteLine("Отчество клиента: "+ client.MiddleName);
            Console.WriteLine("Возраст клиента: "+ client.Age);
            Console.WriteLine("Серия и номер паспорта клиента: "+ client.PassportNumber);
            Console.WriteLine("Пол: "+ client.Gender);

            break;

        case CommandsType.CreateOrder:
            
            Order order = CreateOrder();

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
            Console.WriteLine("Дата заказа: " + order.OrderDate.ToString("yyyy-MM-dd"));
            Console.WriteLine("Адрес доставки: " + order.DeliveryAddress);
            


            break;
        default:
            Console.WriteLine("Неизвестная команда!");
            break;
    }

    Console.WriteLine(new StringBuilder().Append('-', 100));
    Console.WriteLine("Доступные команды: {1 - создать клинта}, {2 - создать заказ},{3 - завершения программы}");
    
    while (!int.TryParse(Console.ReadLine(), out commandNumber))
    {
        Console.WriteLine("Доступные команды: {1 - создать клинта}, {2 - создать заказ},{3 - завершения программы}");
    }

    command = (CommandsType)commandNumber;
}
    



Client CreateClient() 
{
    Console.WriteLine("Введите имя клиента: ");
    string firstName = Console.ReadLine();

    while (!ClientValidator.IsValidFirstName(firstName))
    {
        Console.WriteLine("Введите имя клиента: ");
        firstName = Console.ReadLine();
    }

    Console.WriteLine("Введите фамилию клиента: ");
    string lastName = Console.ReadLine();

    while (!ClientValidator.IsValidLastName(lastName))
    {
        Console.WriteLine("Введите фамилию клиента: ");
        lastName = Console.ReadLine();
    }

    Console.WriteLine("Введите отчества клиента: {НЕОБЯЗАТЕЛЬНОЕ ПОЛЕ} ");
    string? middleName = Console.ReadLine();

    short age;
    Console.WriteLine("Укажите возраст клиента: ");
    string ageString = Console.ReadLine();

    while (!ClientValidator.IsValidAge(ageString, out age))
    {
        Console.WriteLine("Укажите возраст клиента: ");
        ageString = Console.ReadLine();
    }

    Console.WriteLine("Укажите номер и серию паспорта клиента: ");
    string passportNumber = Console.ReadLine();

    while (!ClientValidator.IsValidPassportId(passportNumber))
    {
        Console.WriteLine("Укажите номер и серию паспорта клиента: ");
        passportNumber = Console.ReadLine();
    }

    short genderNumber;
    Console.WriteLine("Укажите пол клиента: {1 - М} {2 - Ж} ");
    string genderString = Console.ReadLine();

    while(!ClientValidator.IsValidGender(genderString, out genderNumber))
    {
        Console.WriteLine("Укажите пол клиента: {1 - М} {2 - Ж} ");
         genderString = Console.ReadLine();
    }

    Gender gender = (Gender)genderNumber;

    ClientDto clientDto = new ClientDto()
    {
        FirstName = firstName,
        LastName = lastName,
        MiddleName = middleName,
        Age = age,
        PassportNumber = passportNumber,
        Gender = gender
    };

   Client newClient = clientService.CreateClient(clientDto);

    return newClient;
}

Order CreateOrder()
{
    Console.WriteLine("Описания заказа: ");
    string description = Console.ReadLine();

    while (!OrderValidator.IsValidDescription(description))
    {
        Console.WriteLine("Описания заказа: ");
        description = Console.ReadLine();
    }

    decimal price;
    Console.WriteLine("Цена заказа: ");
    string priceString  = Console.ReadLine();

    while(!OrderValidator.IsValidPrice(priceString, out price))
    {
        Console.WriteLine("Цена заказа: ");
        priceString = Console.ReadLine();
    }

    DateTime orderDate;
    Console.WriteLine("Укажите дату: {формат - гггг-ММ-дд} ");
    string dateString = Console.ReadLine();

    while (!OrderValidator.IsValidDate(dateString, out orderDate))
    {
        Console.WriteLine("Укажите дату: {формат - гггг-мм-дд} ");
        dateString = Console.ReadLine();
    }

    short deliverTypeNumber;
    Console.WriteLine("Тип доставки: {1 - Express} {2 - Standart} {3 - Free} ");
    string deliverTypeString = Console.ReadLine();

    while (!OrderValidator.IsValidDeliverType(deliverTypeString, out deliverTypeNumber))
    {
        Console.WriteLine("Тип доставки: {1 - Express} {2 - Standart} {3 - Free} ");
        deliverTypeString = Console.ReadLine();
    }

    DeliveryType deliveryType = (DeliveryType)deliverTypeNumber;

    Console.WriteLine("Адрес доставки: ");
    string deliveryAddress = Console.ReadLine();

    while (!OrderValidator.IsValidDeliverAddress(deliveryAddress))
    {
        Console.WriteLine("Адрес доставки: ");
        deliveryAddress = Console.ReadLine();
    }


    Order newOrder = orderService.CreateOrder(
        1, //Обычно Id генерируется в таблице, в БД, если конечно это не GUID
        description,
        price,
        orderDate,
        deliveryType,
        deliveryAddress
    );

    return newOrder;
}
