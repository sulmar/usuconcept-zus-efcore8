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

W celu łatwiejszej identyfikacji zapytań w narzędziach takich jak _profiler_ warto dodać metodę `TagWith`.
~~~ csharp
var customers =  context.Customers
                  .Where(c => c.FirstName.StartsWith("A"))
                  .TagWith("This is my query!");
~~~                 

W rezultacie zostanie dodanie komentarz w nagłówku zapytania:
~~~
 -- This is my query!

 ...
~~~


# ToQueryString

Metoda `ToQueryString` umożliwia wyświetlenie zapytania SQL:

~~~ csharp
var query = context.Customers.Where(c => c.FirstName.StartsWith("A"));
Console.WriteLine(query.ToQueryString());
~~~