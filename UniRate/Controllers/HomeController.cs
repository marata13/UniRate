﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
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

            ViewBag.LoggedIn = HttpContext.Request.Cookies.ContainsKey("LoginCookie");
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

                ViewBag.LoggedIn = HttpContext.Request.Cookies.ContainsKey("LoginCookie");
                return View("Login", user);
            }

            var loginUser = await _context.User
                .FirstOrDefaultAsync(m => m.UserName == user.UserName);

            if (loginUser == null)
            {
                //wrong username
                ViewBag.errorMessage = "The username-password combination you entered is wrong";

                ViewBag.LoggedIn = HttpContext.Request.Cookies.ContainsKey("LoginCookie");
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


                ViewBag.LoggedIn = true;
                return View("HomePage", user);

            }
            //wrong password
            ViewBag.errorMessage = "The username-password combination you entered is wrong";

            ViewBag.LoggedIn = HttpContext.Request.Cookies.ContainsKey("LoginCookie");
            return View("Login", user);
        }


        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            ViewBag.LoggedIn = false;
            return View("HomePage");
        }


        public IActionResult HomePage()
        {
            ViewBag.LoggedIn = HttpContext.Request.Cookies.ContainsKey("LoginCookie");
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> UniResults(string? UniName, Guid? Id)
        {
            var university = await _context.University.FirstOrDefaultAsync(m => m.Name == UniName);

            if (university == null)
            {
                university = await _context.University.FirstOrDefaultAsync(m => m.Id == Id);
            }

            ViewBag.LoggedIn = HttpContext.Request.Cookies.ContainsKey("LoginCookie");

            if (ViewBag.LoggedIn)
            {
                var User = await _context.User.FirstOrDefaultAsync(m => m.UserName == HttpContext.User.Identity.Name);

                try
                {
                    ViewBag.IsFavoriteUni = User.FavoriteUniversities.Exists(m => m.University == university);
                }
                catch (NullReferenceException)
                {
                    ViewBag.IsFavoriteUni = false;
                }
            }
            else
            {
                ViewBag.IsFavoriteUni = false;
            }

            return View(university);
        }


        public IActionResult DepResults()
        {
            ViewBag.LoggedIn = HttpContext.Request.Cookies.ContainsKey("LoginCookie");
            return View();
        }


        public IActionResult TopRated()
        {
            ViewBag.LoggedIn = HttpContext.Request.Cookies.ContainsKey("LoginCookie");
            return View();
        }


        public async Task<IActionResult> Unies()
        {
            ViewBag.LoggedIn = HttpContext.Request.Cookies.ContainsKey("LoginCookie");
            return _context.University != null ?
                          View(await _context.University.ToListAsync()) :
                          Problem("Entity set 'UniRateContext.User'  is null.");
        }
        public IActionResult About()
        {
            ViewBag.LoggedIn = HttpContext.Request.Cookies.ContainsKey("LoginCookie");
            return View();
        }
        public IActionResult Contact()
        {
            ViewBag.LoggedIn = HttpContext.Request.Cookies.ContainsKey("LoginCookie");
            return View();
        }


        public IActionResult Index()
        {
            ViewBag.LoggedIn = HttpContext.Request.Cookies.ContainsKey("LoginCookie");
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.LoggedIn = HttpContext.Request.Cookies.ContainsKey("LoginCookie");
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
            ViewBag.LoggedIn = HttpContext.Request.Cookies.ContainsKey("LoginCookie");
            return View("Login", user);
        }
    }
}