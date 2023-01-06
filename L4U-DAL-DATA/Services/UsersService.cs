using L4U_BOL_MODEL.Models;
using System.Data;
using System.Data.SqlClient;

namespace L4U_DAL_DATA.Services
{
    public class UsersService
    {

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
            catch (Exception)
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
            catch (Exception)
            {
                return false;
            }
        }
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
            catch (Exception)
            {
                return null;
            }
        }

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
            catch (Exception)
            {
                return false;
            }
        }

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
            catch (Exception)
            {
                return false;
            }
        }
    }
}
