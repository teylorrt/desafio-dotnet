using ByCodersChallengeDotNet.Core.Entities;
using ByCodersChallengeDotNet.Core.Repositories;
using ByCodersChallengeDotNet.Infrastructure.DbContext;

namespace ByCodersChallengeDotNet.Infrastructure.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        private readonly IDbContext _dbContext;
        private static readonly Dictionary<long, Operation> TempDataBase = [];

        public OperationRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Operation> List()
        {
            return TempDataBase.Select(d => d.Value);
        }

        public bool Save(IEnumerable<Operation> operations)
        {
            int id = 1;
            foreach (var operation in operations)
            {
                operation.Id = id;
                TempDataBase[operation.Id] = operation;
                id++;
            }

            return true;
        }
    }
}
