using Microsoft.EntityFrameworkCore;
using Sakila.Domain.Model;

namespace Sakila.Infrastructure;

public partial class SakilaContext : DbContext
{
    public virtual DbSet<Award> Awards { get; set; }

    // Metoda częściowa
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .Navigation(p => p.Address)
            .AutoInclude();

        modelBuilder.Entity<Address>()
            .Navigation(p => p.City)
            .AutoInclude();
    }
}
