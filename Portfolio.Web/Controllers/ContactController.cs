using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class ContactController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            var contact=context.ContactInfos.FirstOrDefault();
            return View(contact);
        }

        [HttpPost]
        public IActionResult Index(ContactInfo contactInfo)
        {
            if (!ModelState.IsValid)
            {
                return View(contactInfo);
            }

            // Veritabanında güncelleme
            context.ContactInfos.Update(contactInfo);
            context.SaveChanges();

            // Başarılı mesajı TempData ile gönder
            TempData["SuccessMessage"] = "İletişim bilgileri başarıyla güncellendi!";

            // Redirect ile GET metodunu çağır, böylece form yeniden submit olmaz
            return RedirectToAction("Index");
        }


    }
}
