Umożliwia automatyczne wygenerowane modelu danych i kontekstu na podstawie istniejącej bazy danych. Sposób generowania modelu możemy dostosować za pomocą szablonów w formacie T4.

## Generowanie modelu

1. Zainstaluj narzędzia EF dla dotnet CLI
~~~ bash
dotnet tool install --global dotnet-ef
~~~

2. Dodaj paczkę
~~~ bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
~~~ 

3. Dodaj paczkę
~~~ bash
dotnet add package Microsoft.EntityFrameworkCore.Design
~~~ 

4. Generowanie modelu 
~~~ bash
dotnet ef dbcontext scaffold "Data Source=(local);Initial Catalog=sakila;Integrated Security=True;TrustServerCertificate=True"  Microsoft.EntityFrameworkCore.SqlServer
~~~

- Generowanie modelu 
~~~ bash
dotnet ef dbcontext scaffold "Data Source=(local);Initial Catalog=sakila;Integrated Security=True;TrustServerCertificate=True"  Microsoft.EntityFrameworkCore.SqlServer -f -o Infrastructure -n Sakila.Infrastructure
~~~ 

- Generowanie modelu 

~~~ bash
 dotnet ef dbcontext scaffold "Name=ConnectionStrings:Sakila" Microsoft.EntityFrameworkCore.SqlServer -o ..\Sakila.Domain\Model  --context-dir ..\Sakila.Infrastructure\ -f -n Sakila.Domain.Model --context-namespace Sakila.Intrastructure
 ~~~ 


# Dostosowanie kontekstu

## Dostosowanie modelu

- Utwórz klasę częściową o takiej samej nazwie jak kontekst aplikacji
~~~ csharp
partial class SakilaContext
{

   

}
~~~

## Dostosowanie encji

~~~ csharp
partial class SakilaContext
{
   partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
   {
      modelBuilder.Entity<Customer>()
         .Navigation(p=>p.Address)
         .AutoInclude();
   }
}
~~~
# Niestandardowe szablony inżynierii odwrotnej

## Dodawanie szablonów domyślnych
~~~ bash
dotnet new install Microsoft.EntityFrameworkCore.Templates
~~~

Teraz możesz dodać szablony domyślne do projektu. W tym celu uruchom następujące -polecenie z katalogu projektu.

~~~ bash
dotnet new ef-templates
~~~

To polecenie dodaje następujące pliki do projektu.

- CodeTemplates/
    - EFCore/
        - DbContext.t4
        - EntityType.t4


Szablon `DbContext.t4` służy do tworzenia szkieletu klasy DbContext dla bazy danych, a `EntityType.t4` szablon służy do tworzenia szkieletu klas typów jednostek dla każdej tabeli i widoku w bazie danych.

## Dostosowanie encji

`EntityType.t4` Otwórz szablon i znajdź miejsce wygenerowania `List<T>`pliku . Wygląda to tak:


``` T4
    if (navigation.IsCollection)
    {
#>
    public virtual ICollection<<#= targetType #>> <#= navigation.Name #> { get; } = new List<<#= targetType #>>();
<#
    }
```

Zastąp element List elementem ObservableCollection.


``` T4
public virtual ICollection<<#= targetType #>> <#= navigation.Name #> { get; } = new ObservableCollection<<#= targetType #>>();
```

Musimy również dodać dyrektywę `using` do kodu szkieletowego. Użycie jest określone na liście w górnej części szablonu. Dodaj `System.Collections.ObjectModel` do listy.


``` T4
var usings = new List<string>
{
    "System",
    "System.Collections.Generic",
    "System.Collections.ObjectModel"
};
```

Przetestuj zmiany przy użyciu poleceń inżynierii odwrotnej. Szablony w projekcie są używane automatycznie przez polecenia.

~~~ bash
dotnet ef dbcontext scaffold "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Sakila" Microsoft.EntityFrameworkCore.SqlServer
~~~

Jeśli wszystko zostało wykonane poprawnie, właściwości nawigacji kolekcji powinny teraz używać polecenia `ObservableCollection<T>`.

``` csharp
public virtual ICollection<Film> Films { get; } = new ObservableCollection<Film>();
```

## Dostosowanie kontekstu 

Otwórz szablon `DbContext.t4`  i znajdź miejsce w którym znajduje się  `virtual`. Wygląda to tak:


``` T4
    if (navigation.IsCollection)
    {
#>
    public virtual DbSet<T> ...
<#
    }
```

Usuń słowo kluczowe `virtual` i zamień `IDbSet` 

Przetestuj ponownie zmiany przy użyciu poleceń inżynierii odwrotnej. 

~~~ bash
dotnet ef dbcontext scaffold "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Sakila" Microsoft.EntityFrameworkCore.SqlServer --force
~~~

Jeśli wszystko zostało wykonane poprawnie, właściwości zestaów powinny teraz używać polecenia `IDbSet<T>`.

``` csharp
public IDbSet<Film> Films { get; set; }
```
