using L4U_BOL_MODEL.Models;
using System.Data;
using System.Data.SqlClient;

namespace L4U_DAL_DATA.Services
{
    public class UsersService
    {


        /// <summary>
        /// This Method gets all users from the database
        /// </summary>
        /// <param name="connectString"></param>
        /// <returns></returns>
        public static async Task<List<User>> GetAllUsers(string connectString)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectString);

                string updateLocker = "SELECT * FROM users";
                SqlCommand cmd = new SqlCommand(updateLocker);


                cmd.Connection = conn;
                conn.Open();
                // Execute the command and get the data
                SqlDataReader reader = cmd.ExecuteReader();
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    User user = new User();
                    user.Id = reader.GetString(0);
                    user.FirstName = reader.GetString(1);
                    user.LastName = reader.GetString(2);
                    user.Email = reader.GetString(3);
                    user.Password = reader.GetString(4);
                    users.Add(user);
                }

                return users;

            }
            catch (Exception e)
            {
                return null;
            }
        }




        /// <summary>
        /// This method adds a User to the database
        /// </summary>
        /// <param name="user">User object</param>
        /// <returns>True if succeed, false otherwise</returns>
        public static async Task<bool> AddNewUser(User user, string connectString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    //conn.Open();
                    string addUser = "INSERT INTO Users " +
                        "(FirstName, LastName, Email, Password) " + //Username, City) " +
                        "VALUES " +
                        "(@FirstName,@LastName,@Email,@Password)";
                    using (SqlCommand cmd = new SqlCommand(addUser))
                    {

                        cmd.Connection = conn;

                        cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = user.FirstName;
                        cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = user.LastName;
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = user.Email;
                        cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = user.Password;

                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        conn.Close();
                        return result.Equals(1);

                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }



        /// <summary>
        /// This method Authenticates a User on the Database
        /// </summary>
        /// <param name="user"></param>
        /// <param name="connectString"></param>
        /// <returns></returns>
        public static async Task<User> Authenticate(UserAuth user, string connectString)
        {
            User authUser = new User();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {

                    string addUser = " SELECT * FROM users  " +
                                     " WHERE " +
                                     " email = @Email AND[password] = @Pass " +
                                     " AND isActive = 1";
                    using (SqlCommand cmd = new SqlCommand(addUser))
                    {
                        conn.Open(); //this
                        //user.Password = Criptography.Encrypt(user.Password);
                        cmd.CommandTimeout = 120;

                        cmd.Connection = conn;

                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = user.Email;
                        cmd.Parameters.Add("@Pass", SqlDbType.NVarChar, 50).Value = user.Password;

                        var x = cmd.ExecuteScalar();

                        //conn.Open();
                        authUser = new User(x);
                        //Console.WriteLine(cmd.ExecuteScalarAsync());
                        //MessageBox.Show(x.GetType());
                        var y = x.GetType();
                        conn.Close();
                        return authUser;

                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }



        /// <summary>
        /// This method Updates info of a user on de Database
        /// </summary>
        /// <param name="user"></param>
        /// <param name="connectString"></param>
        /// <returns></returns>
        public static async Task<bool> UpdateUser(User user, string connectString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    string updateUser = "UPDATE users SET firstName = @FirstName, lastName = @LastName ,email = @Email, password = @Password WHERE id = @Id";
                    using (SqlCommand cmd = new SqlCommand(updateUser))
                    {

                        //cmd.CommandType = CommandType.Text;

                        cmd.Connection = conn;
                        cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = user.Id;
                        cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = user.FirstName;
                        cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = user.LastName;
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = user.Email;
                        cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = user.Password;

                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        conn.Close();
                        return result.Equals(1);

                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }



        /// <summary>
        /// This method Deletes a User on the Database
        /// </summary>
        /// <param name="user"></param>
        /// <param name="connectString"></param>
        /// <returns></returns>
        public static async Task<bool> DeleteUser(User user, string connectString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    string deleteUser = "Delete from users where id=@Id";
                    using (SqlCommand cmd = new SqlCommand(deleteUser))
                    {

                        //cmd.CommandType = CommandType.Text;

                        cmd.Connection = conn;
                        cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = user.Id;
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        conn.Close();
                        return result.Equals(1);

                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }



        #region Material estudo - para implementação

        /*
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
                    cmd.Parameters.AddWithValue("@Id", user.Id);
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
       
            

        #endregion

        */

        #endregion


    }
}
