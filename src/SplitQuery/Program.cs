using Microsoft.EntityFrameworkCore;
using Infrastructure;

Console.WriteLine("Hello, Spliting Query!");

using var context = new SakilaContext();

var customers = context.Customers
    .Include(p => p.Payments)        
    // .AsSplitQuery() // Lokalne włączenie dzielenia zapytań
    .ToList();

customers.Dump();