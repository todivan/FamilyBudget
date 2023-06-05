using FamilyBudget.Api.Model;
using FamilyBudget.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudget.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class BudgetShareController : DBController<BudgetShare, BudgetShareRepository>
    {
        private readonly ILogger<BudgetShareController> _logger;


        public BudgetShareController(ILogger<BudgetShareController> logger, BudgetShareRepository userRepository)
            : base(userRepository)
        {
            _logger = logger;
        }
    }
}
