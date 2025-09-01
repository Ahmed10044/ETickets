using ETickets.DataAccess;
using ETickets.Models;
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
        [HttpGet]
        public IActionResult Create()
        {
            var Categories = _context.Categories;
            var Cinemas = _context.Cinemas;
            var Actors = _context.Actors;

            var Movie = new CategoryAndCineamAndActorVM()
            {
                Cinemas = Cinemas.ToList(),
                Categories = Categories.ToList(),
                Actors = Actors.ToList(),
            };
            return View(Movie);
        }
        [HttpPost]
        public IActionResult Create(Movie movie,List<int> actorId)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            foreach (var item in actorId)
            {
               
               _context.ActorMovies.Add(new ActorMovie
                {
                  MovieId = movie.Id,
                  ActorId= item,
                 });
            _context.SaveChanges();

            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.FirstOrDefault(e=>e.Id==id);
            var Cinemas=_context.Cinemas;
            var Categories =_context.Categories;
            
            var actorsMovie = _context.ActorMovies.Include(e => e.Actor).Include(e => e.Movie);

            var Movie = new MovieAndMovieActorsVM()
            {
                Movie = movie,
                ActorMovies = actorsMovie.ToList(),
                Cinemas= Cinemas.ToList(),
                Categories=Categories.ToList(),
                
            };

            return View(Movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie, List<int> actorId)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
            foreach (var item in actorId)
            {

                _context.ActorMovies.Add(new ActorMovie
                {
                    MovieId = movie.Id,
                    ActorId = item,
                });
                _context.SaveChanges();

            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.FirstOrDefault(e => e.Id == id);
            if(movie == null)
            {
                return NotFound();
            }
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            var actors=_context.ActorMovies;
            foreach (var item in actors.Where(e=>e.MovieId==id))
            {
                _context.ActorMovies.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

