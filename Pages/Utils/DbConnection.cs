using Microsoft.Data.SqlClient;

namespace RFID2.Pages.Utils
{
    public class DbConnection
    {
      
       
            public static string ConnectionString { get; private set; }

            public static void Init(IConfiguration config)
            {
                ConnectionString = config.GetConnectionString("GIC_Local_DB");
            }

            public static SqlConnection GetConnection()
            {
                return new SqlConnection(ConnectionString);
            }
            
    }

}
