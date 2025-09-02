using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents.AdminLayout
{
    public class _AdminLayoutHeaderComponent(PortfolioContext context):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.username = HttpContext.Session.GetString("UserName");
            return View();
        }
    }
}
