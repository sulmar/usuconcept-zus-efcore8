using Microsoft.EntityFrameworkCore;
using Infrastructure;

Console.WriteLine("Hello, Queries with primitive collections!");

var context = new SakilaContext();


var ratings = new[] { "PG", "G", "PG-13" };

var films = await context.Films
    .Where(f => ratings.Contains(f.Rating))
    .ToArrayAsync();


films.Dump();