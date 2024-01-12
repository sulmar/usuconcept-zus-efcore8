Entity Framework Core umożliwia mapowanie na encje nie tylko tabel, ale również widoków.


1. Przygotuj widok
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

2. Zdefiniuj model:

~~~ csharp
public class FilmsByRating
{  
	public int Rating { get; set; }  	
	public int TotalAmount { get; set; }
   
    public override string ToString() => $"{Rating} {TotalAmount}";
}
~~~

Dodaj do kontekstu encję:

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

     modelBuilder
        .Entity<FilmsByRating>()
        .Property(e => e.FilmCount)
       .HasColumnName("film_count");
}
~~~

uwaga: jeśli twoja encja nie zawiera klucza zastosuj metodę `HasNoKey`.

3. Dodaj migrację:
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

4. Przenieś kod do tworzenia widoku do migracji:
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

5. Zaktualizuj bazę danych:
~~~ bash
update-database
~~~

6. Pobierz dane z widoku
~~~ csharp
using var context = new SakilaContext();
var filmsByRatings = context.FilmsByRatings.ToList();
~~~

