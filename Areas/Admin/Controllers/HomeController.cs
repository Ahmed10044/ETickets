using ETickets.Utility;
using Microsoft.AspNetCore.Mvc;

namespace ETickets.Areas.Admin.Controllers
{
    [Area(SD.AdminArea)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
