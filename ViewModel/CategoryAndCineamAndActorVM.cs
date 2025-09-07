using ETickets.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ETickets.ViewModel
{
    public class CategoryAndCineamAndActorVM
    {
        public List<Category>? Categories { get; set; }
        public List<Cinema>? Cinemas { get; set; }
        public List<Actor>? Actors { get; set; }
        public Movie movie { get; set; }
        ////public Cinema? cinema { get; set; }
        ////public Category? category { get; set; }
        public ActorMovie ActorMovie { get; set; }

    }
}
