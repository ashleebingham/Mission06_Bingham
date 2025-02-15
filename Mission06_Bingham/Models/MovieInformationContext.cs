using Microsoft.EntityFrameworkCore;

namespace Mission06_Bingham.Models
{
    public class MovieInformationContext : DbContext
    {
        public MovieInformationContext(DbContextOptions<MovieInformationContext> options) : base (options)
        {

        }

        public DbSet<MovieAddition> MovieDetails { get; set; }
    }
}
