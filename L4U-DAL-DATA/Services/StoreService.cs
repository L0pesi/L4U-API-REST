using L4U_BOL_MODEL.Models;
using L4U_DAL_DATA.Data;
using L4U_DAL_DATA.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4U_DAL_DATA.Services
{
    public class StoreService
    {
        /// <summary>
        /// This method gets all Stores from the database
        /// </summary>
        /// <param name="appPath">Application path</param>
        /// <returns>List of Stores or null</returns>
        public static async Task<List<Stores>> GetAll(string appPath)
        {
            List<Stores> stores = (List<Stores>)await GeneralProcedureCall.CallStoredProcedure<Stores>(
                SqlEnumTypes.GetList,
                StoreProcedures.GetAllStores,
                appPath);

            return stores;
        }
    }
}
