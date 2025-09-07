using ETickets.DataAccess;
using ETickets.Models;
using ETickets.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;

namespace ETickets.Areas.Admin.Controllers
{
    [ Area(SD.AdminArea)]
    public class CinemaController : Controller
    {
        private ApplictionDbContext _context = new();

        public IActionResult Index()
        {
            var Cinemas=_context.Cinemas.ToList();
            return View(Cinemas);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Cinema());
        }
        [HttpPost]
        public IActionResult Create(Cinema cinema)
        {
            if(!ModelState.IsValid)
            {
                return View(cinema);
            }
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            TempData["Success-Notification"] = "Add Cinema Successfully";
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(e => e.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            return View(cinema);
        }
        [HttpPost]
        public IActionResult Edit(Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            _context.Cinemas.Update(cinema);
            _context.SaveChanges();
            TempData["Success-Notification"] = "Edit Cinema Successfully";

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var Cinema = _context.Cinemas.FirstOrDefault(e => e.Id == id);
            if (Cinema == null)
            {
                return NotFound();
            }
            _context.Cinemas.Remove(Cinema);
            _context.SaveChanges();
            TempData["Success-Notification"] = "Delete Cinema Successfully";

            return RedirectToAction(nameof(Index));
        }
    }
}
