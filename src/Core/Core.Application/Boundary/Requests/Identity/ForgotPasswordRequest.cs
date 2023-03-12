using System.ComponentModel.DataAnnotations;

namespace Application.Boundary.Requests.Identity;

public class ForgotPasswordRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public string Origin { get; set; }
}