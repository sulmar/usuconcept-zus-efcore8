
# First Level Cache


Pojęcie to również jest znane jako "lokalna pamięć podręczna" (localcache) lub "pamięć podręczna kontekstu" (context cache).

EF Core używa pamięci podręcznej pierwszego poziomu do śledzenia encji, które zostały zapytane lub dodane do kontekstu. Podczas zapytania o encję EF Core sprawdza, czy już znajduje się w pamięci podręcznej pierwszego poziomu, zanim wyśle zapytanie do bazy danych. Jeśli znajdzie encję w pamięci podręcznej, zwraca tę encję, zamiast przeprowadzać zapytanie do bazy danych. 

1. Install the appropriate NuGet packages:
- Microsoft.Extensions.Caching.Memory
- Microsoft.Extensions.DependencyInjection

2. 
~~~ csharp
services.AddMemoryCache();

services.AddDbContext<SakilaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MyDb"))
.UseMemoryCache(myCache));

~~~

~~~ csharp
base.OnModelCreating(modelBuilder);

modelBuilder.Entity<MyEntity>()
  .HasQueryFilter(e => !e.IsDeleted)
  .Cacheable();
~~~ 
