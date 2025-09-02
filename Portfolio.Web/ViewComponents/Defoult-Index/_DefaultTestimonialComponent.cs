using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents.Defoult_Index
{
    public class _DefaultTestimonialComponent(PortfolioContext context):ViewComponent
    {
       public IViewComponentResult Invoke()
        {
            var testimonial=context.Testimonials.ToList();
            return View(testimonial);
        }
    }
}
