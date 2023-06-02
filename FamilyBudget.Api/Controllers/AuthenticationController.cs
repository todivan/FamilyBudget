using FamilyBudget.Api.Model;
using FamilyBudget.Api.Model.Configurations;
using FamilyBudget.Api.Model.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FamilyBudget.Api.Controllers
{
    [Route(template: "api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        //private readonly JwtConfig _jwtConfig;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            //_jwtConfig = jwtToken;
        }

        [HttpPost]
        [Route(template:"Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDto userRegistrationRequestDto)
        {
            // Validate the incoming request
            if (ModelState.IsValid)
            {
                var userExist = await _userManager.FindByEmailAsync(userRegistrationRequestDto.Email);

                if (userExist != null)
                {
                    return BadRequest(error: new AuthResult()
                    {
                        Result = false,
                        Errors = new List<string>()
                        {
                            "Email already exist"
                        }
                    });
                }

                //Crete user
                var newUser = new IdentityUser()
                {
                    Email = userRegistrationRequestDto.Email,
                    UserName = userRegistrationRequestDto.Email
                };

                IdentityResult isCreated = await _userManager.CreateAsync(newUser, userRegistrationRequestDto.Password);
                if (isCreated.Succeeded)
                {
                    //Generate token
                    var token = GenerateJwtToken(newUser);

                    return Ok(new AuthResult()
                    {
                        Result = true,
                        Token = token
                    });
                }

                return BadRequest(error: new AuthResult()
                {
                    Result = false,
                    Errors = new List<string>()
                        {
                            "Server error"
                        }
                });
            }

            return BadRequest();
        }

        [HttpPost]
        [Route(template:"Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto userLoginRequestDto)
        {
            if(ModelState.IsValid)
            {
                //Check if user exist
                var existingUser =  await _userManager.FindByEmailAsync(userLoginRequestDto.Email);
                if (existingUser == null)
                {
                    return BadRequest(error: new AuthResult()
                    {
                        Result = false,
                        Errors = new List<string>()
                        {
                            "Invalid payload"
                        }
                    });
                }

                var iscorrect = await _userManager.CheckPasswordAsync(existingUser, userLoginRequestDto.Password);

                if(!iscorrect)
                {
                    return BadRequest(error: new AuthResult()
                    {
                        Result = false,
                        Errors = new List<string>()
                        {
                            "Invalid credentials"
                        }
                    });
                }

                var jwtToken = GenerateJwtToken(existingUser);
                return Ok(new AuthResult()
                {
                    Result = true,
                    Token = jwtToken
                });
            }

            return BadRequest(error:new AuthResult()
            {
                Result = false,
                Errors = new List<string>()
                {
                    "Invalid payload"
                }
            });
        }


        private string GenerateJwtToken(IdentityUser identityUser)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection(key: "JwtConfig:Secret").Value);

            //Token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(type: "Id", value: identityUser.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, value: identityUser.Email),
                    new Claim(JwtRegisteredClaimNames.Email, value: identityUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, value: Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, value: DateTime.Now.ToUniversalTime().ToString())
                }),

                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);
            return jwtToken;
        }
    }
}
