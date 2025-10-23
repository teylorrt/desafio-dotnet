using Npgsql;
using System.Data;

namespace ByCodersChallengeDotNet.Tests.DbContext
{
    public class DBConnectionTest : IDbConnection
    {
        private readonly NpgsqlConnection _dbConnection;

        public DBConnectionTest(string? connectionString)
        {
            _dbConnection = new NpgsqlConnection(connectionString);
        }

        public string ConnectionString { get => _dbConnection.ConnectionString; set => _dbConnection.ConnectionString = value; }

        public int ConnectionTimeout => _dbConnection.ConnectionTimeout;

        public string Database => _dbConnection.Database;

        public ConnectionState State => _dbConnection.State;

        public IDbTransaction BeginTransaction()
        {
            var transaction = _dbConnection.BeginTransaction();

            return new DbTransactionTest(_dbConnection, transaction);
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            var transaction = _dbConnection.BeginTransaction(il);

            return new DbTransactionTest(_dbConnection, transaction);
        }

        public void ChangeDatabase(string databaseName) => _dbConnection.ChangeDatabase(databaseName);

        public void Close()
        {
            //do nothing
        }
        public IDbCommand CreateCommand() => _dbConnection.CreateCommand();

        public void Dispose() => _dbConnection.Dispose();

        public void Open()
        {
            if(_dbConnection.State == ConnectionState.Closed)
            {
                _dbConnection.Open();
            }
        }
    }
}
