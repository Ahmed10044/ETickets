using ETickets.DataAccess;
using ETickets.Models;
using ETickets.Utility;
using Microsoft.AspNetCore.Mvc;

namespace ETickets.Areas.Admin.Controllers
{
    [Area(SD.AdminArea)]
    public class ActorController : Controller
    {
        private ApplictionDbContext _context = new();

        public IActionResult Index()
        {
            var Actors=_context.Actors;
            return View(Actors.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            //var Actors=_context.Actors;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            _context.Actors.Add(actor);
            _context.SaveChanges();
            TempData["Success-Notification"] = "Add Cinema Successfully";

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var actor = _context.Actors.FirstOrDefault(x => x.Id == id);
            if (actor == null)
            {
                return NotFound();
            }
            return View(actor);
        }
        [HttpPost]
        public IActionResult Edit(Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            _context.Actors.Update(actor);
            _context.SaveChanges();
            TempData["Success-Notification"] = "Add Cinema Successfully";

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var Actor=_context.Actors.FirstOrDefault(e => e.Id == id);
            if(Actor == null)
            {
                return NotFound();
            }
            _context.Actors.Remove(Actor);
            _context .SaveChanges();  
            TempData["Success-Notification"] = "Add Cinema Successfully";

            return RedirectToAction(nameof(Index));
        }


    }


}
