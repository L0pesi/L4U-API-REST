using L4U_BOL_MODEL.Models;
using L4U_BOL_MODEL.Response;
using L4U_DAL_DATA.Utilities;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Reflection.Metadata;
using Xceed.Wpf.Toolkit.Primitives;

namespace L4U_DAL_DATA.Services
{
    /// <summary>
    ///  The Data Acess Layer Class of Lockers
    /// </summary>
    public class LockersService
    {



        /// <summary>
        /// This Method Gets All Lockers in the Database
        /// </summary>
        /// <param name="connectString"></param>
        /// <returns></returns>
        public static async Task<List<Locker>> GetAllLockers(string connectString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    string GetAllLockers = "SELECT * FROM lockers";
                    using (SqlCommand cmd = new SqlCommand(GetAllLockers))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        // Execute the command and get the data
                        SqlDataReader reader = cmd.ExecuteReader();
                        List<Locker> lockers = new List<Locker>();
                        while (reader.Read())
                        {
                            Locker locker = new Locker();
                            locker.StoreId = reader.GetString(0);
                            locker.PinCode = reader.GetString(1);
                            locker.MasterCode = reader.GetString(2);
                            locker.LockerType = reader.GetString(3);
                            locker.LockerStatus = reader.GetBoolean(4);
                            locker.Id = reader.GetString(5);
                            locker.UserId = reader.GetString(6);
                            lockers.Add(locker);
                        }
                        return lockers;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// This is the method for ChooseLocker
        /// </summary>
        /// <param name="connectString"></param>
        /// <param name="userId"></param>
        /// <param name="email"></param>
        /// <param name="lockerId"></param>
        /// <returns></returns>
        /// <remarks>This method selects a locker by the userId and lockerId parameter and sets lockerStatus to 1 if is 0 
        /// and sends a email to the associated userId  email, with the following message:
        /// "Your PinCode for the locker {lockerId} is {pinCode}". This method for now only works with gmail
        /// emails. The lockerStatus 1 represent's when the locker ocupancy/lockerIsClose and 0 the locker 
        /// availabily/lockerIsOpen.</remarks>
        public static async Task<ResponseFunction> ChooseLocker(string connectString, string userId, string email, string lockerId)
        {
            int rowsAffected = 0;
            string pinCode = string.Empty;


            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string sql = "UPDATE lockers SET lockerStatus = 1, " +
                        " userId = @UserId " +
                        "WHERE id = @LockerId ";

                    SqlCommand command = new SqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@LockerId", lockerId);
                    command.Parameters.AddWithValue("@UserId", userId);

                    rowsAffected = command.ExecuteNonQuery();

                    command.Dispose();
                    if (rowsAffected.Equals(1))
                    {
                        //select from database

                        sql = "Select pinCode FROM lockers WHERE id = @LockerId ";
                        command = new SqlCommand(sql, conn);
                        command.Parameters.AddWithValue("@LockerId", lockerId);

                        pinCode = (string)command.ExecuteScalar();

                        // retrieve email from database
                        sql = "Select email FROM users WHERE id = @UserId ";
                        command = new SqlCommand(sql, conn);
                        command.Parameters.AddWithValue("@UserId", userId);
                        email = (string)command.ExecuteScalar();



                    }

                }

                if (rowsAffected.Equals(1) && !string.IsNullOrEmpty(pinCode) && !string.IsNullOrEmpty(email))
                {
                    //sends email with pincode
                    var smtpClient = EmailSender.GetSmtpClient();

                    string subject = "Locker PinCode";
                    string body = $"Your PinCode for locker {lockerId} is {pinCode}";

                    MailMessage mailMessage = new MailMessage();

                    mailMessage.From = new MailAddress("isitp2.2023@gmail.com");
                    mailMessage.To.Add(email);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;

                    smtpClient.Send(mailMessage);
                }

                return new ResponseFunction { StatusCode = L4U_BOL_MODEL.Utilities.StatusCodes.SUCCESS };

            }
            catch (Exception e)
            {

                throw;
            }

            //return new ResponseFunction { StatusCode = L4U_BOL_MODEL.Utilities.StatusCodes.SUCCESS };
        }




        /// <summary>
        /// This Method Adds a new Locker to the database
        /// </summary>
        /// <param name="locker"></param>
        /// <param name="connectString"></param>
        /// <returns></returns>
        public static async Task<bool> AddNewLocker(Locker locker, string connectString)
        {

            try
            {
                string pinCode = GenerateRandomPinCode();
                string masterCode = GenerateRandomPinCode();


                using (SqlConnection conn = new SqlConnection(connectString))
                {

                    string addLocker = "INSERT INTO lockers " +
                        "(storeid, pinCode, masterCode, lockerType) " + //Username, City) " +
                        "VALUES " +
                        "(@StoreId, @PinCode,@LockerType ,@LockerType)";

                    using (SqlCommand cmd = new SqlCommand(addLocker))
                    {

                        conn.Open();
                        cmd.Connection = conn;
                        cmd.Parameters.Add("@StoreId", SqlDbType.NVarChar).Value = locker.StoreId;
                        cmd.Parameters.Add("@PinCode", SqlDbType.NVarChar).Value = pinCode;
                        cmd.Parameters.Add("@Mastercode", SqlDbType.NVarChar).Value = masterCode;
                        cmd.Parameters.Add("@LockerType", SqlDbType.NVarChar).Value = locker.LockerType;

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




        /// <summary>
        /// Method to Generate a random Pincode
        /// </summary>
        /// <returns>The PinCode</returns>
        public static string GenerateRandomPinCode()
        {
            Random rnd = new Random();
            int pinCode = rnd.Next(1000, 9999); // generates a random PinCode of 4 digits
            return pinCode.ToString();
        }



        /// <summary>
        /// Method to Generate a random Mastercode
        /// </summary>
        /// <returns>The MasterCode</returns>
        public static string GenerateRandomMasterCode()
        {
            Random rnd = new Random();
            int masterCode = rnd.Next(1000, 9999); // generates a random MasterCode of 4 digits
            return masterCode.ToString();
        }




        /// <summary>
        /// This is the controller of the Method that changes the status of the locker
        /// </summary>
        /// <param name="locker"></param>
        /// <param name="connectString"></param>
        /// <returns></returns>
        public static async Task<bool> OpenLocker(Locker locker, string connectString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string sql = "UPDATE lockers SET lockerStatus = 0 " +
                        "WHERE storeId = @StoreId AND userId = @UserId " +
                        "AND (pinCode = @PinCode OR masterCode = @MasterCode)";

                    SqlCommand command = new SqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@StoreId", locker.StoreId);
                    command.Parameters.AddWithValue("@PinCode", locker.PinCode);
                    command.Parameters.AddWithValue("@MasterCode", locker.MasterCode);
                    command.Parameters.AddWithValue("@UserId", locker.UserId);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected.Equals(1);
                    /*
                    if (rowsAffected == 0)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Locker not found or invalid pin code");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    */
                }
            }
            catch (Exception)
            {
                return false;
            }
        }



        /// <summary>
        /// This Method Deletes a Locker in the Database
        /// </summary>
        /// <param name="locker"></param>
        /// <param name="connectString"></param>
        /// <returns></returns>
        public static async Task<bool> DeleteLocker(Locker locker, string connectString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    string updateLocker = "Delete from lockers where id = @Id";
                    using (SqlCommand cmd = new SqlCommand(updateLocker))
                    {

                        //cmd.CommandType = CommandType.Text;

                        cmd.Connection = conn;
                        cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = locker.Id;
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



        /// <summary>
        /// This method returns a list of lockers from a specific store id
        /// </summary>
        /// <param name="connectString"></param>
        /// <param name="storeLockerId"></param>
        /// <returns></returns>
        public static async Task<List<Locker>> GetAllLockersFromStore(string connectString, string storeLockerId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    string getLockers = "SELECT * FROM lockers WHERE storeId = @StoreId";
                    using (SqlCommand cmd = new SqlCommand(getLockers))
                    {
                        cmd.Connection = conn;
                        cmd.Parameters.AddWithValue("@StoreId", storeLockerId);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        List<Locker> lockers = new List<Locker>();
                        while (reader.Read())
                        {
                            Locker locker = new Locker();
                            locker.StoreId = reader.GetString(0);
                            locker.PinCode = reader.GetString(1);
                            locker.MasterCode = reader.GetString(2);
                            locker.LockerType = reader.GetString(3);
                            locker.LockerStatus = reader.GetBoolean(4);
                            locker.Id = reader.GetString(5);
                            locker.UserId = reader.GetString(6);
                            lockers.Add(locker);
                        }
                        return lockers;
                    }
                }
            }
            catch (Exception e)
            {
                // handle the exception here
                return null;
            }
        }


        #region Material Estudo - Para implementação

        /*

        /// <summary>
        /// This is the controller of the Method that gives information about the closure of the locker
        /// When it is close it's state is 1
        /// </summary>
        /// <param name="locker"></param>
        /// <param name="connectString"></param>
        /// <returns></returns>
        public static async Task<bool> CloseLocker(Locker locker, string connectString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string sql = "UPDATE lockers SET lockerStatus = 1 WHERE id = @id AND pinCode = @pinCode";

                    SqlCommand command = new SqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@id", locker.Id);
                    command.Parameters.AddWithValue("@pinCode", locker.PinCode);

                    int rowsAffected = command.ExecuteNonQuery();
                    conn.Close();
                    return rowsAffected.Equals(1);
                    
                }
            }
            catch (Exception)
            {
                return false;
            }
        }



        /// <summary>
        /// This Method Updates a locker in the Database
        /// </summary>
        /// <param name="locker"></param>
        /// <param name="connectString"></param>
        /// <returns></returns>
        public static async Task<bool> UpdateLocker(Locker locker, string connectString)
        {
            try

            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    string updateLocker = "UPDATE lockers SET pinCode = @PinCode, masterCode = @MasterCode ,lockerType = @lockerType WHERE id = @Id";
                    using (SqlCommand cmd = new SqlCommand(updateLocker))
                    {

                        //cmd.CommandType = CommandType.Text;

                        cmd.Connection = conn;
                        cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = locker.Id;
                        cmd.Parameters.Add("@PinCode", SqlDbType.NVarChar).Value = locker.PinCode;
                        cmd.Parameters.Add("@MasterCode", SqlDbType.NVarChar).Value = locker.MasterCode;
                        cmd.Parameters.Add("@LockerType", SqlDbType.NVarChar).Value = locker.LockerType;

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

        */


        #endregion




    }
}
