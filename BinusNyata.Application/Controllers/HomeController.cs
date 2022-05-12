using Microsoft.AspNetCore.Mvc;

namespace BinusNyata.Application.Controllers
{
  [Controller]
  [Route("Home")]
  public class HomeController : Controller
  {
    public HomeController()
    { }

    public IActionResult Index()
    {
      return View();
    }
  }
}