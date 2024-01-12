Entity Framework Core umożliwia mapowanie na encje nie tylko tabel, ale również widoków.
## Database First

Utwórz widok
~~~ sql
CREATE OR ALTER VIEW FilmsByRating AS
SELECT 
	rating,
	COUNT(*) AS film_count
FROM 
	film 
GROUP BY
	rating
~~~

Zdefiniuj model:

~~~ csharp
public class FilmsByRating
{  
	public int Rating { get; set; }  	
	[Column("film_count")]  
	public int TotalAmount { get; set; }
   
    public override string ToString() => $"{Rating} {TotalAmount}";
}
~~~

Dodaj do modelu encję:

~~~ csharp
public DbSet<FilmsByRating> FilmsByRatings { get; set; }
~~~

i skonfiguruj model:
~~~ csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)  
{
	modelBuilder  
		.Entity<FilmsByRating>()  
		.ToView("FilmsByRating")
	    .HasNoKey();		
}
~~~

uwaga: jeśli twoja encja nie zawiera klucza zastosuj metodę `HasNoKey`.
## Code First

W przypadku podejścia _Code First_ należy widok dodać poprzez migrację.

1. Dodaj migrację:
~~~ bash 
Add-Migration FilmsByRatingView
~~~

Zostanie utworzona pusta klasa migracji:
~~~ csharp
public partial class FilmsByRatingView : Migration  
{  
	protected override void Up(MigrationBuilder migrationBuilder)  
	{  
	}  
	protected override void Down(MigrationBuilder migrationBuilder)  
	{  
	}  
}
~~~

2. Przenieś kod do tworzenia widoku do migracji:
~~~ csharp
public partial class FilmsByRatingView : Migration  
{  
	protected override void Up(MigrationBuilder migrationBuilder)  
	{  
	    migrationBuilder.Sql("CREATE OR REPLACE VIEW FilmsByRating ...");
	}  
	protected override void Down(MigrationBuilder migrationBuilder)  
	{  
	   migrationBuilder.Sql("DROP VIEW FilmsByRating ...");
	}  
}
~~~

3. Zaktualizuj bazę danych:
~~~ bash
update-database
~~~



# Mapowanie funkcji

~~~ csharp
public DbSet<ExpenseByTotal> ExpenseTotals { get; set; }

modelBuilder  
	.Entity<ExpenseByTotal>()  
	.ToFunction("expensebyyear(2024)")  
	.HasKey(t => t.Id);  
~~~
