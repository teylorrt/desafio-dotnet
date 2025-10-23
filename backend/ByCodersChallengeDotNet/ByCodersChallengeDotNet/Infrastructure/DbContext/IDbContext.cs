using System.Data;

namespace ByCodersChallengeDotNet.Infrastructure.DbContext
{
    public interface IDbContext
    {
        IDbConnection DbConnection { get; }
    }
}
