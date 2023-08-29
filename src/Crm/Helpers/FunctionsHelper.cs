namespace Crm.Helpers;

public static class FunctionsHelper
{
    public static string GetAvailableCommands()
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
        {12 - удалить заказ },
        {13 - изменить статус заказа},
        {14 - Общее количество созданных заказов},
        {15 - Oбщее количество созданных клиентов},
        {16 - Количество заказов по статусу}";

    }

    public static void AddNewEmptyLine()
    {
        Console.WriteLine();
    }

    public static string? GetStringOrderState(int stateNumeric)
    {
        switch (stateNumeric)
        {
            case 1:
                return "Pending";
            case 2:
                return "Approved";
            case 3:
                return "Cancelled";
            default:
                return null;
        }
    }

    public static string? GetStringDeliveryType(int deliverTypeNumeric)
    {
        switch (deliverTypeNumeric)
        {
            case 1:
                return "Express";
            case 2:
                return "Standart";
            case 3:
                return "Free";
            default:
                return null;
        }
    }

    public static string? GetStringClientGender(int genderNumeric)
    {
        switch (genderNumeric)
        {
            case 1:
                return "Male";
            case 2:
                return "Female";
            default:
                return null;
        }
    }
}
