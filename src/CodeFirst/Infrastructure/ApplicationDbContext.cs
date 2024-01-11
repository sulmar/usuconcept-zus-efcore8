using CodeFirst.Configurations;
using CodeFirst.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Infrastructure;

// dotnet add package Microsoft.EntityFrameworkCore.SqlServer
internal class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .ApplyConfiguration(new CustomerConfiguration())
            .ApplyConfiguration(new ProductConfiguration());


        // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }



}
