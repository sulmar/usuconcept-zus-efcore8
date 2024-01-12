
# Z użyciem Proxy


1. Dodaj bibliotekę do projektu
~~~ bash
dotnet add package Microsoft.EntityFrameworkCore.Proxies
~~~

2. Dodaj słowo kluczowe `virtual` do właściwości nawigacyjnych
~~~ csharp
public partial class Customer
{
    // ...
    public virtual Address Address { get; set; };
    public virtual ICollection<Payment> Payments { get; set; } 
}
~~~

3. Wywołaj metodę _UseLazyLoadingProxies()_
~~~ csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
        .UseSqlServer("Data Source=(local);Initial Catalog=sakila;Integrated Security=True;TrustServerCertificate=True")
        .UseLazyLoadingProxies();
~~~        

4. Pobierz klientów
~~~ csharp
var customers = context.Customers.ToList();

foreach(var customer in customers)
{
   Console.WriteLine($"{customer.Address.City}");
}
~~~


# Bez użycia Proxy


1. Dodaj bibliotekę do projektu
~~~ bash
dotnet add package Microsoft.EntityFrameworkCore.Abstraction
~~~

2. Dodaj `ILazyLoader` do konstruktora
~~~ csharp
public partial class Customer
{
   private ILazyLoader LazyLoader { get; set; }

	public Customer() {}
	  
	private Customer(ILazyLoader lazyLoader) 
	{ 
	   LazyLoader = lazyLoader; 
	}

    // ...
    public Address Address { get; set; };

    private ICollection<Payment> Payments 
    public ICollection<Payment> Payments 
    {
    get => LazyLoader.Load(this, ref _payments); 
    set => _payments = value;
    }
}
~~~
