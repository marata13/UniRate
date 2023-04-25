using Microsoft.AspNetCore.Mvc;

namespace UniRate.Controllers
{
    public class RegisteredUsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HomeRegistered()
        {
            return View();
        }

        public IActionResult SearchRegistered()
        {
            return View();
        }
    }
}
