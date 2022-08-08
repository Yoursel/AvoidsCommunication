using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvoidsCommunication.Domain.Enum
{
    public enum StatusCode
    {
        UserNotFound = 0,

        RamblingNotFound = 10,

        OK = 200,
        InternalServerError = 500

    }
}
