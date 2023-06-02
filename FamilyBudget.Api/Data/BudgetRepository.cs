
using FamilyBudget.Api.Data;
using FamilyBudget.Api.Model;

namespace FamilyBudget.Data
{
    public class BudgetRepository : EfCoreRepository<Budget, AppDbContext>
    {

        public BudgetRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}
