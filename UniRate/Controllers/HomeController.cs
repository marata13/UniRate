using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Diagnostics;
using System.Security.Claims;
using UniRate.Data;
using UniRate.Models;

namespace UniRate.Controllers
{
    public class HomeController : Controller
    {
        private readonly UniRateContext _context;


        public HomeController(UniRateContext context)
        {
            _context = context;
        }



        //GET
        public IActionResult Login()
        {
            return View();
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("UserName,Password")] User user)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.errorMessage = "You entered invalid details";
                return View("Login", user);
            }

            var loginUser = await _context.User
                .FirstOrDefaultAsync(m => m.UserName == user.UserName);

            if (loginUser == null)
            {
                //wrong username
                ViewBag.errorMessage = "The username-password combination you entered is wrong";
                return View("Login", user);
            }

            if (Data.Hashing.VerifyPassword(user.Password, loginUser.Password, loginUser.Salt))
            {

                //Creating and populating the identity cookie with data
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginUser.UserName)
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                //Sending the cookie to the clients machine
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                return View("HomePage", user);

            }
            //wrong password
            ViewBag.errorMessage = "The username-password combination you entered is wrong";
            return View("Login", user);
        }


        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }


        public IActionResult HomePage()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public async Task<IActionResult> SignUp([Bind("UserName,Email,Password")] User user)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.errorMessage = "You entered invalid details";
                return View("Login", user);
            }

            var loginUser = await _context.User
                .FirstOrDefaultAsync(m => m.UserName == user.UserName || m.Email == user.Email);

            if (loginUser != null)
            {
                //username or email already exists
                if (user.UserName == loginUser.UserName)
                {
                    ViewBag.errorMessage = "An account whith this username already exists";
                }
                else
                {
                    ViewBag.errorMessage = "An account whith this email already exists";
                }
                return View("Login", user);
            }

            byte[] generatedSalt;
            user.Password = Hashing.HashPasword(user.Password, out generatedSalt);
            user.Salt = generatedSalt;

            _context.Add(user);
            await _context.SaveChangesAsync();

            ViewBag.errorMessage = "SignUp succesful please log in with your credentials";
            return View("Login", user);
        }


        //public IActionResult Search()
        //{
        //    return View();
        //}
    }
}