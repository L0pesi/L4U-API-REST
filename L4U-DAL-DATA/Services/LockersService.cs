using L4U_BOL_MODEL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4U_DAL_DATA.Services
{
    public class LockerService
    {
        //conexao
        string conexao = "Server=l4u.database.windows.net;Database=L4U;User Id=supergrupoadmin;Password=supergrupo+2022;";

        public List<Locker> GetLockers()
        {
            List<Locker> lockers = new List<Locker>();

            using (SqlConnection conn = new SqlConnection(conexao))
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



        public void AddLocker(Locker locker)
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




        }


    }
}
