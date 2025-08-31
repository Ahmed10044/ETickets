using ETickets.DataAccess;
using ETickets.Utility;
using ETickets.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Areas.Admin.Controllers
{
    [Area(SD.AdminArea)]
    public class MovieController : Controller
    {
        private ApplictionDbContext _context = new();
        public IActionResult Index()
        {
            var movies = _context.Movies.Include(e => e.category).Include(e => e.cinema);

            var movieActors = _context.ActorMovies.Include(e => e.Actor).Include(e => e.Movie);

            var Movie = new MovieAndMovieActorsVM()
            {
                Movies = movies.ToList(),
                ActorMovies = movieActors.ToList(),
            };

            return View(Movie);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
