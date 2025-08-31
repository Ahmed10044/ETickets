using ETickets.Models;
using Microsoft.EntityFrameworkCore;

namespace ETickets.DataAccess
{
    public class ApplictionDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
              base.OnConfiguring(optionsBuilder);

               optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ETickets;" +
                            "Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");
         }

    }
}
