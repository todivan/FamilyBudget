
using FamilyBudget.Api.Data;
using FamilyBudget.Api.Model;

namespace FamilyBudget.Data
{
    public class TransactionRepository : EfCoreRepository<Transaction, AppDbContext>
    {

        public TransactionRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}
