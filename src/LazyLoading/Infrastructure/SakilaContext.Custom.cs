using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

// dotnet add package Microsoft.EntityFrameworkCore.Proxies

public partial class SakilaContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
        .UseSqlServer("Data Source=(local);Initial Catalog=sakila;Integrated Security=True;TrustServerCertificate=True")
       // .UseLazyLoadingProxies()
        ;
}
