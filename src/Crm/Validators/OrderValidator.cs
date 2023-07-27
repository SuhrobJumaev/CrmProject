using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Validators
{
    public static class OrderValidator
    {
        public static bool IsValidDescription(string description)
        {
            if (string.IsNullOrEmpty(description) || string.IsNullOrWhiteSpace(description))
                return false;
            return true;
        }

        public static bool IsValidPrice(string priceString, out decimal price)
        {
            if(!decimal.TryParse(priceString, out price))
                return false;
            return true;
        }

        public static bool IsValidDate(string dateString, out DateTime date)
        {
            if (!DateTime.TryParse(dateString, out date))
                return false;
            return true;
        }

        public static bool IsValidDeliverType(string deliverTypeString, out short deliverTypeNumber)
        {
            deliverTypeNumber = 0;

            if (!deliverTypeString.Equals("1") & !deliverTypeString.Equals("2") & !deliverTypeString.Equals("3"))
                return false;

            if (!short.TryParse(deliverTypeString, out deliverTypeNumber))
                return false;

            return true;
        }

        public static bool IsValidDeliverAddress(string deliverAddress)
        {
            if (string.IsNullOrEmpty(deliverAddress) || string.IsNullOrWhiteSpace(deliverAddress))
                return false;
            return true;
        }

    }
}
