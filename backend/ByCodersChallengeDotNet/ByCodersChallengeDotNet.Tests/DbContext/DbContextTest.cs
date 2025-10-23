using ByCodersChallengeDotNet.Infrastructure.DbContext;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace ByCodersChallengeDotNet.Tests.DbContext
{
    public class DbContextTest : IDbContext
    {
        private readonly DBConnectionTest _dbConnection;
        private IDbTransaction? _dbTransaction;

        public NpgsqlTransaction? Transaction => (_dbTransaction as DbTransactionTest)?.Transaction;

        public DbContextTest(IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("PostegreSQL");
            _dbConnection = new DBConnectionTest(connectionString);
        }

        public IDbConnection Connection => _dbConnection;

        public IDbTransaction BeginTransaction()
        {
            _dbTransaction ??= _dbConnection.BeginTransaction();

            return _dbTransaction;
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            _dbTransaction ??= _dbConnection.BeginTransaction(il);

            return _dbTransaction;
        }

        public void Dispose()
        {
            RollbackTransaction();
            _dbConnection.Dispose();
        }

        public void RollbackTransaction()
        {
            if (_dbTransaction is not null)
            {
                _dbTransaction.Rollback();
                _dbTransaction = null;
            }
        }

        public void OpenConnection()
        {
            if (_dbConnection.State is ConnectionState.Closed)
            {
                _dbConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (_dbConnection.State is ConnectionState.Open)
            {
                _dbConnection.Close();
            }
        }
    }
}
