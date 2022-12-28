using L4U_DAL_DATA.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L4U_DAL_DATA.Services;
using System.Data.SqlClient;



namespace L4U_DAL_DATA.Data
{
    /// <summary>
    /// This class is a generic class, responsible to call sql stored procedures
    /// </summary>
    public static class GenericProcedureCall
    {
        /// <summary>
        /// This generic method, calls a stored procedure in Sql database
        /// </summary>
        /// <typeparam name="T">Generic type of object</typeparam>
        /// <param name="req">Type of the sql request made</param>
        /// <param name="procedure">Name of the stored procedure</param>
        /// <param name="appPath">Application path</param>
        /// <param name="parameters">Sql parameters (if needed)</param>
        /// <returns></returns>
        public static async Task<object> CallStoredProcedure<T>(SqlRequestTypes req, string procedure, string appPath, SqlParameter[] parameters = null) where T : new()
        {
            // possible variables. Only 1 will be returned
            string reqId = string.Empty;
            int sqlResult = -1;
            bool boolResult = false;
            T singleResult = new T();
            List<T> listOfResult = new List<T>();

            try
            {
                ConfigData config = new ConfigData();

                using (DataTable dataTable = new DataTable())
                {
                    using (SqlConnection connection = new SqlConnection(config.GetConnectionString()))
                    {
                        await connection.OpenAsync();
                        using (SqlCommand command = new SqlCommand(procedure, connection))
                        {
                            command.CommandTimeout = 120;
                            command.CommandType = CommandType.StoredProcedure;

                            if (parameters != null)
                                command.Parameters.AddRange(parameters);

                            switch (req)
                            {
                                case SqlRequestTypes.GetSingle:
                                case SqlRequestTypes.GetList:
                                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                                    {
                                        dataAdapter.Fill(dataTable);
                                    }
                                    break;

                                    /*case SqlRequestTypes.Insert:
                                    sqlResult = await command.ExecuteNonQueryAsync();
                                    if (!procedure.Equals(SqlStoredProcedures.IntegratePositivePersons)
                                        && !procedure.Equals(SqlStoredProcedures.IntegrateRiscContactPersons)
                                        && !procedure.Equals(SqlStoredProcedures.AddProduct)
                                        && !procedure.Equals(SqlStoredProcedures.AddProductStore))
                                        reqId = command.Parameters["@ReqIdOut"].Value.ToString();
                                    else
                                        boolResult = sqlResult > 0;
                                    break;*/

                                case SqlRequestTypes.Update:
                                case SqlRequestTypes.Delete:
                                    sqlResult = await command.ExecuteNonQueryAsync();   //used for this operations
                                    boolResult = sqlResult > 0;
                                    break;

                                default:
                                    break;
                            }
                        }
                    }

                    if (dataTable.Rows.Count > 0)
                    {
                        // If the sql request type is getlist means the result will be a list of objects of type T
                        if (req.Equals(SqlRequestTypes.GetSingle))
                            singleResult = (T)Activator.CreateInstance(typeof(T), dataTable.Rows[0]);
                        else
                            foreach (DataRow dataRow in dataTable.Rows)
                                listOfResult.Add((T)Activator.CreateInstance(typeof(T), dataRow));
                    }
                }

            }
            catch (Exception e)
            {
                //FileService.AddLog("GenericProcedureCall", "CallStoredProcedure", e.Message, appPath);
                return false;
            }
            if (req.Equals(SqlRequestTypes.GetSingle))
                return singleResult;
            if (req.Equals(SqlRequestTypes.GetList))
                return listOfResult;
            if (req.Equals(SqlRequestTypes.Insert) && !string.IsNullOrEmpty(reqId))
                return reqId;
            return boolResult;
        }
    }
}
