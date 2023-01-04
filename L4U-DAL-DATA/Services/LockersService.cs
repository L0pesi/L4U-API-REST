using L4U_BOL_MODEL.Models;
using System.Data;
using System.Data.SqlClient;

namespace L4U_DAL_DATA.Services
{
    public class LockersService
    {
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



        public static async Task<bool> AddNewLocker(Locker locker, string connectString)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    //conn.Open();
                    string addLocker = "INSERT INTO lockers " +
                        "(pinCode, masterCode, lockerType) " + //Username, City) " +
                        "VALUES " +
                        "(@PinCode, @MasterCode, @LockerType)";
                    using (SqlCommand cmd = new SqlCommand(addLocker))
                    {

                        //cmd.CommandType = CommandType.Text;

                        cmd.Connection = conn;
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


        
        public List<Locker> GetLockers()
        {
            List<Locker> lockers = new List<Locker>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM lockers", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var locker = new Locker();
                                //locker.IdClient = reader["idClient"].ToString();
                                locker.PinCode = reader["pinCode"].ToString();
                                locker.MasterCode = reader["masterCode"].ToString();
                                locker.LockerType = reader["lockerType"].ToString();
                                //locker.IdStore = reader["idStore"].ToString();

                                lockers.Add(locker);
                            }
                        }
                    }

                }
            }

            return lockers;
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
