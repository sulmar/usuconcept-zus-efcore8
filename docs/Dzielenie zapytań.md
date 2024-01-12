Metoda _UseSplitQuery_ w Entity Framework Core służy do automatycznego podziału zapytań. Może to być korzystne w scenariuszach, gdzie załadowanie powiązanych danych można zoptymalizować poprzez wykonanie osobnych zapytań SQL.

Zakładając, że masz encje takie jak Film i Category , możesz użyć _UseSplitQuery_ w ten sposób:

~~~ csharp
var films = context.Customers
			  .Include(c => c.Store)
			  .Where(c => c.Active == "1")
			  .UseSplitQuery()
			  .ToList();	
~~~

Korzystając z _UseSplitQuery_, Entity Framework Core automatycznie generuje osobne zapytania SQL dla głównej encji (Customer w tym przypadku) i jej powiązanych encji (Store), co potencjalnie poprawia wydajność.