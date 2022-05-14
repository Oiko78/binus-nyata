using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BinusNyata.Application.DTOs;
using BinusNyata.Application.Services;
using BinusNyata.Domain.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BinusNyata.Application.Controllers
{
  [Controller]
  public class AuthController : Controller
  {
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
      _authService = authService;
    }

    [Route("login")]
    [HttpGet]
    public async Task<IActionResult> Login()
    {
      return View("Login", new LoginRequest());
    }

    [Route("login")]
    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest data)
    {
      if (!ModelState.IsValid)
        return View("Login", data);

      LoginResponse res = await _authService.Login(data);
      res.Errors.ToList().ForEach(error =>
        error.Value.ForEach(value =>
          ModelState.AddModelError(error.Key, value)
        )
      );

      if (!ModelState.IsValid)
        return View("Login", data);

      return View("Login", data);
    }

    [Route("register")]
    [HttpGet]
    public async Task<IActionResult> Register()
    {
      return View("Register", new RegisterRequest());
    }

    [Route("register")]
    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequest data)
    {
      if (!ModelState.IsValid)
        return View("Register", data);

      RegisterResponse res = await _authService.Register(data);
      res.Errors.ToList().ForEach(error =>
        error.Value.ForEach(value =>
          ModelState.AddModelError(error.Key, value)
        )
      );

      if (!ModelState.IsValid)
        return View("Register", data);

      return View("Login", data);
    }
  }
}