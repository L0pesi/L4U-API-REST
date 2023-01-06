using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4U_DAL_DATA.Utilities
{

    /// <summary>
    /// Library for StoreProcedures
    /// </summary>
    public class StoreProcedures
    {
        //Stored procedures for users
        public static readonly string AddNewUser = "AddNewUser";
        public static readonly string DeleteUser = "DeleteUser";
        public static readonly string LoginUser = "LoginUser";

        //Stored procedures for Lockers
        public static readonly string AddLocker = "AddLocker";
        public static readonly string GetLocker = "GetLocker";
        public static readonly string GetAllLockers = "GetAllLockers";
        public static readonly string UpdateLocker = "UpdateLocker";
        public static readonly string DeleteLocker = "DeleteLocker";

        //Stored procedures for Lockers
        public static readonly string AddStore = "AddStore";
        public static readonly string GetStore = "GetStore";
        public static readonly string GetAllStores = "GetAllStores";
        public static readonly string UpdateStore = "UpdateStore";
        public static readonly string DeleteStore = "DeleteStore";
    }
}
