using Infrastructure;

Console.WriteLine("Hello, Global Filters!");

using var context = new SakilaContext();

// TODO: Move to global filters
var customers = context.Customers.Where(c=>c.Active == "1").ToList();

customers.Dump();