using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ToDoProject.Web.Models;
using Microsoft.AspNetCore.Session;

namespace ToDoProject.Web.Controllers
{
    public class LoginController : Controller
    {
        ToDoDbContext db = new ToDoDbContext();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User model)
        {
            bool isUservalid = false;

            User user = db.Users.Where(usr => usr.UserName == model.UserName && usr.UserPassword == model.UserPassword).SingleOrDefault();

            if (user != null)
            {
                isUservalid = true;
            }

            if (ModelState.IsValid && isUservalid)
            {
                HttpContext.Session.SetInt32("Id", user.Id);
                var claims = new List<Claim>();

                claims.Add(new Claim(ClaimTypes.Name, user.UserName));

                var identity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,principal).Wait();

                return RedirectToAction("Index", "Task");
            }
            else
            {
                ViewData["message"] = "Geçersiz kullanıcı adı veya şifre!";
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
