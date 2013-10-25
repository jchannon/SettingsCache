using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SettingsCache
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        public IDbConnection GetOpenConnection()
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            connection.Open();

            return connection;
        }

        public IDbConnection GetConnection()
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

            return connection;
        }
    }
}