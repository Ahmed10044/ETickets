using ETickets.DataAccess;
using ETickets.Models;
using ETickets.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return View();
        }
        [HttpPost]
        public IActionResult Create(Cinema cinema)
        {
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

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
            _context.Cinemas.Update(cinema);
            _context.SaveChanges();
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
            return RedirectToAction(nameof(Index));
        }
    }
}
