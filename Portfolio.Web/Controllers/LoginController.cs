using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class LoginController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = context.UserLogins.FirstOrDefault(u => u.UserName == username && u.UserPassword == password);
            if (user != null)
            {
                // Başarılı giriş → istediğin sayfaya yönlendir
                return RedirectToAction("Index", "Category");
            }
            else
            {
                // Hatalı giriş → ViewComponent tekrar render edilir
                ViewData["LoginError"] = "Kullanıcı adı veya şifre hatalı";
                return ViewComponent("_DefaultLoginComponent");
            }
        }


        public IActionResult ProfileSetting()
        {
            ViewBag.Id = context.UserLogins.FirstOrDefault()?.UserLoginId;
            ViewBag.Name = context.UserLogins.FirstOrDefault()?.UserName;
            ViewBag.Password = context.UserLogins.FirstOrDefault()?.UserPassword;
            return View();
        }

        [HttpPost]
        public IActionResult ProfileSetting(UserLogin userLogin)
        {
            context.UserLogins.Update(userLogin);
            context.SaveChanges();
            return RedirectToAction("Index", "Statistic");
        }
    }
}
