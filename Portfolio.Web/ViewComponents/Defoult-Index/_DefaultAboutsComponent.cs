using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents.Defoult_Index
{
    public class _DefaultAboutsComponent(PortfolioContext context):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var About=context.Abouts.FirstOrDefault();
            return View(About);
        }
    }
}
