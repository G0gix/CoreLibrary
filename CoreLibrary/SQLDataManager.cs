using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace CoreLibrary.SQL
{
    public class SQLDataManager
    {
        private readonly string ConnectionString;

        public SQLDataManager(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public async Task<DataTable> Read(SqlCommand command)
        {
            try
            {
                DataTable tableToFill = new DataTable();

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    await conn.OpenAsync();
                    using (command)
                    {
                        command.Connection = conn;

                        using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                        {
                            if (dataReader.HasRows)
                            {
                                tableToFill.Load(dataReader);
                            }
                        }
                    }
                }

                return tableToFill;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
