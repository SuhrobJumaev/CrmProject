using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Entities
{
    public enum CommandsType : short
    {
        CreateClient = 1,
        CreateOrder = 2,
        Exit = 3,
    }
}
