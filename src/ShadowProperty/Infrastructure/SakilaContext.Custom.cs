using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public partial class SakilaContext : DbContext
{
    public override int SaveChanges()
    {
        var addedEntities = ChangeTracker.Entries().Where(e=>e.State == EntityState.Added);

        foreach (var entity in addedEntities)
        {
            entity.Property("created_date").CurrentValue = DateTime.UtcNow;
        }

        return base.SaveChanges();
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>()
            .Property<DateTime>("created_date");
            
    }
}
