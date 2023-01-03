using L4U_BOL_MODEL.Models;
using System.Data;
using System.Data.SqlClient;

namespace L4U_DAL_DATA.Services
{
    public class StoresService
    {
        //conexao
        string conexao = "Server=l4u.database.windows.net;Database=L4U;User Id=supergrupoadmin;Password=supergrupo+2022;";

        public List<Store> GetAllStores()
        {
            List<Store> stores = new List<Store>();

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM stores", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                var store = new Store();
                                store.Address = reader["address"].ToString();
                                store.City = reader["city"].ToString();
                                store.District = reader["district"].ToString();
                                store.Name = reader["name"].ToString();

                                stores.Add(store);
                            }
                        }
                    }

                }
            }

            return stores;
        }



            public static async Task<bool> AddNewStore(Store store, string connectString)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    //conn.Open();
                    string addStore = "INSERT INTO Stores " +
                        "(Address, City, District, Name) " + //Username, City) " +
                        "VALUES " +
                        "(@Address,@City,@District,@Name)";
                    using (SqlCommand cmd = new SqlCommand(addStore))
                    {

                        //cmd.CommandType = CommandType.Text;

                        cmd.Connection = conn;
                
                        cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = store.Address;
                        cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = store.City;
                        cmd.Parameters.Add("@District", SqlDbType.NVarChar).Value = store.District;
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = store.Name;

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

        public void UpdateStore(Store store)
        {
            List<Store> stores = new List<Store>();

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE stores SET id = @Id, address = @Address,  city = @City, district = @District,name = @Name WHERE id = @Id", conn))

                {

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Id", store.Id);
                    cmd.Parameters.AddWithValue("@Address", store.Address);
                    cmd.Parameters.AddWithValue("@City", store.City);
                    cmd.Parameters.AddWithValue("@District", store.District);
                    cmd.Parameters.AddWithValue("@Name", store.Name);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void DeleteStore(Store store)
        {
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();

                List<Store> stores = new List<Store>();
                string deleteSql = "DELETE FROM stores WHERE id = @Id";
                SqlCommand deleteCommand = new SqlCommand(deleteSql, conn);
                deleteCommand.Parameters.AddWithValue("@Id", store.Id);
                conn.Close();

                /*
                int rowsAffected = deleteCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return Ok("Successfully deleted the user with ID: " + store.Id);
                }
                else
                {
                    return NotFound("No user found with ID: " + store.Id);
                }
                */
            }
        }
    }
}
