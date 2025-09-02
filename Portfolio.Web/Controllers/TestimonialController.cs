using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class TestimonialController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            var testimonials=context.Testimonials.ToList();
            return View(testimonials);
        }


        public IActionResult CreateTestimonial()
        {
           return View();
        }

        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial testimonial)
        {
            context.Testimonials.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult EditTestimonial(int id)
        {
            var testimonial = context.Testimonials.FirstOrDefault(t => t.TestimonialId == id);
            ViewBag.ReviewList = new SelectList(
                new List<int> { 1, 2, 3, 4, 5 },
                testimonial.Review
            );
            return View(testimonial);
        }

        [HttpPost]
        public IActionResult EditTestimonial(Testimonial testimonial)
        {
            context.Testimonials.Update(testimonial);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTestimonial(int id)
        {
            var testimonial=context.Testimonials.Find(id);
            context.Testimonials.Remove(testimonial);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
