using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4U_BOL_MODEL.Utils
{
    public enum StatusCodes
    {
        SUCCESS = 200,
        CREATED = 201,
        NOCONTENT = 204,
        BADREQUEST = 400,
        UNAUTHORIZED = 401,
        NOTFOUND = 404,
        INTERNALSERVERERROR = 500

    }
}
