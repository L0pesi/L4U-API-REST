using L4U_BAL_SERVICES.Utils;
using L4U_BOL_MODEL.Models;
using L4U_DAL_DATA.Services;
using L4U_BOL_MODEL.Models.Request;
using L4U_BOL_MODEL.Models.Response;
using L4U_BOL_MODEL.Utils;


namespace L4U_BAL_SERVICES.Logic
{
    public class UsersLogic
    {
        /// <summary>
        /// This method adds a new productStore to the database
        /// </summary>
        /// <param name="prod">ProductStore object</param>
        /// <param name="appPath">Application path</param>
        /// <returns>Response</returns>
        public static async Task<Response> AddNewUser(User user, string appPath)
        {
            user.Password = Criptography.Encrypt(user.Password);

            string result = await UsersService.AddNewUser(user, appPath);

            if (result.Equals(CommonMessages.CREATED))
                return new Response
                {
                    StatusCode = StatusCodes.CREATED,
                    Message = CommonMessages.RecordAdded,
                    Data = true
                };
            if (result.Equals(CommonMessages.ALLREADYEXISTS))
                return new Response
                {
                    StatusCode = StatusCodes.BADREQUEST,
                    Message = CommonMessages.USEREXISTS,
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
        public static async Task<Response> DeleteUser(string uid, string appPath)
        {
            bool b = await UsersService.DeleteUser(uid, appPath);

            if (b)
                return new Response
                {
                    StatusCode = StatusCodes.SUCCESS,
                    Message = CommonMessages.RecordDeleted,
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
        public static async Task<Response> LoginUser(UserRequestMin user, string appPath)
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
        }
    }
}
