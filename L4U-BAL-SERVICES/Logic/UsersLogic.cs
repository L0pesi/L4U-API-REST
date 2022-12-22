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



    }
}
