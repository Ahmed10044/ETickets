using System.ComponentModel.DataAnnotations;

namespace ETickets.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(15)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string CinemaLogo { get; set; }
        [Required]
        public string Address { get; set; }

        public ICollection<Movie> movies { get; set; } = new List<Movie>();

    }
}
