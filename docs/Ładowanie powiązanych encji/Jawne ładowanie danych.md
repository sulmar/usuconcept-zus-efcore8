
# Ładowanie obiektu

~~~ csharp
 context.Entry(customer).Reference(p => p.Address).Load();
~~~ 

Ładowanie podobiektu:
~~~ csharp
context.Entry(customer.Address).Reference(p => p.City).Load();
~~~

# Ładowanie kolekcji

~~~ csharp
context.Entry(customer).Collection(p => p.Payments).Load();
~~~