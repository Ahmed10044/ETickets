using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ETickets.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(15)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string ImgUrl { get; set; }
        [Required]
        public string TrailerUrl { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public MovieStatus MovieStatus { get; set; }
        
        [Required]
        public int CinemaId { get; set; }
        public Cinema cinema { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category category { get; set; }

        public ICollection<Actor> actors { get; set; } = new List<Actor>();



    }
}
