using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4U_DAL_DATA.Utils
{
    internal class SqlStoredProcedures
    {
        //Stored procedures for users
        public static readonly string AddNewUser = "AddNewUser";
        public static readonly string DeleteUser = "DeleteUser";
        public static readonly string LoginUser = "LoginUser";
    }
}
