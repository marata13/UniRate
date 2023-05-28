using Microsoft.AspNetCore.Mvc;

namespace UniRate.Controllers
{
    public class RegisteredUsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddReview()
        {
            return View();
        }

        public IActionResult FavoritesRegistered()
        {
            return View();
        }
    }
}
