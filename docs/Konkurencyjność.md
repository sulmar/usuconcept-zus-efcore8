
# ConcurrencyToken

~~~ csharp
 modelBuilder.Entity<Customer>()
     .Property(p => p.FirstName)
     .IsConcurrencyToken();
~~~ 

Spowoduje wysłanie instrukcji SQL:

~~~ csharp
 UPDATE customer SET first_name=... WHERE customer_id = ... AND first_name = ...
~~~ 

# RowVersion

Dodaj do modelu właściwość typu `byte[]`
~~~ csharp
public partial class Customer
{
   public byte[] Version { get; set; }
}
~~~ 

oraz skonfiguruj model:
~~~ csharp
 modelBuilder.Entity<Customer>()
     .Property(p => p.Version)
     .IsRowVersion()
     .IsConcurrencyToken();
~~~ 

Spowoduje wysłanie instrukcji SQL:

~~~ csharp
 UPDATE customer SET first_name=... WHERE customer_id = ... AND Version = ...
~~~ 

Jeśli nie chcesz zaśmiecać modelu polem Version możesz zastosować [[Shadow Property]]:

~~~ csharp
 modelBuilder.Entity<Customer>()
     .Property<byte>("Version")
     .IsRowVersion()
     .IsConcurrencyToken();
~~~ 


