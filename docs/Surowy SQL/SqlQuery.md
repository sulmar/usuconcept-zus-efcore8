Metoda _SqlQuery_ umożliwia pobieranie danych bez potrzeby mapowania typów w kontekscie:

```csharp
var sql = $"select COUNT(*) from film_category where category_id = 3";
var total = _context.Database.SqlQuery<int>(sql).Single();
```

Od EF Core 8 istnieje możliwość mapowania na typy złożone (klasy lub rekordy):

~~~ csharp
public record CustomerDTO(string FirstName, string LastName);
~~~

~~~ csharp
var sql = $"SELECT first_name AS FirstName, last_name AS LastName";

var customers = context.Database.SqlQuery<CustomerDTO>(sql)
    .Where(a => a.firstname.Contains("a"))
    .ToList();
~~~~
