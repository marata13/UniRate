using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniRate.Data;
using UniRate.Models;

namespace UniRate.Controllers
{
    [Authorize]
    public class RegisteredUsersController : Controller
    {
        private readonly UniRateContext _context;


        public RegisteredUsersController(UniRateContext context)
        {
            _context = context;
        }


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

        public IActionResult UniResultsRegistered()
        {
            return View();
        }

        public IActionResult AddReview()
        {
            return View();
        }

        public IActionResult DepResultsRegistered()
        {
            return View();
        }

        public IActionResult FavoritesRegistered()
        {
            return View();
        }


        public async Task<IActionResult> AddFavoriteUni(Guid Id)
        {
            ViewBag.LoggedIn = HttpContext.Request.Cookies.ContainsKey("LoginCookie");

            University university = await _context.University.FirstOrDefaultAsync(m => m.Id == Id);
            FavoriteUniversity FavUni = new FavoriteUniversity();
            FavUni.Id = new Guid();
            FavUni.University = university;
            try
            {
                await _context.FavoriteUniversity.AddAsync(FavUni);
                _context.SaveChanges();

                var User = await _context.User.FirstOrDefaultAsync(m => m.UserName == HttpContext.User.Identity.Name);

                if (User.FavoriteUniversities != null)
                {
                    User.FavoriteUniversities.Add(FavUni);
                    _context.SaveChanges();
                }
                else
                {
                    List<FavoriteUniversity> favUnies = new() { FavUni };
                    User.FavoriteUniversities = favUnies;
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                ViewBag.errorMessage = "this university is already on the favorites list";
            }

            return RedirectToAction("UniResults", "Home", new { university.Id });
        }


        public async Task<IActionResult> RemoveFavoriteUni(Guid Id)
        {
            ViewBag.LoggedIn = HttpContext.Request.Cookies.ContainsKey("LoginCookie");

            University university = await _context.University.FirstOrDefaultAsync(m => m.Id == Id);
            var User = await _context.User.FirstOrDefaultAsync(m => m.UserName == HttpContext.User.Identity.Name);

            try
            {
                FavoriteUniversity FavUni = User.FavoriteUniversities.FirstOrDefault(m => m.University == university);
                User.FavoriteUniversities.Remove(FavUni);

                _context.FavoriteUniversity.Remove(FavUni);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                ViewBag.errorMessage = "this university is not on the favorites list";
            }

            return RedirectToAction("UniResults", "Home", new { university.Id });
        }
    }
}
