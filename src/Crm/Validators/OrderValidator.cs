// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

namespace Crm.Validators;

public static class OrderValidator
{
    public static bool IsValidDescription(string? description)
    {
        if (string.IsNullOrEmpty(description) || string.IsNullOrWhiteSpace(description))
        {
            return false;
        }

        return true;
    }

    public static bool IsValidPrice(string? priceString, out decimal price)
    {
        if (!decimal.TryParse(priceString, out price))
        {
            return false;
        }

        return true;
    }

    public static bool IsValidId(string? idString, out int id)
    {
        if (!int.TryParse(idString, out id))
        {
            return false;
        }

        return true;
    }

    public static bool IsValidDate(string? dateString, out DateTime date)
    {
        if (!DateTime.TryParse(dateString, out date))
        {
            return false;
        }

        return true;
    }

    public static bool IsValidDeliverType(string? deliverTypeString, out short deliverTypeNumber)
    {
        if (!short.TryParse(deliverTypeString, out deliverTypeNumber))
        {
            return false;
        }

        if (!deliverTypeString.Equals("1") & !deliverTypeString.Equals("2") & !deliverTypeString.Equals("3"))
        {
            return false;
        }

        return true;
    }

    public static bool IsValidOrderState(string? orderStateString, out short orderStateNumber)
    {
        if (!short.TryParse(orderStateString, out orderStateNumber))
        {
            return false;
        }

        if (!orderStateString.Equals("1") & !orderStateString.Equals("2") & !orderStateString.Equals("3"))
        {
            return false;
        }

        return true;
    }

    public static bool IsValidDeliverAddress(string deliverAddress)
    {
        if (string.IsNullOrEmpty(deliverAddress) || string.IsNullOrWhiteSpace(deliverAddress))
        {
            return false;
        }

        return true;
    }
}
