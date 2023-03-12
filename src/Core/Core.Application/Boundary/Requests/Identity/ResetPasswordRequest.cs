using System.ComponentModel.DataAnnotations;

namespace Application.Boundary.Requests.Identity;

public class ResetPasswordRequest
{
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [DataType(DataType.Password)]
    [Compare("Password",ErrorMessage = "Password and confirm password do not match")]
    public string ConfirmPassword { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
}