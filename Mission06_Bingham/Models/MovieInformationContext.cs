using Microsoft.EntityFrameworkCore;

namespace Mission06_Bingham.Models
{
    public class MovieInformationContext : DbContext
    {
        public MovieInformationContext(DbContextOptions<MovieInformationContext> options) : base (options)
        {        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
                .Property(m => m.CopiedToPlex)
                .HasConversion<int?>(
                    v => v.HasValue ? (v.Value ? 1 : 0) : (int?)null,  // Convert bool? to int (1 or 0)
                    v => v.HasValue ? (v.Value == 1) : (bool?)null     // Convert int (1 or 0) to bool?
                );

            modelBuilder.Entity<Movie>()
                .Property(m => m.Edited)
                .HasConversion<int?>(
                    v => v.HasValue ? (v.Value ? 1 : 0) : (int?)null,  // Convert bool? to int (1 or 0)
                    v => v.HasValue ? (v.Value == 1) : (bool?)null     // Convert int (1 or 0) to bool?
                );

        }
    }
}
