using TrackingChanges.Model;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, Tracking Changes!");

var context = new SakilaContext();

// Lokalne wyłączenie śledzenie zmian obiektów
var customers = context.Customers.AsNoTracking().ToList();

// Hint: idealne do słowników!

// context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;



var customer = context.Customers.First();

Console.WriteLine(context.Entry(customer).State);

customer.Active = customer.Active == "1" ? "0" : "1";

Console.WriteLine(context.Entry(customer).State);

context.SaveChanges();

Console.WriteLine(context.Entry(customer).State);

customer.LastUpdate = DateTime.Now;

Console.WriteLine(context.Entry(customer).State);

context.SaveChanges();

Console.WriteLine(context.Entry(customer).State);

customer.FirstName = "BOB";
Console.WriteLine(context.Entry(customer).State);

var firstNameProperty = context.Entry(customer).Property(p => p.FirstName);

Console.WriteLine($"OriginalValue: {firstNameProperty.OriginalValue} CurrentValue: {firstNameProperty.CurrentValue} IsModified: {firstNameProperty.IsModified}");

context.SaveChanges();
Console.WriteLine(context.Entry(customer).State);

customer.FirstName = "JOHN";
Console.WriteLine(context.Entry(customer).State);

context.SaveChanges();


var film2 = new Film { FilmId = 1, Length = 120, Title = "Lorem", LanguageId = 1 };
context.Attach(film2);
context.Entry(film2).State = EntityState.Modified;
context.SaveChanges();


var film = new Film { Length = 120, Title = "Lorem", LanguageId = 1 };

Console.WriteLine(context.Entry(film).State);

context.Films.Add(film);

Console.WriteLine(context.Entry(film).State);

context.SaveChanges();

Console.WriteLine(context.Entry(film).State);