using FamilyBudget.Api.Data;
using FamilyBudget.Api.Model;
using FamilyBudget.Data;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudget.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : DBController<User, UserRepository>
    {
        private readonly ILogger<UserController> _logger;


        public UserController(ILogger<UserController> logger, UserRepository userRepository)
            : base(userRepository)
        {
            _logger = logger;
        }
    }
}