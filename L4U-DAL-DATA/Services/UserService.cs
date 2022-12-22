using L4U_BOL_MODEL.Models;
using L4U_BOL_MODEL.Models.Request;
using L4U_DAL_DATA.Data;
using System.Data;
using System.Data.SqlClient;
using L4U_DAL_DATA.Utils;
using System.Threading.Tasks;

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
            SqlParameter p1 = new SqlParameter("@firstName", SqlDbType.NVarChar, 100);
            SqlParameter p2 = new SqlParameter("@lastName", SqlDbType.NVarChar, 50);
            SqlParameter p3 = new SqlParameter("@username", SqlDbType.NVarChar, 50);
            SqlParameter p4 = new SqlParameter("@userPassword", SqlDbType.NVarChar, 250);
            SqlParameter p5 = new SqlParameter("@email", SqlDbType.NVarChar, 250);
            SqlParameter p6 = new SqlParameter("@city", SqlDbType.NVarChar, 250);
            SqlParameter p7 = new SqlParameter("@id", SqlDbType.NVarChar, 50);

            p1.Value = user.FirstName ?? string.Empty;
            p2.Value = user.LastName;
            p3.Value = user.UserName;
            p4.Value = user.Password;
            p5.Value = user.Email;
            p6.Value = user.City;
            p7.Direction = ParameterDirection.Output;

            string result = (string)await GenericProcedureCall.CallStoredProcedure<User>(
                SqlRequestTypes.Insert,
                SqlStoredProcedures.AddNewUser,
                appPath,
                parameters: new SqlParameter[] { p1, p2, p3, p4, p5, p6, p7 });
            return result;
        }

        /// <summary>
        /// This method deletes a user on the database
        /// </summary>
        /// <param name="userUid">user's unique id</param>
        /// <param name="appPath">Application path</param>
        /// <returns>True if succeed, false otherwise</returns>
        public static async Task<bool> DeleteUser(string userUid, string appPath)
        {
            SqlParameter p1 = new SqlParameter("@Uid", SqlDbType.NVarChar, 50);
            p1.Value = userUid;
            bool result = (bool)await GenericProcedureCall.CallStoredProcedure<User>(
                SqlRequestTypes.Delete,
                SqlStoredProcedures.DeleteUser,
                appPath,
                parameters: new SqlParameter[] { p1 });

            return result;
        }

        /// <summary>
        /// This method checks username and password on the db, in order to perform login
        /// </summary>
        /// <param name="user">User's object</param>
        /// <param name="appPath">Application path</param>
        /// <returns>Authenticated user</returns>
        public static async Task<User> LoginUser(UserRequestMin user, string appPath)
        {
            SqlParameter p1 = new SqlParameter("@Username", SqlDbType.NVarChar, 50);
            SqlParameter p2 = new SqlParameter("@Team", SqlDbType.NVarChar, 50);
            p1.Value = user.Username;
            p2.Value = user.Team;
            User result = (User)await GenericProcedureCall.CallStoredProcedure<User>(
                SqlRequestTypes.GetSingle,
                SqlStoredProcedures.LoginUser,
                appPath,
                parameters: new SqlParameter[] { p1, p2 });

            return result;
        }
    }
}
