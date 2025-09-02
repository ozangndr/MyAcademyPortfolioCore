using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Web.ViewComponents.Defoult_Index
{
    public class _DefaultHeroComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {            
            return View();
        }
    }
}
