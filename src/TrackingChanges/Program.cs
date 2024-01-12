using TrackingChanges.Model;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, Tracking Changes!");

var context = new SakilaContext();


// Lokalne wyłączenie śledzenie zmian obiektów
var customers = context.Customers.AsNoTracking().ToList();

// Hint: idealne do słowników!

// context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

// UpdateFilm(context);

// UpdateDetachedFilm(context);

// AddNewFilm(context);

// DisableAutoDetectChanges(context);

var film = context.Inventories.Where(i => i.Film.Title.Contains("ACADEMY")).AsNoTracking().First();
var customer =  context.Customers.AsNoTracking().First();
var stuff = context.Staff.AsNoTracking().First();

Console.WriteLine(context.Entry(customer).State);

// context.Entry(film).State = EntityState.Unchanged;

var rental = new Rental();

rental.Customer = customer;
rental.Staff = stuff;
rental.Inventory = film;
rental.RentalDate = DateTime.Now;

var context2 = new SakilaContext();


//var entries = context.ChangeTracker.Entries().ToList();
//foreach(var entry in entries)
//{
//    Console.WriteLine($"{entry} {entry.State}");
//}

// Opisujemy strategię ustawiania stanów encji
// https://learn.microsoft.com/en-us/ef/core/change-tracking/explicit-tracking#custom-tracking-with-trackgraph

context2.ChangeTracker.TrackGraph(rental, node =>
{
    if (node.Entry.IsKeySet)
    {
        node.Entry.State = EntityState.Unchanged;
    }
    else
    {
        node.Entry.State = EntityState.Added;
    }

});


context2.Rentals.Add(rental);


// Diagnostyka


Console.WriteLine(context2.ChangeTracker.DebugView.ShortView);

Console.WriteLine(context2.ChangeTracker.DebugView.LongView);



context.SaveChanges();




static void UpdateDetachedFilm(SakilaContext context)
{
    var film = new Film { FilmId = 1, Length = 120, Title = "Lorem" };
    Console.WriteLine(context.Entry(film).State);

    context.Attach(film);

    // Modyfikacja wszystkich właściwości
    // context.Entry(film).State = EntityState.Modified;

    // Modyfikacja wybranych właściwości
    context.Entry(film).Property(p => p.Length).IsModified = true;
    context.Entry(film).Property(p => p.Title).IsModified = true;

    context.SaveChanges();
    Console.WriteLine(context.Entry(film).State);
}

static void AddNewFilm(SakilaContext context)
{
    var film = new Film { Length = 120, Title = "Lorem", LanguageId = 1 };

    Console.WriteLine(context.Entry(film).State);

    context.Films.Add(film);

    Console.WriteLine(context.Entry(film).State);

    context.SaveChanges();

    Console.WriteLine(context.Entry(film).State);
}

static void UpdateFilm(SakilaContext context)
{
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
}

static void DisableAutoDetectChanges(SakilaContext context)
{
    var language1 = new Language { Name = "a" };
    var language2 = new Language { Name = "b" };
    var language3 = new Language { Name = "c" };

    context.ChangeTracker.AutoDetectChangesEnabled = false;

    Console.WriteLine(context.Entry(language1).State);

    context.Languages.Add(language1);

    context.Languages.Add(language2);
    context.Languages.Add(language3);

    Console.WriteLine(context.Entry(language1).State);

    language1.Name = "x";

    context.ChangeTracker.DetectChanges();
    Console.WriteLine(context.Entry(language1).State);


    context.SaveChanges();
    Console.WriteLine(context.Entry(language1).State);
}