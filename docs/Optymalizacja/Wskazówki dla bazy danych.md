Dzięki interceptorom i [[TagWith]] można wysyłania wskazówki do bazy danych, które mogą pomóc w zwiększeniu wydajności.


1. Dodaj `TagWith` 

~~~ csharp
var customers = context.Customers.TagWith("Use hint: robust plan").ToList();
~~~

2. Utwórz klasę, która zmodyfikuje zapytanie SQL jeśli znajdzie zdefiniowany powyżej komentarz:

~~~ csharp
public class TaggedQueryCommandInterceptor : DbCommandInterceptor
{
    public override InterceptionResult<DbDataReader> ReaderExecuting(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result)
    {
        ManipulateCommand(command);

        return result;
    }

    public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result,
        CancellationToken cancellationToken = default)
    {
        ManipulateCommand(command);

        return new ValueTask<InterceptionResult<DbDataReader>>(result);
    }

    private static void ManipulateCommand(DbCommand command)
    {
        if (command.CommandText.StartsWith("-- Use hint: robust plan", StringComparison.Ordinal))
        {
            command.CommandText += " OPTION (ROBUST PLAN)";
        }
    }
}
~~~

W rezultacie zostanie wysłane zapytanie ze wskazówką:
~~~ sql
-- Use hint: robust plan

SELECT [c].[customer_id], [c].[first_name]
FROM [customer] AS [c] OPTION (ROBUST PLAN)
~~~
