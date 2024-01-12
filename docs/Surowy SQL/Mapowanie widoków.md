
Utwórz widok
~~~ sql
CREATE OR REPLACE VIEW FilmsByRating AS
SELECT 
	rating,
	COUNT(*) AS film_count
FROM 
	film 
GROUP BY
	rating
~~~

Dodaj migrację:
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

Uzupełnij metody:
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

Zaktualizuj bazę danych:
~~~ bash
update-database
~~~

Zdefiniuj model:

~~~ csharp
public class FilmsByRating
{  
	public int Rating { get; set; }  	
	[Column("film_count")]  
	public int TotalAmount { get; set; }
}
~~~

Zmodyfikuj model:

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
}
~~~

# Mapowanie funkcji

~~~ csharp
public DbSet<ExpenseByTotal> ExpenseTotals { get; set; }

modelBuilder  
	.Entity<ExpenseByTotal>()  
	.ToFunction("expensebyyear(2024)")  
	.HasKey(t => t.Id);  
~~~
