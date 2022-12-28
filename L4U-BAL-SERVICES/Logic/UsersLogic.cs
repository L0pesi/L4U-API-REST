using L4U_BOL_MODEL.Models;
using L4U_BOL_MODEL.Utilities;
using L4U_BOL_MODEL.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L4U_DAL_DATA.Services;


namespace L4U_BAL_SERVICES.Logic
{
    public class UsersLogic
    {


        /// <summary>
        /// This method adds a new User to the database
        /// </summary>
        /// <param name="User">User object</param>
        /// <param name="appPath">Application path</param>
        /// <returns>Response</returns>
        public static async Task<ResponseFunction> AddNewUser(User user, string appPath)
        {
           

            string result = await UsersService.AddNewUser(user, appPath);
                
            if (result.Equals(SystemMessages.CREATED))
                return new ResponseFunction
                {
                    StatusCode = StatusCodes.CREATED,
                    Message = SystemMessages.RecordAdded,
                    Data = true
                };
            if (result.Equals(SystemMessages.ALREADYEXISTS))
                return new ResponseFunction
                {
                    StatusCode = StatusCodes.BADREQUEST,
                    Message = SystemMessages.USEREXISTS,

                    Data = false
                };
            return StandardResponse.Error();
        }





        /// <summary>
        /// This method deletes a user on the database
        /// </summary>
        /// <param name="user">User object</param>
        /// <param name="appPath">Application path</param>
        /// <returns>Response</returns>
        public static async Task<ResponseFunction> DeleteUser(string uid, string appPath)
        {
            bool b = await UsersService.DeleteUser(uid, appPath);

            if (b)
                return new ResponseFunction()
                {
                    StatusCode = StatusCodes.SUCCESS,
                    Message = SystemMessages.RecordDeleted,
                    Data = b
                };
            return StandardResponse.Error();
        }

        /// <summary>
        /// This method performs login operation
        /// </summary>
        /// <param name="user">User object</param>
        /// <param name="appPath">Application path</param>
        /// <returns>Response</returns>
        /*public static async Task<ResponseFunction> LoginUser(UserRequestMin user, string appPath)
        {
            User authUser = await UsersService.LoginUser(user, appPath);

            if (string.IsNullOrEmpty(authUser.UserName))
                return new Response
                {
                    StatusCode = StatusCodes.BADREQUEST,
                    Message = CommonMessages.UserDontExist,
                    Data = null
                };

            if (user.Password.Equals(Criptography.Decrypt(authUser.Password)))  //checks pw
            {
                authUser.Password = "TOP SECRET";
                return new Response
                {
                    StatusCode = StatusCodes.SUCCESS,
                    Message = "Login com sucesso",
                    Data = authUser
                };
            }
            return new Response
            {
                StatusCode = StatusCodes.NOCONTENT,
                Message = CommonMessages.NoContentMessage,
                Data = null
            };
        }*/

    }
}
