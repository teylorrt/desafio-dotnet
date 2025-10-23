using Npgsql;
using System.Data;

namespace ByCodersChallengeDotNet.Infrastructure.DbContext
{
    public interface IDbContext : IDisposable
    {
        IDbConnection Connection { get; }
        NpgsqlTransaction? Transaction { get; }
        void OpenConnection();
        void CloseConnection();
        void RollbackTransaction();
        IDbTransaction BeginTransaction();
        IDbTransaction BeginTransaction(IsolationLevel il);
    }
}
