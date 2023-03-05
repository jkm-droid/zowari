using System.ComponentModel.DataAnnotations;

namespace Application.Boundary.Requests;

public class UserRegistrationRequest
{
    public string Username { get; set; }
    public string Email { get; set; }
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}