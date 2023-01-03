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
    public class LockersLogic
    {

        private readonly LockersService _lockerService;

        public LockersLogic()
        {

            _lockerService = new LockersService();

        }

        public List<Locker> GetLockers
        {
            get
            {
                return _lockerService.GetLockers();
            }
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
    }
}