using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BinusNyata.Application.DTOs;
using BinusNyata.Domain.Accounts;
using BinusNyata.Domain.Interfaces;
using BinusNyata.Domain.Users;
using BinusNyata.Infrastructure.Data.Repositories;

namespace BinusNyata.Application.Services
{
  public class AuthService : BaseService
  {
    private readonly UserRepository _userRepository;

    public AuthService(
      IUnitOfWork unitOfWork,
      UserRepository userRepository) : base(unitOfWork)
    {
      _userRepository = userRepository;
    }

    public async Task<LoginResponse> Login(LoginRequest data)
    {
      LoginResponse res = new LoginResponse(data);
      User user = await _userRepository.Get(user => user.Account.Email.Equals(data.Email));

      if (user == null)
      {
        res.Errors[nameof(data.Email)].Add("Incorrect email / password!");
        res.Errors[nameof(data.Password)].Add("Incorrect email / password!");
        return res;
      }

      return res;
    }

    public async Task<RegisterResponse> Register(RegisterRequest data)
    {
      RegisterResponse res = new RegisterResponse(data);
      User user = null;

      // check if user exists
      user = await _userRepository.Get(user => user.Account.Email.Equals(data.Email));
      if (user != null)
      {
        res.Errors[nameof(data.Email)].Add("Email already exists! Please choose another email!");
        return res;
      }

      // create a user
      user = new User()
      {
        FirstName = data.FirstName,
        LastName = data.LastName,
        Profile = new Profile()
        {
          Birthday = data.Birthday
        },
        Account = new Account()
        {
          Email = data.Email,
          Password = data.Password
        },
        Roles = new List<Role>()
        {
          await _userRepository.GetRole(role => role.Id == Role.Student)
        }
      };

      // insert and save
      await _userRepository.Add(user);
      await UnitOfWork.SaveChangesAsync();

      return res;
    }
  }
}