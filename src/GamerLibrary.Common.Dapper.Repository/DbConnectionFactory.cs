using System.Data;
using System.Data.SqlClient;

namespace GamerLibrary.Common.Repository
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateDbConnection();
    }

    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public DbConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateDbConnection() => new SqlConnection(_connectionString);
    }
}
