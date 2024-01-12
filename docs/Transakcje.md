
# Transakcje bazy danych

~~~ csharp
var transaction = context.Database.BeginTransaction();

try
{
    context.Actors.Add(new Actor { FirstName = "a", LastName = "a" });
    context.SaveChanges();

    context.Actors.Add(new Actor { FirstName = "b", LastName = "b" });
    context.SaveChanges();

    transaction.Commit();

}
catch (Exception)
{
    transaction.Rollback();
}
~~~