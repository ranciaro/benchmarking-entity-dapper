   using System.Data;
   using System.Data.SqlClient;
   using Microsoft.Extensions.Configuration;

   namespace PersistencePoc.Core.Context
   {
       public class DatabaseContext
       {
           private readonly IConfiguration _configuration;
           private readonly string? _connectionString;

           public DatabaseContext(IConfiguration configuration)
           {
               _configuration = configuration;
               _connectionString = _configuration.GetConnectionString("DefaultConnection");
           }

           public IDbConnection CreateConnection()
               => new SqlConnection(_connectionString);
       }
   }
   