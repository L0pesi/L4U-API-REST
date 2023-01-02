using L4U_BOL_MODEL.Models;
using System.Data;
using System.Data.SqlClient;

namespace L4U_DAL_DATA.Services
{
    public class UsersService
    {

        //conexao sem uso dos Stored Procedures
        string connect = "Server=l4u.database.windows.net;Database=L4U;User Id=supergrupoadmin;Password=supergrupo+2022";



        /// <summary>
        /// This method adds a User to the database
        /// </summary>
        /// <param name="user">User object</param>
        /// <returns>True if succeed, false otherwise</returns>
        public void AddNewUser(User user)
        {

            List<User> users = new List<User>();

            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Users (FirstName, LastName, Email, Username, City) VALUES (@FirstName,@LastName,@Email,@Username,@City)", conn))
                {

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Username", user.UserName);
                    cmd.Parameters.AddWithValue("@City", user.City);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void UpdateUser(User user)
        {
            List<User> users = new List<User>();

            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                //using (SqlCommand cmd = new SqlCommand("UPDATE users SET id = @Id, firstName = @FirstName,  lastName = @LastName , email = @Email, password = @Password", conn))
                using (SqlCommand cmd = new SqlCommand("UPDATE users SET firstName = @FirstName, lastName = @LastName , email = @Email, password = @Password WHERE id = @Id", conn))

                {

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Id",user.Id);
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        /// <summary>
        /// Lista todos os utilizadores
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Users", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var user = new User();
                                user.FirstName = reader["FirstName"].ToString();
                                user.LastName = reader["LastName"].ToString();
                                user.Email = reader["Email"].ToString();
                                user.UserName = reader["Username"].ToString();
                                user.City = reader["City"].ToString();

                                users.Add(user);
                            }
                        }
                    }

                }
            }

            return users;
        }






        #region Versão com STORED PROCEDURES

        /*

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

            string result = (string)await GeneralProcedureCall.CallStoredProcedure<User>(
                SqlEnumTypes.Insert,
                StoreProcedures.AddNewUser,
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
            bool result = (bool)await GeneralProcedureCall.CallStoredProcedure<User>(
                SqlEnumTypes.Delete,
                StoreProcedures.DeleteUser,
                appPath,
                parameters: new SqlParameter[] { p1 });

            return result;

        }
       
            */

        #endregion



    }
}
