
Ładowanie powiązanej encji
~~~ csharp
var customers = context.Customers
    .Include(p => p.Address);
~~~

W taki sam sposób możemy pobrać obiekty kolekcji:
~~~ csharp
var customers = context.Customers
    .Include(p => p.Rentals);
~~~

Możemy również wygodnie pobierać zagnieżdżone obiekty: 
~~~ csharp
var customers = context.Customers
    .Include(p=>p.Address)
        .ThenInclude(p=>p.City)
~~~        

W przypadku ładowania większej ilości powiązanych obiektów zapisujemy to następująco:

~~~ csharp
var customers = context.Customers
    .Include(p=>p.Address)
        .ThenInclude(p=>p.City)
    .Include(p=>p.Rentals)
        .ThenInclude(p=>p.Inventory)
    .ToList();
~~~

# Automatyczne dołączanie powiązanych encji

Jeśli w wielu miejscach kodu powtarzasz ten sam `Include`
~~~ csharp
var films = context.Films.Include(p => p.Language).ToList();
~~~ 
to warto włączyć automatyczny mechanizm.

W konfiguracji musimy wywołać:
~~~ csharp
modelBuilder.Entity<Film>()
    .Navigation(p => p.Language)
    .AutoInclude();
~~~

Warunek będzie automatycznie dołączany mimo, że w LINQ nie widać predykatu:
~~~ csharp
var films = context.Films.ToList();
~~~ 

W razie potrzeby możemy pominąć filtr w zapytaniu:
~~~ csharp
var films = context.Films.IgnoreAutoIncludes().ToList();
~~~ 

Możesz włączyć ładowanie na wielu encjach:
~~~ csharp
 modelBuilder.Entity<Customer>()
     .Navigation(p => p.Address)
     .AutoInclude();
     
 modelBuilder.Entity<Address>()
     .Navigation(p => p.City)
     .AutoInclude();
     
  modelBuilder.Entity<City>()
     .Navigation(p => p.Country)
     .AutoInclude();
~~~ csharp 