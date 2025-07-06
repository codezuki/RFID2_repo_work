using Microsoft.Data.SqlClient;

namespace RFID2.Pages.Utils
{
    public class DbConnection
    {


        private static string _connectionString;

        public static void Init(IConfiguration config)
            {
            _connectionString = config.GetConnectionString("GIC_Local_DB");
            }

            public static SqlConnection GetConnection()
            {
                return new SqlConnection(_connectionString);
            }
            
    }

}
