# ExecuteUpdate

Załóżmy, że chcesz podnieść ceny wypożyczenia wszystkim filmom. Typowa implementacja tej funkcji w programie EF Core wygląda następująco:

~~~ csharp
foreach (var film in context.Films)
{
    film.ReplacementCost += 1;
}
context.SaveChanges();
~~~

Metoda _SaveChanges_ wyśle osobne instrukcje sql _UPDATE_ dla każdego filmu:
~~~ sql
UPDATE [film] SET [replacement_cost] = [replacement_cost] + 1 WHERE film_id = 1
UPDATE [film] SET [replacement_cost] = [replacement_cost] + 1 WHERE film_id = 2
UPDATE [film] SET [replacement_cost] = [replacement_cost] + 1 WHERE film_id = 3
...
~~~

Począwszy od programu EF Core 7.0, możesz użyć metody `ExecuteUpdate` aby wykonać to samo znacznie wydajniej:

~~~ csharp
context.Films.ExecuteUpdate(s => s.SetProperty(e => e.ReplacementCost, e => e.ReplacementCost + 1));
~~~

Spowoduje to wysłanie następującej instrukcji SQL do bazy danych:
~~~ sql
UPDATE [film] SET [replacement_cost] = [replacement_cost] + 1;
~~~

Możesz równocześnie modyfikować kilka właściwości i stosować filtry:

~~~ csharp
using (var context = new LibraryContext())
{
    context.Films
        .Where(b => b.ReleaseYear.Year < 2018)
        .ExecuteUpdateAsync(s => s
            .SetProperty(a => a.Title, a => a.Title + " (" + a.ReleaseYear.Year + ")")
            .SetProperty(a => a.Description, a => a.Description + " ( This content was published in " + b.ReleaseYear.Year + ")"));
}
~~~~
# ExecuteDelete

W podobny sposób możesz wykonać masowane usuwanie rekordów:
~~~ csharp
context.Actors.ExecuteDelete();
~~~ 

Możesz również filtrować:
~~~ csharp
context.Actors.Where(a=>a.Name.Contains("John")).ExecuteDelete();
~~~ 

Spowoduje to wysłanie następującej instrukcji SQL do bazy danych:
~~~ sql
DELETE FROM [a]
FROM [actor] AS [a]
WHERE [a].[Name] LIKE N'%John%'
~~~ 