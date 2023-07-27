using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Entities.Dtos
{
    public  readonly struct OrderDto
    {
        public   int Id { get; init; }
        public  string Description { get; init; }
        public  decimal Price { get; init; }
        public  DateTime OrderDate { get; init; }
        public  DeliveryType DeliveryType { get; init; }
        public  string DeliveryAddress { get; init; }
    }
}
