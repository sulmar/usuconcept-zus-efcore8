Domyślnie wszystkie pobierane obiekty poprzez context są śledzone i dzięki temu po przy wywołaniu metody _SaveChanges_ zmiany utrwalane są w bazie danych.

## Automatyczne śledzenie zmian

Domyślnie właściwość _ChangeTracker.AutoDetectChanges_ jest ustawiona na true.

W celu zwiększenia wydajności, zwłaszcza przy dodawaniu wielu encji, ustaw na false.  

~~~ csharp
private static void DetectChangesTest()
{
    var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
    optionsBuilder.UseSqlite("Data Source=blog.db")
      .EnableSensitiveDataLogging();

    var context = new MyContext(optionsBuilder.Options);
    
    context.ChangeTracker.AutoDetectChangesEnabled = false;

    Customer customer = new Customer { Id = 5, FirstName = "Abc" };

    context.Customers.Attach(customer);

    Console.WriteLine(context.Entry(customer).State);

    customer.FirstName = "Xyz";

    Console.WriteLine(context.Entry(customer).State);

    context.ChangeTracker.DetectChanges();

    Console.WriteLine(context.Entry(customer).State);


}

~~~
Pamiętaj! o wywołaniu metody _DetectChanges()_ przed _SaveChanges()_

## Wyłączenie śledzenia pojedynczego zapytania

~~~ csharp
var customers = context.Customers
	.AsNoTracking()
	.ToList();

~~~

## Globalne wyłączenie śledzenia 

~~~ csharp
    context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
~~~

# Strategie śledzenie zmian


## Strategia Snapshot

Domyślnie EF Core tworzy migawkę (_snapshot_) encji, która jest śledzona przez DbContext. Wartości te są przechowywane i porównywanie z bieżącą wartością i na tej podstawie określane jest, która właściwość się zmieniła.


~~~ csharp
using var context = new SakilaContext();
var customer = context.Customers.Find(1);

// Change a property value
customer.Name = ".NET";

Console.WriteLine(context.ChangeTracker.DebugView.LongView);
context.ChangeTracker.DetectChanges();
Console.WriteLine(context.ChangeTracker.DebugView.LongView);
~~~
## Strategia ChangedNotifications

EF Core umożliwia śledzenie zmian na podstawie interfejsu *INotifyPropertyChanged*

~~~ csharp
public abstract class BaseEntity : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propname = "")
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
    }
}

public class Customer : BaseEntity
{
    public int Id { get; set; }

    private string firstname;
    public string FirstName
    {
        get => firstname; set
        {
            firstname = value;
            OnPropertyChanged();
        }
    }

    public string LastName { get; set; }
}
~~~

~~~ csharp
public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangedNotifications);

            base.OnModelCreating(modelBuilder);
        }
    }
~~~

# ChangeTracker

`ChangeTracker` to mechanizm, który śledzi zmiany w obiektach śledzonych przez kontekst bazy danych. Jest to istotna część EF Core, ponieważ umożliwia śledzenie, identyfikowanie i zarządzanie zmianami w encjach, co jest kluczowe podczas pracy z bazą danych.

## DebugView
Śledzone obiekty można wyświetlić za pomocą metody _ShortView_ lub _LongView_ zależnie od tego jak szczegółowych informacji potrzebujemy:

~~~ csharp
Console.WriteLine(context.ChangeTracker.DebugView.ShortView);
~~~

~~~ csharp
Console.WriteLine(context.ChangeTracker.DebugView.LongView);
~~~

## TrackGraph

~~~ csharp
context.ChangeTracker.TrackGraph(rental, 
 e => {
		if (e.Entry.IsKeySet)
		{
			e.Entry.State = EntityState.Unchanged;
		}
		else
		{
			e.Entry.State = EntityState.Added;
		}
	});
	~~~~


# `AutoDetectChangesEnabled`

Jeśli ustawisz `AutoDetectChangesEnabled` na `false`, będziesz musiał ręcznie wywołać metodę `DetectChanges` na obiekcie `ChangeTracker`, aby EF Core wykrył zmiany przed zapisaniem ich do bazy danych.

~~~ csharp
context.ChangeTracker.AutoDetectChangesEnabled = false;
context.ChangeTracker.DetectChanges();
~~~

To może być przydatne w następujących scenariuszach:
1. **Operacje na dużej ilości danych** W przypadku masowych operacji na dużej ilości danych, wyłączenie automatycznego wykrywania zmian (`AutoDetectChangesEnabled = false`) może poprawić wydajność. Możesz ręcznie wywołać `DetectChanges`, gdy uznasz to za konieczne.
