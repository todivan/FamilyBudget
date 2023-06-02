using System.ComponentModel.DataAnnotations;

namespace FamilyBudget.Api.Model.Dto
{
    public class UserLoginRequestDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
