using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.ViewComponents.Defoult_Index
{
    public class _DefaultSendMessageComponent(PortfolioContext context):ViewComponent
    {
        public IViewComponentResult Invoke()
        {           
            return View();
        }
    }
}
