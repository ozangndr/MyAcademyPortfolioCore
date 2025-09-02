using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class SocialMediaController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            var SocialMedia = context.SocialMedias.FirstOrDefault();
            return View(SocialMedia);
        }
              

        [HttpPost]
        public IActionResult Index(SocialMedia socialMedia)
        {
            if(!ModelState.IsValid)
            {
                return View(socialMedia);
            }
            context.SocialMedias.Update(socialMedia);
            context.SaveChanges();
            TempData["SuccessMessage"] = "Sosyal medya bilgileri başarıyla güncellendi!";

            return RedirectToAction("Index");
        }


    }
}
