using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public partial class SakilaContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      => optionsBuilder
      .UseSqlServer("Data Source=(local);Initial Catalog=sakila;Integrated Security=True;TrustServerCertificate=True",
           options => options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));

    // Globalne włączenie dzielenia zapytań

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Film>()
            .Navigation(p => p.Language)
            .AutoInclude();
            
    }
}
