using L4U_BOL_MODEL.Models;
using System.Data;
using System.Data.SqlClient;

namespace L4U_DAL_DATA.Services
{
    /// <summary>
    ///  The Data Acess Layer Class of Stores
    /// </summary>
    public class StoresService
    {



        /// <summary>
        /// This Method Adds a new Store to the Database
        /// </summary>
        /// <param name="store"></param>
        /// <param name="connectString"></param>
        /// <returns></returns>
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
            catch (Exception)
            {
                return false;
            }
        }



        /// <summary>
        /// This method Updates a Store in the Database
        /// </summary>
        /// <param name="store"></param>
        /// <param name="connectString"></param>
        /// <returns></returns>
        public static async Task<bool> UpdateStore(Store store, string connectString)

        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))

                {
                    //conn.Open();
                    string addStore = "UPDATE stores SET id = @Id , address = @Address,  city = @City, district = @District,name = @Name WHERE id = @Id";
                    using (SqlCommand cmd = new SqlCommand(addStore))
                    {

                        //cmd.CommandType = CommandType.Text;

                        cmd.Connection = conn;

                        cmd.Parameters.Add("Id", SqlDbType.NVarChar, 50).Value = store.Id;
                        cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 50).Value = store.Address;
                        cmd.Parameters.Add("@City", SqlDbType.NVarChar, 50).Value = store.City;
                        cmd.Parameters.Add("@District", SqlDbType.NVarChar, 50).Value = store.District;
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = store.Name;

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
        /// This Method Deletes a Store in the Database
        /// </summary>
        /// <param name="store"></param>
        /// <param name="connectString"></param>
        /// <returns></returns>
        public static async Task<bool> DeleteStore(Store store, string connectString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    string deleteLocker = "DELETE FROM lockers WHERE id = @Id";
                    string deleteStore = "DELETE FROM stores WHERE id = @Id";

                    using (SqlCommand cmd = new SqlCommand(deleteLocker, conn))
                    {
                        cmd.Parameters.Add("@Id", SqlDbType.NVarChar, 50).Value = store.Id;
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();                
                        conn.Close();
                    }

                    using (SqlCommand cmd = new SqlCommand(deleteStore, conn))
                    {
                        cmd.Parameters.Add("@Id", SqlDbType.NVarChar, 50).Value = store.Id;
                        conn.Open();
                        int result = cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }




        /// <summary>
        /// This Method Gets All Stores in the Database
        /// </summary>
        /// <param name="connectString"></param>
        /// <returns></returns>
        public static async Task<List<Store>> GetAllStores(string connectString)
        {
            try

            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    string getStores = "SELECT * FROM stores";
                    using (SqlCommand cmd = new SqlCommand(getStores))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        List<Store> stores = new List<Store>();
                        while (reader.Read())
                        {
                            Store store = new Store();
                            store.Id = reader.GetString(0);
                            store.Address = reader.GetString(1);
                            store.City = reader.GetString(2);
                            store.District = reader.GetString(3);
                            store.Name = reader.GetString(4);
                            stores.Add(store);
                        }
                        return stores;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        
        }


        #region Material Estudo - para implementação

        #endregion

    }
    

