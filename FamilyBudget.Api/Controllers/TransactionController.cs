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
    public class TransactionController : DBController<Transaction, TransactionRepository>
    {
        private readonly ILogger<TransactionController> _logger;


        public TransactionController(ILogger<TransactionController> logger, TransactionRepository userRepository)
            : base(userRepository)
        {
            _logger = logger;
        }
    }
}
