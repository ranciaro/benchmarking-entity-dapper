using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PersistencePoc.Infra.Dapper.Context
{
    public class DatabaseContext
    {
        private readonly IConfiguration _configuration;
        private readonly string? _connectionString;

        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DapperConnection");
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
