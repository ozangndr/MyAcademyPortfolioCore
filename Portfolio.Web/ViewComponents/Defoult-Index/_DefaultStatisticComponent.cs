using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents.Defoult_Index
{
    public class _DefaultStatisticComponent(PortfolioContext context):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.projectCount = context.Projects.Count();
            ViewBag.SkillsCount = context.Skills.Count();
            ViewBag.readMessagesCount = context.UserMessages.Count(x => x.IsRead == true);
            ViewBag.unReadMessagesCount = context.UserMessages.Count(x => x.IsRead == false);
            ViewBag.testimonialCount=context.Testimonials.Count();
            return View();
        }
    }
}
