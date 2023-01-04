using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using L4U_BOL_MODEL.Models;
using L4U_BOL_MODEL.Response;
using L4U_BOL_MODEL.Utilities;
using L4U_DAL_DATA.Services;
using Microsoft.Extensions.Logging;

namespace L4U_BAL_SERVICES.Logic
{
    public class LockersLogic
    {

        private readonly LockersService _lockerService;

        public LockersLogic()
        {

            _lockerService = new LockersService();

        }



        public static async Task<ResponseFunction> AddNewLocker(Locker locker, string connectString)
        {
            //string result = await UsersService.AddNewUser(user, connectString);
            if (!locker.IsLockerValid()) throw new Exception("Propriedades não intanciadas");

            ResponseFunction response = new ResponseFunction();
            try
            {
                if (await LockersService.AddNewLocker(locker, connectString))
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

        public static async Task<ResponseFunction> UpdateLocker(Locker locker, string connectString)
        {
            //string result = await UsersService.AddNewUser(user, connectString);
            if (!locker.IsLockerValid()) throw new Exception("Propriedades não intanciadas");

            ResponseFunction response = new ResponseFunction();
            try
            {
                if (await LockersService.UpdateLocker(locker, connectString))
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

        

        public static async Task<ResponseFunction> DeleteLocker(Locker locker, string connectString)
        {
            bool b = await LockersService.DeleteLocker(locker, connectString);

            if (b)
                return new ResponseFunction
                {
                    StatusCode = StatusCodes.SUCCESS,
                    Message = SystemMessages.RecordDeleted,
                    Data = b
                };
            return StandardResponse.Error();
        }

        /// <summary>
        /// This method calls the necessary service to get all productStore and based on the response, builds up the response
        /// </summary>
        /// <param name="appPath">Application path</param>
        /// <returns>List of products</returns>
        public static async Task<ResponseFunction> GetAllLockers(string connectString)
        {
            List<Locker> pList = await LockersService.GetAllLockers(connectString);
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

    }
}