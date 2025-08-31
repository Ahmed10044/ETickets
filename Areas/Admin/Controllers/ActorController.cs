using ETickets.DataAccess;
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
        public IActionResult Create()
        {
            return View();
        }
    }

    
}
