**Konwerter** umożliwia zamianę typu lub sposobu zapisu wartości pola "w locie" pomiędzy modelem a bazą danych.  Na przykład zamianę wartości numerycznej na tekst lub obiektu na XML/JSON i odwrotnie.

# Wbudowane konwertery

EF Core posiada wiele zaimplementowanych konwerterów [https://learn.microsoft.com/en-us/ef/core/modeling/value-conversions?tabs=data-annotations#built-in-converters]

## Predefiniowane konwersje

~~~ csharp 
builder.Property(p=>p.Gender)
                .HasConversion<string>();
~~~       

## Konwersja Enum na String

~~~ csharp              

protected override void OnModelCreating(ModelBuilder modelBuilder)  
{  
    var converter = new EnumToStringConverter<Gender>();
    
	modelBuilder.Entity<MyEntity>()  
			.Property(e => e.Gender)  
			.HasConversion(converter);  
}
~~~

## Konwersja Bool na varchar


~~~ csharp              
            builder.Property(p=>p.IsDeleted)
                .HasConversion(new BoolToStringConverter("Yes", "No"));
~~~

## Konwersja Bool na char

~~~ csharp
  var converter = new BoolToTwoValuesConverter<char>('0', '1');

  modelBuilder.Entity<Customer>()
      .Property(p => p.Active)
      .HasColumnType("char(1)")
      .HasConversion(converter);
~~~

Można również utworzyć własną klasę konwertera:
~~~ csharp
 public class BoolToCharConverter : ValueConverter<bool, char>
 {
     public BoolToCharConverter(char falseValue, char trueValue) : base(
         v => v ? trueValue : falseValue,   // Convert from bool to char
         v => v == trueValue         // Convert from char to bool
     )
     { }
 }
 ~~~ 
 
# Własny konwerter

## Konwersja za pomocą wyrażeń 
~~~ csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)  
{  
	modelBuilder.Entity<MyEntity>()  
			.Property(e => e.Coordinate)  
			.HasConversion(  
			v => $"{v.Latitude},{v.Longitude}",  
			v => new Coordinate  
			{  
				Latitude = double.Parse(v.Split(',')[0]),  
				Longitude = double.Parse(v.Split(',')[1])  
			}  
		);  
}
~~~


## Konwersja za pomocą instancji konwertera

~~~ csharp            
var genderToStringConverter = new ValueConverter<Gender, string>(
v => v.ToString(),
v => (Gender)Enum.Parse(typeof(Gender), v));

protected override void OnModelCreating(ModelBuilder modelBuilder)  
{  
	modelBuilder.Entity<MyEntity>()  
			.Property(e => e.Gender)  
			.HasConversion(genderToStringConverter);  
}

~~~

## Kompozycja 
~~~ csharp
modelBuilder.Entity<Order>()
    .Property(e => e.ShippingAddress)
    .HasConversion(
        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
        v => JsonSerializer.Deserialize<Address>(v, (JsonSerializerOptions)null));
~~~
## Konwerter zdefiniowany za pomocą klasy

Konwerter możemy przenieść do osobnej klasy:
~~~ csharp
public class CoordinateConverter : ValueConverter<Coordinate, string>
{
    public CoordinateConverter()
        : base(
            v => $"{v.Latitude},{v.Longitude}",  
			v => new Coordinate  
			{  
				Latitude = double.Parse(v.Split(',')[0]),  
				Longitude = double.Parse(v.Split(',')[1])  
			} )
    {
    }
}


protected override void OnModelCreating(ModelBuilder modelBuilder)  
{  
	modelBuilder.Entity<MyEntity>()  
			.Property(e => e.Coordinate)  
			.HasConversion<CoordinateConverter>();
}
~~~

Jeśli konwerter wymaga parametrów możemy to zrobić w ten sposób:
~~~ csharp
public class CoordinateConverter : ValueConverter<Coordinate, string>
{
    public CoordinateConverter(string separator)
        : base(
            v => $"{v.Latitude}{separator}{v.Longitude}",  
			v => new Coordinate  
			{  
				Latitude = double.Parse(v.Split(separator)[0]),  
				Longitude = double.Parse(v.Split(separator)[1])  
			} )
    {
    }
}


protected override void OnModelCreating(ModelBuilder modelBuilder)  
{  
	modelBuilder.Entity<MyEntity>()  
			.Property(e => e.Coordinate)  
			.HasConversion(new CoordinateConverter(";"));
}
~~~



## Użycie konwertera w konwencjach

Konwerter możemy zastosować jako konwencje:

~~~ csharp            
public class CurrencyConverter : ValueConverter<Currency, decimal>
{
    public CurrencyConverter()
        : base(
            v => v.Amount,
            v => new Currency(v))
    {
    }
}

protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
{
    configurationBuilder
        .Properties<Currency>()
        .HaveConversion<CurrencyConverter>();
}
~~~


