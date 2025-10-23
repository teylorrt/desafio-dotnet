using Npgsql;
using System.Data;

namespace ByCodersChallengeDotNet.Infrastructure.DbContext
{
    public class DapperDbContext : IDbContext
    {
        private readonly IDbConnection _dbConnection;
        private IDbTransaction? _dbTransaction;

        public DapperDbContext(IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("PostgresSQL");
            _dbConnection = new NpgsqlConnection(connectionString);
        }

        public IDbConnection Connection => _dbConnection;

        public IDbTransaction? Transaction => _dbTransaction;

        NpgsqlTransaction? IDbContext.Transaction => _dbTransaction as NpgsqlTransaction;

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
            _dbConnection.Dispose();
        }

        public void OpenConnection()
        {
            if(_dbConnection.State is ConnectionState.Closed)
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

        public void RollbackTransaction()
        {
            if(_dbTransaction is not null)
            {
                _dbTransaction.Rollback();
                _dbTransaction = null;
            }
        }
    }
}
