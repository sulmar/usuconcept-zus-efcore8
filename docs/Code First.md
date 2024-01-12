Umożliwia automatyczne wygenerowane struktur danych na podstawie modelu. Sposób generowania modelu możemy dostosować za pomocą konfiguracji encji.

## Generowanie struktur danych

1. Utwórz kontekst na podstawie DbContext

~~~ csharp
public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions options) : base(options)
	{
	}
}
~~~

2. Dodanie mapowanie klas (encji)
3. Dostosuj model
4. Utworzenie bazy danych

- uwaga: baza danych utworzona za pomocą metody _EnsureCreated_ nie pozwala na późniejsze zastosowanie migracji. 

# Aktualizacja bazy danych (migracje)

1. Zainstaluj narzędzia EF Core
~~~ bash
dotnet tool install --global dotnet-ef
~~~

1. Sprawdź poprawność instalacji narzędzi EF Core
~~~ bash
dotnet ef
~~~

W wyniku powinna pojawić się wersja narzędzi, które są obecnie zainstalowane:
~~~
                   _/\__
               ---==/    \\
         ___  ___   |.    \|\
        | __|| __|  |  )   \\\
        | _| | _|   \_/ |  //|\\
        |___||_|       /   \\\/\\

Entity Framework Core .NET Command-line Tools 8.0.0
~~~

Jeśli pojawia się komunikat błędu zaktualizuj narzędzia do tej samej wersji jak EF Core.

~~~ bash
dotnet tool update --global dotnet-ef --version 8.0.0
~~~

W razie potrzeby przywrócenia poprzedniej wersji odinstaluj narzędzia i zainstaluj ponownie:
~~~ bash
dotnet tool uninstall dotnet-ef --global
dotnet tool install --global dotnet-ef
~~~

3. Włącz migracje
4. Utwórz bazę danych na podstawie migracji
5. Aktualizacja bazy danych
6. Wycofanie zmian z bazy danych
