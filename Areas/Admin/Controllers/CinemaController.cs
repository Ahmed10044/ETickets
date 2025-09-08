using ETickets.DataAccess;
using ETickets.IRepositories.IRepositories;
using ETickets.Models;
using ETickets.Repositories;
using ETickets.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;
using System.Threading.Tasks;

namespace ETickets.Areas.Admin.Controllers
{
    [ Area(SD.AdminArea)]
    public class CinemaController : Controller
    {
        private  Repository<Cinema> _cinemaRepo;

        //public CinemaController(IRepository<Cinema> cinemaRepo)
        //{
        //    _cinemaRepo = cinemaRepo;
        //}

        public async Task<IActionResult> Index()
        {
            var Cinemas=await _cinemaRepo.GetAsync();
            return View(Cinemas.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Cinema());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Cinema cinema)
        {
            if(!ModelState.IsValid)
            {
                return View(cinema);
            }
             await _cinemaRepo.CreateAsync(cinema);
             await _cinemaRepo.CommitAsync();
            TempData["Success-Notification"] = "Add Cinema Successfully";
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var cinema =await _cinemaRepo.GetOneAsync(e => e.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            return View(cinema);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            _cinemaRepo.Update(cinema);
            await _cinemaRepo.CommitAsync();
            TempData["Success-Notification"] = "Edit Cinema Successfully";

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var Cinema =await _cinemaRepo.GetOneAsync(e => e.Id == id);
            if (Cinema == null)
            {
                return NotFound();
            }
            _cinemaRepo.Delete(Cinema);
            await _cinemaRepo.CommitAsync();
            TempData["Success-Notification"] = "Delete Cinema Successfully";

            return RedirectToAction(nameof(Index));
        }
    }
}
