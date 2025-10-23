using Npgsql;
using System.Data;
using System.Data.Common;

namespace ByCodersChallengeDotNet.IntegrationTests.DbContext
{
    public class DbTransactionTest : DbTransaction
    {
        private readonly NpgsqlTransaction _dbTransaction;
        private readonly DbConnection _dbConnection;

        public NpgsqlTransaction? Transaction => _dbTransaction;

        public DbTransactionTest(NpgsqlConnection dbConnection, NpgsqlTransaction dbTransaction)
        {
            _dbTransaction = dbTransaction;
            _dbConnection = dbConnection;
        }

        public new DbConnection? Connection => _dbConnection;

        public override IsolationLevel IsolationLevel => _dbTransaction.IsolationLevel;

        protected override DbConnection? DbConnection => _dbConnection;

        public override void Commit()
        {
            // do nothing
        }

        public void Dispose()
        {
            // do nothing
        }

        public override void Rollback()
        {
            if(_dbConnection.State is ConnectionState.Open)
            {
                _dbTransaction.Rollback();
            }
        }
    }
}
