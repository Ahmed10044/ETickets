using System.ComponentModel.DataAnnotations;

namespace ETickets.Models
{
    public class Actor
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(15)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(15)]
        public string LastName { get; set; }
        [Required]
        public string Bio { get; set; }
        [Required]
        public string ProfilePicture { get; set; }
        [Required]
        public string News { get; set; }
        public ICollection<Movie> movies { get; set; } = new List<Movie>();

    }
}
