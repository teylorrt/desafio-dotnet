using ByCodersChallengeDotNet.Core.Entities.Operation;
using ByCodersChallengeDotNet.Core.Models;
using ByCodersChallengeDotNet.Core.Repositories;
using ByCodersChallengeDotNet.Infrastructure.DbContext;
using Dapper;

namespace ByCodersChallengeDotNet.Infrastructure.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        private readonly IDbContext _dbContext;

        public OperationRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<OperationModel> List()
        {
            string query = @"select 
	                t.id,
	                t.type,
	                tt.description,
	                tt.nature,
	                tt.sign,
	                TO_CHAR(t.time AT TIME ZONE 'UTC-3', 'DD/MM/YYYY HH24:MI:SS') as time,
	                t.value,
	                t.cpf,
	                t.card,
	                t.store_owner as storeOwner,
	                t.store_name as storeName
                from public.""operation"" t
                inner join transaction_type tt on tt.id = t.type";
            return _dbContext.Connection.Query<OperationModel>(sql: query, transaction: _dbContext.Transaction);
        }

        public bool Save(IEnumerable<Operation> operations)
        {
            _dbContext.OpenConnection();

            var affectedRows = 0;
            var param = operations
                .Select(o => new
                {
                    Type = o.Type.Value,
                    value = o.Value.Value,
                    Cpf = o.Cpf.Value,
                    Card = o.Card.Value,
                    Time = o.Time.Value,
                    StoreOwner = o.StoreOwner.Value,
                    StoreName = o.StoreName.Value,
                });

            using (var transaction = _dbContext.BeginTransaction())
            {
                try
                {
                    affectedRows = _dbContext.Connection.Execute(
                    sql: @"INSERT INTO public.""operation"" (type, value, cpf, card, time, store_owner, store_name) VALUES
                               (@Type, @Value, @Cpf, @Card, @Time, @StoreOwner, @StoreName)",
                    param: param,
                    transaction: _dbContext.Transaction
                    );

                    transaction.Commit();
                }
                catch (Exception)
                {
                    _dbContext.RollbackTransaction();
                    throw;
                }
            }

            _dbContext.CloseConnection();

            return affectedRows == operations.Count();
        }
    }
}
