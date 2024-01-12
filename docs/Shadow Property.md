**Shadow Property** to właściwość, która nie jest widoczne w modelu ale istnieje w bazie danych. 

Przydatne w wielu scenariuszach:
- definicja kluczy obcych
- pola metadanych (DateCreated, LastUpdated lub rowversion).
- brak dostępu do kodu źródłowego modelu

## Konfiguracja

~~~ csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
	modelBuilder.Entity<Customer>()
		.Property<DateTime>("LastUpdated");
}

~~~

https://www.learnentityframeworkcore.com/model/shadow-properties

## Ustawianie wartości Shadow Properties 

- Ręczne ustawianie wartości
~~~ csharp
context.Add(customer);
context.Entry(customer).Property("LastUpdated").CurrentValue = DateTime.UtcNow();
context.SaveChanges();
~~~

- automatycznie podczas zapisu
~~~ csharp
public overrride int SaveChanges()
{
    var addedEntities = ChangeTracker.Entries().Where(p=>p.State == EntityState.Added);

    foreach(var entry in addedEntities)
    {
        entry.Property("CreatedDate").CurrentValue = DateTime.UtcNow;
    }

    return base.SaveChanges();
}
~~~

## Zapytania

Mimo, że Shadow Property nie jest widoczne w modelu, możemy używać ich w zapytaniach za pomocą metody _EF.Property()_
~~~ csharp
var customers = context.Customers.OrderBy(c => EF.Property<DateTime>(c, "LastUpdated"));
~~~

lub od C# 6.0 jeszcze wygodniej z użyciem _using static_

~~~ csharp
using static Microsoft.EntityFrameworkCore.EF;
var customers = context.Customers.OrderBy(c => Property<DateTime>(c, "LastUpdated"));
~~~