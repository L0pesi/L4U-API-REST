using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L4U_DAL_DATA.Utilities;

namespace L4U_DAL_DATA.Data
{
    /// <summary>
    /// This class is a generic class, responsible to call sql stored procedures
    /// </summary>
    public static class GeneralProcedureCall
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
        public static async Task<object> CallStoredProcedure<T>(SqlEnumTypes req, string procedure, string appPath, SqlParameter[] parameters = null) where T : new()
        {
            // possible variables. Only 1 will be returned
            string reqId = string.Empty;
            int sqlResult = -1;
            bool boolResult = false;
            T singleResult = new T();
            List<T> listOfResult = new List<T>();

            try
            {
                Config config = new Config();

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
                                case SqlEnumTypes.GetSingle:
                                case SqlEnumTypes.GetList:
                                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                                    {
                                        dataAdapter.Fill(dataTable);
                                    }
                                    break;

                                case SqlEnumTypes.Insert:
                                    sqlResult = await command.ExecuteNonQueryAsync();
                                    if (!procedure.Equals(StoreProcedures.AddNewUser)        /// APENAS EXEMPLO PA TESTE
                                        && !procedure.Equals(StoreProcedures.DeleteUser)    /// APENAS EXEMPLO PA TESTE
                                        && !procedure.Equals(StoreProcedures.LoginUser))   /// APENAS EXEMPLO PA TESTE
                                        reqId = command.Parameters["@ReqIdOut"].Value.ToString();
                                    else
                                        boolResult = sqlResult > 0;
                                    break;

                                case SqlEnumTypes.Update:
                                case SqlEnumTypes.Delete:
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
                        if (req.Equals(SqlEnumTypes.GetSingle))
                            singleResult = (T)Activator.CreateInstance(typeof(T), dataTable.Rows[0]);
                        else
                            foreach (DataRow dataRow in dataTable.Rows)
                                listOfResult.Add((T)Activator.CreateInstance(typeof(T), dataRow));
                    }
                }
            }
            catch (Exception e)
            {
                /// Sistema de LOGS
                return false;
            }
            if (req.Equals(SqlEnumTypes.GetSingle))
                return singleResult;
            if (req.Equals(SqlEnumTypes.GetList))
                return listOfResult;
            if (req.Equals(SqlEnumTypes.Insert) && !string.IsNullOrEmpty(reqId))
                return reqId;
            return boolResult;
        }
    }
}
