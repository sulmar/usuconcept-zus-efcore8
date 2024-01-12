using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public partial class SakilaContext : DbContext
{
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Film>()
            .Navigation(p => p.Language)
            .AutoInclude();
            
    }
}
