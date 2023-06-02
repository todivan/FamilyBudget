using FamilyBudget.Api.Model;
using FamilyBudget.Data;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudget.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BudgetController : DBController<Budget, BudgetRepository>
    {
        private readonly ILogger<BudgetController> _logger;


        public BudgetController(ILogger<BudgetController> logger, BudgetRepository userRepository)
            : base(userRepository)
        {
            _logger = logger;
        }
    }
}
