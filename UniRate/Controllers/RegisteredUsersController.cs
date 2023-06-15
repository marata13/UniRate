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



        public async Task<IActionResult> Favorites()
        {
            ViewBag.LoggedIn = HttpContext.User.Identity.Name != null;

            var User = await _context.User.FirstOrDefaultAsync(m => m.UserName == HttpContext.User.Identity.Name);
            FavoritesModel favourites = new()
            {
                Departments = User.GetFavoriteDepartments(_context, true),
                Universities = User.GetFavoriteUniversities(_context, true)
            };

            return View(favourites);
        }

        public async Task<IActionResult> AccountInfo()
        {
            ViewBag.LoggedIn = HttpContext.User.Identity.Name != null;

            var User = await _context.User.FirstOrDefaultAsync(m => m.UserName == HttpContext.User.Identity.Name);

            return View(User);
        }


        [HttpPost]
        public async Task<IActionResult> AccountInfo([Bind("UserName,Email,Password")] User user, string newPassword)
        {
            ViewBag.LoggedIn = HttpContext.User.Identity.Name != null;
            var loggedUser = await _context.User.FirstOrDefaultAsync(m => m.UserName == HttpContext.User.Identity.Name);

            if (Data.Hashing.VerifyPassword(user.Password, loggedUser.Password, loggedUser.Salt) && ModelState.IsValid)
            {
                byte[] generatedSalt;
                loggedUser.Password = Hashing.HashPasword(newPassword, out generatedSalt);
                loggedUser.Salt = generatedSalt;
                _context.Update(loggedUser);
                await _context.SaveChangesAsync();
                ViewBag.errorMessage = "Password successfuly changed";
            }
            else
            {
                ViewBag.errorMessage = "Old password is wrong";
            }

            return View(loggedUser);
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


        public async Task<IActionResult> AddFavoriteDep(Guid Id)
        {
            ViewBag.LoggedIn = HttpContext.User.Identity.Name != null;

            Department department = await _context.Department.FirstOrDefaultAsync(m => m.Id == Id);
            FavoriteDepartment FavDep = new();
            FavDep.Id = new Guid();
            FavDep.Department = department;
            try
            {

                var User = await _context.User.FirstOrDefaultAsync(m => m.UserName == HttpContext.User.Identity.Name);
                User.FavoriteDepartments = User.GetFavoriteDepartments(_context);

                if (!User.FavoriteDepartments.Contains(FavDep))
                {
                    User.FavoriteDepartments.Add(FavDep);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                ViewBag.errorMessage = "this department is already on the favorites list";
            }

            return RedirectToAction("DepResults", "Home", new { department.Id });
        }


        public async Task<IActionResult> RemoveFavoriteUni(Guid Id, bool fromFavorites = false)
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

            if (fromFavorites)
            {
                return RedirectToAction("Favorites");
            }

            return RedirectToAction("UniResults", "Home", new { university.Id });
        }


        public async Task<IActionResult> RemoveFavoriteDep(Guid Id, bool fromFavorites = false)
        {
            ViewBag.LoggedIn = HttpContext.User.Identity.Name != null;

            Department department = await _context.Department.FirstOrDefaultAsync(m => m.Id == Id);
            var User = await _context.User.FirstOrDefaultAsync(m => m.UserName == HttpContext.User.Identity.Name);
            User.FavoriteDepartments = User.GetFavoriteDepartments(_context);

            FavoriteDepartment FavDep = User.FavoriteDepartments.FirstOrDefault(m => m.Department == department);

            if (User.FavoriteDepartments.Contains(FavDep))
            {
                User.FavoriteDepartments.Remove(FavDep);
                _context.SaveChanges();
            }

            if (fromFavorites)
            {
                return RedirectToAction("Favorites");
            }

            return RedirectToAction("DepResults", "Home", new { department.Id });
        }


        //GET
        public IActionResult AddUniReview(Guid Id)
        {
            var University = _context.University.FirstOrDefault(m => m.Id == Id);
            ViewBag.University = University.Name;
            ViewBag.universityId = Id;
            ViewBag.UserName = HttpContext.User.Identity.Name;
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

                var User = await _context.User.Include(u => u.UniRatings).FirstOrDefaultAsync(m => m.UserName == HttpContext.User.Identity.Name);
                User.UniRatings.Add(rating);

                var University = await _context.University.Include(u => u.Ratings).FirstOrDefaultAsync(m => m.Id == universityId);
                University.Ratings.Add(rating);

                await _context.SaveChangesAsync();
            }
            else
            {
                ViewBag.errorMessage = "You entered wrong data";
            }
            return RedirectToAction("UniResults", "Home", new { Id = universityId });
        }


        //GET
        [HttpGet]
        public IActionResult AddDepReview(Guid Id)
        {
            var Department = _context.Department.Include(m => m.university).FirstOrDefault(m => m.Id == Id);
            ViewBag.University = Department.university.Name;
            ViewBag.Department = Department.Name;
            ViewBag.DepartmentId = Id;
            ViewBag.UserName = HttpContext.User.Identity.Name;
            return View();
        }


        //POST
        [HttpPost]
        public async Task<IActionResult> AddDepReview([Bind("DifficultyRating,ProfessorsRating,SubjectsRating,FreshnessRating,OrganisationRating,Review")] DepRating rating, Guid departmentId)
        {
            if (ModelState.IsValid)
            {
                rating.DateTime = DateTime.UtcNow;

                rating.OverallRating = (rating.DifficultyRating + rating.ProfessorsRating + rating.OrganisationRating
                                        + rating.SubjectsRating + rating.FreshnessRating) / 5.0;

                var User = await _context.User.FirstOrDefaultAsync(m => m.UserName == HttpContext.User.Identity.Name);
                User.DepRatings = User.GetDepRatings(_context);
                User.DepRatings.Add(rating);

                var Department = await _context.Department.FirstOrDefaultAsync(m => m.Id == departmentId);
                Department.Ratings = Department.GetRatings(_context);
                Department.Ratings.Add(rating);

                await _context.SaveChangesAsync();
            }
            else
            {
                ViewBag.errorMessage = "You entered wrong data";
            }
            return RedirectToAction("DepResults", "Home", new { Id = departmentId });
        }
    }
}

