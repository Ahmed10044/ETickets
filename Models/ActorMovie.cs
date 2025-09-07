using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ETickets.Models
{
    [PrimaryKey(nameof(ActorId), nameof(MovieId))]
    
    public class ActorMovie
    {
        //public int Id { get; set; }
        [Required]
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
        [Required]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
