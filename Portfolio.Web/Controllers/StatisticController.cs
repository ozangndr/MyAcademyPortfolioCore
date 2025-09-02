using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.Controllers
{
    
    public class StatisticController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            ViewBag.projectCount = context.Projects.Count();
            ViewBag.SkillAverage = context.Skills.Any() ? context.Skills.Average(x => x.Percentage): 0;
            ViewBag.maxReviewOwner = context.Testimonials.OrderByDescending(x => x.Review).Select(x => x.Name).FirstOrDefault();
            ViewBag.reviewAverage = context.Testimonials.Any() ? context.Testimonials.Average(x => x.Review).ToString() : "Değerlendirme Yok";

            ViewBag.messageCount=context.UserMessages.Count();
            ViewBag.readMessagesCount = context.UserMessages.Count(x => x.IsRead == true);
            ViewBag.unReadMessagesCount = context.UserMessages.Count(x => x.IsRead == false);
            ViewBag.lastMesageOwner = context.UserMessages.OrderByDescending(x=>x.Name).Select(x=>x.Name).FirstOrDefault();

           

            
            ViewBag.experienceCount=context.Experiences.Count();
            #region Toplam Çalışma yılı
            var experiences =context.Experiences.ToList();
            int toplamyil=0;
            foreach (var item in experiences)
            {
                int end;
                if(int.TryParse(item.EndYear,out end))
                {
                    toplamyil = toplamyil+(end - item.StartYear);
                }
                else
                {
                    toplamyil= toplamyil + (DateTime.Now.Year - item.StartYear);
                }
            }
            ViewBag.experienceTotal=toplamyil;

            #endregion

            ViewBag.educationCount=context.Educations.Count();

            #region Toplam Eğitim yılı
            var education = context.Educations.ToList();
            int totaleducation = 0;
            foreach (var item in education)
            {
                int end;
                if (int.TryParse(item.EndYear, out end))
                {
                    totaleducation = totaleducation + (end - item.StartYear);
                }
                else
                {
                    totaleducation = totaleducation + (DateTime.Now.Year - item.StartYear);
                }
            }
            ViewBag.educationTotal = totaleducation;

            #endregion


            return View();
        }
    }
}
