using System.Diagnostics;
using ETickets.DataAccess;
using ETickets.Models;
using ETickets.Utility;
using ETickets.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ETickets.Areas.Customer.Controllers
{
    [Area(SD.CustomerArea)] 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplictionDbContext _context = new();
        


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(String? MovieName,int? CategoryId,int? CinemaId,int page=1)
        {
            var movies=_context.Movies.Include(e=>e.cinema).Include(e=>e.category).AsQueryable();
            if (MovieName is not null)
            {
                movies = movies.Where(e => e.Name.Contains(MovieName));
                ViewBag.MovieName = MovieName;
            }
            if (CategoryId is not null)
            {
                movies = movies.Where(e => e.category.Id == CategoryId);
                ViewBag.Category = CategoryId;
            }
            if (CinemaId is not null)
            {
                movies = movies.Where(e => e.cinema.Id == CinemaId);
                ViewBag.CinemaId = CinemaId;
            }
            //Category filter
            var Categories=_context.Categories;
            ViewBag.Categories=Categories.ToList();
            //Cinema filter
            var Cinemas = _context.Cinemas;
            ViewBag.Cinemas = Cinemas.ToList();
            // Paginitation
            var totalNumberOfPages = Math.Ceiling(movies.Count() / 8.0);
            var currentPage = page;
            ViewBag.totalNumberOfPages = totalNumberOfPages;
            ViewBag.currentPage = currentPage;

            movies = movies.Skip((page - 1) * 8).Take(8);



            return View(movies.ToList());
        }


        public IActionResult Details(int Id)
        {
            var movies= _context.Movies.Include(e=>e.category).Include(e=>e.cinema).FirstOrDefault(e => e.Id == Id);

            var movieActors = _context.ActorMovies.Include(e => e.Actor).Include(e => e.Movie).Where(e=>e.MovieId==Id);

            var Movie = new MovieAndMovieActorsVM()
            {
                Movie = movies,
                ActorMovies = movieActors.ToList(),
            };
                

            return View(Movie);
        }
        
        public IActionResult Cinemas()
        {
            var Cinemas= _context.Cinemas.ToList();
            return View(Cinemas);
        }
        

        public IActionResult Categories()
        {
            var Categories = _context.Categories.ToList();
            return View(Categories);
        }

        public IActionResult Actor(int id)
        {
            var Actor = _context.Actors.FirstOrDefault(e=>e.Id==id);
            return View(Actor);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
