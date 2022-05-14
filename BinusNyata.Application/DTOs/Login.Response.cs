using BinusNyata.Domain.Accounts;
using BinusNyata.Domain.Base;

namespace BinusNyata.Application.DTOs
{
  public class LoginResponse : BaseOutput
  {
    public Account Account { get; set; }
    public LoginResponse(object obj) : base(obj) { }
  }
}