using ETickets.DataAccess;
using ETickets.Models;
using ETickets.Utility;
using Microsoft.AspNetCore.Mvc;

namespace ETickets.Areas.Admin.Controllers
{
    [Area(SD.AdminArea)]
    public class CategoryController : Controller
    {
        private ApplictionDbContext _context = new();
        public IActionResult Index()
        {
            var Categories=_context.Categories.ToList();
            return View(Categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(!ModelState.IsValid)
            {
                return View(category);
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            TempData["Success-Notification"] = "Add Cinema Successfully";

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var  Category = _context.Categories.FirstOrDefault(e =>e.Id == id);
            if (Category == null) 
            { 
               return NotFound();
            }
            return View(Category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            _context.Categories.Update(category);
            _context.SaveChanges();
            TempData["Success-Notification"] = "Add Cinema Successfully";

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
           var Category= _context.Categories.FirstOrDefault(e => e.Id == id);
            if (Category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(Category);
            _context.SaveChanges();
            TempData["Success-Notification"] = "Add Cinema Successfully";

            return RedirectToAction(nameof(Index));
        }


    }
}
