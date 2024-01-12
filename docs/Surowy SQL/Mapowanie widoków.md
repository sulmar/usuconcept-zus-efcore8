
~~~ csharp
public DbSet<ExpenseByTotal> ExpenseTotals { get; set; }

modelBuilder  
	.Entity<ExpenseByTotal>()  
	.ToView("expensebytotal")  
	.HasKey(t => t.Id);  
~~~

# Mapowanie funkcji

~~~ csharp
public DbSet<ExpenseByTotal> ExpenseTotals { get; set; }

modelBuilder  
	.Entity<ExpenseByTotal>()  
	.ToFunction("expensebyyear(2024)")  
	.HasKey(t => t.Id);  
~~~
