using L4U_API_SOAP.SoapModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace L4U_API_SOAP.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Users" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Users.svc or Users.svc.cs at the Solution Explorer and start debugging.
    public class Users : IUsers
    {
        
        /// <summary>
        /// Listar todos os usuários
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {
            try
            {
                ResponseFunction response = new ResponseFunction();

                var list = db.Users.ToList();

                return list;

            }
            catch (Exception)
            {

                return null;
            }
        }


        //conexao sem uso dos Stored Procedures
        string connectString = "Server=l4u.database.windows.net;Database=L4U;User Id=supergrupoadmin;Password=supergrupo+2022";



        /// <summary>
        /// Add new User
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public bool AddNewUtilizador(User User)
        {

            if (User == null) return false; //checks if obj is null

            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    //conn.Open();
                    string addUser = "INSERT INTO Users (FirstName, LastName, Email, Username, City) VALUES (@FirstName,@LastName,@Email,@Username,@City)";
                    using (SqlCommand cmd = new SqlCommand(addUser))
                    {

                        //cmd.CommandType = CommandType.Text;

                        cmd.Connection = conn;
                        /*
                        cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", user.LastName);
                        cmd.Parameters.AddWithValue("@Email", user.Email);
                        cmd.Parameters.AddWithValue("@Password", user.Password);
                        */
                        cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = User.FirstName;
                        cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = User.LastName;
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = User.Email;
                        cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = User.Password;

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        return true;

                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }



        }





    }
}
