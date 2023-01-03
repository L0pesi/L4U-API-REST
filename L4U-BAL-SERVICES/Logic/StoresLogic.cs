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

namespace L4U_BAL_SERVICES.Logic
{
    public class StoresLogic
    {
        private readonly StoresService _storeService;

        public StoresLogic()
        {

            _storeService = new StoresService();

        }

        public List<Store> GetAll
        {
            get
            {
                return _storeService.GetAllStores();
            }
        }



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

        public void UpdateStores(Store store)
        {
            _storeService.UpdateStore(store);
        }

        public void DeleteStore(Store store)
        {
            _storeService.DeleteStore(store);
        }
    }
}

