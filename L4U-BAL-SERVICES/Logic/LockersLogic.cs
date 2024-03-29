using L4U_BOL_MODEL.Models;
using L4U_BOL_MODEL.Response;
using L4U_BOL_MODEL.Utilities;
using L4U_DAL_DATA.Services;

namespace L4U_BAL_SERVICES.Logic
{
    /// <summary>
    /// The Business Acess Layer Class of Lockers
    /// </summary>
    public class LockersLogic
    {
        private readonly LockersService _lockerService;

        public LockersLogic()
        {
            _lockerService = new LockersService();
        }



        /// <summary>
        ///  This method adds a New Locker to the Database 
        /// </summary>
        /// <param name="locker"></param>
        /// <param name="connectString"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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



        /// <summary>
        /// This is the controller of the Method that changes the status of the locker
        /// </summary>
        /// <param name="locker"></param>
        /// <param name="connectString"></param>
        /// <returns></returns>
        public static async Task<ResponseFunction> OpenLocker(Locker locker, string connectString)
        {

            ResponseFunction response = new ResponseFunction();
            try
            {
                if (await LockersService.OpenLocker(locker, connectString))
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
        /// This method deletes a locker in the Database
        /// </summary>
        /// <param name="locker"></param>
        /// <param name="connectString"></param>
        /// <returns></returns>
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
        /// This is the method for ChooseLocker
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="userId"></param>
        /// <param name="email"></param>
        /// <param name="lockerId"></param>
        /// <returns></returns>
        /// <remarks>This method selects a locker by the userId and lockerId parameter and sets lockerStatus to 1 if is 0 
        /// and sends a email to the associated userId  email, with the following message:
        /// "Your PinCode for the locker {lockerId} is {pinCode}". This method for now only works with gmail
        /// emails. The lockerStatus 1 represent's when the locker ocupancy/lockerIsClose and 0 the locker 
        /// availabily/lockerIsOpen.</remarks>
        public static async Task<ResponseFunction> ChooseLocker(string connectionString, string userId,string email, string lockerId)
        {
            LockersService service = new LockersService();
            ResponseFunction response = await LockersService.ChooseLocker(connectionString, userId, email, lockerId);
            if (response.StatusCode == StatusCodes.SUCCESS)
            {
                return new ResponseFunction
                {
                    StatusCode = StatusCodes.SUCCESS,
                    Data = null
                };
            }
            else
            {
                return new ResponseFunction
                {
                    StatusCode = StatusCodes.NOCONTENT,
                    Data = null
                };
            }
        }



        /// <summary>
        /// This method retrieves all Lockers and based on the response, builds up the response
        /// </summary>
        /// <param name="connectString"></param>
        /// <returns></returns>
        public static async Task<ResponseFunction> GetAllLockers(string connectString)
        {
            List<Locker> pList = await LockersService.GetAllLockers(connectString);
            //string result = await UsersService.AddNewUser(user, connectString);

            return BuildReponseFromList(pList);
        }



        /// <summary>
        /// This method returns a list of lockers from a specific store id
        /// </summary>
        /// <param name="connectString"></param>
        /// <param name="storeLockerId"></param>
        /// <returns></returns>
        public static async Task<ResponseFunction> GetAllLockersFromStore(string connectString, string storeLockerId)
        {
            List<Locker> pList = await LockersService.GetAllLockersFromStore(connectString, storeLockerId);

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


        #region Material estudo - para implementação

        /*
       

        /// <summary>
        /// This is the controller of the Method that gives information about the closure of the locker
        /// When it is close it's state is 1 
        /// </summary>
        /// <param name="locker"></param>
        /// <param name="connectString"></param>
        /// <returns></returns>
        public static async Task<ResponseFunction> CloseLocker(Locker locker, string connectString)
        {

            ResponseFunction response = new ResponseFunction();
            try
            {
                if (await LockersService.CloseLocker(locker, connectString))
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
        /// This method updates a locker in the database
        /// </summary>
        /// <param name="locker"></param>
        /// <param name="connectString"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

        */


        #endregion


    }
}