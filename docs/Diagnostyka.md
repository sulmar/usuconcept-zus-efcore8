# Logowanie

~~~ csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder
        .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True")
        .LogTo(Console.WriteLine, LogLevel.Information);
}
~~~ 

Gdy poziom rejestrowania jest ustawiony na `LogLevel.Information`wartość , program EF emituje komunikat dziennika dla każdego wykonania polecenia z upływem czasu.

# TagWith

~~~ csharp
var customers = context.People.TagWith("This is my spatial query!")
                     orderby f.Location.Distance(myLocation) descending
                     select f).Take(5).ToList();

	ToQueryString