using ETickets.Models;

namespace ETickets.ViewModel
{
    public class CategoryAndCineamAndActorVM
    {
        public List<Category>? Categories { get; set; }
        public List<Cinema>? Cinemas { get; set; }
        public List<Actor>? Actors { get; set; }
    }
}
