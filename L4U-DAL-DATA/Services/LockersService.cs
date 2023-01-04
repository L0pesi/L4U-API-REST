using L4U_BOL_MODEL.Models;
using L4U_DAL_DATA.Data;
using L4U_DAL_DATA.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace L4U_DAL_DATA.Services
{
    public class LockersService
    {
        //conexao
        string conexao = "Server=l4u.database.windows.net;Database=L4U;User Id=supergrupoadmin;Password=supergrupo+2022;";

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
