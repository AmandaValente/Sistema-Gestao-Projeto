using System.Configuration;
using System.Data.SqlClient;

namespace GestaoProjetoAPI.Repositories
{
    public static class ConfigConexao
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["TaskFlow"].ConnectionString;

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
