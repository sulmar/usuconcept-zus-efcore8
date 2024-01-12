
Filtry globalne umożliwiają zdefiniowanie warunku, który będzie automatycznie dołączany do wszystkich zapytań z danej encji:

~~~ csharp
 internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
 {
     public void Configure(EntityTypeBuilder<Customer> builder)
     {
        builder.HasQueryFilter(p => p.Active == true);
      }
   }
~~~

W razie potrzeby możemy wyłączyć filtr globalny dla konkretnego zapytania: 

~~~ csharp
using(var context = new SakilaContext())
{
	var customers = context.Customers.IgnoreQueryFilters().ToList();
}
~~~