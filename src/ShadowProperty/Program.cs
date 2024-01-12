using Infrastructure;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, Shadow Property!");

/*
ALTER TABLE actor
	ADD created_date datetime2
*/

var actor = new Actor { FirstName = "a", LastName = "b" };

using var context = new SakilaContext();

context.Actors.Add(actor);
//context.Entry(actor).Property("created_date").CurrentValue = DateTime.UtcNow;

context.SaveChanges();

// Sortowanie z użyciem shadow property
var actors = context.Actors
	.OrderBy(a => EF.Property<DateTime>(a, "created_date"))
	.ToList();

actors.Dump();
