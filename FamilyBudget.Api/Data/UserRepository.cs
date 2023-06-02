
using FamilyBudget.Api.Data;
using FamilyBudget.Api.Model;

namespace FamilyBudget.Data
{
    public class UserRepository : EfCoreRepository<User, AppDbContext>
    {

        public UserRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}
