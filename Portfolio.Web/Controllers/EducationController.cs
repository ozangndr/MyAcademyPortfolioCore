using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class EducationController : Controller
    {
        private readonly PortfolioContext _context;

        public EducationController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var education=_context.Educations.ToList();
            return View(education);
        }

        
        public IActionResult CreateEducation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateEducation(Education education)
        {
            _context.Add(education);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult EditEducation(int id)
        {
            var education = _context.Educations.Find(id);
            return View(education);
        }
        [HttpPost]
        public IActionResult EditEducation(Education education)
        {
            _context.Update(education);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEducation(int id)
        {
            var education = _context.Educations.Find(id);
            _context.Educations.Remove(education);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
