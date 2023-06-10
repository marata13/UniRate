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
            ViewBag.LoggedIn = HttpContext.User.Identity.Name != null;
            return View();
        }

        public IActionResult AddReview()
        {
            ViewBag.LoggedIn = HttpContext.User.Identity.Name != null;
            return View();
        }

        public IActionResult FavoritesRegistered()
        {
            ViewBag.LoggedIn = HttpContext.User.Identity.Name != null;
            return View();
        }

        public IActionResult AccountInfo()
        {
            ViewBag.LoggedIn = HttpContext.User.Identity.Name != null;
            return View();
        }


        public async Task<IActionResult> AddFavoriteUni(Guid Id)
        {
            ViewBag.LoggedIn = HttpContext.User.Identity.Name != null;

            University university = await _context.University.FirstOrDefaultAsync(m => m.Id == Id);
            FavoriteUniversity FavUni = new FavoriteUniversity();
            FavUni.Id = new Guid();
            FavUni.University = university;
            try
            {

                var User = await _context.User.FirstOrDefaultAsync(m => m.UserName == HttpContext.User.Identity.Name);
                User.FavoriteUniversities = User.GetFavoriteUniversities(_context);

                if (!User.FavoriteUniversities.Contains(FavUni))
                {
                    User.FavoriteUniversities.Add(FavUni);
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
            ViewBag.LoggedIn = HttpContext.User.Identity.Name != null;

            University university = await _context.University.FirstOrDefaultAsync(m => m.Id == Id);
            var User = await _context.User.FirstOrDefaultAsync(m => m.UserName == HttpContext.User.Identity.Name);
            User.FavoriteUniversities = User.GetFavoriteUniversities(_context);

            FavoriteUniversity FavUni = User.FavoriteUniversities.FirstOrDefault(m => m.University == university);

            if (User.FavoriteUniversities.Contains(FavUni))
            {
                User.FavoriteUniversities.Remove(FavUni);
                _context.SaveChanges();
            }

            return RedirectToAction("UniResults", "Home", new { university.Id });
        }

        //GET
        public IActionResult AddUniReview(Guid Id)
        {
            ViewBag.University = Id;
            return View();
        }


        //POST
        [HttpPost]
        public async Task<IActionResult> AddUniReview([Bind("SchoolRating,ActionsRating,Locationrating,AccessabilityRating,OrganisationRating,Review")] UniRating rating, Guid universityId)
        {
            if (ModelState.IsValid)
            {
                rating.DateTime = DateTime.UtcNow;

                rating.OverallRating = (rating.SchoolRating + rating.ActionsRating + rating.OrganisationRating
                                        + rating.AccessabilityRating + rating.Locationrating) / 5.0;

                var User = await _context.User.FirstOrDefaultAsync(m => m.UserName == HttpContext.User.Identity.Name);
                User.UniRatings = User.GetUniRatings(_context);
                User.UniRatings.Add(rating);

                var University = await _context.University.FirstOrDefaultAsync(m => m.Id == universityId);
                University.Ratings = University.GetRatings(_context);
                University.Ratings.Add(rating);

                await _context.SaveChangesAsync();
            }
            else
            {
                ViewBag.errorMessage = "You entered wrong data";
            }
            return RedirectToAction("UniResults", "Home", new { Id = universityId });
        }
    }
}
