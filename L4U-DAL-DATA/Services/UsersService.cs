using L4U_BOL_MODEL.Models;
using L4U_DAL_DATA.Data;
using L4U_DAL_DATA.Utilities;
using System.Data;
using System.Data.SqlClient;

namespace L4U_DAL_DATA.Services
{
    public class UsersService
    {


        /// <summary>
        /// This method adds a User to the database
        /// </summary>
        /// <param name="user">User object</param>
        /// <param name="appPath">Application path</param>
        /// <returns>True if succeed, false otherwise</returns>
        public static async Task<string> AddNewUser(User user, string appPath)
        {

            SqlParameter p1 = new SqlParameter("@Name", SqlDbType.NVarChar, 100);
            SqlParameter p2 = new SqlParameter("@Email", SqlDbType.NVarChar, 50);
            SqlParameter p3 = new SqlParameter("@Username", SqlDbType.NVarChar, 50);
            SqlParameter p4 = new SqlParameter("@Password", SqlDbType.NVarChar, 250);

            p1.Value = user.Name ?? string.Empty;
            p2.Value = user.Email;
            p3.Value = user.Username;
            p4.Value = user.Password;

            string result = (string)await GeneralProcedureCall.CallStoredProcedure<User>(
                SqlEnumTypes.Insert,
                StoreProcedures.AddNewUser,
                appPath,
                parameters: new SqlParameter[] { p1, p2, p3, p4 });
            return result;
        }

            

    }
}
