using System.ComponentModel.DataAnnotations;

namespace ETickets.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; }

        public ICollection<Movie> movies { get; set; } = new List<Movie>();

    }
}
