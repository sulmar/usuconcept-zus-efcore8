
~~~ csharp
FormattableString sql = $"SELECT * FROM film";

var films = context.Customers.FromSql(sql);
~~~ 

Istnieje możliwość łączenia zapytania SQL z Linq
~~~ csharp
var sql = $"SELECT * FROM film";

var films = context.Customers.FromSql(sql)
 .Where(f => f.Rating == 'PG')
 .OrderBy(f => f.Title)
 .ToList();
~~~ 


Istnieje również możliwość pobierania powiązanych danych:
~~~ csharp
var sql = $"SELECT * FROM film";

var films = context.Customers.FromSql(sql)
 .Include(p=>p.Language)
 .ToList();
~~~ 

Istnieje również możliwość tworzenia zapytań z użyciem **Table-Valued Function (TVF)**
~~~ csharp
var searchTerm = "Lorem ipsum";
var sql = $"SELECT * FROM dbo.SearchFilms({searchTerm})"; 

var films = context.Customers.FromSql(sql)
 .Where(f => f.Rating == 'PG')
 .OrderBy(f => f.Title)
 .ToList();
~~~