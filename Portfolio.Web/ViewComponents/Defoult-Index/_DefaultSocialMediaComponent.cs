using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents.Defoult_Index
{
    public class _DefaultSocialMediaComponent(PortfolioContext context):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var sociallinks=context.SocialMedias.ToList();
            return View(sociallinks);
        }
    }
}
