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
	                t.time AT TIME ZONE 'UTC-3' as time,
	                t.value,
	                t.cpf,
	                t.card,
	                t.store_owner as storeOwner,
	                t.store_name as storeName
                from public.""operation"" t
                inner join transaction_type tt on tt.id = t.type";
            return _dbContext.DbConnection.Query<OperationModel>(query);
        }

        public bool Save(IEnumerable<Operation> operations)
        {
            _dbContext.DbConnection.Open();

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

            using (var transaction = _dbContext.DbConnection.BeginTransaction())
            {
                try
                {
                    affectedRows = _dbContext.DbConnection.Execute(
                    sql: @"INSERT INTO public.""operation"" (type, value, cpf, card, time, store_owner, store_name) VALUES
                               (@Type, @Value, @Cpf, @Card, @Time, @StoreOwner, @StoreName)",
                    param: param,
                    transaction: transaction
                    );

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            _dbContext.DbConnection.Close();

            return affectedRows == operations.Count();
        }
    }
}
