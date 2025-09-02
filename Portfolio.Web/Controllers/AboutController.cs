using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class AboutController : Controller
    {
        private readonly PortfolioContext _context;

        public AboutController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var about = _context.Abouts.FirstOrDefault();
            return View(about);
        }

        [HttpPost]
        public IActionResult Index(About about)
        {
            if(!ModelState.IsValid)
            {
                return View(about);
            }

            _context.Abouts.Update(about);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Bilgilerim başarıyla güncellendi!";
            return RedirectToAction("Index");
        }
    }
}
