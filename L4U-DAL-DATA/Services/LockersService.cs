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
                    //get da store-> cacifos criados nessa loja
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
            catch (Exception e)
            {
                return null;
            }
        }

        public static async Task<bool> AddNewLocker(Locker locker, string connectString)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {

                    string addLocker = "INSERT INTO lockers " +
                        "(pinCode, masterCode, lockerType) " + //Username, City) " +
                        "VALUES " +
                        "(@PinCode, @MasterCode, @LockerType)";
                    using (SqlCommand cmd = new SqlCommand(addLocker))
                    {


                        cmd.Connection = conn;
                        cmd.Parameters.Add("@PinCode", SqlDbType.NVarChar).Value = locker.PinCode;
                        cmd.Parameters.Add("@MasterCode", SqlDbType.NVarChar).Value = locker.MasterCode;
                        cmd.Parameters.Add("@LockerType", SqlDbType.NVarChar).Value = locker.LockerType;
                        //parametro id(store) (9dkjaslkdasjdklç)

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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
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
            catch (Exception e)
            {
                return false;
            }
        }

        /*public void AddLocker(Locker locker)
        {
            List<Locker> lockers = new List<Locker>();

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO lockers (pinCode, masterCode, lockerType) VALUES (@PinCode, @MasterCode, @LockerType)", conn))

                //using (SqlCommand cmd = new SqlCommand("INSERT INTO lockers (idClient, pinCode, masterCode, lockerType, idStore) VALUES (@IdClient, @PinCode, @MasterCode, @LockerType,@IdStore)", conn))
                {

                    cmd.CommandType = CommandType.Text;
                    //cmd.Parameters.AddWithValue("@IdClient", locker.IdClient);
                    cmd.Parameters.AddWithValue("@PinCode", locker.PinCode);
                    cmd.Parameters.AddWithValue("@MasterCode", locker.MasterCode);
                    cmd.Parameters.AddWithValue("@LockerType", locker.LockerType);
                    //cmd.Parameters.AddWithValue("@IdStore", locker.IdStore);

                    cmd.ExecuteNonQuery();

                }
            }

        }*/


    }
}
