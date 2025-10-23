using ByCodersChallengeDotNet.Core.Entities;
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
	                t.date,
	                t.value,
	                t.cpf,
	                t.card,
	                t.time,
	                t.store_owner as storeOwner,
	                t.store_name as storeName
                from public.""operation"" t
                inner join transaction_type tt on tt.id = t.type";
            return _dbContext.DbConnection.Query<OperationModel>(query);
        }

        public bool Save(IEnumerable<Operation> operations)
        {
            _dbContext.DbConnection.Open();

            int affectedRows = 0;

            using (var transaction = _dbContext.DbConnection.BeginTransaction())
            {
                try
                {
                    affectedRows = _dbContext.DbConnection.Execute(
                    sql: @"INSERT INTO public.""operation"" (type, date, value, cpf, card, time, store_owner, store_name) VALUES
                               (@Type, @Date, @Value, @CPF, @Card, @Time, @StoreOwner, @StoreName)",
                    param: operations,
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
