using MappingView.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public partial class SakilaContext : DbContext
{
    public DbSet<FilmsByRating> FilmsByRatings { get; set; }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FilmsByRating>()
            .ToView("FilmsByRating")
            .HasNoKey();

        modelBuilder.Entity<FilmsByRating>().
            Property(e => e.FilmCount)
            .HasColumnName("film_count");

    }
}
