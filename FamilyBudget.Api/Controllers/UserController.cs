using FamilyBudget.Api.Data;
using FamilyBudget.Api.Model;
using FamilyBudget.Data;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudget.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : DBController<User, UserRepository>
    {
        private readonly ILogger<UserController> _logger;


        public UserController(ILogger<UserController> logger, UserRepository userRepository)
            : base(userRepository)
        {
            _logger = logger;
        }
    }

    //[ApiController]
    //[Route("api/user")]
    //public class UserController : ControllerBase
    //{
    //    private readonly ILogger<UserController> _logger;
    //    private readonly AppDbContext _context;

    //    public UserController(ILogger<UserController> logger, AppDbContext appDbContext)
    //    {
    //        _logger = logger;
    //        _context = appDbContext;
    //    }

    //    [HttpGet(Name = "GetUser")]
    //    public User? Get(int id)
    //    {
    //        return _context.Users.FirstOrDefault(x => x.Id == id);
    //    }

    //    [HttpPost(Name = "CreateUser")]
    //    public User? Post(User user)
    //    {
    //        var createdUser = _context.Users.Add(user);
    //        _context.SaveChanges();
    //        return createdUser.Entity;
    //    }
    //}
}