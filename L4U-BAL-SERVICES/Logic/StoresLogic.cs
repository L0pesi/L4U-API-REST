using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using L4U_BOL_MODEL.Models;
using L4U_BOL_MODEL.Response;
using L4U_BOL_MODEL.Utilities;
using L4U_DAL_DATA.Services;
using L4U_DAL_DATA.Utilities;

namespace L4U_BAL_SERVICES.Logic
{
    public class StoresLogic
    {
       
        
        /// <summary>
        /// This method Gets information of all Stores
        /// </summary>
        /// <param name="connectString"></param>
        /// <returns></returns>
        public static async Task<ResponseFunction> GetAllStores(string connectString)
        {
            List<Store> pList = await StoresService.GetAllStores(connectString);
            //string result = await UsersService.AddNewUser(user, connectString);

            return BuildReponseFromList(pList);
        }




        /// <summary>
        /// This is a generic method to build the response object from a response list
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="list">List of generic object</param>
        /// <returns>Response object</returns>
        private static ResponseFunction BuildReponseFromList<T>(List<T> list)
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




        /// <summary>
        /// This method Adds a new store to the Database
        /// </summary>
        /// <param name="store"></param>
        /// <param name="connectString"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<ResponseFunction> AddNewStore(Store store, string connectString)
        {
            //string result = await UsersService.AddNewUser(user, connectString);
            if (!store.IsStoreValid()) throw new Exception("Propriedades não intanciadas");

            ResponseFunction response = new ResponseFunction();
            try
            {
                if (await StoresService.AddNewStore(store, connectString))
                {
                    response.StatusCode = StatusCodes.CREATED;
                    response.Message = SystemMessages.RecordAdded;
                    //response.Data = true;
                }
                else
                {
                    response.StatusCode = StatusCodes.INTERNALSERVERERROR;
                    response.Message = SystemMessages.ErrorMessage;
                }
            }
            catch (Exception e)
            {
                response.StatusCode = StatusCodes.BADREQUEST;
                //response.Message = SystemMessages.USEREXISTS;
                response.Message = e.Message ?? SystemMessages.BadRequestMessage;
                //response.Data = false;
                throw;
            }
            return response;
        }



        /// <summary>
        /// This method Updates a Store in the Database
        /// </summary>
        /// <param name="store"></param>
        /// <param name="connectString"></param>
        /// <returns></returns>
        public static async Task<ResponseFunction> UpdateStore(Store store, string connectString)
        {
            bool b = await StoresService.UpdateStore(store, connectString);

            if (b)
                return new ResponseFunction
                {
                    StatusCode = StatusCodes.SUCCESS,
                    Message = SystemMessages.RecordUpdated,
                    Data = b
                };
            return StandardResponse.Error();
        }
 


        /// <summary>
        /// This method is to Delete a Store from the Database
        /// </summary>
        /// <param name="store"></param>
        /// <param name="connectString"></param>
        /// <returns></returns>
        public static async Task<ResponseFunction> DeleteStore(Store store, string connectString)
        {
            bool b = await StoresService.DeleteStore(store, connectString);

            if (b)
                return new ResponseFunction
                {
                    StatusCode = StatusCodes.SUCCESS,
                    Message = SystemMessages.RecordDeleted,
                    Data = b
                };
            return StandardResponse.Error();
        }



        #region Material Estudo - Para implementação

        /*
        private readonly StoresService _storeService;

        public StoresLogic()
        {

            _storeService = new StoresService();

        }
        */

        #endregion



    }
}

