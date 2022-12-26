using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L4U_BOL_MODEL.Models;
using L4U_BOL_MODEL.Response;
using L4U_BOL_MODEL.Utilities;
using L4U_DAL_DATA.Services;

namespace L4U_BAL_SERVICES.Logic
{
    public class LockersLogic
    {

        /// <summary>
        /// This method calls the necessary service to get all Lockers and based on the response, builds up the response
        /// </summary>
        /// <param name="appPath">Application path</param>
        /// <returns>List of lockers</returns>
        public static async Task<ResponseFunction> GetAllLockers(string appPath)
        {
            //var lockers = new List<LockersLogic>();
            List<Locker> lockerList = await LockerService.GetAll(appPath);
            return BuildResponseFromList(lockerList);
        }




        /// <summary>
        /// GENÉRICO
        /// This is a generic method to build the response object from a response list
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="list">List of generic object</param>
        /// <returns>Response object</returns>
        private static ResponseFunction BuildResponseFromList<T>(List<T> list)
        {
            if (list.Equals(null))
                return new ResponseFunction
                {
                    StatusCode = StatusCodes.INTERNALSERVERERROR,
                    Message = "Ocorreu um erro inesperado",
                    Data = null
                };
            if (list.Count.Equals(0))
                return new ResponseFunction
                {
                    StatusCode = StatusCodes.NOCONTENT,
                    Message = "Não existem registos",
                    Data = null
                };
            return new ResponseFunction
            {
                StatusCode = StatusCodes.SUCCESS,
                Message = $"Foram obtidos {list.Count} resultados",
                Data = list
            };
        }


    }
}
