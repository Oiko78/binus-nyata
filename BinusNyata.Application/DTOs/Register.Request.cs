using System.ComponentModel.DataAnnotations;

namespace BinusNyata.Application.DTOs
{
  public class RegisterRequest
  {
    [Required()]
    [EmailAddress()]
    public string Email { get; set; }

    [Required]
    [StringLength(8)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$")]
    public string Password { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }
  }
}