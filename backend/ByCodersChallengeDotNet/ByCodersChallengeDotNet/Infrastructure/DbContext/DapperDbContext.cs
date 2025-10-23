using Npgsql;
using System.Data;

namespace ByCodersChallengeDotNet.Infrastructure.DbContext
{
    public class DapperDbContext : IDbContext
    {
        private readonly IDbConnection _dbConnection;

        public DapperDbContext(IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("PostegreSQL");
            _dbConnection = new NpgsqlConnection(connectionString);
        }

        public IDbConnection DbConnection => _dbConnection;
    }
}
