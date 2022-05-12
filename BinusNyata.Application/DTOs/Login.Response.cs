using System.ComponentModel.DataAnnotations;
using BinusNyata.Domain.Accounts;

namespace BinusNyata.Application.DTOs
{
  public class LoginResponse
  {
    public Account Account { get; set; }
  }
}