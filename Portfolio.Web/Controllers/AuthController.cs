using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;
using Portfolio.Web.Models;
using System.Security.Claims;

namespace Portfolio.Web.Controllers
{
    [AllowAnonymous]
    public class AuthController(PortfolioContext context) : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user=context.UserLogins.FirstOrDefault(x=>x.UserName==model.UserName && x.UserPassword==model.UserPassword);

            if(user is  null)
            {
                ModelState.AddModelError("","Kullanıcı adı veya şifre hatalı");
                return View(model);
               
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim("fullName",string.Join(" ",user.FirstName,user.LastName))
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
                IsPersistent = false,
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                           new ClaimsPrincipal(claimsIdentity),
                                           authProperties);

            HttpContext.Session.SetString("UserName", user.UserName);

            return RedirectToAction("Index", "Statistic");

           
        }

        
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear(); 
            return RedirectToAction("Index", "Default");
        }


        public IActionResult ProfileSetting()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProfileSetting(ChangeUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // eski bilgileri kontrol et
            var user = context.UserLogins
                .FirstOrDefault(x => x.UserName == model.OldUserName
                                  && x.UserPassword == model.OldPassword);

            if (user == null)
            {
                ModelState.AddModelError("", "Mevcut kullanıcı adı veya şifre hatalı.");
                return View(model);
            }

            // yeni bilgileri kaydet
            user.UserName = model.NewUserName;
            user.UserPassword = model.NewPassword;
            context.SaveChanges();

            ViewBag.Message = "Kullanıcı bilgileri başarıyla güncellendi.";
            return View();
        }



    }
}
