using System.ComponentModel.DataAnnotations;

namespace BinusNyata.Application.DTOs
{
  public class LoginRequest
  {
    [Required()]
    [EmailAddress()]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
  }
}