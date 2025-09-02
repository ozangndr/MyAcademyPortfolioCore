using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Context;

namespace Portfolio.Web.Controllers
{
    public class UserMessagesController(PortfolioContext context) : Controller
    {
        public IActionResult Index()
        {
            var messages = context.UserMessages.OrderBy(x => x.IsRead).ThenBy(x => x.UserMessageId).ToList();
            return View(messages);
        }

        
        public IActionResult ReadUserMessages()
        {
           
            return View();
        }

        [HttpPost]

        public IActionResult ReadUserMessages(int id)
        {
            var message = context.UserMessages.Find(id);
            message.IsRead = true;
            context.UserMessages.Update(message);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult DeleteUserMessages(int id)
        {
            var usermessage=context.UserMessages.Find(id);
            context.UserMessages.Remove(usermessage);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
