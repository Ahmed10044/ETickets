using ETickets.Models;

namespace ETickets.ViewModel
{
    public class MovieAndMovieActorsVM
    {
        public Movie? Movie { get; set; }
        public List<ActorMovie>? ActorMovies { get; set; }
        public List<Movie>? Movies { get; set; }
        public List<Category> Categories { get; set; }
        public List<Cinema> Cinemas { get; set; }
    }
}
