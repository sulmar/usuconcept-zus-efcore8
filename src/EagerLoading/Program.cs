using Infrastructure;

Console.WriteLine("Hello, Eager Loading!");

using var context = new SakilaContext();

var customers = context.Customers.ToList();

customers.Dump();