using Microsoft.EntityFrameworkCore;
using Infrastructure;

Console.WriteLine("Hello, Eager Loading!");

using var context = new SakilaContext();

var customers = context.Customers
    .Include(p=>p.Address)
        .ThenInclude(p=>p.City)
    .Include(p=>p.Rentals)
        .ThenInclude(p=>p.Inventory)
    .ToList();


var films = context.Films.IgnoreAutoIncludes().ToList();

customers.Dump();