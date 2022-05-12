using System;
using System.Text.Json;
using BinusNyata.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BinusNyata.Application.Controllers
{
  [Controller]
  public class AuthController : Controller
  {
    public AuthController()
    { }

    [Route("login")]
    [HttpGet]
    public IActionResult Login()
    {
      return View("Login", new LoginRequest());
    }

    [Route("login")]
    [HttpPost]
    public IActionResult Login(LoginRequest data)
    {
      Console.WriteLine(JsonSerializer.Serialize(data));
      return View("Login", data);
    }

    [Route("register")]
    [HttpGet]
    public IActionResult Register()
    {
      return View("Register", new RegisterRequest());
    }

    [Route("register")]
    [HttpPost]
    public IActionResult Register(RegisterRequest data)
    {
      Console.WriteLine(JsonSerializer.Serialize(data));
      return View("Register", data);
    }
  }
}