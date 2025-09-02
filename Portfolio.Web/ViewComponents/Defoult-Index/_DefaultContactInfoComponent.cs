using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents.Defoult_Index
{
    public class _DefaultContactInfoComponent(PortfolioContext context):ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var ContactInfo=context.ContactInfos.ToList();
            return View(ContactInfo);
        }
    }
}
