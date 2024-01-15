using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public partial class SakilaContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     => optionsBuilder
     .UseSqlServer("Data Source=(local);Initial Catalog=sakila;Integrated Security=True;TrustServerCertificate=True")
       .LogTo(Console.WriteLine);
       
        

}
