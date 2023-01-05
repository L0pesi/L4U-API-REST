using L4U_BOL_MODEL.Models;
using System.Data;
using System.Data.SqlClient;


namespace L4U_DAL_DATA.Services
{
    public class LockersService
    {
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
                            locker.Id = reader.GetString(0);
                            locker.PinCode = reader.GetString(1);
                            locker.MasterCode = reader.GetString(2);
                            locker.LockerType = reader.GetString(3);
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

        public static async Task<bool> AddNewLocker(Locker locker, string connectString)
        {

            try
            {
                string pinCode = GenerateRandomPinCode();
                string masterCode = GenerateRandomPinCode();


                using (SqlConnection conn = new SqlConnection(connectString))
                {

                    string addLocker = "INSERT INTO lockers " +
                        "(pinCode, masterCode, lockerType) " + //Username, City) " +
                        "VALUES " +
                        "(@PinCode, @MasterCode, @LockerType, @IdStore)";
                    using (SqlCommand cmd = new SqlCommand(addLocker))
                    {

                        conn.Open();
                        cmd.Connection = conn;
                        cmd.Parameters.Add("@PinCode", SqlDbType.NVarChar).Value = pinCode;
                        cmd.Parameters.Add("@MasterCode", SqlDbType.NVarChar).Value = masterCode;
                        cmd.Parameters.Add("@LockerType", SqlDbType.NVarChar).Value = locker.LockerType;

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

        public static string GenerateRandomPinCode()
        {
            Random rnd = new Random();
            int pinCode = rnd.Next(1000, 9999); // generates a random PinCode of 4 digits
            return pinCode.ToString();
        }

        public static string GenerateRandomMasterCode()
        {
            Random rnd = new Random();
            int masterCode = rnd.Next(1000, 9999); // generates a random MasterCode of 4 digits
            return masterCode.ToString();
        }

        public static async Task<bool> OpenLocker(Locker locker, string connectString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string sql = "UPDATE lockers SET lockerStatus = 0 WHERE id = @id AND pinCode = @pinCode";

                    SqlCommand command = new SqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@id", locker.Id);
                    command.Parameters.AddWithValue("@pinCode", locker.PinCode);

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

        public static async Task<bool> DeleteLocker(Locker locker, string connectString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    string updateLocker = "Delete from lockers where id=@Id";
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
    }
}
