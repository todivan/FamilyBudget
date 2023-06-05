
using FamilyBudget.Api.Data;
using FamilyBudget.Api.Model;

namespace FamilyBudget.Data
{
    public class BudgetShareRepository : EfCoreRepository<BudgetShare, AppDbContext>
    {

        public BudgetShareRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}
