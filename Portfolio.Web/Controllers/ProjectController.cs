using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Web.Context;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Controllers
{
    public class ProjectController(PortfolioContext context) : Controller
    {
        private void CategoryDropDown()
        {
            var categories = context.Categories.ToList();
            ViewBag.Categories = (from x in categories
                                  select new SelectListItem
                                  {
                                      Text = x.CategoryName,
                                      Value = x.CategoryId.ToString()
                                  }).ToList();
        }
        
        public IActionResult Index()
        {
            //Eager Loading
            var project=context.Projects.Include(x=>x.Category).ToList();
            return View(project);
        }

        public IActionResult CreateProject()
        {
            CategoryDropDown();
            return View();
        }
        [HttpPost]
        public IActionResult CreateProject(Project model)
        {
            CategoryDropDown();

            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                context.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            

        }

        public IActionResult EditProject(int id)
        {
            CategoryDropDown();
            var project = context.Projects.Find(id);
            return View(project);
        }

        [HttpPost]
        public IActionResult EditProject(Project project)
        {
            CategoryDropDown();
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                context.Projects.Update(project);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }

        public IActionResult DeleteProject(int id)
        {
            
            var project = context.Projects.Find(id);
            context.Projects.Remove(project);
            context.SaveChanges();
            return RedirectToAction("Index");
             
        }
    }
}
